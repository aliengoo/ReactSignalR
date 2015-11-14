import Q from 'q';
import {invoke as toastrActionInvoke} from '../actions/toastrAction';
import store from '../store/store';

//http://www.asp.net/signalr/overview/guide-to-the-api/hubs-api-guide-javascript-client

setTimeout(function(){
  const testHub = global.jQuery.connection.testHub;

  testHub.client.broadcastMessage = function(message) {

    console.log("message:" + message);
    store.dispatch(toastrActionInvoke({
      toastType: "info",
        title: "From someone",
        message: message
    }));
  };


}, 2);

export function send(message) {
  const defer = Q.defer();
  const testHub = global.jQuery.connection.testHub;
  testHub.server.send(message).done((response) => {
    defer.resolve(response);
  });

  return defer.promise;
}
