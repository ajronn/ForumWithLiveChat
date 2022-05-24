import React from "react";
import { useDispatch } from "react-redux";
import { useHistory } from "react-router-dom";

import { AuthService } from "../../services/authService";
import { LoggedInGuard, LoggedOutGuard } from "../../guards/authGuards"

import { Logo } from "./logo/Logo"

import style from "./Header.module.css"
import { BACKGROUND } from "../../utils/index"

import { Button } from "@mui/material"
import { useSelector } from "react-redux";
import { IRootState } from "../../store/reducers";
import { makeUserNameFromEmail } from "../../tools";

export const Header = () => {
    const history = useHistory();
    const dispatch = useDispatch();

    const { user } = useSelector((state: IRootState) => state.auth)

    const formattedUserName = () => {
        return user ? `Hi ${makeUserNameFromEmail(user.userName)}!` : ''
    }

    return (
        <div className={style.container}>
            <div className={style.bar}>
                <div>
                    <Logo />
                </div>
                <div className={style.right}>
                    <LoggedOutGuard>
                        <Button variant="contained" onClick={() => history.push("/login")} >Zaloguj</Button>
                    </LoggedOutGuard>
                    <LoggedInGuard>
                        <p className={style.userName}>{formattedUserName()}</p>
                        <Button variant="contained" onClick={() => { AuthService.logout(dispatch) }} >Wyloguj</Button>
                    </LoggedInGuard>
                </div>
            </div>
            <div className={style.graphic} style={{ backgroundImage: `url(${BACKGROUND})` }} />
        </div>
    )
}