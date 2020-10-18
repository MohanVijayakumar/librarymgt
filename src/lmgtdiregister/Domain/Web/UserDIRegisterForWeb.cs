using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;

using lmgtdomain.User.Repository;
using lmgtdomain.User.Converter;
using lmgtdomain.User.Validator;
using lmgtpersistence.Domain.User;
namespace lmgtdiregister.Domain
{
    public class UserDIRegisterForWeb : IForWeb
    {
        public void Register(IServiceCollection services)
        {
            _Repository(services);
            _Converter(services);
            _Validator(services);
        }

        private void _Repository(IServiceCollection services)
        {
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddTransient<IUserRoleRepository,UserRoleRepository>();
            services.AddTransient<IUserSettingsRepository,UserSettingsRepository>();
            services.AddTransient<IUserOutputModelRepository,UserOutputModelRepository>();
        }

        private void _Validator(IServiceCollection services)
        {
            services.AddTransient<IEditUserValidator,EditUserNameValidator>();
            services.AddTransient<IEditUserValidator,EditUserRoleValidator>();
            
            services.AddTransient<List<IEditUserValidator>>(s=> {
                return s.GetServices<IEditUserValidator>().ToList();
            });

            services.AddTransient<IUserValidator,UserNameValidator>();
            services.AddTransient<IUserValidator,UserRoleValidator>();

            services.AddTransient<UserNameValidator,UserNameValidator>();
            services.AddTransient<UserRoleValidator,UserRoleValidator>();

            services.AddTransient<List<IUserValidator>>(s=> {
                return s.GetServices<IUserValidator>().ToList();
            });
        }

        private void _Converter(IServiceCollection services)
        {
            services.AddTransient<ToUserDtoConverter,ToUserDtoConverter>();
        }
    }
}