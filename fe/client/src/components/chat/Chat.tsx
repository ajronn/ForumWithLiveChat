import React, { useState, useEffect } from "react";
import { SOCKET_TYPE } from "../../App"
import style from "./Chat.module.css"

interface Props {
    socket: SOCKET_TYPE,
    userName: string,
    room: string
}
const Chat = (props: Props) => {
    const [message, setMessage] = useState("")

    const sendMessage = async () => {

        if (message) {
            const messageData = {
                room: props.room,
                author: props.userName,
                message: message,
                time: new Date(Date.now()).getHours() + ":" + new Date(Date.now()).getMinutes()
            }
            await props.socket.emit("send_message", messageData)
        }
    }

    useEffect(() => {
        props.socket.on("recive_message", (data) => {
            console.log(data)
        })
    }, [props.socket])

    return (
        <div>
            <div className={style.header}>
                <p>Live chat</p>
                {/* <p>{props.userName}</p>
                <p>{props.room}</p> */}
            </div>
            <div className={style.body}>

            </div>
            <div className={style.footer}>
                <input type="text" placeholder="Send message" onChange={(e) => { setMessage(e.target.value) }} />
                <button onClick={sendMessage}>Send</button>
            </div>
        </div>
    )
}

export default Chat