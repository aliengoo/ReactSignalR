"use strict";

import Immutable from 'immutable';

const home = Immutable.Map({
  currentUser: null,
  fetching: false,
  messageOfTheDay: "",
  err: null
});

const customer = Immutable.Map({
  fetching: false,
  err: null
});

export default {
  home,
  customer
};
