import { isUserInSessionStorage } from "../../tools"
import { AUTH_ACTIONS } from "../actions/auth"

export type USER = {
    id: string,
    userName: string,
    email: string,
    isActive: boolean,
    isArchival: boolean
}

const INIT_STATE: {
    token: string | null,
    user: USER | null,
    error: string | null,
} = {
    token: null,
    user: isUserInSessionStorage(),
    error: null,
}

export const authReducer = (state = INIT_STATE, action: { type: AUTH_ACTIONS, payload?: USER }): typeof INIT_STATE => {
    switch (action.type) {
        case AUTH_ACTIONS.LOGIN:
            return { ...state, user: action.payload || null }
        case AUTH_ACTIONS.LOGOUT:
            return { ...state, user: null }
        default:
            return state
    }
}