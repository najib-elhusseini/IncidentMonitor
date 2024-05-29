
export function stringEquals(strLeft: string | null | undefined, strRight: string | null | undefined): boolean {
    strLeft ??= ''
    strRight ??= ''
    strLeft = strLeft.toLowerCase();
    strRight = strRight.toLowerCase();

    return strLeft === strRight

}

export function capitalize(str: string) {
    if (!str) return '';
    return `${str[0].toUpperCase()}${str.substring(1, str.length)}`;
}