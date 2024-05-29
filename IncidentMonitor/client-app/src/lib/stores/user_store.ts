import { writable } from "svelte/store";

export const anon: User = {
    id: '',
    userName: ''
}

export const loggedInUser = writable<User>(anon);

export const localUserKey = "loc-user";


export interface User {
    id: string,
    firstName?: string,
    lastName?: string,
    userName: string,
    fullName?: string,
    email?: string,
    isAdmin?: boolean,
    token?: string,
    roleName?: string,
    lastLoginDate?: string
    loginValidUntil?: string,
    isActive?: boolean,
    enableEmailNotifications?: boolean,
    companySiteId?: number | undefined | null | string,
    shiftStartHours?: number,
    shiftStartMinutes?: number,
    shiftEndHours?: number,
    shiftEndMinutes?: number,
    tzOffset?: number,
    companySiteName?: string,
    externalId?: string
}


export type Fetch = (input: RequestInfo | URL, init?: RequestInit | undefined) => Promise<Response>