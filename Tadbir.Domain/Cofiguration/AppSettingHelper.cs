using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Tadbir.Domain.Cofiguration
{
    public static class AppSettingHelper
    {
        public static IConfigurationRoot GetConfigurationFromJson( string baseName= "appsettings", string environmentName="")
        {
            string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                var configuration = new ConfigurationBuilder()
                        .SetBasePath(basePath)
                        .AddJsonFile($"{baseName}.json")
                        .AddJsonFile($"{baseName}.{environmentName}.json", optional: true)
                        .Build();

                return configuration;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occurred while creating configuration", ex);
            }
        }
    }
}
