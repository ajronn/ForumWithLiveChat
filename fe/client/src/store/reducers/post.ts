import { POST_ACTIONS } from "../actions/post"

export type POST = {
    postId: number,
    content: string,
    createdAt: Date,
    editedAt: Date,
    userId: any,
    user: any,
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