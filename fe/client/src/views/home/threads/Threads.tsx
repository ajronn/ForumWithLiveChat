import React, { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { useDispatch } from "react-redux";
import { useParams, useHistory } from "react-router-dom";

import { LoggedInGuard } from "../../../guards/authGuards";
import { ThreadService } from "../../../services/threadService";
import { IRootState } from "../../../store/reducers";

import { AddThreadForm } from "./addThreadForm/AddThreadForm";
import { Button, Modal } from "../../../components"

import style from "./Threads.module.css"

export const Threads = () => {
    const dispatch = useDispatch()
    const history = useHistory();
    const { threads, name } = useSelector((state: IRootState) => state.thread)
    const { id } = useParams<{ id: string }>();
    const [isModalVisible, setIsModalVisible] = useState(false)

    useEffect(() => {
        ThreadService.get(dispatch, id)
    }, [])

    const onTopicClickHandler = (topicId: number) => {
        history.push(`/post/${id}/${topicId}`)
    }

    const addThread = () => {
        setIsModalVisible(true)
    }

    const closeModal = () => {
        setIsModalVisible(false)
    }

    return (
        <div className={style.container}>
            <Button onClick={() => history.push('/')}>Powrót</Button>

            {
                isModalVisible
                    ?
                    <Modal>
                        <AddThreadForm id={Number(id)} close={() => closeModal()} />
                    </Modal>
                    :
                    ''
            }
            {
                threads.length !== 0
                    ?
                    <>
                        <h1>{name}</h1>
                        <LoggedInGuard>
                            <Button onClick={addThread} >Dodaj wątek</Button>
                        </LoggedInGuard>
                        {threads.map((thread, index) => {
                            return <div key={index} className={`${style.tile} ${style['tile-clickable']}`} onClick={() => onTopicClickHandler(thread.threadId)} >
                                {thread.name}
                            </div>
                        })}
                    </>
                    :
                    <h1>Brak wątków</h1>
            }
        </div>
    )
}