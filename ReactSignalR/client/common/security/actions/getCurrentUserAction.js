"use strict";

import {invokeGetAsync} from '../../api/restApi';

const type = "getCurrentUserAction";

export {
  type
};

export function invoke() {
  return invokeGetAsync("/api/current-user", null, type);
}


