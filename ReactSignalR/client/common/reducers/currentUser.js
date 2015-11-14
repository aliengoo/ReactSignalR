import {type as getCurrentUserActionType} from '../security/actions/getCurrentUserAction';

export default function currentUser(currentUser = null, action) {

  let newCurrentUser = currentUser;

  if (action.type === getCurrentUserActionType) {
    if (action.fetching) {
      newCurrentUser = null;
    } else if (action.err) {
      newCurrentUser = null;
    } else {
      newCurrentUser = Object.assign({}, action.data);
    }
  }

  return newCurrentUser;
};
