import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { IRootState } from "../../../store/reducers";
import { useHistory } from "react-router-dom";

import { SectionService } from "../../../services/sectionService";

import { Section, SubSection } from "../../../components"

import style from "./Body.module.css"

export const Body = () => {
    const history = useHistory();
    const dispatch = useDispatch();

    const { sections } = useSelector((state: IRootState) => state.sections)


    useEffect(() => {
        SectionService.get(dispatch)
    }, [])

    return (
        <div className={style.content} style={{ gridArea: "a" }}>
            {sections.map((section, index) => {
                return (
                    <Section
                        key={index + 'bodysection'}
                        name={section.name}>
                        {section.subsections.map((subsection, index) => {
                            return (
                                <div
                                    key={index + 'bodysubsection'}
                                    className={`${style.clickable} ${index % 2 === 0 ? style.backgound : ''}`}
                                    onClick={() => history.push(`/thread/${subsection.sectionId}`)}>
                                    <SubSection
                                        name={subsection.name}
                                        description={subsection.description} />
                                </div>
                            )
                        })}
                    </Section>
                )

            })}
        </div>
    )
}