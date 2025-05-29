using Microsoft.Extensions.DependencyInjection;
using Sport.Models;
using Sport.Services.Interfaces;

namespace Sport.Services.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlobStorageService(this IServiceCollection services, string connectionString)
        {
            services.Configure<BlobStorageConnection>(options => options.ConnectionString = connectionString);
            services.AddScoped<IBlobStorageService, BlobStorageService>();

            return services;
        }
    }
}
