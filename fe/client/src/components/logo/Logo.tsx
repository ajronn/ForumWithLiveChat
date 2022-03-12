import React from "react";
import style from "./Logo.module.css"
import { useHistory } from "react-router-dom";

const Logo = () => {
    const history = useHistory();
    const onLogoClickHandler = () => {
        history.push('/')
    }
    return (
        <div className={style.logo} onClick={onLogoClickHandler}>
            ForumWithLiveChat
        </div>
    )
}

export default Logo