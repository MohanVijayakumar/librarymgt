using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;

using lmgtdomain.Author.Converter;
using lmgtdomain.Author.Repository;
using lmgtdomain.Author.Validator;

using lmgtpersistence.Domain.Author;
namespace lmgtdiregister.Domain
{
    public class AuthorDIRegisterForWeb : IForWeb
    {
        public void Register(IServiceCollection services)
        {
            _Converter(services);
            _Repository(services);
            _Validator(services);
        }

        public void _Repository(IServiceCollection services)
        {
            services.AddTransient<IAuthorRepository,AuthorRepository>();
            services.AddTransient<IAuthorSettingsRepository,AuthorSettingsRepository>();
        }

        public void _Validator(IServiceCollection services)
        {
            services.AddTransient<IAuthorValidator,AuthorNameValidator>();

            services.AddTransient<List<IAuthorValidator>>(s=> {
                return s.GetServices<IAuthorValidator>().ToList();
            });
        }

        public void _Converter(IServiceCollection services)
        {
            services.AddTransient<ToAuthorDtoConverter,ToAuthorDtoConverter>();
        }
    }
}