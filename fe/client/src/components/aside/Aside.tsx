import { useState, useRef, useEffect } from "react";
import style from "./Aside.module.css"
import { HubConnectionBuilder } from '@microsoft/signalr';
import { useSelector } from "react-redux";
import { IRootState } from "../../store/reducers";
import { USER } from "../../store/reducers/auth";
import { Input } from "@mui/material";
import { makeUserNameFromEmail } from "../../tools";
import Picker from 'emoji-picker-react';

type MESSAGE = {
    userId: string,
    userName: string,
    content: string,
    date: Date
}

const Aside = () => {
    const [chat, setChat] = useState<MESSAGE[]>([]);
    const [message, setMessage] = useState<string>('');
    const latestChat = useRef(null);
    const { user } = useSelector((state: IRootState) => state.auth)
    let element: HTMLTextAreaElement | null = null

    const onEmojiClick = (event: any, emojiObject: any) => {
        setMessage(message + emojiObject.emoji);
    };

    //@ts-ignore
    latestChat.current = chat;
    useEffect(() => {
        getChat()

        const connection = new HubConnectionBuilder()
            .withUrl(`${process.env.REACT_APP_DOMAIN}/chat`)
            .withAutomaticReconnect()
            .build();

        connection.start()
            .then(result => {
                connection.on('ReceiveMessage', message => {
                    //@ts-ignore
                    const updatedChat = [...latestChat.current];
                    updatedChat.push(message);
                    //@ts-ignore
                    setChat(updatedChat);
                });
            })
            .catch(e => console.log('Connection failed: ', e));

    }, [])

    const getChat = async () => {
        const t = JSON.parse(window.sessionStorage.getItem('token') || '')
        await fetch(`${process.env.REACT_APP_DOMAIN}/api/message/list?` + new URLSearchParams({
            Page: '0',
            PageSize: '50',
        }), {
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': "http://localhost:3000",
                'Authorization': `bearer ${t}`,
            },
            method: "GET",
        }).then((res: any) => res.json()).then((res) => {
            const { data } = res;
            setChat(data.items)
        })
    }

    const sendMessage = async (message: string) => {
        const u: USER | null = user
        if (!u) {
            return;
        }
        const chatMessage = {
            userId: u.id,
            userName: u.userName,
            content: message,
        };

        try {
            const t = JSON.parse(window.sessionStorage.getItem('token') || '')
            await fetch(`${process.env.REACT_APP_DOMAIN}/api/message/create`, {
                method: 'POST',
                mode: 'cors',
                headers: {
                    'Content-Type': 'application/json',
                    'Access-Control-Allow-Origin': "http://localhost:3000",
                    'Authorization': `bearer ${t}`,
                },
                body: JSON.stringify(chatMessage),
            })
        }
        catch (e) {
            console.log('Sending message failed.', e);
        }
    }

    const getMessages = () => {
        let result = ''
        try {
            chat.forEach((m) => {
                result += `${makeUserNameFromEmail(m.userName)}: ${m.content}\n`
            })
        } catch (err) { }
        return result
    }

    const onEnterClick = (code: string) => {
        if ((code === 'Enter' || code === 'NumpadEnter') && message) {
            sendMessage(message)
            setMessage('')
            if (element) {
                element.scrollTop = element.scrollHeight
            }
        }
    }

    return (
        <div className={style.content}>
            <div className={style.chat} >
                <p>Live chat</p>
                <textarea className={style.messages} readOnly value={getMessages()} ref={(e) => { element = e; if (e) { e.scrollTop = e.scrollHeight } }} />
                <div className={style.send}>
                    <Input placeholder="Type a message..." onChange={(e) => setMessage(e.target.value)} value={message} onKeyDown={(e) => onEnterClick(e.code)} />
                </div>
            </div>
            <Picker onEmojiClick={onEmojiClick} />
        </div>
    )
}

export default Aside