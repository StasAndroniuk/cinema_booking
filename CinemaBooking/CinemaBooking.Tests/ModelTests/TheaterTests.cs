using CinemaBooking.Domain.Theaters;
using CinemaBooking.Domain.Theaters.Dtos;
using FluentAssertions;

namespace CinemaBooking.Tests.ModelTests
{
    internal class TheaterTests : BaseTest
    {
        [Test]
        public void Constructor_UseCorrectArgs_TheaterCreated()
        {
            var numberOfRows = (ushort)232;
            var numberOfSits = (ushort)22;

            var theater = new Theater(numberOfRows, numberOfSits);

            theater.SitsInRow.Should().Be(numberOfSits);
            theater.RowCount.Should().Be(numberOfRows);
        }

        [Test]
        public void Update_UseCorrectArgs_TheaterUpdated()
        {
            var numberOfRows = (ushort)232;
            var numberOfSits = (ushort)22;

            var theater = new Theater(numberOfRows, numberOfSits);

            var udpateDetails = new TheaterUpdateDetails { RowCount = 33, SitsInRow = 98 };
            theater.Update(udpateDetails);

            theater.SitsInRow.Should().Be(udpateDetails.SitsInRow);
            theater.RowCount.Should().Be(udpateDetails.RowCount);
        }
    }
}
