import React, { useEffect, useState } from "react";
import { useSelector, useDispatch } from "react-redux";
import { useParams, useHistory } from "react-router-dom";

import { LoggedInGuard } from "../../../guards/authGuards";
import { PostService } from "../../../services/postService";
import { IRootState } from "../../../store/reducers";

import style from "./Posts.module.css"

import { Button, Input, TextareaAutosize } from "@mui/material"
import { formatDate, makeUserNameFromEmail } from "../../../tools";
import { ThreadService } from "../../../services/threadService";

export const Posts = () => {
    const [form, setForm] = useState<string>('')
    const [name, setName] = useState<string>('')
    const { thread, id } = useParams<{ thread: string, id: string }>();
    const dispatch = useDispatch()
    const { data } = useSelector((state: IRootState) => state.post)
    const { threads } = useSelector((state: IRootState) => state.thread)
    const history = useHistory();
    useEffect(() => {
        PostService.get(dispatch, id)
        getName()
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
        ThreadService.getSingle(thread).then((name: string) => setName(name));
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
                <LoggedInGuard>
                    <div className={style.button}>
                        <Button>Dodaj post</Button>
                    </div>
                </LoggedInGuard>
            </div>
            <div className={style.posts}>
                {data.map((post, index) => {
                    return (
                        <div key={index} className={style.tile}>
                            <div className={style.user} >
                                <p>{makeUserNameFromEmail(post.user.userName)}</p>
                                <p>Utworzono {formatDate(post.createdAt)}</p>
                            </div>
                            <div className={style.postContent} >
                                {post.content}
                            </div>
                        </div>
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