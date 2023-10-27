using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Domain.Sessions.Dtos
{
    public class SessionCreationDetails
    {
        /// <summary>
        /// Id of the movie.
        /// </summary>
        public Guid MovieId { get; set; }

        /// <summary>
        /// Theater id
        /// </summary>
        public Guid TheaterId { get; set; }

        /// <summary>
        /// Session start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Session end date
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Session price
        /// </summary>
        public decimal Price { get; set; }
    }
}
