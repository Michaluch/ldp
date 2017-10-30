import React, { Component } from 'react';
import qs from 'qs';
import { Row, Col, Button, Input } from 'react-materialize';
import xhrRequest from '../helpers/xhrRequest';

class LoginPage extends Component {
    constructor(props) {
        super(props);
        this.state = {username: "",
                      pass: "",
                      authToken: "" 
        };
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(event) {
        const target = event.target;
        const name = target.name;

        this.setState(
            {
                [name]: target.value
            }
        );
    }

    handleSubmit(event) {
        event.preventDefault();

        const credentials = {};

        credentials.Username = this.state.username;
        credentials.Password = this.state.pass;

        xhrRequest.post(['/api/Token',qs.stringify(credentials, { addQueryPrefix: true })].join(''))
            .then((responce) => {
                this.setState({authToken: responce.data});
                sessionStorage.setItem('Authorization', responce.data);
            });
    }

    render() {
        return (
            <Row>
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