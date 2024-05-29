export interface Company {
    id: number,
    companyName: string,
    shiftStartHours: number,
    shiftStartMinutes: number,
    shiftEndHours: number,
    shiftEndMinutes: number,
    enableEmailNotifications: boolean,
    enableAlarmNotifications: boolean,
    alarmInterval: number,
    tzOffset?: number,
}