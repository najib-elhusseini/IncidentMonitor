export type intlDateFormatOption = "full" | "long" | "medium" | "short" | undefined;

export function formatDate(date: Date | string,
    dateStyle: intlDateFormatOption = "medium",
    timeStyle: intlDateFormatOption = "medium") {
    if (typeof date === "string") {
        date = new Date(date);
    }

    let formatter = new Intl.DateTimeFormat(undefined, {
        dateStyle,
        timeStyle
    });

    return formatter.format(date);
}