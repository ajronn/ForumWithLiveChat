import React, { useEffect } from "react";
import Section from "../../components/section/Section"
import style from "./Home.module.css"
import { useHistory } from "react-router-dom";

import { SectionService } from "../../services/sectionService";
import { useDispatch, useSelector } from "react-redux";
import { IRootState } from "../../store/reducers";

const Home = () => {
    const { data } = useSelector((state: IRootState) => state.sections)

    const history = useHistory();
    const dispatch = useDispatch();
    useEffect(() => {
        SectionService.get(dispatch)
    }, [dispatch])

    const onSubSectionClickHandler = (id: string) => {
        history.push("/topic/" + id);
    }
    return (
        <div className={style.content} style={{ gridArea: "a" }}>
            {data.map((sec, index) => {
                return <Section key={index} data={sec} onSubSectionClick={(id: string) => onSubSectionClickHandler(id)} />
            })}
        </div>
    )
}

export default Home