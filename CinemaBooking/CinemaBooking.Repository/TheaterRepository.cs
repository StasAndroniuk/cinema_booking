using CinemaBooking.Domain.Theaters;
using CinemaBooking.Infrustructure.Repositories;
using CinemaBooking.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Repository
{
    public class TheaterRepository : ITheaterRepository
    {
        private readonly CinemaDbContext _dbContext;

        public TheaterRepository(CinemaDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task CreateTheaterAsync(Theater theater, CancellationToken cancellationToken = default)
        {
            await _dbContext.Theaters.AddAsync(theater, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteTheaterAsync(Theater theater, CancellationToken cancellationToken = default)
        {
            _dbContext.Theaters.Remove(theater);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Theater?> GetTheaterAsync(Guid theaterId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Theaters.FirstOrDefaultAsync(t => t.Id == theaterId, cancellationToken);
        }

        public async Task UpdateTheaterAsync(Theater theater, CancellationToken cancellationToken = default)
        {
            _dbContext.Theaters.Update(theater);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
