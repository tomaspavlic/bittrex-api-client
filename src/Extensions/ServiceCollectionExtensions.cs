using Microsoft.Extensions.DependencyInjection;

namespace Topdev.Bittrex.Client.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBittrexClient(this IServiceCollection services)
        {
            services.AddSingleton<IBittrexClient, BittrexClient>();
        }
    }
}