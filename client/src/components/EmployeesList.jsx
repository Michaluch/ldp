import React, { Component } from 'react';
import { Button, Row, Col, Table } from 'react-materialize';
import EmployeeRow from './EmployeeRow';
import Header from './Header';
import employeesJSON from '../helpers/employeesJSON';


class EmployeesList extends Component {
    render() {

        return (
            <Row>
                <Header />
                <Col s={1} />
                <Col s={10}>
                    <Table hoverable={true}>
                        <thead>
                            <th data-field='employee'>Employee</th>
                            <th data-field='dismissal'>Dismissal persent</th>
                        </thead>

                        <tbody>
                            {employeesJSON.map((item, index) =>
                                <EmployeeRow key={index + 1} index={index} item={item} />
                            )}
                        </tbody>
                    </Table>
                </Col>
                <Col s={1} />
            </Row>
        );
    }
}

export default EmployeesList;