import { AnyAction, Dispatch } from "redux"
import { login as log_in, logout as log_out } from "../store/actions/auth"
import { USER } from "../store/reducers/auth"

export type LOGIN_PAYLOAD = {
    email: string,
    password: string,
    rememberMe: boolean
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
            const user: USER = data.data.user
            dispatch(log_in(user))
        }).catch((err) => {
            dispatch(log_in(undefined))
        })
    }
    static logout(dispatch: Dispatch<AnyAction>) {
        dispatch(log_out())
    }
}