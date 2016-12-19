using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Data.Entities;

namespace Web.Models
{
    public class MeetingRoomEditModel
    {
       public int? Id { get; set; }

        [Required(ErrorMessage = @"Room number is required")]
        [Display(Name = @"Room number")]
        public string RoomNumber { get; set; }

        [Display(Name = @"Number of seats")]
        public int NumberOfSeats { get; set; }

        [Display(Name = @"Projector available")]
        public bool IsProjectorAvailable { get; set; }

        [Display(Name = @"Board available")]
        public bool IsBoardAvailable { get; set; }

        public MeetingRoomEditModel()
        {

        }
        private MeetingRoomEditModel(MeetingRoom source)
        {
            Id = source.Id;
            RoomNumber = source.RoomNumber;
            NumberOfSeats = source.NumberOfSeats;
            IsProjectorAvailable = source.IsProjectorAvailable;
            IsBoardAvailable = source.IsBoardAvailable;
        }

        public static MeetingRoomEditModel FromBO(MeetingRoom source)
        {
            return new MeetingRoomEditModel(source);
        }

        public void UpdateBO(MeetingRoom target)
        {
            target.Id = Id.HasValue ? Id.Value : default(int);
            target.RoomNumber = RoomNumber;
            target.NumberOfSeats = NumberOfSeats;
            target.IsProjectorAvailable = IsProjectorAvailable;
            target.IsBoardAvailable = IsBoardAvailable;
        }
    }
}