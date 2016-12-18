using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class BookingRequest : BaseEntity
    {
        public int MeetingRoomId { get; set; }

        public DateTime DateTimeFrom { get; set; }

        public DateTime DateTimeTo { get; set; }

        public bool IsApproved { get; set; }

        public int CreateUserId { get; set; }

        public DateTime CreateDateTime { get; set; }

        public virtual MeetingRoom MeetingRoom { get; set; }

        public virtual User CreateUser { get; set; }
    }
}
