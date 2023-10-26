using CinemaBooking.Domain;
using CinemaBooking.Domain.Movies;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Repository.Context
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: Constants.DatabaseName);
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
