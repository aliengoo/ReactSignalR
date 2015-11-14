import {invoke as toastrActionInvoke} from '../actions/toastrAction';
import store from '../store/store';
import Q from 'q';
import {createHub} from './connection';
// defer readiness
setTimeout(init, 1);

let testHubProxy;

export function getTestHub() {
  if (!testHubProxy) {
    testHubProxy = createHub('testHub');
  }

  return testHubProxy;
}

function init() {
  getTestHub().on('broadcastMessage', (message) => {
    console.log("message");
    store.dispatch(toastrActionInvoke({
      toastType: "info",
      title: "New message",
      message
    }));
  });
}


export function sendMessage(message) {
  const defer = Q.defer();
  getTestHub().invoke('send', message).done((response) => {
    console.log("done");
    defer.resolve(response);
  });

  return defer.promise;
}




