"use strict";

import React, {Component, PropTypes} from 'react';

export default class CurrentUser extends Component {
  render() {
    const {currentUser} = this.props;

    if (currentUser) {
      return (
        <div>
          <pre>{JSON.stringify(currentUser)}</pre>
        </div>
      );

    }

    return (<div>No current user</div>);
  }
}

CurrentUser.propTypes = {
  currentUser: PropTypes.object
};

