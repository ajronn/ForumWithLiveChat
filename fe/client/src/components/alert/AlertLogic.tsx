import React, { createContext, useContext } from "react";
import AlertUI, { AlertType } from "./Alert"
import style from "./Alert.module.css"

interface Props {
    children: React.ReactNode
}

type Alert = {
    id: string,
    message: string,
    type?: AlertType
}

interface STATE {
    data: Alert[],
    addAlert: (msg: string, type?: AlertType) => void,
    removeAlert: (id: string) => void
}

const st: STATE = {
    data: [],
    addAlert: (msg: string, type?: AlertType) => { },
    removeAlert: (id: string) => { }
}

const Context = createContext(st)

class AlertsProvider extends React.Component<Props, STATE> {

    checkId = (id: string): boolean => {
        return !!this.state.data.find((a) => a.id === id)
    }

    generateId = (): string => {
        let id = ''
        do {
            id = Math.floor(Math.random() * 10000) + ''
        } while (this.checkId(id))
        return id;
    }

    addAlert = (msg: string, type?: AlertType) => {
        const id = this.generateId();
        this.setState({ data: [...this.state.data, { id: id, message: msg, type: type }] });
    }

    removeAlert = (id: string) => {
        this.setState({ data: this.state.data.filter(e => e.id !== id) });
    }

    state: STATE = {
        data: [],
        addAlert: this.addAlert,
        removeAlert: this.removeAlert
    }

    render() {
        return (
            <Context.Provider value={this.state}>
                <div className={style.container}>
                    {this.state.data.map((a: Alert) => {
                        return <AlertUI message={a.message} type={a.type} id={a.id} />
                    })}
                </div>
                {this.props.children}
            </Context.Provider>
        )
    }
}

export const useAlerts = () => {
    return useContext(Context);
}

export default AlertsProvider;