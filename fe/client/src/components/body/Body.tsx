import React from "react";
import style from "./Body.module.css"

const Body = () => {
    return (
        <div className={style.wrapper}>
            <div className={style.content} style={{ gridArea: "a" }}>
                <div className={style.card} ></div>
                <div className={style.card} ></div>
                <div className={style.card} ></div>
                <div className={style.card} ></div>
            </div>
            <div className={`${style.content} ${style["content-separate"]}`} style={{ gridArea: "b" }}>
                <div className={`${style.card}`} ></div>
            </div>
        </div>
    )
}

export default Body