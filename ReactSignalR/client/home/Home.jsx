"use strict";

import React, {Component, PropTypes} from 'react';
import {connect} from 'react-redux';
import {invoke as messageOfTheDayActionInvoke} from './actions/messageOfTheDayAction';
import {invoke as getCurrentUserActionInvoke} from '../common/security/actions/getCurrentUserAction';
import {invoke as toastrActionInvoke} from '../common/actions/toastrAction';

import {sendMessage} from '../common/api/testHub';

export default class Home extends Component {

  componentDidMount() {
    this.props.dispatch(messageOfTheDayActionInvoke());
    this.props.dispatch(getCurrentUserActionInvoke());
  }

  render() {

    const {home} = this.props;

    return (

      <div className="container">
        <header>
          <h1>Home</h1>
        </header>

        <div className="col-lg-12">
          <p>{home.messageOfTheDay}</p>
          <button className="btn btn-primary btn-lg" type="button" onClick={() => {
              sendMessage("Poop!");
          }}>Send
          </button>
        </div>
      </div>
    );
  }
}

function select(state) {
  return {
    home: state.home
  };
}

export default connect(select)(Home);
