import { combineReducers } from "redux"
import { authReducer } from "./auth"
import { sectionReducer } from "./section"

export const combinedReducers = combineReducers({
    auth: authReducer,
    sections: sectionReducer
})

export type IRootState = ReturnType<typeof combinedReducers>