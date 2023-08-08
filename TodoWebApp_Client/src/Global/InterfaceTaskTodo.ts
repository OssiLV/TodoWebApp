export interface ITaskTodo {
    id: number;
    name: string;
    priority: string;
    due_Date: string;
    description: string;
    isCompleted: boolean;
    section_id: number;
}
export interface ITaskTodoHandleComplete {
    id: number;
    isCompleted: boolean;
}
