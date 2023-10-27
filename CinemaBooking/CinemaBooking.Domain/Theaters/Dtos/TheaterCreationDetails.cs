using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Domain.Theaters.Dtos
{
    public class TheaterCreationDetails
    {
        /// <summary>
        /// Number of sits rows
        /// </summary>
        public ushort RowCount { get; set; }

        /// <summary>
        /// Number of sits in 1 row
        /// </summary>
        public ushort SitsInRow { get; set; }
    }
}
