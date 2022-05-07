import React, { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { ThreadService } from "../../../services/threadService";
import style from "./AddModal.module.css"

type PROPS = {
    close: () => void,
    id: number
}

type FORM = {
    name: string,
    description: string,
    content: string
}

const AddModal = (props: PROPS) => {
    const dispatch = useDispatch()
    const [form, setForm] = useState<FORM>({
        name: '',
        description: '',
        content: ''
    })
    useEffect(() => {
        window.scrollTo(0, 0)
        document.body.style.overflow = 'hidden'
        return () => {
            document.body.style.overflow = 'auto'
        }
    }, [])

    const addThread = () => {
        const validate = Object.values(form).reduce((prev, acc: string) => {
            return !!acc && prev
        }, true)

        if (validate) {
            ThreadService.post(form.name, form.description, form.content, props.id).then(() => {
                ThreadService.get(dispatch, `${props.id}`).then(() => {
                    props.close()
                })
            })
        }
    }

    const setName = (name: string) => setForm({ ...form, name })
    const setDescription = (description: string) => setForm({ ...form, description })
    const setContent = (content: string) => setForm({ ...form, content })

    return (
        <div className={style.modal}>

            <div className={style.container}>
                <button onClick={props.close} >X</button>
                <form className={style.form} >
                    <p>Dodaj wątek</p>
                    <label>
                        Tytuł
                        <input onChange={(event) => setName(event.target.value)} />
                    </label>
                    <label>
                        Opis
                        <input onChange={(event) => setDescription(event.target.value)} />
                    </label>
                    <label>
                        Treść postu
                        <input onChange={(event) => setContent(event.target.value)} />
                    </label>
                    <button type="button" onClick={addThread} >Dodaj</button>
                </form>
            </div>
        </div>
    )
}

export default AddModal