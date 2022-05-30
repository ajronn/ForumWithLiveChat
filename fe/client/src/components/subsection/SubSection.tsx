import style from "./SubSection.module.css"
interface Props {
    name: string,
    description: string
}

export const SubSection = (props: Props) => {
    return (
        <div className={style.container}>
            <p className={style.name} >{props.name}</p>
            <p className={style.description} >{props.description}</p>
        </div>
    )
}