import React, { Component } from 'react';
import {Navbar, NavItem} from 'react-materialize';

class Header extends Component {
    render() {
        let navItem = (
          <NavItem href='/login'>Log In</NavItem>
        );

        if (sessionStorage.getItem('Authorization')) {
          navItem = (
            <NavItem href='/logout'>Log Out</NavItem>
          );
        }

        return(
            <Navbar brand='LDP: Dismissal Prediction' right className={'indigo darken-4'}>
              {navItem}
            </Navbar>
        );
    }
}

export default Header;