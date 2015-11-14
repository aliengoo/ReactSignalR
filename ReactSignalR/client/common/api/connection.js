let connection;

export function getConnection() {

  if (!connection) {
    connection = global.jQuery.hubConnection();
  }

  return connection;
}

export function createHub(hubName) {
  return getConnection().createHubProxy(hubName);
};

export function start() {
  getConnection().start().done(() => {
    console.log(`Now connected, connection ID=${connection.id}`);
  }).fail(function () {
    console.log("Could not connect");
  });
}
