using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace BusinessLogic.Dto
{
    public class MeetingRoomDto
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }

        public int NumberOfSeats { get; set; }

        public bool IsProjectorAvailable { get; set; }

        public bool IsBoardAvailable { get; set; }

        public IEnumerable<BookingRequest> BookingRequests { get; set; }
    }
}
