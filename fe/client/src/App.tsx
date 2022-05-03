import React, { useEffect } from 'react';
import Header from "./components/header/Header"
import Body from "./components/body/Body"
import { BrowserRouter as Router } from "react-router-dom";
import AlertsProvider from "./components/alert/AlertLogic"
import { WEBSITE } from './config';

const App = () => {
  useEffect(() => {
    console.log(WEBSITE)
  }, [])
  return (
    <Router>
      <AlertsProvider>
        <Header />
        <Body />
      </AlertsProvider>
    </Router>
  );
}

export default App;
