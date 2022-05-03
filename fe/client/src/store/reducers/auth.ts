import { AUTH_ACTIONS } from "../actions/auth"

export type USER = {
    id: string,
    userName: string,
    email: string,
    isActive: boolean,
    isArchival: boolean
}
const user = JSON.parse(JSON.stringify(sessionStorage.getItem('auth')));
const INIT_STATE: {
    token: string | null,
    user: USER | null,
    error: string | null,
} = {
    token: null,
    user: user === 'null' || !user ? null : user,
    error: null,
}

export const authReducer = (state = INIT_STATE, action: { type: AUTH_ACTIONS, payload?: USER }) => {
    console.log(action)
    switch (action.type) {
        case AUTH_ACTIONS.LOGIN:
            return { ...state, user: action.payload }
        case AUTH_ACTIONS.LOGOUT:
            return { ...state, user: null }
        default:
            return state
    }
}