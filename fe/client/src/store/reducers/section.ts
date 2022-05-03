import { SECTION_ACTIONS } from "../actions/section"

export type SUBSECTION = {
    subsectionId: 1,
    name: string,
    description: string,
    sectionId: number,
    threads: []
}

export type SECTION = {
    name: string,
    sectionId: 1,
    subsections: SUBSECTION[]
}

const INIT_STATE: {
    data: SECTION[]
} = {
    data: []
}

export const sectionReducer = (state = INIT_STATE, action: { type: SECTION_ACTIONS, payload: SECTION[] }) => {
    switch (action.type) {
        case SECTION_ACTIONS.GET:
            return { ...state, data: action.payload }
        default:
            return state
    }
}