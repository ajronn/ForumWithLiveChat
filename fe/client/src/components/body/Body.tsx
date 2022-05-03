import React from "react";
import { Route, Switch } from "react-router-dom";
import Home from "../home/Home"
import Aside from "../aside/Aside"
import Topics from "../topics/Topics"
import Subject from "../subject/Subject"
import style from "./Body.module.css"

const Body = () => {
    return (
        <div className={style.wrapper}>
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