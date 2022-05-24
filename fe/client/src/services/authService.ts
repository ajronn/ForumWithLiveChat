import { AnyAction, Dispatch } from "redux"
import { login as log_in, logout as log_out } from "../store/actions/auth"
import { USER } from "../store/reducers/auth"

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
        await fetch(`${process.env.REACT_APP_DOMAIN}/api/user/login`, {
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': "http://localhost:3000"
            },
            method: "POST",
            body: JSON.stringify(payload)
        }).then((res: any) => res.json()).then((data) => {
            window.sessionStorage.setItem('token', JSON.stringify(data.data.token))
            const user: USER = data.data.user
            dispatch(log_in(user))
        }).catch((err) => {
            dispatch(log_in(undefined))
        })
    }

    static async register(dispatch: Dispatch<AnyAction>, payload: REGISTER_PAYLOAD) {
        await fetch(`${process.env.REACT_APP_DOMAIN}/api/user/register`, {
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