using Microsoft.Extensions.DependencyInjection;

using lmgtusecase.Book;
namespace lmgtdiregister.Usecase
{
    public class BookDIRegisterForWeb : IForWeb
    {
        public void Register(IServiceCollection services)
        {
            services.AddTransient<AddNewBook,AddNewBook>();
            services.AddTransient<EditBook,EditBook>();
            services.AddTransient<DeleteBook,DeleteBook>();
            services.AddTransient<LendBook,LendBook>();
            services.AddTransient<CoverImagePathGenerator,CoverImagePathGenerator>();
        }
    }
}