import React from "react";
import axios from "axios";

export default class AddPost extends React.Component {
    constructor() {
      super();
      this.state = { user: {} };
      this.onSubmit = this.handleSubmit.bind(this);
    }
    handleSubmit(e) {
      e.preventDefault();
      var self = this;
      // On submit of the form, send a POST request with the data to the server.
      fetch('https://localhost:5001/api/Products', { 
          method: 'POST',
          headers:{
            Authorization: "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6Ijg4NjVkNGU3LTdiZDUtNDdkZS1hYWZhLTg5NWNkZTgxZmUxNiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJQYWNUYTAyIiwianRpIjoiZTRkODRlODAtYmFkMS00ODg0LWI2MzUtMzYyMTJhZDViN2NkIiwiZXhwIjoxNjM5MDExNTU0LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.2FPeRYYzE-OeK-vlVKuILQHpfHqqGxgPKNmSJQFPrSU",
          },
          data: {
            name: self.refs.name,
            description: self.refs.description,
            title: self.refs.title,
            price: self.refs.price,
            userId: self.refs.userId, 
            photos: self.refs.photos
          }
        })
        .then(function(response) {
          return response.json()
        }).then(function(body) {
          console.log(body);
        });
    }
    render() {
      return (
        <form onSubmit={this.onSubmit}>
          <input type="text" placeholder="Name" ref="name"/>
          <input type="text" placeholder="description" ref="description"/>
          <input type="text" placeholder="title" ref="title"/>
          <input type="text" placeholder="price" ref="price"/>
          <input type="text" placeholder="photos" ref="photos"/>
          <input type="text" placeholder="id" ref="userId"/>
          <input type="submit" />
        </form>
      );
    }
  }