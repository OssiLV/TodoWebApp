import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { IDataTransfer } from "../Global/Interfaces";

const initialDataTransfer: IDataTransfer = {
    id: 0,
    name: "",
    categories: "",
    tailwindBgHexCode: "",
};

export const DataTransferReducer = createSlice({
    name: "DataTransferReducer",
    initialState: initialDataTransfer,
    reducers: {
        setDataTransfer: (
            state: IDataTransfer,
            action: PayloadAction<IDataTransfer>
        ) => {
            state.id = action.payload.id;
            state.name = action.payload.name;
            state.categories = action.payload.categories;
            state.tailwindBgHexCode = action.payload.tailwindBgHexCode;
        },
    },
});

export const { setDataTransfer } = DataTransferReducer.actions;
export default DataTransferReducer.reducer;
