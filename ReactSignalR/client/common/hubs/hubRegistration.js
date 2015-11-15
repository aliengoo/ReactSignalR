import {registerTestHub} from './testHub';

let connection;

export function registerAllHubs() {
  setTimeout(() => {

    registerTestHub(getConnection());

    getConnection().start().done(() => {
      console.log(`Now connected, connection ID=${connection.id}`);
    }).fail(function () {
      console.error("Could not connect");
    });

  }, 1);
}

export function getConnection() {

  if (!connection) {
    connection = global.jQuery.hubConnection();
  }

  return connection;
}

