using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Domain.Exceptions
{
    public class MovieDuplicateException : Exception
    {
        public MovieDuplicateException(string message) : base(message) { }
    }
}
