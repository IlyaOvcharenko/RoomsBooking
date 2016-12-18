using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BusinessLogic;
using BusinessLogic.Paging;
using Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class MeetingRoomsController : ApiController
    {
        private readonly IMeetingRoomsService _meetingRoomsService;

        public MeetingRoomsController(IMeetingRoomsService meetingRoomsService)
        {
            _meetingRoomsService = meetingRoomsService;
        }

        // GET api/MeetingRooms
        public EntityDataPage<MeetingRoom> Get(int skip, int take, int page, int pageSize)
        {
            return _meetingRoomsService.GetMeetingRoomsPage(page - 1, pageSize);
        }
    }
}