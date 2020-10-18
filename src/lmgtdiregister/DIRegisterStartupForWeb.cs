using Microsoft.Extensions.DependencyInjection;

using lmgtdiregister.Domain;
using lmgtdiregister.Persistence;
using lmgtdiregister.Security;
using lmgtdiregister.Usecase;
namespace lmgtdiregister
{
    public class DIRegisterStartupForWeb : IForWeb
    {
        public void Register(IServiceCollection services)
        {
            DomainDIRegisterForWeb domainDIRegister = new DomainDIRegisterForWeb();
            domainDIRegister.Register(services);

            PersistenceDIRegisterForWeb persistenceDIRegister = new PersistenceDIRegisterForWeb();
            persistenceDIRegister.Register(services);

            SecurityDIRegisterForWeb securityDIRegister = new SecurityDIRegisterForWeb();
            securityDIRegister.Register(services);
            
            UsecaseDIRegisterForWeb usecaseDIRegister = new UsecaseDIRegisterForWeb();
            usecaseDIRegister.Register(services);
            
            
        }
    }
}