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
  )
}

export default App;
