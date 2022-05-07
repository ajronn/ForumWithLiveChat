import React, { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { useDispatch } from "react-redux";
import { useParams, useHistory } from "react-router-dom";
import { ThreadService } from "../../services/threadService";
import { IRootState } from "../../store/reducers";
import AddModal from "./add-modal/AddModal"

import style from "./Threads.module.css"

const Threads = () => {
    const { id } = useParams<{ id: string }>();
    const [isModalVisible, setIsModalVisible] = useState(false)
    const dispatch = useDispatch()
    const history = useHistory();
    const { data, name } = useSelector((state: IRootState) => state.thread)

    useEffect(() => {
        ThreadService.get(dispatch, id)
    }, [])

    const onTopicClickHandler = (topicId: number) => {
        history.push('/post/' + topicId)
    }

    const addThread = () => {
        setIsModalVisible(true)
    }

    const closeModal = () => {
        setIsModalVisible(false)
    }

    return (
        <div className={style.container}>
            {isModalVisible ? <AddModal close={closeModal} id={Number(id)} /> : ''}
            {
                data.length !== 0 ? <>
                    <h1>{name}</h1>
                    <button onClick={addThread} >+</button>
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