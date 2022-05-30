import React, { useEffect, useState } from "react";
import { useSelector, useDispatch } from "react-redux";
import { useParams, useHistory } from "react-router-dom";

import { LoggedInGuard } from "../../../guards/authGuards";
import { PostService } from "../../../services/postService";
import { IRootState } from "../../../store/reducers";

import style from "./Posts.module.css"

import { Button, TextareaAutosize } from "@mui/material"
import { formatDate, makeUserNameFromEmail } from "../../../tools";
import { ThreadService } from "../../../services/threadService";
import { Modal } from "../../../components"

import { POST } from "../../../store/reducers/post"
import { useAlerts } from "../../../store/providers/AlertLogic";
import { AlertType } from "../../../components/alert/Alert";

type ALERT = {
    msg: string,
    type: AlertType
}

type PROPS = {
    post: POST;
    first: boolean;
}
const Post = (props: PROPS) => {
    const [isEditing, setIsEditing] = useState(false)
    const [isModalVisible, setIsModalVisible] = useState(false)
    const [content, setContent] = useState(props.post.content)
    const { user } = useSelector((state: IRootState) => state.auth)

    const isButtonsVisible = (id: string) => `${id}` === `${user?.id}` && !props.first;

    const editPost = () => {
        PostService.edit(content, props.post.postId).finally(() => {
            let alertsFetch: null | string = window.sessionStorage.getItem('alerts');
            let alerts = []
            if (alertsFetch) {
                alerts = JSON.parse(alertsFetch)
            }

            window.sessionStorage.setItem('alerts', JSON.stringify([
                ...alerts,
                {
                    msg: 'Post został edytowany',
                    type: AlertType.INFO
                }
            ]))
            window.location.reload()
        })
    }

    const removePost = () => {
        PostService.delete(props.post.postId).finally(() => {
            let alertsFetch: null | string = window.sessionStorage.getItem('alerts');
            let alerts = []
            if (alertsFetch) {
                alerts = JSON.parse(alertsFetch)
            }

            window.sessionStorage.setItem('alerts', JSON.stringify([
                ...alerts,
                {
                    msg: 'Post został usunięty',
                    type: AlertType.WARNING
                }
            ]))
            window.location.reload()
        })
    }

    return (
        <div className={style.tile}>
            {
                isModalVisible
                    ?
                    <Modal>
                        <div className={style.removeModal} >
                            <p>Czy chcesz usunąć ten post?</p>
                            <div className={style.buttonsModal} >
                                <div className={style.buttonSec}>
                                    <Button variant="contained" type="button" onClick={removePost} >Tak</Button>
                                </div>
                                <div className={style.buttonSec}>
                                    <Button variant="contained" type="button" onClick={() => setIsModalVisible(false)} >Nie</Button>
                                </div>
                            </div>
                        </div>
                    </Modal>
                    :
                    ''
            }
            <div className={style.user} >
                <p>{makeUserNameFromEmail(props.post.user.userName)}</p>
                {
                    props.post.editedAt && !props.first
                        ?
                        <p className={style.smoked} >Edytowano {formatDate(props.post.editedAt)}</p>
                        :
                        ''
                }
                <p>Utworzono {formatDate(props.post.createdAt)}</p>
            </div>
            <div className={style.postContent} >
                {
                    isEditing
                        ?
                        <div className={style.multiLine}>
                            <TextareaAutosize value={content} onChange={(e) => setContent(e.target.value)} />
                        </div>
                        :
                        <div className={style.text} >
                            <TextareaAutosize value={props.post.content} readOnly />
                        </div>
                }
            </div>
            {
                isButtonsVisible(props.post.user.id)
                    ?
                    <div className={style.remove} >
                        <div className={style.button}>
                            {
                                isEditing
                                    ?
                                    <Button onClick={() => editPost()} >Akceptuj</Button>
                                    :
                                    <Button onClick={() => setIsEditing(true)} >Edytuj</Button>
                            }
                            {
                                isEditing
                                    ?
                                    ''
                                    :
                                    <Button onClick={() => setIsModalVisible(true)} >Usuń</Button>
                            }
                        </div>
                    </div>
                    : ''
            }
        </div>
    )
}

export const Posts = () => {
    const [form, setForm] = useState<string>('')
    const [name, setName] = useState<string>('')
    const { thread, id } = useParams<{ thread: string, id: string }>();
    const dispatch = useDispatch()
    const { data } = useSelector((state: IRootState) => state.post)
    const { addAlert } = useAlerts();
    const history = useHistory();
    useEffect(() => {
        PostService.get(dispatch, id)
        getName()
        const alerts = window.sessionStorage.getItem('alerts');
        if (alerts) {
            JSON.parse(alerts).forEach((a: ALERT) => {
                addAlert(a.msg, a.type)
            })
            sessionStorage.removeItem('alerts')
        }
    }, [])

    const setContent = (content: string) => setForm(content)

    const addPost = () => {
        if (form) {
            PostService.post(form, Number(id)).then(() => {
                PostService.get(dispatch, id)
                setContent('')
            })
        }
    }

    const getName = () => {
        ThreadService.getSingle(id).then((name: string) => setName(name));
    }

    return (
        <div className={style.content}>
            <div className={style.header} >
                {name}
            </div>
            <div className={style.buttons} >
                <div className={style.button}>
                    <Button onClick={() => history.push(`/thread/${thread}`)}>Powrót</Button>
                </div>
            </div>
            <div className={style.posts}>
                {data.map((post, index) => {
                    return (
                        <Post key={index} post={post} first={index === 0} />
                    )
                })}
                <LoggedInGuard>
                    <div className={style.tile}>
                        <div>
                            <label>
                                <p className={style.white} >Treść postu</p>
                                <div className={style.multiLine}>
                                    <TextareaAutosize onChange={(event) => setContent(event.target.value)} value={form} />
                                </div>
                            </label>
                        </div>
                        <div className={style.buttonSec}>
                            <Button variant="contained" type="button" onClick={addPost} >Dodaj</Button>
                        </div>
                    </div>
                </LoggedInGuard>
            </div>
        </div>
    )
}