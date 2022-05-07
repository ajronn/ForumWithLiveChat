import React from "react";
import { Route, Switch } from "react-router-dom";

import { Body } from "./body/Body"
import { Posts } from "./posts/Posts"
import Aside from "../../components/aside/Aside"
import { Threads } from "./threads/Threads"

import style from "./Home.module.css"

export const Home = () => {
    return (
        <div className={style.wrapper}>
            <Switch>
                <Route path="/thread/:id">
                    <Threads />
                </Route>
                <Route path="/post/:thread/:id">
                    <Posts />
                </Route>
                <Route path="/">
                    <Body />
                </Route>
            </Switch>
            <Aside />
        </div>
    )
}