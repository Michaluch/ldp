import React, { Component } from 'react';
import qs from 'qs';
import { Row, Col, Button, Input } from 'react-materialize';
import xhrRequest from '../helpers/xhrRequest';
import Header from './Header';

class LoginPage extends Component {
    state = {
      username: "", //"superuser",
      pass: "", //"password_GOD",
      authToken: ""
    };

    componentWillMount() {
      if (sessionStorage.getItem('Authorization')) {
        window.location.href = '/employees';
      }
    }

    handleChange = (event) => {
        const target = event.target;
        const name = target.name;

        this.setState(
            {
                [name]: target.value
            }
        );
    };

    handleSubmit = (event) => {
        event.preventDefault();

        const credentials = {};

        credentials.Username = this.state.username;
        credentials.Password = this.state.pass;

        xhrRequest.post(['/api/Token',qs.stringify(credentials, { addQueryPrefix: true })].join(''))
            .then((responce) => {
                this.setState({authToken: responce.data});
                sessionStorage.setItem('Authorization', responce.data);
                window.location.href = '/employees';
            });
    };

    render() {
        return (
            <Row>
                <Header />
                <Col s={3}> </Col>
                <Col s={6}>
                    <form onSubmit={this.handleSubmit}>
                        <Input type="text" name="username" label="Username" s={12} value={this.state.value} onChange={this.handleChange} />
                        <Input type="password" name="pass" label="password" s={12} value={this.state.value} onChange={this.handleChange} />
                        <Button waves='light' >Log In</Button>
                    </form>
                </Col>
                <Col s={3}> </Col>
            </Row>
        );
    }
}

export default LoginPage;