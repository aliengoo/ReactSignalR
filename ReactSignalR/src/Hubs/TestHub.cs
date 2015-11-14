using Microsoft.AspNet.SignalR;

namespace ReactSignalR.Hubs
{
    public class TestHub : Hub
    {
        public void Send(string message)
        {
            Clients.Others.broadcastMessage(message);
        }
        
    }
}