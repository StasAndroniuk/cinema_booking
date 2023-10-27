using CinemaBooking.Domain;
using CinemaBooking.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CinemaBooking.Api.Mappers;
using CinemaBooking.Repository;
using CinemaBooking.Infrustructure.Services;
using CinemaBooking.Application.Movies;
using CinemaBooking.Infrustructure.Repositories;
using CinemaBooking.Application.Theaters;
using System.ComponentModel.Design;
using CinemaBooking.Application.Sessions;

namespace CinemaBooking.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
        }

        public static void ConfigureDbContext(this IServiceCollection services)
        {
            services.AddDbContext<CinemaDbContext>(options => options.UseInMemoryDatabase(Constants.DatabaseName));
        }

        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ITheaterRepository, TheaterRepository>();
            services.AddScoped<IScheduledSessionRepository, ScheduledSessionRepository>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ITheaterService, TheaterService>();
            services.AddScoped<IScheduledSessionService, ScheduledSessionService>();
            services.AddScoped<IReservationService, ReservationService>();
        }

        public static void ConfigureMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(
                mapperConfigurationExpression =>
                {
                    mapperConfigurationExpression.AddProfile<DomainToContractMapperProfile>();
                    mapperConfigurationExpression.AddProfile<ContractToDomainProfile>();
                },
                Array.Empty<Assembly>());
        }
    }
}
