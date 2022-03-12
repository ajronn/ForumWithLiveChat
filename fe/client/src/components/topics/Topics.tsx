import React from "react";
import { useParams, useHistory } from "react-router-dom";
import { TOPICS, SECTIONS } from "../../utils/index"
import style from "./Topic.module.css"

const Topics = () => {
    const { id } = useParams<{ id: string }>();
    const subsection = SECTIONS.find((sec) => sec.subSections.find((sec) => sec.id === id))?.subSections.find((sec) => sec.id === id)
    const topics = TOPICS.filter((top) => top.subsectionId === subsection?.id)
    const history = useHistory();

    const onTopicClickHandler = (topicId: string) => {
        history.push('/subject/' + topicId)
    }

    return (
        <div className={style.container}>
            <h1>{subsection?.name}</h1>
            <div style={{ height: "25px" }} />
            {topics.map((top, i) => {
                return (
                    <div key={i} className={`${style.tile} ${style['tile-clickable']}`} onClick={() => onTopicClickHandler(top.id)} >
                        {top.name}
                    </div>
                )
            })}
            {topics.length === 0 &&
                <div>
                    <div className={style.tile} >
                        W tym dziale nie ma jeszcze tematów.
                    </div>
                </div>
            }
        </div>
    )
}

export default Topics