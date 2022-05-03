import React from "react";
import style from "./Alert.module.css"
import InfoImg from "../../utils/info.png"
import WarningImg from "../../utils/warning.png"
import ErrorImg from "../../utils/error.png"
import SuccessImg from "../../utils/success.png"
import CloseImg from "../../utils/close.png"

export enum AlertType {
    INFO = 'info',
    WARNING = 'warning',
    ERROR = 'error',
    SUCCESS = 'success'
}

interface Props {
    id: string,
    message: string
    type?: AlertType
    close: () => void
}

const Alert = (props: Props) => {
    const selectType = (): string => {
        const styles = {
            [AlertType.INFO]: style.info,
            [AlertType.WARNING]: style.warning,
            [AlertType.ERROR]: style.error,
            [AlertType.SUCCESS]: style.success
        }
        return styles[props.type ? props.type : AlertType.INFO]
    }

    const selectImage = () => {
        const icons = {
            [AlertType.INFO]: InfoImg,
            [AlertType.WARNING]: WarningImg,
            [AlertType.ERROR]: ErrorImg,
            [AlertType.SUCCESS]: SuccessImg
        }
        return icons[props.type ? props.type : AlertType.INFO]
    }
    return (
        <div className={`${style.alert} ${selectType()}`}>
            <div className={style.center}><img src={selectImage()} height={23} width={23} alt="" /></div>
            <div className={style.center}>{props.message}{props.id}</div>
            <div className={style.close} onClick={() => { props.close() }}><img src={CloseImg} alt="" height={10} /></div>
        </div>
    )
}

export default Alert;