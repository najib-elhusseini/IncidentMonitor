
import type { SmtpConfiguration } from "$lib/models/smtp_configuration.js";
import { loggedInUser, type Fetch } from "$lib/stores/user_store";


async function getSmtpConfiguration(fetch: Fetch, token: string) {
    const url = '/api/smtpconfig/getsmtpconfig';


    const response = await fetch(url, {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });
    if (response.ok) {
        const config:SmtpConfiguration = await response.json();
        return config;
    }
    return {
        id: 0,
    }

}

export async function load({ fetch }) {
    let token: string = "";
    const unsubscribe = loggedInUser.subscribe(u => {
        token = u.token ?? "";
    });
    const config = await getSmtpConfiguration(fetch, token);
    console.log(config);
    return {
        config
    }
}


