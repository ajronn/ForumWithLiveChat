import React, { useEffect, useState } from "react";
import { useSelector, useDispatch } from "react-redux";
import { useParams, useHistory } from "react-router-dom";

import { LoggedInGuard } from "../../../guards/authGuards";
import { PostService } from "../../../services/postService";
import { IRootState } from "../../../store/reducers";

import style from "./Posts.module.css"

import { Button, Input } from "@mui/material"
import { formatDate } from "../../../tools";

export const Posts = () => {
    const [form, setForm] = useState<string>('')
    const { thread, id } = useParams<{ thread: string, id: string }>();
    const dispatch = useDispatch()
    const { data } = useSelector((state: IRootState) => state.post)
    const history = useHistory();
    useEffect(() => {
        PostService.get(dispatch, id)
    }, [])

    const setContent = (content: string) => setForm(content)

    const addPost = () => {
        if (form) {
            PostService.post(form, Number(id)).then(() => {
                PostService.get(dispatch, id)
            })
        }
    }

    return (
        <div className={style.container}>
            <Button variant="contained" onClick={() => history.push(`/thread/${thread}`)}>Powrót</Button>
            {data.map((post, index) => {
                return (
                    <div key={index + "post"} className={style.post}>
                        <div className={`${style.column} ${style.author}`}>
                            {/* {post.user} */}
                        </div>
                        <div className={style.column}>
                            <p className={style.date}>{formatDate(post.createdAt)}</p>
                            <div className={style.content}>
                                <p>{post.content}</p>
                            </div>
                        </div>
                    </div>)
            })}
            <LoggedInGuard>
                <div>
                    <form>
                        <label>
                            Treść postu
                            <Input onChange={(event) => setContent(event.target.value)} />
                        </label>
                        <Button variant="contained" type="button" onClick={addPost}>Dodaj</Button>
                    </form>
                </div>
            </LoggedInGuard>
        </div>
    )
}