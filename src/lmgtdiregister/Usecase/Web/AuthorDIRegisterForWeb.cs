using Microsoft.Extensions.DependencyInjection;

using lmgtusecase.Author;
namespace lmgtdiregister.Usecase
{
    public class AuthorDIRegisterForWeb : IForWeb
    {
        public void Register(IServiceCollection services)
        {
            services.AddTransient<AddNewAuthor,AddNewAuthor>();
            services.AddTransient<EditAuthor,EditAuthor>();
            services.AddTransient<DeleteAuthor,DeleteAuthor>();
        }
    }
}