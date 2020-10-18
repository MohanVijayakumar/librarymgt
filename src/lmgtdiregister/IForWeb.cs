using Microsoft.Extensions.DependencyInjection;
namespace lmgtdiregister
{
    public interface IForWeb
    {
        void Register(IServiceCollection services);
    }
}