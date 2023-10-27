using CinemaBooking.Domain.Exceptions;
using CinemaBooking.Domain.Movies.Dtos;
using CinemaBooking.Domain.Sessions.Dtos;
using CinemaBooking.Domain.Theaters.Dtos;
using CinemaBooking.Infrustructure.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBooking.Tests.ApplicationTests
{
    internal class ReservationServiceTests : BaseTest
    {
        [Test]
        public async Task ReserveSitInSessionAsync_UseCorrectArgs_SitReserved()
        {
            var service = TestServiceProvider.GetService<IScheduledSessionService>()!;
            var movieService = TestServiceProvider.GetService<IMovieService>()!;
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;
            var reservationService = TestServiceProvider.GetService<IReservationService>()!;

            var creationDetails = new MovieCreationDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };

            var id = await movieService.CreateMovieAsync(creationDetails);


            var theaterCreationDetails = new TheaterCreationDetails { RowCount = 12, SitsInRow = 22 };

            var theaterId = await theaterService.CreateTheaterAsync(theaterCreationDetails);

            var sessionCreationDetails = new SessionCreationDetails
            {
                StartDate = DateTime.Now.AddHours(1),
                EndDate = DateTime.Now.AddHours(3),
                MovieId = id,
                TheaterId = theaterId,
                Price = 22
            };

            var sessionId = await service.CreateSchedulledSessionAssync(sessionCreationDetails);

            var reservationDetails = new ReservationDetails
            {
                SessionId = sessionId,
                SitNumber = 1,
                CustomerName = "sdasdsad",
                CustomerPhoneNumber = "324324",
                RowNumber = 1,
            };

            var reservationId = await reservationService.ReserveSitInSessionAsync(reservationDetails);

            var session = await service.GetScheduledSessionAsync(sessionId);
            var reservation = session.OrderedSits.FirstOrDefault(s => s.Id == reservationId);
            reservation.Should().NotBeNull();
            reservation.IsReserved.Should().BeTrue();
        }

        [Test]
        public async Task ReserveSitInSessionAsync_UseReservedSit_ThrowSitReservationException()
        {
            var service = TestServiceProvider.GetService<IScheduledSessionService>()!;
            var movieService = TestServiceProvider.GetService<IMovieService>()!;
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;
            var reservationService = TestServiceProvider.GetService<IReservationService>()!;

            var creationDetails = new MovieCreationDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };

            var id = await movieService.CreateMovieAsync(creationDetails);


            var theaterCreationDetails = new TheaterCreationDetails { RowCount = 12, SitsInRow = 22 };

            var theaterId = await theaterService.CreateTheaterAsync(theaterCreationDetails);

            var sessionCreationDetails = new SessionCreationDetails
            {
                StartDate = DateTime.Now.AddHours(1),
                EndDate = DateTime.Now.AddHours(3),
                MovieId = id,
                TheaterId = theaterId,
                Price = 22
            };

            var sessionId = await service.CreateSchedulledSessionAssync(sessionCreationDetails);

            var reservationDetails = new ReservationDetails
            {
                SessionId = sessionId,
                SitNumber = 1,
                CustomerName = "sdasdsad",
                CustomerPhoneNumber = "324324",
                RowNumber = 1,
            };

            var reservationId = await reservationService.ReserveSitInSessionAsync(reservationDetails);

            var action = async () => await reservationService.ReserveSitInSessionAsync(reservationDetails);

            await action.Should().ThrowAsync<SitReservationException>();

        }

        [Test]
        public async Task ReserveSitInSessionAsync_UseNotExtsingSession_ThrowEntityNotFoundException()
        {
            var reservationService = TestServiceProvider.GetService<IReservationService>()!;

            var reservationDetails = new ReservationDetails
            {
                SessionId = Guid.NewGuid(),
                SitNumber = 1,
                CustomerName = "sdasdsad",
                CustomerPhoneNumber = "324324",
                RowNumber = 1,
            };

            var action = async () => await reservationService.ReserveSitInSessionAsync(reservationDetails);

            await action.Should().ThrowAsync<EntityNotFoundException>();

        }

        [Test]
        public async Task ConfirmResevationAsync_UseCorrectArgs_SitConfirmed()
        {
            var service = TestServiceProvider.GetService<IScheduledSessionService>()!;
            var movieService = TestServiceProvider.GetService<IMovieService>()!;
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;
            var reservationService = TestServiceProvider.GetService<IReservationService>()!;

            var creationDetails = new MovieCreationDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };

            var id = await movieService.CreateMovieAsync(creationDetails);


            var theaterCreationDetails = new TheaterCreationDetails { RowCount = 12, SitsInRow = 22 };

            var theaterId = await theaterService.CreateTheaterAsync(theaterCreationDetails);

            var sessionCreationDetails = new SessionCreationDetails
            {
                StartDate = DateTime.Now.AddHours(1),
                EndDate = DateTime.Now.AddHours(3),
                MovieId = id,
                TheaterId = theaterId,
                Price = 22
            };

            var sessionId = await service.CreateSchedulledSessionAssync(sessionCreationDetails);

            var reservationDetails = new ReservationDetails
            {
                SessionId = sessionId,
                SitNumber = 1,
                CustomerName = "sdasdsad",
                CustomerPhoneNumber = "324324",
                RowNumber = 1,
            };

            var reservationId = await reservationService.ReserveSitInSessionAsync(reservationDetails);

            await reservationService.ConfirmResevationAsync(sessionId, reservationId);

            var session = await service.GetScheduledSessionAsync(sessionId);
            var reservation = session.OrderedSits.FirstOrDefault(s => s.Id == reservationId);
            reservation.Should().NotBeNull();
            reservation.IsConfirmed.Should().BeTrue();
        }

        [Test]
        public async Task ConfirmResevationAsync_UsenotExtsingSession_ThrowsEntityNotFoundException()
        {
            var reservationService = TestServiceProvider.GetService<IReservationService>()!;
            var sessionId = Guid.NewGuid();
            var reservationId = Guid.NewGuid();

            var action = async () => await reservationService.ConfirmResevationAsync(sessionId, reservationId);
            
            await action.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Test]
        public async Task GetAvailableSessionsAsync_UseCorrectArgs_RecievedSession()
        {
            var service = TestServiceProvider.GetService<IScheduledSessionService>()!;
            var movieService = TestServiceProvider.GetService<IMovieService>()!;
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;
            var reservationService = TestServiceProvider.GetService<IReservationService>()!;

            var creationDetails = new MovieCreationDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };

            var id = await movieService.CreateMovieAsync(creationDetails);


            var theaterCreationDetails = new TheaterCreationDetails { RowCount = 12, SitsInRow = 22 };

            var theaterId = await theaterService.CreateTheaterAsync(theaterCreationDetails);

            var sessionCreationDetails = new SessionCreationDetails
            {
                StartDate = DateTime.Now.AddHours(1),
                EndDate = DateTime.Now.AddHours(3),
                MovieId = id,
                TheaterId = theaterId,
                Price = 22
            };

            var sessionId = await service.CreateSchedulledSessionAssync(sessionCreationDetails);

            var availableSessions = await reservationService.GetAvailableSessionsAsync(id);

            availableSessions.Should().NotBeNull();
            availableSessions.Count().Should().BePositive();

        }

        [Test]
        public async Task GetAvailableSessionsAsync_UsenoSessions_RecievedEmptyList()
        {
            var reservationService = TestServiceProvider.GetService<IReservationService>()!;

            var availableSessions = await reservationService.GetAvailableSessionsAsync(Guid.NewGuid());

            availableSessions.Should().NotBeNull();
            availableSessions.Count().Should().Be(0);

        }

        [Test]
        public async Task GetAvailableSessionsAsync_UseResevedSit_WithoutReservedSit()
        {
            var service = TestServiceProvider.GetService<IScheduledSessionService>()!;
            var movieService = TestServiceProvider.GetService<IMovieService>()!;
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;
            var reservationService = TestServiceProvider.GetService<IReservationService>()!;

            var creationDetails = new MovieCreationDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };

            var id = await movieService.CreateMovieAsync(creationDetails);


            var theaterCreationDetails = new TheaterCreationDetails { RowCount = 12, SitsInRow = 22 };

            var theaterId = await theaterService.CreateTheaterAsync(theaterCreationDetails);

            var sessionCreationDetails = new SessionCreationDetails
            {
                StartDate = DateTime.Now.AddHours(1),
                EndDate = DateTime.Now.AddHours(3),
                MovieId = id,
                TheaterId = theaterId,
                Price = 22
            };

            var sessionId = await service.CreateSchedulledSessionAssync(sessionCreationDetails);

            var reservationDetails = new ReservationDetails
            {
                SessionId = sessionId,
                SitNumber = 1,
                CustomerName = "sdasdsad",
                CustomerPhoneNumber = "324324",
                RowNumber = 1,
            };

            var reservationId = await reservationService.ReserveSitInSessionAsync(reservationDetails);

            await reservationService.ConfirmResevationAsync(sessionId, reservationId);

            var availableSession = (await reservationService.GetAvailableSessionsAsync(id)).FirstOrDefault();
            availableSession.Should().NotBeNull();
            availableSession?.AvailableSits.Any(s => s.RowNumber == reservationDetails.RowNumber && s.SitNumber == reservationDetails.SitNumber).Should().BeFalse();
        }

        [Test]
        public async Task GetReservationDetailsAsync_UseResevedSit_DetailsRecieved()
        {
            var service = TestServiceProvider.GetService<IScheduledSessionService>()!;
            var movieService = TestServiceProvider.GetService<IMovieService>()!;
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;
            var reservationService = TestServiceProvider.GetService<IReservationService>()!;

            var creationDetails = new MovieCreationDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };

            var id = await movieService.CreateMovieAsync(creationDetails);


            var theaterCreationDetails = new TheaterCreationDetails { RowCount = 12, SitsInRow = 22 };

            var theaterId = await theaterService.CreateTheaterAsync(theaterCreationDetails);

            var sessionCreationDetails = new SessionCreationDetails
            {
                StartDate = DateTime.Now.AddHours(1),
                EndDate = DateTime.Now.AddHours(3),
                MovieId = id,
                TheaterId = theaterId,
                Price = 22
            };

            var sessionId = await service.CreateSchedulledSessionAssync(sessionCreationDetails);

            var reservationDetails = new ReservationDetails
            {
                SessionId = sessionId,
                SitNumber = 1,
                CustomerName = "sdasdsad",
                CustomerPhoneNumber = "324324",
                RowNumber = 1,
            };

            var reservationId = await reservationService.ReserveSitInSessionAsync(reservationDetails);

            await reservationService.ConfirmResevationAsync(sessionId, reservationId);

            var details = await reservationService.GetReservationDetailsAsync(sessionId, reservationId);
            details.Should().NotBeNull();
            details.RowNumber.Should().Be(reservationDetails.RowNumber);
            details.SitNumber.Should().Be(reservationDetails.SitNumber);
            details.CustomerName.Should().Be(reservationDetails.CustomerName);
            details.EndDate.Should().Be(sessionCreationDetails.EndDate);
            details.StartDate.Should().Be(sessionCreationDetails.StartDate);
        }

        [Test]
        public async Task GetReservationDetailsAsync_UseNotExistingSit_ThrowsEntityNotFoundException()
        {
            var service = TestServiceProvider.GetService<IScheduledSessionService>()!;
            var movieService = TestServiceProvider.GetService<IMovieService>()!;
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;
            var reservationService = TestServiceProvider.GetService<IReservationService>()!;

            var creationDetails = new MovieCreationDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };

            var id = await movieService.CreateMovieAsync(creationDetails);


            var theaterCreationDetails = new TheaterCreationDetails { RowCount = 12, SitsInRow = 22 };

            var theaterId = await theaterService.CreateTheaterAsync(theaterCreationDetails);

            var sessionCreationDetails = new SessionCreationDetails
            {
                StartDate = DateTime.Now.AddHours(1),
                EndDate = DateTime.Now.AddHours(3),
                MovieId = id,
                TheaterId = theaterId,
                Price = 22
            };

            var sessionId = await service.CreateSchedulledSessionAssync(sessionCreationDetails);


            var action = async () =>  await reservationService.GetReservationDetailsAsync(sessionId, Guid.NewGuid());
            await action.Should().ThrowAsync<EntityNotFoundException>();

        }

        [Test]
        public async Task GetReservationDetailsAsync_UseNotExistingSession_ThrowsEntityNotFoundException()
        {
            var reservationService = TestServiceProvider.GetService<IReservationService>()!;


            var action = async () => await reservationService.GetReservationDetailsAsync(Guid.NewGuid(), Guid.NewGuid());
            await action.Should().ThrowAsync<EntityNotFoundException>();

        }
    }
}
