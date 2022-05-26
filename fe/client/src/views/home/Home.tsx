import React from "react";
import { Route, Switch } from "react-router-dom";

import { Body } from "./body/Body"
import { Posts } from "./posts/Posts"
import Aside from "../../components/aside/Aside"
import { Threads } from "./threads/Threads"
import { Menu } from "../../components"

import style from "./Home.module.css"
import { LoggedInGuard } from "../../guards/authGuards";

export const Home = () => {
    return (
        <div className={style.wrapper}>
            <div>
                <Menu></Menu>
            </div>
            <div>
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
            </div>
            <LoggedInGuard>
                <Aside />
            </LoggedInGuard>
        </div>
    )
}