using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;

using lmgtdomain.Publisher.Converter;
using lmgtdomain.Publisher.Repository;
using lmgtdomain.Publisher.Validator;
using lmgtpersistence.Domain.Publisher;
namespace lmgtdiregister.Domain
{
    public class PublisherDIRegisterForWeb : IForWeb
    {
        public void Register(IServiceCollection services)
        {
            _Converter(services);
            _Repository(services);
            _Validator(services);
        }

        private void _Repository(IServiceCollection services)
        {
            services.AddTransient<IPublisherRepository,PublisherRepository>();
            services.AddTransient<IPublishSettingsRepository,PublisherSettingsRepository>();
        }

        private void _Validator(IServiceCollection services)
        {
            services.AddTransient<IPublisherValidator,PublisherNameValidator>();

            services.AddTransient<List<IPublisherValidator>>(s=> {
                return s.GetServices<IPublisherValidator>().ToList();
            });
        }

        private void _Converter(IServiceCollection services)
        {
            services.AddTransient<ToPublisherDtoConverter,ToPublisherDtoConverter>();
        }
    }
}