import { USER } from "../store/reducers/auth"

export const isUserInSessionStorage = (): USER | null => {
    return sessionStorage.getItem('auth') === null || sessionStorage.getItem('auth') === 'null' ? null : JSON.parse(sessionStorage.getItem('auth')!)
}

export const formatDate = (date: Date) => {
    const d = new Date(date)
    const day = d.getDate()
    const formattedDay = day < 10 ? `0${day}` : day
    const month = d.getMonth() + 1
    const formattedMonth = month < 10 ? `0${month}` : month
    const year = d.getFullYear()
    const hour = d.getHours()
    const formattedHour = hour < 10 ? `0${hour}` : hour
    const minute = d.getMinutes()
    const formattedMinute = minute < 10 ? `0${minute}` : minute
    return `${formattedDay}.${formattedMonth}.${year} ${formattedHour}:${formattedMinute}`
}

export const makeUserNameFromEmail = (value: string) => {
    return value.split('@')[0];
}