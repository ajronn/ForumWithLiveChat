import React from "react";
import { useSelector } from "react-redux"
import { IRootState } from "../store/reducers"

type PROPS = {
    children: React.ReactNode
}

export const LoggedInGuard = (props: PROPS) => {
    const { children } = props;
    const { user } = useSelector((state: IRootState) => state.auth)
    return (
        <>
            {(!!user) ? <>{children}</> : ''}
        </>
    )
}

export const LoggedOutGuard = (props: PROPS) => {
    const { children } = props;
    const { user } = useSelector((state: IRootState) => state.auth)
    return (
        <>
            {!(!!user) ? <>{children}</> : ''}
        </>
    )
}