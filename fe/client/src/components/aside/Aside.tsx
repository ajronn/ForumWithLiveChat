import React from "react";
// import Section from "../section/Section"
import style from "./Aside.module.css"

const Aside = () => {
    return (
        <div className={`${style.content} ${style["content-separate"]}`} style={{ gridArea: "b" }}>
            {/* {SPECIAL_SECTIONS.map((data: SECTION, i) => <Section key={i} data={data} />)} */}
        </div>
    )
}

export default Aside