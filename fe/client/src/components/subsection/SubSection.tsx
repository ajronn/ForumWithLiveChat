import style from "./SubSection.module.css"
interface Props {
    name: string,
    description: string
}

export const SubSection = (props: Props) => {
    return (
        <div className={style.container}>
            <p>{props.name}</p>
            <p>{props.description}</p>
        </div>
    )
}