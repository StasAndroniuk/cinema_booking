using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Domain.Sessions
{
    public class AvailableSit
    {
        public AvailableSit(ushort rowNumber, ushort sitNumber)
        {
            RowNumber = rowNumber;
            SitNumber = sitNumber;
        }

         public ushort RowNumber { get; private set; }

        public ushort SitNumber { get; private set; }
    }
}
