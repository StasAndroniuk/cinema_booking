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

        public async Task CreateSessionAsync(ScheduledSession session, CancellationToken cancellationToken = default)
        {
            await _context.ScheduledSessions.AddAsync(session, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteSchedulledSession(ScheduledSession session, CancellationToken cancellationToken = default)
        {
            _context.ScheduledSessions.Remove(session);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<ScheduledSession?> GetScheduledSessionAsync(Guid sessionId, CancellationToken cancellationToken = default)
        {
            return await _context.ScheduledSessions
                .Include(s => s.Movie)
                .Include(s => s.Theater)
                .Include(s => s.OrderedSits)
                .FirstOrDefaultAsync(s => s.Id == sessionId, cancellationToken);
        }

        public async Task<ScheduledSession?> TryFindSchedulledSessionAsync(Guid movieId, Guid theaterId, DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            return await _context.ScheduledSessions.FirstOrDefaultAsync(s =>
                s.Movie.Id == movieId &&
                s.Theater.Id == theaterId &&
                (
                    (s.StartDate <= startDate && s.EndDate >= startDate) ||
                    (s.StartDate <= endDate && s.EndDate >= endDate)
                ),
                cancellationToken
            );
        }

        public async Task<ScheduledSession?> TryGetScheduledSessionAsync(Guid theaterId, CancellationToken cancellationToken = default)
        {
            return await _context.ScheduledSessions.FirstOrDefaultAsync(s => s.Theater.Id == theaterId && s.EndDate > DateTime.Now, cancellationToken);
        }
    }
}
