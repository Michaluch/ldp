import React, { Component } from 'react';
import { Row, Col, Table } from 'react-materialize';

import Header from './Header';
import PredictionChart from './PredictionChart';
import employeesJSON from '../helpers/employeesJSON';


class Employee extends Component {

    render() {
        const user = employeesJSON[this.props.match.params.userId - 1];

        return (
            <Row>
                <Row>
                    <Header />
                </Row>
                <Row>
                    <Col s={4} className="card-content valign center">
                        <div>
                            <img src={'https://pbs.twimg.com/profile_images/3031901161/8ba4bbc3b2dd8269f06b446a8d8d10b8.jpeg'} className={'circle'}/>
                        </div>
                    </Col>
                    <Col s={8}>
                        <h4>{user.Name}</h4>
                        <h6>{user.Position}</h6>
                    </Col>
                </Row>
                <Row>
                    <Col s={1} />
                    <Col s={5} className="card-content valign center">
                        <Table >
                        <h5>Criteria</h5>
                            <tbody>
                                <tr>
                                    <td>CompanyWorkingMonths:</td>
                                    <td>{user.CompanyWorkingMonths}</td>
                                </tr>
                                <tr>
                                    <td>CompetenceGroup: </td>
                                    <td>{user.CompetenceGroup}</td>
                                </tr>
                            </tbody>
                        </Table>
                    </Col>
                    <Col s={6} className="card-content valign center">
                        <h5>Dismissal Prediction Percentage</h5>
                        <PredictionChart />
                    </Col>
                </Row>
                <Row>
                    
                </Row>
            </Row>
        );
    }
}

export default Employee;
