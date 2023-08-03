import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { IPriority } from "../Global/Interfaces";

const initialProject: IPriority = {
    name: "P4",
};

export const PriorityReducer = createSlice({
    name: "PriorityReducer",
    initialState: initialProject,
    reducers: {
        setPriority: (state: IPriority, action: PayloadAction<IPriority>) => {
            state.name = action.payload.name;
        },
    },
});

export const { setPriority } = PriorityReducer.actions;
export default PriorityReducer.reducer;
