using Company.Delivery.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Delivery.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IWaybillService, WaybillService>();

            return services;
        }
    }
}
