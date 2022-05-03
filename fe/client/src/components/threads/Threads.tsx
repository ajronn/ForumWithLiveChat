import React, { useEffect } from "react";
import { useSelector } from "react-redux";
import { useDispatch } from "react-redux";
import { useParams, useHistory } from "react-router-dom";
import { ThreadService } from "../../services/threadService";
import { IRootState } from "../../store/reducers";

import style from "./Threads.module.css"

const Threads = () => {
    const { id } = useParams<{ id: string }>();
    const dispatch = useDispatch()
    const history = useHistory();
    const { data, name } = useSelector((state: IRootState) => state.thread)

    useEffect(() => {
        ThreadService.get(dispatch, id)
    }, [])

    const onTopicClickHandler = (topicId: number) => {
        history.push('/subject/' + topicId)
    }

    return (
        <div className={style.container}>
            {
                data.length !== 0 ? <>
                    <h1>{name}</h1>
                    {data.map((thread, index) => {
                        return <div key={index} className={`${style.tile} ${style['tile-clickable']}`} onClick={() => onTopicClickHandler(thread.threadId)} >
                            {thread.name}
                        </div>
                    })}
                </>
                    : <h1>Brak wątków</h1>
            }
        </div>
    )
}

export default Threads