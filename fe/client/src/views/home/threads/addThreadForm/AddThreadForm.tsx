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
            <Button variant="contained" onClick={props.close}>Close</Button>
            <form className={style.form} >
                <p>Dodaj wątek</p>
                <label>
                    <p>Tytuł</p>
                    <Input onChange={(event) => setName(event.target.value)} />
                </label>
                <label>
                    <p>Opis</p>
                    <Input onChange={(event) => setDescription(event.target.value)} />
                </label>
                <label>
                    <p>Treść postu</p>
                    <TextareaAutosize onChange={(event) => setContent(event.target.value)} style={{ width: '200px', resize: 'vertical', minHeight: '20px' }}></TextareaAutosize>
                </label>
                <Button variant="contained" onClick={addThread} >Dodaj</Button>
            </form>
        </div>
    )
}