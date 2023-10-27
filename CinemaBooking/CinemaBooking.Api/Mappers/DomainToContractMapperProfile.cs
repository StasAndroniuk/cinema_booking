using AutoMapper;
using CinemaBooking.Domain.Movies;
using CinemaBooking.Domain.Theaters;

namespace CinemaBooking.Api.Mappers
{
    public class DomainToContractMapperProfile : Profile
    {
        public DomainToContractMapperProfile()
        {
            CreateMap<Movie, Contract.Api.Models.Movie>();
            CreateMap<Theater, Contract.Api.Models.Theater>();
        }
    }
}
