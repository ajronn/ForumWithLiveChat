import { AnyAction, Dispatch } from "redux"
import { get as getThread } from "../store/actions/thread"
import { THREAD } from "../store/reducers/thread";

export class ThreadService {
    static async get(dispatch: Dispatch<AnyAction>, id: string) {
        await fetch(`${process.env.REACT_APP_DOMAIN}/api/subsection/get?` + new URLSearchParams({
            subsectionId: id
        }), {
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': "http://localhost:3000"
            },
            method: "GET",
        }).then((res: any) => res.json()).then((data) => {
            const threads: THREAD[] = data.data.threads;
            const name = data.data.name
            dispatch(getThread({ subsectionName: name, threads }))
        }).catch((err) => {
            dispatch(getThread({ threads: [], subsectionName: '' }))
        })
    }

    static async post(name: string, description: string, content: string, subsectionId: number) {
        await fetch(`${process.env.REACT_APP_DOMAIN}/api/thread/create`, {
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': "http://localhost:3000"
            },
            method: "POST",
            body: JSON.stringify({
                name,
                description,
                subsectionId
            })
        }).then((res) => res.json()).then(async (data) => {
            const id: number = data.data.threadId
            await fetch(`${process.env.REACT_APP_DOMAIN}/api/post/create`, {
                mode: 'cors',
                headers: {
                    'Content-Type': 'application/json',
                    'Access-Control-Allow-Origin': "http://localhost:3000"
                },
                method: "POST",
                body: JSON.stringify({
                    content,
                    threadId: id
                })
            })
        })
    }
}