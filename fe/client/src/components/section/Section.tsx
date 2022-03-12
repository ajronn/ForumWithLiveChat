import React from "react";
import SubSection from "../subsection/SubSection"
import { SECTION, SUB_SECTION } from "../../utils/index"
import style from "./Section.module.css"
interface Props {
    data: SECTION
    onSubSectionClick?: (id: string) => void,
}
const Section = (props: Props) => {
    return (
        <div className={style.section}>
            <div className={style.header}>
                <p>{props.data.name}</p>
            </div>
            {props.data.subSections.map((data: SUB_SECTION, i: number) => <SubSection key={i} style={`${i % 2 === 0 ? style['container-background'] : ''} ${props.onSubSectionClick ? style['container-clickable'] : ''}`} data={data} onSubSectionClick={props.onSubSectionClick} />)}
        </div>
    )
}

export default Section