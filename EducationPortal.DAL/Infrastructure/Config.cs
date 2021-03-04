using System.IO;
using Microsoft.Extensions.Configuration;

namespace EducationPortal.DAL.Infrastructure
{
    public static class Config
    {
        private static readonly IConfiguration configuration;

        /// <summary>
        /// Configure file appsettings.json in PL app
        /// </summary>
        static Config()
        {
            configuration = new ConfigurationBuilder()
                // .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static string GetConnectionString(string connectionName)
        {
            return configuration.GetConnectionString(connectionName);
        }
    }
}
