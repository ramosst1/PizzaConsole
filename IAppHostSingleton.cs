using Microsoft.Extensions.Configuration;

namespace PizzaConsole
{
    public interface IAppHostSingleton
    {
        IConfigurationRoot GetConfiguration();
    }
}