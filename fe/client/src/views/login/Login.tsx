import React, { useState, useEffect } from "react";
import style from "./Login.module.css"
import { useHistory } from "react-router-dom";
import { AuthService, LOGIN_PAYLOAD } from "../../services/authService"
import { useSelector } from "react-redux"
import { IRootState } from "../../store/reducers"
import { USER } from "../../store/reducers/auth"
import { login as log_in } from "../../store/actions/auth"
import { useDispatch } from "react-redux";
import { isUserInSessionStorage } from "../../tools";
import { useAlerts } from "../../store/providers/AlertLogic";
import jwt from 'jwt-decode'

import { Button, Input } from "@mui/material"
import { AlertType } from "../../components/alert/Alert";

export const Login = () => {
    const [payload, setPayload] = useState<LOGIN_PAYLOAD>({
        email: '',
        password: '',
        rememberMe: false
    });
    const { addAlert } = useAlerts();
    const history = useHistory();
    const { user } = useSelector((state: IRootState) => state.auth)
    const dispatch = useDispatch()
    useEffect(() => {
        if (isUserInSessionStorage()) {
            history.replace('/')
        }
    }, [user, history])

    const login = () => {
        if (payload.email && payload.password) {
            AuthService.login(dispatch, payload).then((res: any) => {
                if (!res.ok) {
                    addAlert('Nieprawidłowy login lub hasło', AlertType.ERROR)
                }
                return res.json()
            }).then((data) => {
                window.sessionStorage.setItem('token', JSON.stringify(data.data.token))
                console.log(jwt(data.data.token))
                const user: USER = data.data.user
                dispatch(log_in(user))
            }).catch((err) => {
                dispatch(log_in(undefined))
            })
        }
    }

    return (
        <div className={style.container}>
            <div className={style.form} >
                <h1>Logowanie</h1>
                <div className={style.input} >
                    <Input onChange={(event) => { setPayload({ ...payload, email: event.target.value }) }} placeholder="Email" />
                </div>
                <div className={style.input} >
                    <Input onChange={(event) => { setPayload({ ...payload, password: event.target.value }) }} placeholder="Hasło" type="password" />
                </div>
                <div className={style.button} >
                    <Button variant="contained" onClick={login}>Zaloguj</Button>
                </div>
                <p className={style.link} onClick={() => history.push('/register')} >Nie masz konta?</p>
            </div>
        </div>
    )
}