import { ITask } from "./Interfaces";

export const setCompleted = (task: ITask, isCompleted: boolean) => {
    task.isCompleted = isCompleted;
};
