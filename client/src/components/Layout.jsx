import React, { Component } from 'react';
import { Row } from 'react-materialize';

import Header from './Header';
import LoginPage from './LoginPage';
import EmployeesList from './EmployeesList';

class Layout extends Component {
    constructor(props) {
        super(props);
        this.state = {
            authToken: ''
        }

        this.updateState = this.updateState.bind(this);
    }

    updateState(event) {
        this.setState({
            authToken: event.target.authToken
        });
        console.log('authToken');
    }

    render () {
        return (
            <Row>
                <Header />
                
                <LoginPage />
                <EmployeesList />
                
                {this.props.children}
            </Row>
        );
    }
}

export default Layout;