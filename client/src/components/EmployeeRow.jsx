import React, { Component } from 'react';
import qs from 'qs';
import xhrRequest from '../helpers/xhrRequest';

class EmployeeRow extends Component {
    constructor(props) {
        super(props);
        this.state = {
            dismiss: this.dissmissalCalculator()
        }
        this.dissmissalCalculator = this.dissmissalCalculator.bind(this);
    }

    dissmissalCalculator() {
        xhrRequest.defaults.headers.common['Authorization'] = sessionStorage.getItem('Authorization');
        xhrRequest.defaults.headers.post['Acept'] = 'application/json';
        
        var user = this.props.item;
        xhrRequest.post(['/api/PredictionDismissal',qs.stringify(user, { addQueryPrefix: true })].join(''))
        .then((response) => {
            this.setState({dismiss: response.data.score});
        })

    }

    render() {
        return(
            <tr>
                <td>
                  <Link to={`/employees/${this.props.index + 1}`}>
                    {this.props.item.Name}
                  </Link>
                  </td>
                  <td>{this.props.item.Position}</td>
                <td>{this.state.dismiss}</td>
            </tr>
        );
    }
}

export default EmployeeRow;