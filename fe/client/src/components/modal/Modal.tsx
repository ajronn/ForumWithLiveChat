import React, { useEffect } from "react";

import style from "./Modal.module.css"

type PROPS = {
    children: React.ReactNode,
}

export const Modal = (props: PROPS) => {
    useEffect(() => {
        // window.scrollTo(0, 0)
        document.body.style.overflow = 'hidden'
        return () => {
            document.body.style.overflow = 'auto'
        }
    }, [])

    return (
        <div className={style.container} >
            {props.children}
        </div>
    )
}