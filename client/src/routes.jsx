import React from 'react';
import {  BrowserRouter as Router, Route } from 'react-router-dom';

import Layout from './components/Layout';

import LoginPage from './components/LoginPage';

const routes =  (
    <Router>
        <Route exact path='/' component={Layout} />
        <Route exact path='/login' component={LoginPage} />
    </Router>
)

export default routes;