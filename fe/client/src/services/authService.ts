import { AnyAction, Dispatch } from "redux"
import { logout as log_out } from "../store/actions/auth"

export type LOGIN_PAYLOAD = {
    email: string,
    password: string,
    rememberMe: boolean
}

export type REGISTER_PAYLOAD = {
    email: string,
    userName: string,
    password: string
}

export class AuthService {
    static async login(dispatch: Dispatch<AnyAction>, payload: LOGIN_PAYLOAD) {
        return await fetch(`${process.env.REACT_APP_DOMAIN}/api/user/login`, {
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': "http://localhost:3000"
            },
            method: "POST",
            body: JSON.stringify(payload)
        })
    }

    static async register(payload: REGISTER_PAYLOAD) {
        return await fetch(`${process.env.REACT_APP_DOMAIN}/api/user/register`, {
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': "http://localhost:3000"
            },
            method: "POST",
            body: JSON.stringify(payload)
        })
    }

    static logout(dispatch: Dispatch<AnyAction>) {
        dispatch(log_out())
    }
}