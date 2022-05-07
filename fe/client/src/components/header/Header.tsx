import React from "react";
import { useDispatch } from "react-redux";
import { useHistory } from "react-router-dom";

import { AuthService } from "../../services/authService";
import { LoggedInGuard, LoggedOutGuard } from "../../guards/authGuards"

import { Logo } from "./logo/Logo"
import { Avatar } from ".."

import style from "./Header.module.css"
import { BACKGROUND } from "../../utils/index"

export const Header = () => {
    const history = useHistory();
    const dispatch = useDispatch();

    return (
        <div className={style.container}>
            <div className={style.bar}>
                <Logo />
                <div>
                    <LoggedInGuard>
                        <button onClick={() => { AuthService.logout(dispatch) }} >Logout</button>
                        <Avatar />
                    </LoggedInGuard>
                    <LoggedOutGuard>
                        <button onClick={() => history.push("/login")} >Login</button>
                    </LoggedOutGuard>
                </div>
            </div>
            <div className={style.graphic} style={{ backgroundImage: `url(${BACKGROUND})` }} />
        </div>
    )
}