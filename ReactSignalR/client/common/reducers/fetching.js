"use strict";

export default function fetching(previousFetching = false, action) {
  return !!action.fetching;
}

