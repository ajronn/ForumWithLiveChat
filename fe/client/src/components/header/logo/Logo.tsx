import React from "react";
import style from "./Logo.module.css"
import { useHistory } from "react-router-dom";

export const Logo = () => {
    const history = useHistory();

    return (
        <div className={style.logo} onClick={() => history.push('/')}>
            ForumWithLiveChat
        </div>
    )
}