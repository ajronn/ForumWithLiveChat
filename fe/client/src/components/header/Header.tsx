import React from "react";
import Logo from "../logo/Logo"
import Avatar from "../avatar/Avatar"
import style from "./Header.module.css"
import { BACKGROUND } from "../../utils/index"

import { LoggedInGuard, LoggedOutGuard } from "../../guards/authGuards"
import { useHistory } from "react-router-dom";
import { AuthService } from "../../services/authService";
import { useDispatch } from "react-redux";

const Header = () => {
    const history = useHistory();
    const dispatch = useDispatch();

    const goToLoginPage = () => {
        history.push("/login");
    }

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
                        <button onClick={goToLoginPage} >Login</button>
                    </LoggedOutGuard>
                </div>
            </div>
            <div className={style.graphic} style={{ backgroundImage: `url(${BACKGROUND})` }}>

            </div>
        </div>
    )
}

export default Header