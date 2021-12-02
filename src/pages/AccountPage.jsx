import React, { Component } from "react";
import axios from "axios";

export class AccountPage extends Component {

    // state = {
    //     users:[]
    // }

    // componentDidMount(){
    //     axios.get('https://localhost:5001/api/Users')
    //     .then(res => {
    //         const users = res.data;
    //         this.setState({ users});
    //     })
    // }

    render(){
        // const{users}=this.state;
        return (
            <div className="Background">
                <div className="Account">
                    <ul>
                        {/* {this.state.users.map(user => <li>{user.email}</li>)} */}
                    </ul>
                </div>
                <div className="MyPosts">
                    <div className="width_pos_listing_prev">
                        <button className="button_left" ></button>
                    </div>
                    <div className="width_pos_listing_next">
                        <button className="button_right"></button>
                    </div>
                </div>
            </div>
        );
    }
};

export default AccountPage;