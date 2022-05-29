import { AnyAction, Dispatch } from "redux"
import { get as getPost } from "../store/actions/post"
import { POST } from "../store/reducers/post";

export class PostService {
    static async get(dispatch: Dispatch<AnyAction>, id: string) {
        await fetch(`${process.env.REACT_APP_DOMAIN}/api/thread/get?` + new URLSearchParams({
            threadId: id
        }), {
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': "http://localhost:3000"
            },
            method: "GET",
        }).then((res: any) => res.json()).then((data) => {

            const posts: POST[] = data.data.posts
            dispatch(getPost({ posts }))
        }).catch((err) => {
            dispatch(getPost({ posts: [] }))
        })
    }

    static async post(content: string, id: number) {
        const t = JSON.parse(window.sessionStorage.getItem('token') || '')
        await fetch(`${process.env.REACT_APP_DOMAIN}/api/post/create`, {
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': "http://localhost:3000",
                'Authorization': `bearer ${t}`,
            },
            method: "POST",
            body: JSON.stringify({
                content,
                threadId: id
            })
        })
    }

    static async edit(content: string, id: number) {
        const t = JSON.parse(window.sessionStorage.getItem('token') || '')
        await fetch(`${process.env.REACT_APP_DOMAIN}/api/post/update`, {
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': "http://localhost:3000",
                'Authorization': `bearer ${t}`,
            },
            method: "PUT",
            body: JSON.stringify({
                content,
                postId: id
            })
        })
    }
    static async delete(id: number) {
        const t = JSON.parse(window.sessionStorage.getItem('token') || '')
        await fetch(`${process.env.REACT_APP_DOMAIN}/api/post/delete`, {
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': "http://localhost:3000",
                'Authorization': `bearer ${t}`,
            },
            method: "DELETE",
            body: JSON.stringify({
                postId: id
            })
        })
    }
}