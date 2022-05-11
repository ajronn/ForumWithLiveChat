import React from "react";
import { AVATAR } from "../../utils/index"
import style from "./Avatar.module.css"

export const Avatar = () => {
    return (
        <img className={style.avatar} src={AVATAR} alt="" />
    )
}