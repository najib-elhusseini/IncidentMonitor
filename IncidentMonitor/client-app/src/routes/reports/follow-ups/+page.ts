import type { DepartmentDto } from "$lib/models/assyst-department.js";
import { loggedInUser } from "$lib/stores/user_store";

export async function load({ fetch }) {

    let token: string = "";
    const unsubscribe = loggedInUser.subscribe(u => {
        token = u.token ?? "";
    });
    const url = `/api/AssystInfrastructure/getdepartments`
    const response = await fetch(url, {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    })
    let departments: DepartmentDto[] = [];
    if (response.ok) {
        departments = await response.json();
    }

    return {
        departments
    }


}