using System.Collections.Generic;

namespace ReactSignalR.Configuration
{
    public interface IApplicationConfiguration
    {
        IEnumerable<string> CorsOrigins { get; }

        string ConnectionString { get; }
    }
}