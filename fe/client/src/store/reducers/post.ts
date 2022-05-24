import { POST_ACTIONS } from "../actions/post"
import { USER } from "./auth"

export type POST = {
    postId: number,
    content: string,
    createdAt: Date,
    editedAt: Date,
    userId: string,
    user: USER,
    threadId: number
}

const INIT_STATE: {
    data: POST[],
} = {
    data: [],
}

export const postReducer = (state = INIT_STATE, action: { type: POST_ACTIONS, payload: { posts: POST[] } }) => {
    switch (action.type) {
        case POST_ACTIONS.GET:
            return { ...state, data: action.payload.posts }
        default:
            return state
    }
}