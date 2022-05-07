import { POST } from "../reducers/post"

export enum POST_ACTIONS {
    GET = "POST_GET"
}

export const get = (payload: { posts: POST[] }) => {
    return {
        type: POST_ACTIONS.GET,
        payload
    }
}