
using Microsoft.Extensions.DependencyInjection;

using lmgtpersistence.Mapping;
using lmgtpersistence.Security.Mapping;
namespace lmgtdiregister.Persistence
{
    public class SecurityMappingDIRegisterForWeb : IForWeb
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton<IMapDto,PasswordDtosMapping>();
        }
    }
}