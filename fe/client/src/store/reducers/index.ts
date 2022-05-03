import { combineReducers } from "redux"
import { authReducer } from "./auth"
import { sectionReducer } from "./section"
import { threadReducer } from "./thread"

export const combinedReducers = combineReducers({
    auth: authReducer,
    sections: sectionReducer,
    thread: threadReducer,
})

export type IRootState = ReturnType<typeof combinedReducers>