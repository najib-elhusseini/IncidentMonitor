import Swal, { type SweetAlertIcon } from "sweetalert2";


export enum ColorTheme {
    dark = "dark",
    light = "light",
    sys = "sys"
}

function getColorTheme(theme: ColorTheme): ColorTheme {

    if (theme === ColorTheme.sys) {
        return window.matchMedia('(prefers-color-scheme: light)').matches ? ColorTheme.light : ColorTheme.dark;
    } else {
        return theme
    }
}

export async function fireDialog(message: string, icon: SweetAlertIcon = "question", theme: ColorTheme) {
    theme = getColorTheme(theme)
    let bg = theme === ColorTheme.dark ? "rgb(51 65 85)" : "#fff"
    let text = theme === ColorTheme.dark ? "#fff" : "#000"
    const result = await Swal.fire({

        showConfirmButton: true,
        showCancelButton: true,
        icon: icon,
        title: message,
        background: bg,
        color: text

    })

    return result;
}

export async function fireDeleteConfirmationDialog() {
    const message = "Are you sure you want to delete this record";
    return fireDialog(message, "question", ColorTheme.sys);
}


export function fireToast(message: string, icon: SweetAlertIcon = "info", theme: ColorTheme) {
    theme = getColorTheme(theme)
    let bg = theme === ColorTheme.dark ? "rgb(51 65 85)" : "#fff"
    let text = theme === ColorTheme.dark ? "#fff" : "#000"
    Swal.fire({
        toast: true,
        position: "top-end",
        showConfirmButton: false,
        showCancelButton: false,
        timer: 1500,
        timerProgressBar: true,
        icon: icon,
        title: message,
        background: bg,
        color: text

    })
}

export function fireSuccessToast(message: string, theme: ColorTheme = ColorTheme.sys) {
    fireToast(message, "success", theme)
}

export function fireErrorToast(message: string, theme: ColorTheme = ColorTheme.sys) {
    fireToast(message, "error", theme)
}

export function fireSaveSuccessToast() {
    fireSuccessToast("Record has been updated", ColorTheme.sys);
}

export function fireSaveErrorToast() {
    fireErrorToast("Failed to update record", ColorTheme.sys);
}


