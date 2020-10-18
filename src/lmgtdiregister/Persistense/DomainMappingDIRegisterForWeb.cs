using Microsoft.Extensions.DependencyInjection;

using lmgtpersistence.Mapping;
using lmgtpersistence.Domain.Mapping;
namespace lmgtdiregister.Persistence
{
    public class DomainMappingDIRegisterForWeb : IForWeb
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton<DtoMappings,DtoMappings>();
            services.AddSingleton<IMapDto,AuthorDtosMapping>();
            services.AddSingleton<IMapDto,BookDtosMapping>();
            services.AddSingleton<IMapDto,PublisherDtosMapping>();
            services.AddSingleton<IMapDto,UserDtosMapping>();
        }
    }
}