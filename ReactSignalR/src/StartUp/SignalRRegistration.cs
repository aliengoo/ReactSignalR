using Owin;

namespace ReactSignalR.StartUp
{
    public class SignalRRegistration
    {
        public static void Register(IAppBuilder appBuilder)
        {
            appBuilder.MapSignalR();
        }
    }
}