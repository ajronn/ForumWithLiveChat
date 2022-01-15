import React from "react";
import SubSection from "../subsection/SubSection"
import { SECTION, SUB_SECTION } from "../../utils/index"
import style from "./Section.module.css"
interface Props {
    data: SECTION
}
const Section = (props: Props) => {
    return (
        <div className={style.section}>
            <div className={style.header}>
                <p>{props.data.name}</p>
            </div>
            {props.data.subSections.map((data: SUB_SECTION) => <SubSection data={data} />)}
        </div>
    )
}

export default Section