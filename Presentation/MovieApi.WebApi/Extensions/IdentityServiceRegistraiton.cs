using Microsoft.AspNetCore.Identity;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Identity;

namespace MovieApi.WebApi.Extensions
{
    public static class IdentityServiceRegistraiton
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MovieContext>()
            .AddDefaultTokenProviders();
            return services;
        }
    }
}
