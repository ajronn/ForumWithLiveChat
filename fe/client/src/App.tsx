import React from 'react';
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

import { AlertsProvider } from "./store/providers/AlertLogic"

import { Home, Login, Register } from "./views"

const App = () => {
  return (
    <Router>
      <AlertsProvider>
        <Switch>
          <Route path="/login">
            <Login />
          </Route>
          <Route path="/register">
            <Register />
          </Route>
          <Route path="/">
            <Home />
          </Route>
        </Switch>
      </AlertsProvider>
    </Router>
  );
}

export default App;
