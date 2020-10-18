using Microsoft.Extensions.DependencyInjection;

namespace lmgtdiregister.Usecase
{
    public class UsecaseDIRegisterForWeb : IForWeb
    {
        public void Register(IServiceCollection services)
        {
            AuthorDIRegisterForWeb authorDIRegister = new AuthorDIRegisterForWeb();
            BookDIRegisterForWeb bookDIRegister = new BookDIRegisterForWeb();
            PublisherDIRegisterForWeb publisherDIRegister = new PublisherDIRegisterForWeb();
            UserDIRegisterForWeb userDIRegister = new UserDIRegisterForWeb();

            authorDIRegister.Register(services);
            bookDIRegister.Register(services);
            publisherDIRegister.Register(services);
            userDIRegister.Register(services);
        }
    }
}