import React from "react";
import style from "./Button.module.css"
type PROPS = {
    children: React.ReactNode,
    onClick: React.MouseEventHandler<HTMLButtonElement> | undefined
}

export const Button = (props: PROPS) => {
    return (
        <button className={style.butt} type="button" onClick={props.onClick}>
            {props.children}
        </button>
    )
}