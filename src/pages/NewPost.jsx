import Button from "@restart/ui/esm/Button";
import React from "react";

const NewPost = () => {
    return (
        <div className="Background">
            <div className="AddPost">
                <div className="AddPostTitle">
                    <div className = "AddImage">
                        <button className="AddPhoto">
                            {/* Класс с фотками */}
                        </button>
                    </div>
                    <div className = "AddInfo">
                        <input className="AddName"></input>
                        <select className="Category">
                            <option value="A">A</option>
                             <option value="B">B</option>
                            <option value="-">Other</option>
                        </select>
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