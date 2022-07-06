using Microsoft.Extensions.DependencyInjection;

namespace Contracts
{
    public interface IModule
    {
        void Registry(IServiceCollection services);
    }
}