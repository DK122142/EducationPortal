using System.IO;
using Microsoft.Extensions.Configuration;

namespace EducationPortal.DAL.Infrastructure
{
    public static class Config
    {
        static private readonly IConfiguration configuration;

        /// <summary>
        /// In Debug mode
        /// File appsettings.json must be in EducationPortal\EducationPortal.Prompt\bin\Debug\net5.0
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
