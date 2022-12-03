using Microsoft.Extensions.DependencyInjection;

namespace Coree.Services
{
    public interface IHelloService
    {
        string SayHello();
    }

    public class HelloService : IHelloService
    {
        public string SayHello()
        {
            return "Hello, world!";
        }
    }

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection UseHelloService(this IServiceCollection services)
        {
            return services.AddScoped<IHelloService, HelloService>();
        }
    }
}