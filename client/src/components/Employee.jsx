import React, { Component } from 'react';
import { Row, Col, Table } from 'react-materialize';

import Header from './Header';
import PredictionChart from './PredictionChart';
import employeesJSON from '../helpers/employeesJSON';

import qs from 'qs';
import Moment from 'moment';

import xhrRequest from '../helpers/xhrRequest';


class Employee extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data : this.getPredictionScores()
        };
        this.getPredictionScores = this.getPredictionScores.bind(this)
    }

    getPredictionScores(event) {
        var user = employeesJSON[this.props.match.params.userId - 1];
        user.Months = 3;

        xhrRequest.defaults.headers.common['Authorization'] = sessionStorage.getItem('Authorization');
        xhrRequest.defaults.headers.post['Acept'] = 'application/json';
        
        xhrRequest.post(['/api/PredictionDismissal/List',qs.stringify(user, { addQueryPrefix: true })].join(''))
        .then((response) => {

            let today = new Date();
            Moment.locale('en');

            this.setState( { data :
            [
                {month: Moment(today).format('MMM YY'), score: response.data['0'].score},
                {month: Moment(today).add(1, 'M').format('MMM YY'), score: response.data['1'].score},
                {month: Moment(today).add(2, 'M').format('MMM YY'), score: response.data['2'].score},
                {month: Moment(today).add(3, 'M').format('MMM YY'), score: response.data['3'].score}
            ]});

            console.log(this.state.data)

        })
        
    }

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
                        <h6>{user.Position.split(/(?=[A-Z])/).join(' ')}</h6>
                    </Col>
                </Row>
                <Row>
                    <Col s={1} />
                    <Col s={3} className="card-content valign center">
                        <Table >
                        <h5>Criteria</h5>
                            <tbody>
                                <tr>
                                    <td><b>Location:</b></td>
                                    <td>{user.Location}</td>
                                </tr>
                                <tr>
                                    <td><b>Competence Group:</b></td>
                                    <td>{user.CompetenceGroup}</td>
                                </tr>
                                <tr>
                                    <td><b>Company Working Months:</b></td>
                                    <td>{user.CompanyWorkingMonths}</td>
                                </tr>
                                <tr>
                                    <td><b>Months In Current Role:</b></td>
                                    <td>{user.MonthsInCurrentRole}</td>
                                </tr>
                                <tr>
                                    <td><b>Months With Current Manager:</b></td>
                                    <td>{user.MonthsWithCurrentManager}</td>
                                </tr>
                                <tr>
                                    <td><b>Project Count:</b></td>
                                    <td>{user.ProjectCount}</td>
                                </tr>
                                <tr>
                                    <td><b>Months After Last Promotion:</b></td>
                                    <td>{user.MonthsAfterLastPromotion}</td>
                                </tr>
                                <tr>
                                    <td><b>Months After Last Performance Appraisal:</b></td>
                                    <td>{user.MonthsAfterLastPerformanceAppraisal}</td>
                                </tr>
                                <tr>
                                    <td><b>Last Performance Appraisal Score:</b></td>
                                    <td>{user.LastPerformanceAppraisalScore}</td>
                                </tr>
                                <tr>
                                    <td><b>Previous Performance Appraisal Score:</b></td>
                                    <td>{user.PreviousPerformanceAppraisalScore}</td>
                                </tr>
                                <tr>
                                    <td><b>Months After Last Salary Review:</b></td>
                                    <td>{user.MonthsAfterLastSalaryReview}</td>
                                </tr>
                                <tr>
                                    <td><b>Last Sarary Review Percentage:</b></td>
                                    <td>{user.LastSalaryReviewPercentage}</td>
                                </tr>
                            </tbody>
                        </Table>
                    </Col>
                    <Col s={1} />
                    <Col s={6} className="card-content valign center">
                        <h5>Dismissal Prediction Percentage</h5>
                        <PredictionChart item={this.state.data} />
                    </Col>
                    <Col s={1} />
                </Row>
                <Row>
                    
                </Row>
            </Row>
        );
    }
}

export default Employee;
