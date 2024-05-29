import { loggedInUser, type Fetch } from "$lib/stores/user_store";
import type { AssystSettings } from "$lib/models/assyst.js";


async function getAssystSettings(fetch: Fetch, token: string): Promise<AssystSettings> {
    const url = `/api/assyst/getassystsettings`;
    const response = await fetch(url, {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });
    if (response.ok) {
        const settings: AssystSettings = await response.json();
        return settings;
    }
    return {
        id: 0,
        baseUrl: "https://assyst.hoist.tech/",
     
    }

}

export async function load({ fetch }) {
    let token: string = "";
    const unsubscribe = loggedInUser.subscribe(u => {
        token = u.token ?? "";
    });
    unsubscribe();
    const settings = await getAssystSettings(fetch, token);
    return {
        settings
    }
}