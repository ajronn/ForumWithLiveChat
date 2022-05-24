import { USER } from "../store/reducers/auth"

export const isUserInSessionStorage = (): USER | null => {
    return sessionStorage.getItem('auth') === null || sessionStorage.getItem('auth') === 'null' ? null : JSON.parse(sessionStorage.getItem('auth')!)
}

export const formatDate = (date: Date) => {
    const day = date.getDate()
    const formattedDay = day < 10 ? `0${day}` : day
    const month = date.getMonth() + 1
    const formattedMonth = month < 10 ? `0${month}` : month
    const year = date.getFullYear()
    const hour = date.getHours()
    const formattedHour = hour < 10 ? `0${hour}` : hour
    const minute = date.getMinutes()
    const formattedMinute = minute < 10 ? `0${minute}` : minute
    return `${formattedDay}.${formattedMonth}.${year} ${formattedHour}:${formattedMinute}`
}

export const makeUserNameFromEmail = (value: string) => {
    return value.split('@')[0];
}