import React from "react";
import { useParams } from "react-router-dom";
import style from "./Subject.module.css"
import { SUBJECT_POSTS } from "../../utils/index"

const Subject = () => {
    const { id } = useParams<{ id: string }>();
    const subjectPosts = SUBJECT_POSTS.filter((post) => post.topicId === id)

    const formatDate = (date: Date) => {
        let day = date.getDate() + ''
        let month = (date.getMonth() + 1) + ''
        const year = date.getFullYear() + ''
        day = day.length === 1 ? `0${day}` : day
        month = month.length === 1 ? `0${month}` : month
        return `${day}.${month}.${year}`
    }
    return (
        <div className={style.container}>
            {subjectPosts.map((post, i) => {
                return (
                    <div key={i} className={style.post}>
                        <div className={`${style.column} ${style.author}`}>
                            {post.author}
                        </div>
                        <div className={style.column}>
                            <p className={style.date}>{formatDate(post.date)}</p>
                            <div className={style.content}>
                                <p>{post.content}</p>
                            </div>
                        </div>
                    </div>)
            })}
        </div>
    )
}

export default Subject