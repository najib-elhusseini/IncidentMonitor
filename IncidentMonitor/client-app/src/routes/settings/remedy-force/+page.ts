import { loggedInUser, type Fetch } from "$lib/stores/user_store";
import type { RemedyForceSettings } from "$lib/models/remedy_force.js";


async function getRemedyForceSettings(fetch: Fetch, token: string): Promise<RemedyForceSettings> {
    const url = `/api/remedyforceincidents/getremedyforcesettings`;
    const response = await fetch(url, {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });
    if (response.ok) {
        const settings: RemedyForceSettings = await response.json();
        return settings;
    }
    return {
        id: 0,
        instanceUrl: "https://hgts.my.salesforce.com",
        tokenEndPoint: "services/oauth2/token",
        userName: "integrations@hoist.tech",
    }

}

export async function load({ fetch }) {
    let token: string = "";
    const unsubscribe = loggedInUser.subscribe(u => {
        token = u.token ?? "";
    });
    unsubscribe();
    const settings = await getRemedyForceSettings(fetch, token);
    return {
        settings
    }
}