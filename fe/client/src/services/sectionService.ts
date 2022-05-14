import { AnyAction, Dispatch } from "redux"
import { get as getSections } from "../store/actions/section"
import { SECTION } from "../store/reducers/section";

export class SectionService {
    static async get(dispatch: Dispatch<AnyAction>) {
        await fetch(`${process.env.REACT_APP_DOMAIN}/api/section/list`, {
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': "http://localhost:3000"
            },
            method: "GET",
        }).then((res: any) => res.json()).then((data) => {
            const sections: SECTION[] = data.data;

            dispatch(getSections(sections ? sections : []))
        }).catch((err) => {
            dispatch(getSections([]))
        })
    }
}