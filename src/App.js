import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './styles/App.css'
import HomePage from "./pages/HomePage";
import AccountPage from "./pages/AccountPage";
import FavoritePage from "./pages/Favorite";
import BasketPage from "./pages/BasketPage";
import Menu from './components/UI/Menu';

function App() {
    return (
        <Menu/>
        // <BrowserRouter>
        //     <div className="Menu">
        //         <div className="Menu__links">
        //             <a href="/HomePage">Главная</a>
        //             <a href="/AccountPage">Моя страница</a>
        //             <a href="/Favorite">Избранное</a>
        //             <a href="/BasketPage">Корзина</a>
        //         </div>
        //     </div>
        //     <Routes>
        //         <Route path="/HomePage" element={<HomePage/>}/>
        //         <Route path="/AccountPage" element={<AccountPage/>}/>
        //         <Route path="/Favorite" element={<FavoritePage/>}/>
        //         <Route path="/BasketPage" element={<BasketPage/>}/>
        //     </Routes>
        // </BrowserRouter>
  )
}

export default App;
