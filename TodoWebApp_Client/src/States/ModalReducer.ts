import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { IModal } from "../Global";

const initialOpenModal: IModal = {
    data: {},
    isOpen: false,
};

export const ModalReducer = createSlice({
    name: "ModalReducer",
    initialState: initialOpenModal,
    reducers: {
        setOpenModal: (state: IModal, action: PayloadAction<IModal>) => {
            state.data = action.payload.data;
            state.isOpen = action.payload.isOpen;
        },
        setCloseModal: (state: IModal, action: PayloadAction<IModal>) => {
            state.data = action.payload.data;
            state.isOpen = action.payload.isOpen;
        },
    },
});

export const { setOpenModal, setCloseModal } = ModalReducer.actions;
export default ModalReducer.reducer;
