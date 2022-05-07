import React from "react";
import { useDispatch } from "react-redux";
import { useHistory } from "react-router-dom";

import { AuthService } from "../../services/authService";
import { LoggedInGuard, LoggedOutGuard } from "../../guards/authGuards"

import { Logo } from "./logo/Logo"
import { Avatar, Button } from ".."

import style from "./Header.module.css"
import { BACKGROUND } from "../../utils/index"

export const Header = () => {
    const history = useHistory();
    const dispatch = useDispatch();

    return (
        <div className={style.container}>
            <div className={style.bar}>
                <div>
                    <Logo />
                </div>
                <div className={style.right}>
                    <LoggedOutGuard>
                        <Button onClick={() => history.push("/login")} >Zaloguj</Button>
                    </LoggedOutGuard>
                    <LoggedInGuard>
                        <Avatar />
                        <Button onClick={() => { AuthService.logout(dispatch) }} >Wyloguj</Button>
                    </LoggedInGuard>
                </div>
            </div>
            <div className={style.graphic} style={{ backgroundImage: `url(${BACKGROUND})` }} />
        </div>
    )
}