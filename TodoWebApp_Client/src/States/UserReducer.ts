import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { IUser } from "./../Global/Interfaces";

const initialUser: IUser = {
    id: "",
    userName: "",
    email: "",
    emailConfirmed: false,
};

export const UserReducer = createSlice({
    name: "UserReducer",
    initialState: initialUser,
    reducers: {
        setLogin: (state: IUser, action: PayloadAction<IUser>) => {
            state.id = action.payload.id;
            state.userName = action.payload.userName;
            state.email = action.payload.email;
            state.emailConfirmed = action.payload.emailConfirmed;
        },
        setLogout: (state: IUser) => {
            state.id = "";
            state.userName = "";
            state.email = "";
            state.emailConfirmed = false;
        },
        setEmailConfirm: (state: IUser, action) => {
            state.emailConfirmed = action.payload.emailConfirmed;
        },
    },
});

export const { setLogin, setLogout, setEmailConfirm } = UserReducer.actions;
export default UserReducer.reducer;
