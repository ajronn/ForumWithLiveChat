import React, { useEffect, useMemo, useState } from "react";
import { useSelector } from "react-redux";
import { useDispatch } from "react-redux";
import { useParams, useHistory } from "react-router-dom";

import { LoggedInGuard } from "../../../guards/authGuards";
import { ThreadService } from "../../../services/threadService";
import { IRootState } from "../../../store/reducers";

import { AddThreadForm } from "./addThreadForm/AddThreadForm";
import { Modal, SubSection } from "../../../components"

import { Button, Input } from "@mui/material"
import SearchIcon from '@mui/icons-material/Search';

import style from "./Threads.module.css"

export const Threads = () => {
    const dispatch = useDispatch()
    const history = useHistory();
    const [search, setSearch] = useState<string>('');
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

    const threadsRender = useMemo(() => {
        return threads.filter((t) => t.name.toLowerCase().includes(search))
    }, [threads, search])

    return (
        <div className={style.content}>
            <div className={style.header} >
                Wątki - {name}
                <div className={style.search} >
                    <SearchIcon fontSize="large" />
                    <Input onChange={(e) => setSearch(e.target.value)} placeholder="Wyszukaj" />
                </div>
            </div>
            <div className={style.buttons} >
                <div className={style.button}>
                    <Button onClick={() => history.push('/')}>Powrót</Button>
                </div>
                <LoggedInGuard>
                    <div className={style.button}>
                        <Button onClick={addThread}>Dodaj wątek</Button>
                    </div>
                </LoggedInGuard>
            </div>
            {
                threads.length === 0
                    ?
                    <p className={style.none}>Brak wątków</p>
                    :
                    <div className={style.threads} >
                        {threadsRender.map((thread, index) => {
                            return <div key={index} onClick={() => onTopicClickHandler(thread.threadId)} ><SubSection name={thread.name} description='' /></div>
                        })}
                    </div>
            }
            {
                isModalVisible
                    ?
                    <Modal>
                        <AddThreadForm id={Number(id)} close={() => closeModal()} />
                    </Modal>
                    :
                    ''
            }
        </div>
    )
}