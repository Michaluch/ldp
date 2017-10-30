import React, { Component } from 'react';
import { Row, Col, Table } from 'react-materialize';
import EmployeeRow from './EmployeeRow';

import employeesJSON from '../helpers/employeesJSON';


class EmployeesList extends Component {
    constructor(props) {
        super(props);
      
    }

    render() {

        return (
            <Row>
                <Col s={1} />
                <Col s={10}>
                    <Table hoverable={true} bordered={true} >
                        <thead>
                            <th data-field='employee'>Employee</th>
                            <th data-field='employee'>Possition</th>
                            <th data-field='dismissal'>Dismissal persent</th>
                        </thead>

                        <tbody>
                            {employeesJSON.map((item, index) =>
                                <EmployeeRow key={index + 1} item={item} />
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