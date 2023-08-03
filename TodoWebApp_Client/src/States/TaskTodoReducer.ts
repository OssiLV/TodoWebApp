import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { ITask } from "./../Global/Interfaces";

const initialTaskTodo: ITask = {
    id: 0,
    name: "",
    description: "",
    priority: "",
    due_Date: "",
    isCompleted: false,
    section_id: 0,
};

export const TaskTodoReducer = createSlice({
    name: "TaskTodoReducer",
    initialState: initialTaskTodo,
    reducers: {
        setTaskTodo: (state: ITask, action: PayloadAction<ITask>) => {
            state.id = action.payload.id;
            state.name = action.payload.name;
            state.description = action.payload.description;
            state.priority = action.payload.priority;
            state.due_Date = action.payload.due_Date;
            state.isCompleted = action.payload.isCompleted;
            state.section_id = action.payload.section_id;
        },
    },
});

export const { setTaskTodo } = TaskTodoReducer.actions;
export default TaskTodoReducer.reducer;
