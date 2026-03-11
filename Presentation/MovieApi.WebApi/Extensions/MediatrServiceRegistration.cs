using MovieApi.Application;
using MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers;
using MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers;
using System.Reflection;

namespace MovieApi.WebApi.Extensions
{
    public static class MediatrServiceRegistration
    {
        public static IServiceCollection AddMediatrServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));

            //services.AddMediatR(cfg =>
            //    cfg.RegisterServicesFromAssembly(typeof(GetTagQueryHandler).Assembly));
            //services.AddMediatR(cfg =>
            //    cfg.RegisterServicesFromAssembly(typeof(GetCastQueryHandler).Assembly));

            return services;
        }
    }
}
