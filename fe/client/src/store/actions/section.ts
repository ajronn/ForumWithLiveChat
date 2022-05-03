import { SECTION } from "../reducers/section"

export enum SECTION_ACTIONS {
    GET = "SECTION_GET"
}

export const get = (payload: SECTION[]) => {
    return {
        type: SECTION_ACTIONS.GET,
        payload: payload
    }
}