import React, { useState, useEffect } from "react";
import style from "./Login.module.css"
import { useHistory } from "react-router-dom";
import { AuthService, LOGIN_PAYLOAD } from "../../services/authService"
import { useSelector } from "react-redux"
import { IRootState } from "../../store/reducers"
import { useDispatch } from "react-redux";
import { sessionStorageUser } from "../../tools";

const Login = () => {
    const [payload, setPayload] = useState<LOGIN_PAYLOAD>({
        email: '',
        password: '',
        rememberMe: false
    });
    const history = useHistory();
    const { user } = useSelector((state: IRootState) => state.auth)
    const dispatch = useDispatch()
    useEffect(() => {
        if (sessionStorageUser()) {
            history.replace('/')
        }
    }, [user, history])

    const login = () => {
        if (payload.email && payload.password) {
            AuthService.login(dispatch, payload).finally(() => {
                //  window.location.reload()
            })
        }
    }

    return (
        <div className={style.container}>
            <h1>Login</h1>
            <input onChange={(event) => { setPayload({ ...payload, email: event.target.value }) }} placeholder="Email" />
            <input onChange={(event) => { setPayload({ ...payload, password: event.target.value }) }} placeholder="Password" type="password" />
            <button onClick={login}>Login</button>
        </div>
    )
}

export default Login