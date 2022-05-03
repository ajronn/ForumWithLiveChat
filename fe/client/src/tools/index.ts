import { USER } from "../store/reducers/auth"

export const sessionStorageUser = (): USER | null => {
    return sessionStorage.getItem('auth') === null || sessionStorage.getItem('auth') === 'null' ? null : JSON.parse(sessionStorage.getItem('auth')!)
}