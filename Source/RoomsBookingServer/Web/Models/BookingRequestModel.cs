using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class BookingRequestModel
    {
        public DateTime DateTimeFrom { get; set; }

        public DateTime DateTimeTo { get; set; }

        public int MeetingRoomId { get; set; }
    }
}