using MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers;
using MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers;

namespace MovieApi.WebApi.Extensions
{
    public static class MediatrServiceRegistration
    {
        public static IServiceCollection AddMediatrServices(this IServiceCollection services)
        {
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(GetTagQueryHandler).Assembly));
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(GetCastQueryHandler).Assembly));

            return services;
        }
    }
}
