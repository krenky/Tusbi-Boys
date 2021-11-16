import React from "react";
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import HomePage from "../../pages/HomePage";
import AccountPage from "../../pages/AccountPage";
import FavoritePage from "../../pages/Favorite";
import BasketPage from "../../pages/BasketPage";
import NewPost from "../../pages/NewPost"
import HomeLogo from "../../img/HomeLogo.png"
import AccountLogo from "../../img/AccountLogo.png"
import FavoriteLogo from "../../img/FavoriteLogo.png";
import BasketLogo from "../../img/BasketLogo.png"
import WebLogo from "../../img/WebLogo.png"
import NewPostLogo from "../../img/NewPostLogo.png"

const Menu = () => {
    return (
        <BrowserRouter>
            <div className="Menu">
                <div className="LogoCell">
                    <img className="Logo" src={WebLogo}></img>
                </div>
                <div className="Menu__links">
                    <div className="MenuCell">
                        <div className="Circle">
                            <Link to="/HomePage"><img className="HomeLogo" src={HomeLogo}/></Link>
                        </div>
                        <div className="Rect">
                            <Link to="/HomePage" className="MenuLink">Главная</Link>
                        </div>
                    </div>
                    <div className="MenuCell">
                        <div className="Circle">
                            <Link to="/AccountPage"><img className="AccountLogo" src={AccountLogo}/></Link>
                        </div>
                        <div className="Rect">
                            <Link to="/AccountPage" className="MenuLink">Моя страница</Link> 
                        </div>
                    </div>
                    <div className="MenuCell">
                        <div className="Circle">
                            <Link to="/Favorite"><img className="FavoriteLogo" src={FavoriteLogo}/></Link>
                        </div>
                        <div className="Rect">
                            <Link to="/Favorite" className="MenuLink">Избранное</Link>
                        </div>
                    </div>
                    <div className="MenuCell">
                        <div className="Circle">
                            <Link to="/BasketPage"><img className="BasketLogo" src={BasketLogo}/></Link>
                        </div>
                        <div className="Rect">
                            <Link to="/BasketPage" className="MenuLink">Корзина</Link>
                        </div>
                    </div>
                    <div className="MenuCell">
                        <div className="Circle">
                            <Link to="/NewPost"><img className="NewPostLogo" src={NewPostLogo}/></Link>
                        </div>
                        <div className="Rect">
                            <Link to="/NewPost" className="MenuLink">Разместить объявление</Link>
                        </div>
                    </div>
                </div>
            </div>
            <Routes>
                <Route path="/HomePage" element={<HomePage/>}/>
                <Route path="/AccountPage" element={<AccountPage/>}/>
                <Route path="/Favorite" element={<FavoritePage/>}/>
                <Route path="/BasketPage" element={<BasketPage/>}/>
                <Route path="/NewPost" element={<NewPost/>}/>
            </Routes>
        </BrowserRouter>
    );
};

export default Menu;