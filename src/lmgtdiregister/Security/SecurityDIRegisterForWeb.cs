using Microsoft.Extensions.DependencyInjection;

using lmgtsecurity.Password.Repository;
using lmgtpersistence.Security;
using lmgtsecurity.Password;
namespace lmgtdiregister.Security
{
    public class SecurityDIRegisterForWeb : IForWeb
    {
        public void Register(IServiceCollection services)
        {
            services.AddTransient<IPasswordSettingsRepository,PasswordSettingsRepository>();
            services.AddTransient<PasswordValidator,PasswordValidator>();
            services.AddTransient<PasswordHasher,PasswordHasher>();
        }
    }
}