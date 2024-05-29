import { capitalize } from "$lib/string-helpers";

type tagNames = "xs:complexType" | string;

export type AxiosDataTypes =
    | 'xs:int'
    | 'xs:boolean'
    | 'xs:string'
    | 'xs:dateTime'
    | 'xs:double'
    | 'xs:base64Binary'
    | string;

export function generateCSharpCode(element: Element): string {
    const tagName: tagNames = element.tagName;
    switch (tagName) {
        case "xs:complexType":
            return generateCSharpComplexType(element);
        default:
            return generateCSharpSimpleType(element);
    }
    return '';
}

function makeCSharpDescription(description: string | null | undefined): string {
    if (description !== null) {
        description = `
        /// <summary>
        /// ${description}
        /// </summary>
        `
    } else {
        description = '';
    }
    return description;
}

function makeTypeScriptDescription(description: string | null | undefined): string {
    if (description !== null) { /** */
        description = `
        /**
         * ${description}
        */
        `
    } else {
        description = '';
    }
    return description;
}

function generateCSharpComplexType(element: Element): string {

    let complexTypeCode = element.getAttribute('name') ?? 'objName';
    complexTypeCode = capitalize(complexTypeCode);
    let description = element.getAttribute('axios:description');
    let sequenceCode = '';
    let sequence = element.getElementsByTagName('xs:sequence');
    let parentObject = element.getElementsByTagName('xs:extension');
    let baseObject: string = '';
    if (parentObject && parentObject.length > 0) {
        baseObject = parentObject[0].getAttribute('base') ?? '';
        if (baseObject !== '') {
            baseObject = `: ${capitalize(baseObject)}`
        }
    }

    if (sequence && sequence.length > 0) {
        let sequenceElements = sequence[0].getElementsByTagName('xs:element');
        for (const _elem of sequenceElements) {
            let name = _elem.getAttribute('name') ?? 'FieldName';
            let description = _elem.getAttribute('axios:description');
            let type: AxiosDataTypes = _elem.getAttribute('type') ?? '';
            let ref = _elem.getAttribute('ref');
            //ignore if a reference, probably wont need it
            if (ref) {
                sequenceCode = `${sequenceCode}
                /**
                 * Ref object discarded 
                 * ${_elem.outerHTML}
                 */
                `;
                continue;
            }
            let dataType: string = type;
            switch (type) {
                case "xs:int":
                    dataType = "int";
                    break;
                case "xs:boolean":
                    dataType = "bool";
                    break;
                case "xs:string":
                    dataType = "string";
                    break;
                case "xs:dateTime":
                    dataType = "DateTime";
                    break;
                case "xs:double":
                    dataType = "double";
                    break;
                case "xs:base64Binary":
                    dataType = "string";
                    break;
                default:
                    dataType = 'object';
                    description = `${description ?? ''}\n/// Data Type : ${type}\n/// Element:${_elem.outerHTML}`
                    break;
            }
            description = makeCSharpDescription(description);
            sequenceCode = `${sequenceCode}
            ${description}
            [JsonPropertyName("${name}")]
            public ${dataType}? ${capitalize(name)} {get; set; }
            `
            if (type === "xs:base64Binary") {
                sequenceCode = `
                ${sequenceCode}
                [JsonPropertyName("${name}Bytes")]
                public byte[]? ${capitalize(name)}Bytes=> Encoding.UTF8.GetBytes(${capitalize(name)});
                `
            }
        }
    }

    description = makeCSharpDescription(description)

    complexTypeCode = `
        ${description ?? ''}
        public class ${complexTypeCode} ${baseObject}
        {
            ${sequenceCode}
        }
        `;
    return complexTypeCode;



}

function generateCSharpSimpleType(element: Element): string {
    let code: string = '';
    let name = element.getAttribute('name') as string;
    name = capitalize(name);
    const enumeration = element.getElementsByTagName('xs:enumeration');
    for (const enumField of enumeration) {
        const value = enumField.getAttribute('value') as string;
        code = `${code}
        ${value},`;
    }
    var converterCode = generateCSharpJsonConverterCode(enumeration, name)
    code = `public enum ${name}
    {
        ${code}
    }
    
    ${converterCode}
    
    `;

    return code;
}

