import React from "react";
import axios from "axios";

 export default class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
        PageNumber: 1,
        PageSize: 1
    };
    this.handleClick = this.handleClick.bind(this);
  }

  handleClick(value) {
    this.setState({ PageNumber: value });
  }

  render() {
    return (
      <div className="App">
        <CommentsView postId={this.state.PageNumber} />
        <PageSelector
          PageNumber={this.state.PageNumber}
          PageSize={this.state.PageSize}
          handleClick={this.handleClick}
        />
      </div>
    );
  }
}

function PageSelector(props) {
  
    const pages = [];
  
    for (let i = 1; i <= props.PageNumber+1; i++) {
      pages.push(
        <button key={i} onClick={() => props.handleClick(i)} className="pos_listing_next">
          {i}
        </button>
      );
    }
  
    return <div className="button_right">{pages}</div>;
  }

class CommentsView extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
        person: []
    };
  }

  componentDidMount() {
    this.getComments(this.props.postId);
  }

  componentDidUpdate() {
    this.getComments(this.props.postId);
  }

  getComments(postId) {
    axios
      .get(`https://localhost:5001/Products?PageNumber=${postId}&PageSize=1`)
      .then(response => this.setState({ person: response.data }))
      .catch(error => console.log(error));
  }

  render() {
    const person = this.state.person.map(persons => (
      <div key={persons.id}>{persons.name}</div>
    ));

    return person.length > 0 ? <div>{person}</div> : <loading>loading</loading>,
        <div className="DashBoard">
          <div className="DashTitle">
              <div className="DashName">
                  { this.state.person.map(person => <div>{person.name}</div>)}
              </div>
                <div className="DashDate">
                  { this.state.person.map(person => <div>{person.title}</div>)}
              </div>
          </div>
          <div className="DashMain">
              <div className ="DashPhoto">
                  { this.state.person.map(person => <img className="DashIMG" src={person.photos}></img>)}
              </div>
              <div className="DashAccount">
                  
              </div>
            </div>
          <div className="DashBottom">
              <div className="DashMenu">
                  <div className="DashPrice">
                      { this.state.person.map(person => <div>{person.price}</div>)}
                  </div>
                  <div className="DashAct">
  
                  </div>
              </div>
              <div className="DashDescr">
                  <div className="DashDescrTitle">
                      Ну тут тип серега не добавил дату, поэтому мы костылим
                  </div>
                  <div className="DashProdDescr">
                      { this.state.person.map(person => <div>{person.description}</div>)}
                  </div>
              </div>
          </div>
        </div>
  }
}