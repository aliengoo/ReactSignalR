const context = "customer";

import _ from 'lodash';
import Immutable from 'immutable';

import {
  type as setCustomerPropertyActionType} from '../actions/setCustomerPropertyAction';

import {type as setValidityPropertyActionType} from '../actions/setValidityPropertyAction';

const formStateInitialState = Immutable.Map({});
const customerInitialState = Immutable.Map({});

function formState(previousFormState = formStateInitialState, action) {


  // pick out properties
  let $error = _.pick(action.data.validity, (val, property) => !!val && property !== "valid");

  if (Object.keys($error).length > 0) {
    return previousFormState.set(action.data.elementName, {$error});
  }

  return previousFormState.delete(action.data.elementName);
}

export default function customer(previousCustomerState = customerInitialState, action) {
  if (action.context === context) {
    switch (action.type) {
      case setCustomerPropertyActionType:
        return previousCustomerState.merge(Immutable.Map(action.data));
        break;
      case setValidityPropertyActionType:
        return previousCustomerState.set('$formState', formState(previousCustomerState.$formState, action));
        break;
    }
  }

  return previousCustomerState;
};
