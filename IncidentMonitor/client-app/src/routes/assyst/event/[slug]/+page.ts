import type { EventDto } from "$lib/models/assyst-event.js";
import { anon, loggedInUser, type User } from "$lib/stores/user_store";


export async function load({ params, fetch }) {
    const id = params.slug;
    let token: string = "";
    const unsubscribe = loggedInUser.subscribe(u => {
        token = u.token ?? "";
    });
    unsubscribe();
    const url = `/api/assyst/getevent?eventId=${id}`;
    
    const response = await fetch(url, {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });
    let event: EventDto = {};
    if (response.ok) {
        event = await response.json();
    }
    console.log(event)
    return {
        event
    }
}