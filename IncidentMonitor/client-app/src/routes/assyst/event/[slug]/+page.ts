import type { EventDto } from '$lib/models/assyst-event.js';
import { loggedInUser } from '$lib/stores/user_store.js';


export async function load({ fetch, params }) {




    return {
        eventId: params.slug
    }
}