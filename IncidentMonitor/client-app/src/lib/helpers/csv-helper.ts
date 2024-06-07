export function exportCsv(lines: string[][], title: string) {

    if (!title.endsWith('.csv')) {
        title = title + '.csv'
    }
    let csvContent = '';
    for (const line of lines) {
        let _line: string[] = [];
        for (let cell of line) {
            cell = cell.replace('\r\n', '').replace('\n', '').replace(',', '~');
            _line.push(cell);
        }
        const lineString = _line.join(',');
        csvContent = csvContent + lineString + "\r\n"
    }
    downloadBlob(csvContent, title, 'data:text/csv;charset=utf-8')

    // let blob = new Blob([csvContent], { type: 'data:text/csv;charset=utf-8' });
    // let url = URL.createObjectURL(blob);
    // const link = document.createElement('a');
    // link.href = url;
    // link.download = title;

    // link.click();
}

function downloadBlob(blobData: any, fileName: string, dataType: string) {
    let blob = new Blob([blobData], { type: dataType });
    let url = URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.download = fileName;

    link.click();
}


export function exportExcel(tableData: string, fileName: string, worksheet: string = 'Sheet1') {
    let dataType = 'data:application/vnd.ms-excel;base64,';
    let template =
        '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--><meta http-equiv="content-type" content="text/plain; charset=UTF-8"/></head><body><table>{table}</table></body></html>';
    // let tableData = '<tr><td>1</td></tr><tr><td>2</td></tr>';
    template = template.replace('{table}', tableData);
    template.replace('{worksheet}', worksheet);
    downloadBlob(template, fileName, dataType)

    // window.location.href = uri + btoa(template)
}
