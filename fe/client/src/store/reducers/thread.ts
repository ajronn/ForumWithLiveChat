import { THREAD_ACTIONS } from "../actions/thread"

export type THREAD = {
    threadId: number,
    name: string,
    description: string,
    subsectionId: number,
    posts: []
}

const INIT_STATE: {
    data: THREAD[],
    name: string,
} = {
    data: [],
    name: ''
}

export const threadReducer = (state = INIT_STATE, action: { type: THREAD_ACTIONS, payload: { subsectionName: string, threads: THREAD[] } }) => {
    switch (action.type) {
        case THREAD_ACTIONS.GET:
            return { ...state, data: action.payload.threads, name: action.payload.subsectionName }
        default:
            return state
    }
}