import React from "react";
import { Route, Switch } from "react-router-dom";
import Home from "../../views/home/Home"
import Aside from "../aside/Aside"
import Threads from "../threads/Threads"
import Post from "../post/Post"
import style from "./Body.module.css"

const Body = () => {
    return (
        <div className={style.wrapper}>
            <Switch>
                <Route path="/thread/:id">
                    <Threads />
                </Route>
                <Route path="/post/:id">
                    <Post />
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