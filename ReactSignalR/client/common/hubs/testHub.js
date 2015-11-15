import {invoke as toastrActionInvoke} from '../actions/toastrAction';
import store from '../store/store';
import Q from 'q';

let testHubProxy;

export function registerTestHub(connection) {
  testHubProxy = connection.createHubProxy("testHub");
  testHubProxy.on('broadcastMessage', (message) => {
    store.dispatch(toastrActionInvoke({
      toastType: "info",
      title: "New message",
      message
    }));
  });
}

export function sendMessage(message) {
  const defer = Q.defer();
  testHubProxy.invoke('send', message).done((response) => {
    defer.resolve(response);
  });

  return defer.promise;
}



