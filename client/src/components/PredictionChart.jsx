import React, { Component } from 'react';
import { Row, Col } from 'react-materialize';
import { Chart } from 'react-google-charts';
import Moment from 'moment';

class PredictionChart extends Component {
    constructor(props) {
        super(props);
        this.state = {
            options: {
              
              hAxis: { title: 'Months' },
              vAxis: { title: 'Percent', minValue: 0 },
              legend: 'none',
            }
        };
    }

    render() {
        let today = new Date();
        Moment.locale('en');
        var data = [
            ['Months', 'Percent'],
            [Moment(today).format('MMM YY'),  0.73],
            [Moment(today).add(1, 'M').format('MMM YY'),  0.85],
            [Moment(today).add(2, 'M').format('MMM YY'),  0.98],
            [Moment(today).add(3, 'M').format('MMM YY'),  0.82]
        ];

        return (
            <Row >
            <Chart
                chartType="AreaChart"
                data={data}
                options={this.state.options}
                graph_id="ScatterChart"
                width="100%"
                height="400px"
                legend_toggle
            />
            </Row>
        );
    }
}

export default PredictionChart;