"use strict";


import React, {Component} from 'react';

export default class Col extends Component {
  render() {
    var klassName = `col-${this.props.media || 'sm'}-${this.props.gridSize || "12"}`;

    return <div className={klassName}>{this.props.children}</div>;
  }
}

