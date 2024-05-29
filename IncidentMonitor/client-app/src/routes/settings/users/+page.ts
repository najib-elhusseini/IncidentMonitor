import type { Company } from '$lib/models/company_site';
import { loggedInUser, type User } from '$lib/stores/user_store.js';



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

async function getUsers(token: string, fetch: (input: RequestInfo | URL, init?: RequestInit | undefined) => Promise<Response>): Promise<User[]> {
    const url = `/api/users/getusers`;

    const response = await fetch(url, {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    })
    if (response.ok) {
        const users: User[] = await response.json();
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
    const companies = await getCompanies(token, fetch);
    const users = await getUsers(token, fetch);
    return {
        users,
        companies: companies
    }


}