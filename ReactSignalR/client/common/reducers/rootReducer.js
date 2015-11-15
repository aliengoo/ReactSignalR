"use strict";

import {combineReducers} from 'redux';
import home from './../../home/reducers/home';
import customer from './../../customer/reducers/customer';


export default combineReducers({
  home,
  customer
});