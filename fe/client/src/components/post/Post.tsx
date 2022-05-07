import React, { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { useDispatch } from "react-redux";
import { useParams } from "react-router-dom";
import { PostService } from "../../services/postService";
import { IRootState } from "../../store/reducers";
import style from "./Post.module.css"

const Post = () => {
    const [form, setForm] = useState<string>('')
    const { id } = useParams<{ id: string }>();
    const dispatch = useDispatch()
    const { data } = useSelector((state: IRootState) => state.post)
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
            <div>
                <form>
                    <label>
                        Treść postu
                        <input onChange={(event) => setContent(event.target.value)} />
                    </label>
                    <button type="button" onClick={addPost}>Dodaj</button>
                </form>
            </div>
        </div>
    )
}

export default Post