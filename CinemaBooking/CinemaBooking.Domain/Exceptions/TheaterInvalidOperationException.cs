using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Domain.Exceptions
{
    public class TheaterInvalidOperationException : Exception
    {
        public TheaterInvalidOperationException(string message) : base(message) { }
    }
}
