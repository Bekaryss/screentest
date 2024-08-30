using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Delivery.Database
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddApplicationDatabase(this IServiceCollection services)
        {
            services.AddDbContext<DeliveryDbContext>(options =>
            {
                options.UseInMemoryDatabase(Database.Name);
            });

            return services;
        }
    }
}
