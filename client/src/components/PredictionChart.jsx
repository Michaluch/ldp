import React, { Component } from 'react';
import { Row } from 'react-materialize';

import {AreaChart, Area, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer} from 'recharts';

class PredictionChart extends Component {
    render() {
        return (
            <Row>
                <ResponsiveContainer width='100%' height={400}>
                <AreaChart data={this.props.item}>
                    <XAxis dataKey="month"/>
                    <YAxis/>
                    <CartesianGrid strokeDasharray="3 3"/>
                    <Tooltip/>
                    <Area type='monotone' dataKey='score' stroke='#283593' fill='#283593' />
                </AreaChart>
                </ResponsiveContainer>
            </Row>
        );
    }
}

export default PredictionChart;
