using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Domain.Exceptions
{
    public class SessionInvalidOperationException : Exception
    {
        public SessionInvalidOperationException(string message) : base(message) { }
    }
}
