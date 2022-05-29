import { useEffect, useState, useMemo } from "react"
import { useSelector } from "react-redux";
import { IRootState } from "../../../store/reducers";
import { useHistory } from "react-router-dom";
import { useDispatch } from "react-redux";
import { SectionService } from "../../../services/sectionService";

import { Section, SubSection } from "../../../components"

import style from "./Body.module.css"
import { Input } from "@mui/material"
import SearchIcon from '@mui/icons-material/Search';

export const Body = () => {
    const [search, setSearch] = useState<string>('');
    const history = useHistory();
    const dispatch = useDispatch()

    useEffect(() => {
        SectionService.get(dispatch)
    }, [])

    const { sections } = useSelector((state: IRootState) => state.section)

    const sectionsRender = useMemo(() => {
        return sections.filter((s) => s.subsections.filter((sub) => sub.name.toLowerCase().includes(search.toLowerCase())).length !== 0)
    }, [search, sections])

    return (
        <div className={style.content}>
            <div className={style.header} >
                Sekcje
                <div className={style.search} >
                    <SearchIcon fontSize="large" />
                    <Input onChange={(e) => setSearch(e.target.value)} />
                </div>
            </div>
            <div className={style.sections}>
                {sectionsRender.map((section, index) => {
                    return (
                        <Section
                            key={index + 'bodysection'}
                            name={section.name}>
                            {section.subsections.filter((subsection) => subsection.name.toLowerCase().includes(search.toLowerCase())).map((subsection, index) => {
                                return (
                                    <div
                                        key={index + 'bodysubsection'}
                                        className={`${style.clickable}`}
                                        onClick={() => history.push(`/thread/${subsection.subsectionId}`)}>
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
        </div>
    )
}