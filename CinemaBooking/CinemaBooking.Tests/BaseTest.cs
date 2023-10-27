using CinemaBooking.Application.Movies;
using CinemaBooking.Application.Theaters;
using CinemaBooking.Domain;
using CinemaBooking.Infrustructure.Repositories;
using CinemaBooking.Infrustructure.Services;
using CinemaBooking.Repository;
using CinemaBooking.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;

namespace CinemaBooking.Tests
{
    internal class BaseTest
    {
        protected BaseTest()
        {
            var services = new ServiceCollection();
            
            services.AddDbContext<CinemaDbContext>(options => options.UseInMemoryDatabase(Constants.DatabaseName));
            services.AddScoped<IServiceContainer, ServiceContainer>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ITheaterRepository, TheaterRepository>();
            services.AddScoped<IScheduledSessionRepository, ScheduledSessionRepository>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ITheaterService, TheaterService>();

            TestServiceProvider = services.BuildServiceProvider();
        }
        protected IServiceProvider TestServiceProvider { get; }
    }
}
