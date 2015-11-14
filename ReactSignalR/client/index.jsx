"use strict";

global.jQuery = require('jquery');
global.$ = global.jQuery;
require('bootstrap');
require('signalr');

import React from 'react';
import ReactDOM from 'react-dom';
import {Router, Route, Link} from 'react-router';
import history from 'history/lib/createHashHistory';

import { Provider } from 'react-redux';
import { DevTools, DebugPanel, LogMonitor } from 'redux-devtools/lib/react';
import Home from './home/Home.jsx';
import store from './common/store/store';
import {start} from './common/api/connection';

var reactContainer = document.getElementById('react-container');
// TODO : shouldn't have to do this
setTimeout(() => {

  start();

}, 1111);

var providerRoot = <Provider store={store}>
  <Router history={history()}>
    <Route path="/" component={Home}/>
  </Router>
</Provider>;

if (reactContainer.hasAttribute("debug")) {
  ReactDOM.render(
    <div>
      {providerRoot}
      <DebugPanel top right bottom>
        <DevTools store={store} monitor={LogMonitor}/>
      </DebugPanel>
    </div>
    , reactContainer);
} else {
  ReactDOM.render(
    <div>
      {providerRoot}
    </div>
    , reactContainer);
}
