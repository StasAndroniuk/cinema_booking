using CinemaBooking.Domain.Sessions;
using CinemaBooking.Infrustructure.Repositories;
using CinemaBooking.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Repository
{
    public class ScheduledSessionRepository : IScheduledSessionRepository
    {
        private readonly CinemaDbContext _context;

        public ScheduledSessionRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<ScheduledSession?> TryGetScheduledSessionAsync(Guid theaterId, CancellationToken cancellationToken = default)
        {
            return await _context.ScheduledSessions.FirstOrDefaultAsync(s => s.Theater.Id == theaterId && s.EndDate > DateTime.Now, cancellationToken);
        }
    }
}
