import { THREAD } from "../reducers/thread"

export enum THREAD_ACTIONS {
    GET = "THREAD_GET"
}

export const get = (payload: { subsectionName: string, threads: THREAD[] }) => {
    return {
        type: THREAD_ACTIONS.GET,
        payload: payload
    }
}