function generateCSharpJsonConverterCode(enumeration: HTMLCollectionOf<Element>, name: string): string {
    let convertCode = '';
    for (const element of enumeration) {
        const value = element.getAttribute('value') as string;
        convertCode = `${convertCode}
        "${value}"=>${name}.${value},`
    }
    convertCode = `
    public override ${name} Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var str = reader.GetString();
        var result = str switch
        {
            ${convertCode}
            _=>default,
        };
        return result;
    }

    public override void Write(Utf8JsonWriter writer, ${name} value, JsonSerializerOptions options)
    {
        var valueString = value.ToString();
        writer.WriteStringValue(valueString);          
    }

    `;

    let converterCode = `public class ${name}JsonConverter : JsonConverter<${name}>
    {
        ${convertCode}
    }
    `;

    return converterCode;
}


export function generateTypeScriptCode(element: Element): string {
    const tagName: tagNames = element.tagName;
    let code: string = ''
    switch (tagName) {
        case "xs:complexType":
            return generateTypeScriptComplexType(element);

        default:
            break;
    }
    return code;
}

function generateTypeScriptComplexType(element: Element): string {

    let complexTypeCode = element.getAttribute('name') ?? 'objName';
    complexTypeCode = capitalize(complexTypeCode);
    let description = element.getAttribute('axios:description');
    let sequenceCode = '';
    let sequence = element.getElementsByTagName('xs:sequence');
    let parentObject = element.getElementsByTagName('xs:extension');
    let baseObject: string = '';
    if (parentObject && parentObject.length > 0) {
        baseObject = parentObject[0].getAttribute('base') ?? '';
        if (baseObject !== '') {
            baseObject = `${capitalize(baseObject)}`
        }
    }

    if (sequence && sequence.length > 0) {
        let sequenceElements = sequence[0].getElementsByTagName('xs:element');
        for (const _elem of sequenceElements) {
            let name = _elem.getAttribute('name') ?? 'FieldName';
            let description = _elem.getAttribute('axios:description');
            let type: AxiosDataTypes = _elem.getAttribute('type') ?? '';
            let ref = _elem.getAttribute('ref');
            //ignore if a reference, probably wont need it
            if (ref) {
                sequenceCode = `${sequenceCode}
                /**
                 * Ref object discarded 
                 * ${_elem.outerHTML}
                 */`;
                continue;
            }
            let dataType: string = type;
            switch (type) {
                case "xs:boolean":
                    dataType = "boolean";
                    break;
                case "xs:string":
                    dataType = "string";
                    break;
                case "xs:dateTime":
                    dataType = "Date";
                    break;
                case "xs:double":
                case "xs:int":
                    dataType = "number";
                    break;
                case "xs:base64Binary":
                    description = `${description ?? ''}\n Data Type : base64Binary\n Element:${_elem.outerHTML}`
                    dataType = "string";
                    break;
                default:
                    dataType = 'any';
                    description = `${description ?? ''}\nData Type : ${type}\n Element:${_elem.outerHTML}`
                    break;
            }
            description = makeTypeScriptDescription(description);
            sequenceCode = `${sequenceCode}
            ${description}
           ${name}?:${dataType},`
        }
    }

    description = makeTypeScriptDescription(description)

    complexTypeCode = `
        ${description ?? ''}
        export interface ${complexTypeCode} extends ${baseObject}{        
            ${sequenceCode}
        }
        `;        
    return complexTypeCode;
}

export function downloadJsonFile(json: any, fileName: string) {
    const stringifiedJson = JSON.stringify(json)
    const dataStr =
        'data:text/json;charset=utf-8,' + encodeURIComponent(stringifiedJson);
    const anchor = document.createElement("a");
    anchor.href = dataStr;
    anchor.setAttribute('download', `${fileName}.json`)
    anchor.click();
}