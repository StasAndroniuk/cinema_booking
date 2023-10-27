using CinemaBooking.Domain;
using CinemaBooking.Domain.Movies;
using CinemaBooking.Domain.Sessions;
using CinemaBooking.Domain.Theaters;
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

        public DbSet<Theater> Theaters { get; set; }

        public DbSet<ScheduledSession> ScheduledSessions { get; set; }

        public DbSet<OrderedSit> OrderedSits { get; set; }
    }
}
