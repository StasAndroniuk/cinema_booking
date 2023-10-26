using CinemaBooking.Repository.Context;
using Microsoft.EntityFrameworkCore;

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
            services.AddDbContext<CinemaDbContext>(options => options.UseInMemoryDatabase("CinemaDb"));
        }
    }
}
