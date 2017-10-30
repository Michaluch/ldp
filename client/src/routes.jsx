import React from 'react';
import {
  BrowserRouter as Router,
  Route,
  Redirect
} from 'react-router-dom'

import LoginPage from './components/LoginPage';
import EmployeesList from './components/EmployeesList';
import Employee from './components/Employee';


const PrivateRoute = ({ component: Component, ...rest }) => (
  <Route {...rest} render={props => (
    sessionStorage.getItem('Authorization') ? (
      <Component {...props}/>
    ) : (
      <Redirect to={{
        pathname: '/login',
        state: { from: props.location }
      }}/>
    )
  )}/>
);

const routes = (
  <Router>
    <div>
      <Route exact path='/' component={LoginPage} />
      <Route path='/login' component={LoginPage} />
      <Route path='/logout' render={() => {
        sessionStorage.removeItem('Authorization');
        window.location.href = '/';
      }} />

      <PrivateRoute exact path="/employees" component={EmployeesList}/>
      <PrivateRoute path="/employees/:userId" component={Employee}/>
    </div>
  </Router>
);

export default routes;