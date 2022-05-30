import { USER } from "../store/reducers/auth"

export enum PassCodes {
    length = 'length',
    lowercase = 'lowercase',
    uppercase = 'uppercase',
    special = 'special'
}

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

export const isMailCorrect = (mail: string): boolean => {
    return /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail)
}

export const isPasswordCorrect = (pass: string): string[] => {
    let result = []
    if (pass.length < 8) {
        result.push(PassCodes.length)
    }

    if (pass.split('').filter((sign) => {
        return sign.charCodeAt(0) > 96 && sign.charCodeAt(0) < 123
    }).length === 0) {
        result.push(PassCodes.lowercase)
    }

    if (pass.split('').filter((sign) => {
        return sign.charCodeAt(0) > 64 && sign.charCodeAt(0) < 91
    }).length === 0) {
        result.push(PassCodes.uppercase)
    }

    if (pass.split('').filter((sign) => {
        return sign.charCodeAt(0) > 31 && sign.charCodeAt(0) < 65
    }).length === 0) {
        result.push(PassCodes.special)
    }

    return result
}