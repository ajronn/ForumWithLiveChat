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
        })
    }
}