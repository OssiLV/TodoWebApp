import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { IDueDate } from "../Global";

const initialDueDate: IDueDate = {
    type: "",
    fullDateTime: "Mon Jul 1 0000 00:00:00 GMT+0700 (Indochina Time)",
};

export const DueDateReducer = createSlice({
    name: "DueDateReducer",
    initialState: initialDueDate,
    reducers: {
        setDueDate: (state: IDueDate, action: PayloadAction<IDueDate>) => {
            state.type = action.payload.type;
            state.fullDateTime = action.payload.fullDateTime;
        },
    },
});

export const { setDueDate } = DueDateReducer.actions;
export default DueDateReducer.reducer;
