import React, { Component } from 'react';
import {Navbar, NavItem} from 'react-materialize';

class Header extends Component {
    render() {
        return(
            <Navbar brand='LDP: Dismissal Prediction' right className={'indigo darken-4'}>
              {navItem}
            </Navbar>
        );
    }
}

export default Header;