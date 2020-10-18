using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace lmgtconfiguration
{
    public class ConfigurationStartupForWeb
    {
        public void Startup(IConfiguration configuration,IServiceCollection services)
        {
            DatabaseConfiguration dbConfig = configuration.GetSection(DatabaseConfiguration.Key).Get<DatabaseConfiguration>();
            LogInfraConfiguration logConfig = configuration.GetSection(LogInfraConfiguration.Key).Get<LogInfraConfiguration>();

            services.AddSingleton<DatabaseConfiguration>(s=> {
                return dbConfig;
            });
            services.AddSingleton<LogInfraConfiguration>(s=> {
                return logConfig;
            });
        }
    }
}