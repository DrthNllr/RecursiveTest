using Microsoft.Extensions.Configuration;

namespace RecursiveTest.Helpers
{
    public static class HelperConfiguration
    {
        public static AppConfiguration GetAppConfiguration(string configurationFile = "App.json")
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile(configurationFile, optional: false)
                .Build();
            var result = configuration.Get<AppConfiguration>();
            return result;
        }

    }
}