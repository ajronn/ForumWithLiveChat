import React from "react";
import { SECTION, SUBSECTION } from "../../store/reducers/section";
import SubSection from "../subsection/SubSection"

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
            {props.data.subsections.map((data: SUBSECTION, index: number) => {
                return <SubSection key={index} style={`${index % 2 === 0 ? style['container-background'] : ''} ${props.onSubSectionClick ? style['container-clickable'] : ''}`} data={data} onSubSectionClick={props.onSubSectionClick} />
            })}
        </div>
    )
}

export default Section