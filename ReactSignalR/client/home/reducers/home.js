"use strict";

import {
  context as messageOfTheDayContext,
  type as messageOfTheDayType
} from '../actions/messageOfTheDayAction';

import fetching from '../../common/reducers/fetching';
import err from '../../common/reducers/err';
import currentUser from '../../common/reducers/currentUser';

function messageOfTheDay(previousMessageOfTheDay = null, action) {
  if (action.type.endsWith(messageOfTheDayType)) {
    if (action.fetching) {
      return null;
    } else if (!!action.err) {
      return null;
    } else {
      return action.data.message;
    }
  }

  return previousMessageOfTheDay;
}

export default function home(homeState = {}, action) {
  let newHomeState = homeState;

  if (action.type.startsWith(messageOfTheDayContext)) {
    newHomeState = Object.assign({}, homeState, {
      currentUser: currentUser(homeState.currentUser, action),
      fetching: fetching(homeState.fetching, action),
      err: err(homeState.err, action),
      messageOfTheDay: messageOfTheDay(homeState.messageOfTheDay, action)
    });
  }

  return newHomeState;
}

