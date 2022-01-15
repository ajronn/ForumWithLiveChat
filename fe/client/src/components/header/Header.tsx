import React from "react";
import Logo from "../logo/Logo"
import Avatar from "../avatar/Avatar"
import style from "./Header.module.css"
import { BACKGROUND } from "../../utils/index"

const Header = () => {
    return (
        <div className={style.container}>
            <div className={style.bar}>
                <Logo />
                <div>
                    <Avatar />
                </div>
            </div>
            <div className={style.graphic} style={{ backgroundImage: `url(${BACKGROUND})` }}>

            </div>
        </div>
    )
}

export default Header