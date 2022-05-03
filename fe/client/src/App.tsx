import React from 'react';
import Header from "./components/header/Header"
import Body from "./components/body/Body"
import Login from "./views/login/Login"
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import AlertsProvider from "./components/alert/AlertLogic"

const App = () => {
  return (
    <Router>
      <AlertsProvider>
        <Switch>
          <Route path="/login">
            <Login />
          </Route>
          <Route path="">
            <Header />
            <Body />
          </Route>

        </Switch>
      </AlertsProvider>
    </Router>
  );
}

export default App;
