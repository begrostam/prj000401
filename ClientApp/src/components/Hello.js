import React, { Component } from 'react';
export class Hello extends React.Component {
    render() {
        return (
          <React.Fragment>
            <nav className="navbar navbar-dark bg-dark mb-3">
              <a className="navbar-brand" href="#">
                <h1>Total Items <span className="badge badge-secondary">{this.props.totalItems}</span></h1>
              </a>
            </nav>
          </React.Fragment>
        );
      }
  }