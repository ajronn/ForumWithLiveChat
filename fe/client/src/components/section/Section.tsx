import React from "react";

import style from "./Section.module.css"
import Leaf from "../../utils/images/leaf.png";

interface Props {
    name: string,
    children: React.ReactNode
}
export const Section = (props: Props) => {

    return (
        <div className={style.container}>
            <div className={style.header}>
                <img src={Leaf} alt="" width={32} height={32} />
                <p>{props.name}</p>
            </div>
            <div className={style.children} >
                {props.children}
            </div>
        </div>
    )
}