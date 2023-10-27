using CinemaBooking.Domain.Movies;
using CinemaBooking.Infrustructure.Repositories;
using CinemaBooking.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaDbContext _cinemaDbContext;

        public MovieRepository(CinemaDbContext cinemaDbContext) 
        {
            _cinemaDbContext = cinemaDbContext;
        }

        public async Task CreateMovieAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            await _cinemaDbContext.AddAsync(movie, cancellationToken);
            await _cinemaDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteMovieAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            _cinemaDbContext.Movies.Remove(movie);
            await _cinemaDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Movie> GetMovieAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _cinemaDbContext.Movies.FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

        public async Task<IEnumerable<Movie>> GetMoviesAsync(CancellationToken cancellationToken = default) =>
            await _cinemaDbContext.Movies.ToListAsync(cancellationToken);

        public async Task<Movie> TryFindMovieByNameAsync(string name, CancellationToken cancellationToken = default) =>
            await _cinemaDbContext.Movies.FirstOrDefaultAsync(m => m.Name == name, cancellationToken);
 

        public async Task UpdateMovieAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            _cinemaDbContext.Update(movie);
            await _cinemaDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
