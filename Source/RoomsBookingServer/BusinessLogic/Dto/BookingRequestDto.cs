using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace BusinessLogic.Dto
{
    public class BookingRequestDto
    {
        public int Id { get; set; }

        public DateTime DateTimeFrom { get; set; }

        public DateTime DateTimeTo { get; set; }

        public bool? IsApproved { get; set; }

        public DateTime CreateDateTime { get; set; }

        public string MeetingRoomNumber { get; set; }

        public virtual User CreateUser { get; set; }
    }
}
