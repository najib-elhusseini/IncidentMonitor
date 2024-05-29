export const prerender = true;
export const ssr = false;
import { loggedInUser, localUserKey, type User, anon } from "$lib/stores/user_store";


function checkLoginValidity(loginValidUntil: string | undefined): boolean {
    if (!loginValidUntil) return false;
    let date = new Date();
    let day = date.getDate();
    let year = date.getFullYear()
    let month = date.getMonth();

    let parts = loginValidUntil.split('-');
    let partYear = Number(parts[0]);
    let partMonth = Number(parts[1]) - 1;
    let partDay = Number(parts[2]);

    let originalDate = new Date(year, month, day);

    let toCompare = new Date(partYear, partMonth, partDay);

    return originalDate <= toCompare;


}


export async function load({ }) {
    const userData = localStorage.getItem(localUserKey)
    let user: User = anon
    if (userData !== null) {
        let data: User = JSON.parse(userData);
        if (checkLoginValidity(data.loginValidUntil)) {
            user = data;
        }
    }
    loggedInUser.set(user);

    return {
        user: { ...user },
    };
}