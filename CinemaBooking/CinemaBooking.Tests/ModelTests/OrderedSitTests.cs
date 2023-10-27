using CinemaBooking.Domain.Sessions;
using FluentAssertions;

namespace CinemaBooking.Tests.ModelTests
{
    internal class OrderedSitTests
    {
        [Test]
        public void Constaructor_useCorrectArgs_SitCreated()
        {
            var rowNumber = (ushort)1;
            var sitNumber = (ushort)1;
            var customerName = "asdsad";
            var number = "31212321";

            var sit = new OrderedSit(rowNumber, sitNumber, customerName, number);

            sit.Should().NotBeNull();
            sit.SitNumber.Should().Be(sitNumber);
            sit.RowNumber.Should().Be(rowNumber);
            sit.IsReserved.Should().BeFalse();
            sit.IsConfirmed.Should().BeFalse();
        }

        [Test]
        public void Reserve_useCorrectArgs_SitReserved()
        {
            var rowNumber = (ushort)1;
            var sitNumber = (ushort)1;
            var customerName = "asdsad";
            var number = "31212321";


            var sit = new OrderedSit(rowNumber, sitNumber, customerName, number);
            sit.Reserve();
            sit.IsReserved.Should().BeTrue();
            sit.IsConfirmed.Should().BeFalse();
        }

        [Test]
        public void Confirm_useCorrectArgs_SitConfirmed()
        {
            var rowNumber = (ushort)1;
            var sitNumber = (ushort)1;
            var customerName = "asdsad";
            var number = "31212321";

            var sit = new OrderedSit(rowNumber, sitNumber, customerName, number);
            sit.Confirm();
            sit.IsConfirmed.Should().BeTrue();
        }
    }
}
