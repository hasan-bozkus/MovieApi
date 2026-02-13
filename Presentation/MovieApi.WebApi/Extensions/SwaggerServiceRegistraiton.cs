using Microsoft.OpenApi.Models;

namespace MovieApi.WebApi.Extensions
{
    public static class SwaggerServiceRegistraiton
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieApi.WebApi", Version = "v1" });
            });
            return services;
        }
    }
}
