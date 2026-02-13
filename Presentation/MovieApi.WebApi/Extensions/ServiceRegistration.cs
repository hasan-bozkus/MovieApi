using Microsoft.AspNetCore.Identity;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers;
using MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers;
using MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Identity;

namespace MovieApi.WebApi.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHanler>();

            services.AddScoped<GetMovieQueryHandler>();
            services.AddScoped<GetMovieByIdQueryHandler>();
            services.AddScoped<CreateMovieCommandHandler>();
            services.AddScoped<UpdateMovieCommandHandler>();
            services.AddScoped<RemoveMovieCommandHandler>();

            services.AddScoped<GetSeriesQueryHandler>();
            services.AddScoped<GetSeriesByIdQueryHandler>();
            services.AddScoped<CreateSeriesCommandHandler>();
            services.AddScoped<UpdateSeriesCommandHandler>();
            services.AddScoped<RemoveSeriesCommandHandler>();

            // Add services to the container.
            services.AddScoped<CreateUserRegisterCommandHandler>();
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MovieContext>()
                .AddDefaultTokenProviders();

            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(GetTagQueryHandler).Assembly));
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(GetCastQueryHandler).Assembly));

            services.AddScoped<MovieContext>();

            return services;
        }
    }
}
