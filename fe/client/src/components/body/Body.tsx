import React from "react";
import Section from "../section/Section"
import style from "./Body.module.css"

import { SECTION, SECTIONS, SPECIAL_SECTIONS } from "../../utils/index"

const Body = () => {
    return (
        <div className={style.wrapper}>
            <div className={style.content} style={{ gridArea: "a" }}>
                {SECTIONS.map((data: SECTION) => <Section data={data} />)}
            </div>
            <div className={`${style.content} ${style["content-separate"]}`} style={{ gridArea: "b" }}>
                {SPECIAL_SECTIONS.map((data: SECTION) => <Section data={data} />)}
            </div>
        </div>
    )
}

export default Body