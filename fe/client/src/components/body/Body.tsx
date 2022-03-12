import React from "react";
import { Route, Switch } from "react-router-dom";
import Home from "../home/Home"
import Aside from "../aside/Aside"
import Topics from "../topics/Topics"
import Subject from "../subject/Subject"
import style from "./Body.module.css"
import { useAlerts } from "../alert/AlertLogic"
import { AlertType } from "../alert/Alert"

const Body = () => {
    const { addAlert } = useAlerts()
    return (
        <div className={style.wrapper}>
            <button onClick={() => addAlert('info', AlertType.INFO)} >add</button>
            <button onClick={() => addAlert('error', AlertType.ERROR)} >add</button>
            <button onClick={() => addAlert('success', AlertType.SUCCESS)} >add</button>
            <button onClick={() => addAlert('warning', AlertType.WARNING)} >add</button>
            <Switch>
                <Route path="/topic/:id">
                    <Topics />
                </Route>
                <Route path="/subject/:id">
                    <Subject />
                </Route>
                <Route path="/">
                    <Home />
                </Route>
            </Switch>
            <Aside />
        </div>
    )
}

export default Body