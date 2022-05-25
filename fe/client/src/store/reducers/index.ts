import { combineReducers } from "redux"
import { authReducer } from "./auth"
import { sectionReducer } from "./section"
import { threadReducer } from "./thread"
import { postReducer } from "./post"

export const combinedReducers = combineReducers({
    auth: authReducer,
    section: sectionReducer,
    thread: threadReducer,
    post: postReducer,
})

export type IRootState = ReturnType<typeof combinedReducers>