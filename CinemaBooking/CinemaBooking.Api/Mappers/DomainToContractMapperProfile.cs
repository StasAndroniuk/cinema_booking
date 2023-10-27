using AutoMapper;
using CinemaBooking.Domain.Movies;
using CinemaBooking.Domain.Sessions;
using CinemaBooking.Domain.Theaters;

namespace CinemaBooking.Api.Mappers
{
    public class DomainToContractMapperProfile : Profile
    {
        public DomainToContractMapperProfile()
        {
            CreateMap<Movie, Contract.Api.Models.Movie>();
            CreateMap<Theater, Contract.Api.Models.Theater>();
            CreateMap<OrderedSit,  Contract.Api.Models.OrderedSit>();
            CreateMap<ScheduledSession, Contract.Api.Models.ScheduleSession>()
                .ForMember(x => x.Movie, opt => opt.MapFrom(x => x.Movie))
                .ForMember(x => x.Theater, opt => opt.MapFrom(x => x.Theater));
        }
    }
}
