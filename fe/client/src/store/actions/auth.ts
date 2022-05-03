import { USER } from "../reducers/auth"

export enum AUTH_ACTIONS {
    LOGIN = "AUTH_LOGIN",
    LOGOUT = "AUTH_LOGOUT"
}

export const login = (payload?: USER) => {
    return {
        type: AUTH_ACTIONS.LOGIN,
        payload: payload
    }
}

export const logout = () => {
    return {
        type: AUTH_ACTIONS.LOGOUT,
    }
}