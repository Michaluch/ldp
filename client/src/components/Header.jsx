import React, { Component } from 'react';
import {Navbar, NavItem} from 'react-materialize';

class Header extends Component {
    render() {
        return(
            <Navbar brand='LDP: Dismissal Prediction' right>
                <NavItem href='/'>Home</NavItem>
                <NavItem href='/login'>Log In</NavItem>
            </Navbar>
        );
    }
}

export default Header;