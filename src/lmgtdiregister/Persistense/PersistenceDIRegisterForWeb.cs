using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;

using lmgtpersistence.PostgreSql;
using lmgtpersistence;
using lmgtpersistence.Mapping;
using lmgtcommon;
namespace lmgtdiregister.Persistence
{
    public class PersistenceDIRegisterForWeb : IForWeb
    {
        public void Register(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            
            services.AddScoped<IDatabaseWrapper,DatabaseWrapper>();
            services.AddSingleton<IDatabaseFactoryProvider,PostgreSqlDatabaseFactoryProvider>();

            DomainMappingDIRegisterForWeb domainMappingDIRegister = new DomainMappingDIRegisterForWeb();
            domainMappingDIRegister.Register(services);

            SecurityMappingDIRegisterForWeb securityMappingDIRegister = new SecurityMappingDIRegisterForWeb();
            securityMappingDIRegister.Register(services);

            services.AddSingleton<PersistenceStartupForWeb,PersistenceStartupForWeb>();

            services.AddSingleton<List<IMapDto>>(s=>{
                return s.GetServices<IMapDto>().ToList();
            });
        }
    }
}