using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    // Models returned by MeController actions.
    public class MeetingRoomViewModel
    {
        public string Hometown { get; set; }
    }
}