"use strict";

import Q from 'q';
import superagent from 'superagent';
import _ from 'lodash';

let agent = function agent(method, url, query, data){
  const defer = Q.defer();

  let request = superagent(method, url);

  if (query) {
    request.query(query);
  }

  if (data) {
    request.send(data);
  }

  request.end((err, response) => defer.resolve({
    err: err,
    data: response.body
  }));

  return defer.promise;
};

export function invokeGetAsync(url, query, actionType) {
  return invokeAsync("GET", url, query, null, actionType);
}

export function invokePostAsync(url, query, data, actionType) {
  return invokeAsync("POST", url, query, data, actionType);
}

export function invokeDeleteAsync(url, query, actionType) {
  return invokeAsync("DELETE", url, query, actionType);
}

export function invokePutAsync(url, query, data, actionType) {
  return invokeAsync("PUT", url, query, data, actionType);
}

export function invokeAsync(method, url, query, data, actionType, actionContext) {
  return (dispatch) => {
    // fetching started
    dispatch({
      context: actionContext,
      type: actionType,
      data,
      fetching: true
    });

    const defer = Q.defer();

    agent(method, url, query, data).then((response) => {
      dispatch({
        context: actionContext,
        type: actionType,
        err: response.err,
        data: response.data,
        fetching: false
      });
    }, (response) => {
      dispatch({
        context: actionContext,
        type: actionType,
        fetching: false,
        err: response.err
      });
    }).finally(() => {
      defer.resolve();
    });

    return defer.promise;
  };
}