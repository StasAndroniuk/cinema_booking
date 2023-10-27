using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Domain.Sessions
{
    public class OrderedSit
    {
        public OrderedSit(ushort rowNumber, ushort sitNumber)
        {
            Id = Guid.NewGuid();
            RowNumber = rowNumber;
            SitNumber = sitNumber;
        }

        public Guid Id { get; private set; }

        public ushort RowNumber { get; private set; }

        public ushort SitNumber { get; private set; }

        public bool IsReserved { get; private set; }

        public bool IsConfirmed { get; private set; }

        public void Reserve()
        {
            IsReserved = true;
        }

        public void Confirm()
        {
            IsConfirmed = true;
        }
    }
}
