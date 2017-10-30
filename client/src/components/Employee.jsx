import React, { Component } from 'react';
import { Button, Row, Col, Table } from 'react-materialize';
import Header from './Header';
import employeesJSON from '../helpers/employeesJSON';


class Employee extends Component {

    render() {
        const user = employeesJSON[this.props.match.params.userId - 1];

        return (
            <Row>
              <Header />
              <Col s={1} />
              <Col s={10}>
                  <p>{user.Name}</p>
              </Col>
              <Col s={1} />
            </Row>
        );
    }
}

export default Employee;