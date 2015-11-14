using System;
using System.Collections.Generic;
using System.Configuration;

namespace ReactSignalR.Configuration
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        private IEnumerable<string> _corsOrigins;

        private string _connectionString;

        private readonly string _connectionStringName;

        public ApplicationConfiguration(string connectionStringName = "leads")
        {
            _connectionStringName = connectionStringName;
        }

        public IEnumerable<string> CorsOrigins
        {
            get
            {
                if (_corsOrigins == null)
                {
                    var corsOrigins = ConfigurationManager.AppSettings["CorsOrigins"];

                    if (string.IsNullOrWhiteSpace(corsOrigins))
                    {
                        // Empty
                        _corsOrigins = new List<string>();
                    }
                    else
                    {
                        _corsOrigins = corsOrigins.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    }
                }

                return _corsOrigins;
            }
        }

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_connectionString))
                {
                    var connectionString = ConfigurationManager.ConnectionStrings[_connectionStringName];

                    if (connectionString == null)
                    {
                        throw new ConfigurationErrorsException(
                            $"'{_connectionStringName}' connectionString was not found");
                    }

                    _connectionString = connectionString.ConnectionString;
                }

                return _connectionString;
            }
        }
    }
}