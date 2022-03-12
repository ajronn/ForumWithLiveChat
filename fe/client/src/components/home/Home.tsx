import React from "react";
import Section from "../section/Section"
import style from "./Home.module.css"
import { useHistory } from "react-router-dom";

import { SECTION, SECTIONS } from "../../utils/index"

const Body = () => {
    const history = useHistory();

    const onSubSectionClickHandler = (id: string) => {
        history.push("/topic/" + id);
    }
    return (
        <div className={style.content} style={{ gridArea: "a" }}>
            {SECTIONS.map((data: SECTION, i) => <Section key={i} data={data} onSubSectionClick={(id: string) => onSubSectionClickHandler(id)} />)}
        </div>
    )
}

export default Body