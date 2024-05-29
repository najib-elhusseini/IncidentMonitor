export function exportCsv(lines: [string[]], title: string) {

    let csvContent = '';
    for (const line of lines) {
        let _line:string[]=[];
        for (let cell of line) {
            cell = cell.replace('\r\n','').replace('\n','').replace(',','~');
            _line.push(cell);
        }
        const lineString = _line.join(',');
        csvContent = csvContent + lineString + "\r\n"
    }

    let blob = new Blob([csvContent], { type: 'data:text/csv;charset=utf-8' });
    let url = URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.download = title;

    link.click();

}