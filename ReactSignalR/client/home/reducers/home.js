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

export default function home(previousHome = null, action) {
  if (action.context === messageOfTheDayContext) {

    const updates = Immutable.Map({
      currentUser: currentUser(previousHome.currentUser, action),
      fetching: fetching(previousHome.fetching, action),
      err: err(previousHome.err, action),
      messageOfTheDay: messageOfTheDay(previousHome.messageOfTheDay, action)
    });

    return previousHome.merge(updates);
  }

  return previousHome;
}

