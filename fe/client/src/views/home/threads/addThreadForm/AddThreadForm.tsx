import { useState } from "react"
import { useDispatch } from "react-redux"

import { ThreadService } from "../../../../services/threadService"

import { Button, Input, TextareaAutosize } from "@mui/material"

import style from "./AddThreadForm.module.css"

type PROPS = {
    id: number
    close: () => void
}

type FORM = {
    name: string,
    description: string,
    content: string
}

export const AddThreadForm = (props: PROPS) => {
    const dispatch = useDispatch()
    const [form, setForm] = useState<FORM>({
        name: '',
        description: '',
        content: ''
    })

    const addThread = () => {
        const validate = Object.values(form).reduce((prev, acc: string) => {
            return !!acc && prev
        }, true)

        if (validate) {
            ThreadService.post(form.name, form.description, form.content, props.id).catch(() => { }).then(() => {
                ThreadService.get(dispatch, `${props.id}`).then(() => {
                    props.close()
                })
            }).catch(() => { })
        }
    }

    const setName = (name: string) => setForm({ ...form, name })
    const setDescription = (description: string) => setForm({ ...form, description })
    const setContent = (content: string) => setForm({ ...form, content })

    return (
        <div className={style.container}>
            <div className={style.button} >
                <Button variant="contained" onClick={props.close}>Close</Button>
            </div>
            <div className={style.form} >
                <div className={style.title} >
                    <p>Dodaj wątek</p>
                </div>
                <div className={style.formContent}>
                    <label className={style.control}>
                        <p>Tytuł</p>
                        <Input onChange={(event) => setName(event.target.value)} />
                    </label>
                    <label className={style.control}>
                        <p>Opis</p>
                        <Input onChange={(event) => setDescription(event.target.value)} />
                    </label>
                    <label className={style.control}>
                        <p>Treść postu</p>
                        <div className={style.multiLine} >
                            <TextareaAutosize onChange={(event) => setContent(event.target.value)}></TextareaAutosize>
                        </div>
                    </label>
                </div>
                <div className={style.button} >
                    <Button variant="contained" onClick={addThread} >Dodaj</Button>
                </div>
            </div>
        </div>
    )
}