import React, { useState } from 'react';
import io from "socket.io-client"
// import Chat from "./components/chat/Chat"
import Header from "./components/header/Header"
import Body from "./components/body/Body"
import { BrowserRouter as Router } from "react-router-dom";
import AlertsProvider from "./components/alert/AlertLogic"
const socket = io("http://localhost:3001").connect()
export type SOCKET_TYPE = typeof socket;

function App() {
  // const [userName, setUserName] = useState("")
  // const [room, setRoom] = useState("")

  // const joinRoom = () => {
  //   if (userName && room) {
  //     socket.emit("join_room", room)
  //   }
  // }

  return (
    <Router>
      <AlertsProvider>
        <Header />
        <Body />
        {/* <h3>Join chat</h3>
      <input type="text" placeholder="Name" onChange={(e) => { setUserName(e.target.value) }} />
      <input type="text" placeholder="Room" onChange={(e) => { setRoom(e.target.value) }} />
      <button onClick={joinRoom}>Join</button>

      <Chat socket={socket} userName={userName} room={room} ></Chat> */}
      </AlertsProvider>
    </Router>
  );
}

export default App;
