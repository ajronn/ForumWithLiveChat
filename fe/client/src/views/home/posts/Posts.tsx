import React, { useEffect, useState } from "react";
import { useSelector, useDispatch } from "react-redux";
import { useParams, useHistory } from "react-router-dom";

import { LoggedInGuard } from "../../../guards/authGuards";
import { PostService } from "../../../services/postService";
import { IRootState } from "../../../store/reducers";

import style from "./Posts.module.css"

export const Posts = () => {
    const [form, setForm] = useState<string>('')
    const { thread, id } = useParams<{ thread: string, id: string }>();
    const dispatch = useDispatch()
    const { data } = useSelector((state: IRootState) => state.post)
    const history = useHistory();
    useEffect(() => {
        PostService.get(dispatch, id)
    }, [])
    const formatDate = (date: Date) => {
        const d = new Date(date)
        const day = d.getDate()
        const formattedDay = day < 10 ? `0${day}` : day
        const month = d.getMonth() + 1
        const formattedMonth = month < 10 ? `0${month}` : month
        const year = d.getFullYear()
        const hour = d.getHours()
        const formattedHour = hour < 10 ? `0${hour}` : hour
        const minute = d.getMinutes()
        const formattedMinute = minute < 10 ? `0${minute}` : minute
        return `${formattedDay}.${formattedMonth}.${year} ${formattedHour}:${formattedMinute}`
    }

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
            <button onClick={() => history.push(`/thread/${thread}`)}>Powrót</button>
            {data.map((post, index) => {
                return (
                    <div key={index + "post"} className={style.post}>
                        <div className={`${style.column} ${style.author}`}>
                            {post.user}
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
                            <input onChange={(event) => setContent(event.target.value)} />
                        </label>
                        <button type="button" onClick={addPost}>Dodaj</button>
                    </form>
                </div>
            </LoggedInGuard>
        </div>
    )
}