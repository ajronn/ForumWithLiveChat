import React from "react";
import { useDispatch } from "react-redux";
import { useHistory } from "react-router-dom";

import { AuthService } from "../../services/authService";
import { LoggedInGuard, LoggedOutGuard } from "../../guards/authGuards"

import { Logo } from "./logo/Logo"

import style from "./Menu.module.css"

import { Button } from "@mui/material"
import { useSelector } from "react-redux";
import { IRootState } from "../../store/reducers";
import { makeUserNameFromEmail } from "../../tools";

export const Menu = () => {
    const history = useHistory();
    const dispatch = useDispatch();

    const { user } = useSelector((state: IRootState) => state.auth)

    const formattedUserName = () => {
        return user ? `Hi ${makeUserNameFromEmail(user.userName)}!` : ''
    }

    const getFirstUserNameLetter = () => {
        const userName = formattedUserName()
        return userName.slice(0, 1).toUpperCase()
    }

    return (
        <div className={style.container}>
            <div className={style.header}>
                <div className={style.logo}>
                    <Logo />
                </div>
                <LoggedInGuard>
                    <div className={style.user} >
                        <div className={style.avatar} >{getFirstUserNameLetter()}</div>
                        {formattedUserName()}
                    </div>
                </LoggedInGuard>
                <LoggedOutGuard>
                    <div className={style.login}>
                        <Button onClick={() => history.push("/login")} >Zaloguj</Button>
                    </div>
                </LoggedOutGuard>
            </div>
            <div className={style.logout} >
                <LoggedInGuard>
                    <Button variant="contained" onClick={() => { AuthService.logout(dispatch) }} >Wyloguj</Button>
                </LoggedInGuard>
            </div>
        </div>
    )
}