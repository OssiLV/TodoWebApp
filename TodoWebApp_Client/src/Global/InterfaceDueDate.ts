export interface IDueDate {
    task_id: number;
    type: "" | "OPTIONS" | "CALENDAR" | "MODAL" | "UPDATE";
    fullDateTime: string;
}
