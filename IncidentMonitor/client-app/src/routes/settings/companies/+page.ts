import type { Company } from "$lib/models/company_site.js";
import { loggedInUser } from "$lib/stores/user_store";



async function getCompanies(token: string, fetch: (input: RequestInfo | URL, init?: RequestInit | undefined) => Promise<Response>)
    : Promise<Company[]> {
    const url = `/api/companysites/getcompanies`;

    const response = await fetch(url, {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    })
    if (response.ok) {
        const users: Company[] = await response.json();
        return users;
    }

    return [];

}




export async function load({ fetch }) {
    let token: string = "";
    const unsubscribe = loggedInUser.subscribe(u => {
        token = u.token ?? "";
    });
    unsubscribe();
    const sites = await getCompanies(token, fetch)

    return {
        sites: [...sites]
    }

}