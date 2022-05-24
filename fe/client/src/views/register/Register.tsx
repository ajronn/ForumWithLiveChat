import React, { useState } from "react";
import style from "./Register.module.css"
import { useHistory } from "react-router-dom";
import { AuthService, REGISTER_PAYLOAD } from "../../services/authService"
import { useDispatch } from "react-redux";

import { Button, Input } from "@mui/material"

export const Register = () => {
    const [payload, setPayload] = useState<REGISTER_PAYLOAD>({
        email: '',
        userName: '',
        password: '',
    });
    const history = useHistory();
    const dispatch = useDispatch()

    const register = () => {
        if (payload.email && payload.password) {
            AuthService.register(dispatch, payload).then(() => {
                history.replace('/');
            })
        }
    }

    return (
        <div className={style.container}>
            <h1>Register</h1>
            <Input className={style.input} onChange={(event) => { setPayload({ ...payload, email: event.target.value, userName: event.target.value }) }} placeholder="Email" />
            <Input className={style.input} onChange={(event) => { setPayload({ ...payload, password: event.target.value }) }} placeholder="Password" type="password" />
            <Button className={style.button} variant="contained" onClick={register}>Register</Button>
        </div>
    )
}