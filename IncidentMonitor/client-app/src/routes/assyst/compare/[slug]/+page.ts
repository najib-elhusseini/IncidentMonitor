import type { EventDto } from "$lib/models/assyst-event";
import type { IHelpDeskComment } from "$lib/models/help-desk-object.js";
import { loggedInUser, type Fetch } from "$lib/stores/user_store";

async function getThirdPartyTicketComments(fetch: Fetch, token: string, eventId?: number, userReference?: string, departmentId?: number) {
    const url = `/api/integrations/getthirdpartyticketcomments?eventId=${eventId}&departmentId=${departmentId}&userReference=${userReference}`;

    const response = await fetch(url, {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });
    if (response.ok) {
        const json: IHelpDeskComment[] = await response.json();
        return json;
    }

    return []

}

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

    const thirdPartyComments = await getThirdPartyTicketComments(fetch, token, event.id, event.userReference, event.departmentId);
    console.log(thirdPartyComments)
    return {
        event,
        thirdPartyComments
    }
}