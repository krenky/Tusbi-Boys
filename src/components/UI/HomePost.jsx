import React from 'react';

import axios from 'axios';

 class DashBoard extends React.Component {
  state = {
    persons: []
  }
  
  componentDidMount() {
    axios.get('https://localhost:5001/api/Products',{
      mode: 'no-cors' 
    })
    
    
      .then(res => {
        const persons = res.data;
        this.setState({ persons });
      })
  }

  render() {
    return (
      <div className="DashBoard">
		<div className="DashTitle">
			<div className="DashName">
				{ this.state.persons.map(person => <div>{person.name}</div>)}
			</div>
		  	<div className="DashDate">
				{ this.state.persons.map(person => <div>{person.title}</div>)}
			</div>
		</div>
		<div className="DashMain">
			<div className ="DashPhoto">
				{ this.state.persons.map(person => <img className="DashIMG" src={person.photos}></img>)}
		    </div>
		    <div className="DashAccount">
				
		    </div>
	  	</div>
		<div className="DashBottom">
			<div className="DashMenu">
				<div className="DashPrice">
					{ this.state.persons.map(person => <div>{person.price}</div>)}
				</div>
				<div className="DashAct">

				</div>
			</div>
			<div className="DashDescr">
				<div className="DashDescrTitle">
					Ну тут тип серега не добавил дату, поэтому мы костылим
				</div>
				<div className="DashProdDescr">
					{ this.state.persons.map(person => <div>{person.description}</div>)}
				</div>
			</div>
		</div>
      </div>
    )
  }
}

export default DashBoard;
