using AutoMapper;
using CinemaBooking.Contract.Api.Requests;
using CinemaBooking.Contract.Api.Requests.Sessions;
using CinemaBooking.Contract.Api.Requests.Theaters;
using CinemaBooking.Domain.Movies;
using CinemaBooking.Domain.Movies.Dtos;
using CinemaBooking.Domain.Sessions.Dtos;
using CinemaBooking.Domain.Theaters.Dtos;

namespace CinemaBooking.Api.Mappers
{
    public class ContractToDomainProfile : Profile
    {
        public ContractToDomainProfile()
        {
            CreateMap<CreateMovieRequest, MovieCreationDetails>()
                .ForMember(x => x.Genre, opt => opt.MapFrom(x => Enum.Parse<MovieGenre>(x.Genre)));

            CreateMap<UpdateMovieRequest, MovieUpdateDetails>()
                .ForMember(x => x.Genre, opt => opt.MapFrom(x => Enum.Parse<MovieGenre>(x.Genre)));

            CreateMap<CreateTheaterRequest, TheaterCreationDetails>();
            CreateMap<UpdateTheaterRequest, TheaterUpdateDetails>();
            CreateMap<CreateScheduledSessionRequest, SessionCreationDetails>();
        }
    }
}
