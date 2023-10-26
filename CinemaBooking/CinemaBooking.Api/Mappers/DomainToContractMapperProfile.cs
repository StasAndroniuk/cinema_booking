using AutoMapper;
using CinemaBooking.Domain.Movies;

namespace CinemaBooking.Api.Mappers
{
    public class DomainToContractMapperProfile : Profile
    {
        public DomainToContractMapperProfile()
        {
            CreateMap<Movie, Contract.Api.Models.Movie>();
        }
    }
}
