import React, { useState } from "react";
import style from "./Register.module.css"
import { useHistory } from "react-router-dom";
import { AuthService, REGISTER_PAYLOAD } from "../../services/authService";
import { useAlerts } from "../../store/providers/AlertLogic";

import { Button, Input } from "@mui/material"
import { AlertType } from "../../components/alert/Alert";
import { isMailCorrect, isPasswordCorrect, PassCodes } from "../../tools";

export const Register = () => {
    const [payload, setPayload] = useState<REGISTER_PAYLOAD>({
        email: '',
        userName: '',
        password: '',
    });
    const history = useHistory();
    const { addAlert } = useAlerts();

    const register = () => {
        if (!isMailCorrect(payload.email)) {
            addAlert('Email jest nieprawidłowy', AlertType.ERROR)
            return
        }

        const codes = isPasswordCorrect(payload.password)

        if (codes.length !== 0) {
            let msg = ''
            codes.forEach((c) => {
                switch (c) {
                    case (PassCodes.length):
                        msg += 'Hasło musi zawierać min 8 znaków\n'
                        break;
                    case (PassCodes.lowercase):
                        msg += 'Hasło musi zawierać min 1 małą literę\n'
                        break;
                    case (PassCodes.special):
                        msg += 'Hasło musi zawierać min 1 znak specjalny\n'
                        break;
                    case (PassCodes.uppercase):
                        msg += 'Hasło musi zawierać min 1 dużą literę\n'
                        break;
                }
            })
            addAlert(msg, AlertType.ERROR)
            return
        }

        if (payload.email && payload.password) {
            AuthService.register(payload).then((res) => res.json()).then((data) => {

                if (data.error.forumErrorCode) {
                    switch (`${data.error.forumErrorCode}`) {
                        case '0':
                            addAlert('Użytkownik już istnieje', AlertType.ERROR)
                            break;
                        case '12':
                            addAlert('Hasło nieprawidłowe', AlertType.ERROR)
                            break;
                        default:
                            addAlert('Wystąpił nieoczekiwany błąd', AlertType.ERROR)
                            break;
                    }
                } else {
                    history.push('/')
                }

            })
        }
    }

    return (
        <div className={style.container}>
            <div className={style.form} >
                <h1>Register</h1>
                <div className={style.input} >
                    <Input onChange={(event) => { setPayload({ ...payload, email: event.target.value, userName: event.target.value }) }} placeholder="Email" />
                </div>
                <div className={style.input} >
                    <Input onChange={(event) => { setPayload({ ...payload, password: event.target.value }) }} placeholder="Password" type="password" />
                </div>
                <div className={style.button} >
                    <Button variant="contained" onClick={register}>Register</Button>
                </div>
            </div>
        </div>
    )
}