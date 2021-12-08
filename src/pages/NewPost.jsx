import Button from "@restart/ui/esm/Button";
import React from "react";
import AddPost from "../components/UI/AddPost";

const NewPost = () => {
    return (
        <div className="Background">
            <div className="AddPost">
                <AddPost/>
                <div className="AddPostTitle">
                    <div className = "AddImage">
                        <button className="AddPhoto">
                            {/* Класс с фотками */}
                        </button>
                    </div>
                    <div className = "AddInfo">
                        <input className="AddName"></input>
                        <input className="AddPrice"></input>
                        {/* Яндекс карты */}
                    </div>
                </div>
                <div className="AddPostMain">
                    <div className="AddDescription">
                        <input className= "WriteDescription"></input>
                    </div>
                    <div className="AddButton">
                        {/* кнопку сюда */}
                    </div>
                </div>
            </div>
        </div>
    )
}

export default NewPost;