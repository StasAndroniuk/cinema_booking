using CinemaBooking.Application.Movies;
using CinemaBooking.Domain;
using CinemaBooking.Infrustructure;
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
            services.AddScoped<IMovieService, MovieService>();
            TestServiceProvider = services.BuildServiceProvider();
        }
        protected IServiceProvider TestServiceProvider { get; }
    }
}
