using Microsoft.Extensions.DependencyInjection;

using lmgtusecase.User;
namespace lmgtdiregister.Usecase
{
    public class UserDIRegisterForWeb : IForWeb
    {
        public void Register(IServiceCollection services)
        {
            services.AddTransient<AddNewUser,AddNewUser>();
            services.AddTransient<EditUser,EditUser>();
            services.AddTransient<DeleteUser,DeleteUser>();
            services.AddTransient<CredentialValidator,CredentialValidator>();
        }
    }
}