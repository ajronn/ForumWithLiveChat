import React from "react";
import { SUB_SECTION } from "../../utils/index"
import style from "./SubSection.module.css"

interface Props {
    data: SUB_SECTION
}

const SubSection = (props: Props) => {
    return (
        <div className={style.container}>
            <p>{props.data.name}</p>
            <p>{props.data.description}</p>
        </div>
    )
}

export default SubSection