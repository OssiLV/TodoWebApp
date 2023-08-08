import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { IPriority } from "../Global";

const initialProject: IPriority = {
    type: "",
    name: "P4",
};

export const PriorityReducer = createSlice({
    name: "PriorityReducer",
    initialState: initialProject,
    reducers: {
        setPriority: (state: IPriority, action: PayloadAction<IPriority>) => {
            state.type = action.payload.type;
            state.name = action.payload.name;
        },
    },
});

export const { setPriority } = PriorityReducer.actions;
export default PriorityReducer.reducer;
