import type { Company } from "$lib/models/company_site";
import { anon, loggedInUser, type Fetch, type User } from "$lib/stores/user_store";


async function getCompanies(token: string, fetch: Fetch)
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



export async function load({ fetch, params }) {
    const userId = params.slug;
    let token: string = "";
    const unsubscribe = loggedInUser.subscribe(u => {
        token = u.token ?? "";
    });
    unsubscribe();
    let contextUser: User = anon;
    const url = `/api/users/getuser?uid=${userId}`;
    const response = await fetch(url, {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });
    if (response.ok) {
        contextUser = await response.json();
    }
    const companies = await getCompanies(token, fetch)

    let offsets = [];
    for (let i = -12; i < 15; i += 0.5) {
        offsets.push(i);
    }

    return {
        contextUser,
        companies,
        offsets
    }


}