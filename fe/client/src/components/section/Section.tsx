import React from "react";

import style from "./Section.module.css"
interface Props {
    name: string,
    children: React.ReactNode
}
export const Section = (props: Props) => {

    return (
        <div className={style.container}>
            <div className={style.header}>
                <p>{props.name}</p>
            </div>
            {props.children}
        </div>
    )
}