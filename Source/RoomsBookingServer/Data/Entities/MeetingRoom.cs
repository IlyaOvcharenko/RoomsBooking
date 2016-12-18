using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class MeetingRoom : BaseEntity
    {
        public string RoomNumber { get; set; }

        public int NumberOfSeats { get; set; }

        public bool IsProjectorAvailable { get; set; }

        public bool IsBoardAvailable { get; set; }

        public ICollection<BookingRequest> BookingRequests { get; set; }
    }
}
