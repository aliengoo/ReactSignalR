"use strict";

import {invokeAsync} from '../../common/api/restApi';

const context = "home";
const type = "messageOfTheDayAction";

export {
  context,
  type
};

export function invoke() {
  return invokeAsync("GET", "/api/message-of-the-day", null, null, type, context);
}