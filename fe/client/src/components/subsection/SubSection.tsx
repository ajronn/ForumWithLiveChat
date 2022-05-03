import React from "react";
import { SUBSECTION } from "../../store/reducers/section";

import style from "./SubSection.module.css"

interface Props {
    data: SUBSECTION,
    style?: string,
    onSubSectionClick?: (id: string) => void
}

const SubSection = (props: Props) => {
    return (
        <div className={`${style.container} ${props.style}`} onClick={() => props.onSubSectionClick && props.onSubSectionClick(`${props.data.subsectionId}`)}>
            <p>{props.data.name}</p>
            <p>{props.data.description}</p>
        </div>
    )
}

export default SubSection