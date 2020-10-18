using Microsoft.Extensions.DependencyInjection;

using lmgtusecase.Publisher;
namespace lmgtdiregister.Usecase
{
    public class PublisherDIRegisterForWeb : IForWeb
    {
        public void Register(IServiceCollection services)
        {
            services.AddTransient<AddNewPublisher,AddNewPublisher>();
            services.AddTransient<EditPublisher,EditPublisher>();
            services.AddTransient<DeletePublisher,DeletePublisher>();            
        }
    }
}