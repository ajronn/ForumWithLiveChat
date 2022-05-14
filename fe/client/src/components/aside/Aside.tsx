import { useState, useRef, useEffect } from "react";
import style from "./Aside.module.css"
import { HubConnectionBuilder } from '@microsoft/signalr';
import { SectionService } from "../../services/sectionService";
import { useDispatch, useSelector } from "react-redux";
import { IRootState } from "../../store/reducers";
import { USER } from "../../store/reducers/auth";
import { Input } from "@mui/material";
import { LoggedInGuard } from "../../guards/authGuards";

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
    const dispatch = useDispatch();
    const { user } = useSelector((state: IRootState) => state.auth)
    let element: HTMLTextAreaElement | null = null

    //@ts-ignore
    latestChat.current = chat;
    useEffect(() => {
        getChat()
        SectionService.get(dispatch)

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
        await fetch(`${process.env.REACT_APP_DOMAIN}/api/message/list`, {
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': "http://localhost:3000"
            },
            method: "GET",
        }).then((res: any) => res.json()).then((res) => {
            const { data } = res;
            setChat(data)
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
            await fetch(`${process.env.REACT_APP_DOMAIN}/api/message/create`, {
                method: 'POST',
                mode: 'cors',
                headers: {
                    'Content-Type': 'application/json',
                    'Access-Control-Allow-Origin': "http://localhost:3000"
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
        chat.forEach((m) => {
            result += m.content + '\n'
        })
        return result
    }

    const onEnterClick = (code: string) => {
        if (code === 'Enter') {
            sendMessage(message)
            setMessage('')
            if (element) {
                element.scrollTop = element.scrollHeight
            }
        }
    }

    return (
        <div className={`${style.content} ${style["content-separate"]}`} style={{ gridArea: "b" }}>
            <LoggedInGuard>
                <div className={style.chat} >
                    <p>Live chat</p>
                    <textarea className={style.messages} readOnly value={getMessages()} ref={(e) => { element = e; if (e) { e.scrollTop = e.scrollHeight } }} />
                    <Input placeholder="Type a message..." onChange={(e) => setMessage(e.target.value)} value={message} onKeyDown={(e) => onEnterClick(e.code)} />
                </div>
            </LoggedInGuard>
        </div>
    )
}

export default Aside