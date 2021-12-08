import React from "react";
import { Link } from 'react-router-dom';
import Filter from "../img/setting.png"
import Search from "../img/search.png"
import DashBoard from "../components/UI/HomePost";
import { string } from "prop-types";
import App from "../components/UI/List"
// import React, {useState} from "react";
// import axios from "axios";

// const [product, SetProduct] = useState(null);
// const apiURL = "Host=localhost;Port=5432;Database=Shopdb;Username=postgres;Password=363kYkmJ";
// const fetchData = async () => {
//     const response = await axios.get(apiURL)

//     SetProduct(response.data) 
// }


const HomePage = () => {
    return (
        <div className="Background">
            <div className="Search">
            <Link to=""><img className="FilterButton" src={Filter}/></Link>
            <input className="SearchText" placeholder="Поиск..."></input>
            <Link to=""><img className="SearchButton" src={Search}/></Link>
            </div>
            <div className="Posts">
                <div className="pos_listing_prev">
                    <button className="button_left" ></button>
                </div>
                <div className="pos_listing_next">
                    <button className="button_right"></button>
                </div>
                <div className="HomePost">
                    {/* <DashBoard/> */}
                    <App/>
                </div>
            </div>
        </div>
    )
}

export default HomePage;