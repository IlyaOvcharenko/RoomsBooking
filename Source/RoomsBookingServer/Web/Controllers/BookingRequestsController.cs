using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using BusinessLogic;
using BusinessLogic.Dto;
using BusinessLogic.Paging;
using Data.Entities;
using Microsoft.AspNet.Identity;
using Web.Common;
using Web.Hubs;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class BookingRequestsController : ApiController
    {
        private readonly IBookingRequestsService _bookingRequestsService;
        public BookingRequestsController(IBookingRequestsService bookingRequestsService)
        {
            _bookingRequestsService = bookingRequestsService;
        }

        public EntityDataPage<BookingRequestDto> Get(int skip, int take, int page, int pageSize)
        {
            return _bookingRequestsService.GetBookingRequestsPage(page - 1, pageSize);
        }

        [HttpPost]
        public IHttpActionResult CreateBookingRequest(BookingRequestModel model)
        {
            int userId;
            if (!int.TryParse(User.Identity.GetUserId(), out userId))
                return Unauthorized();

            _bookingRequestsService.CreateBookingRequest(model.DateTimeFrom, model.DateTimeTo, model.MeetingRoomId, userId);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult ConfirmBookingRequest(int id, [FromBody]RequestsConfirmationActions action)
        {
            var request = _bookingRequestsService.GetBookingRequest(id);

            if (request == null)
                return NotFound();

            if (request.IsApproved.HasValue)
            {
                return BadRequest("Request already " + (request.IsApproved.Value ? "approved" : "rejected"));
            }
            string result;
            if (action == RequestsConfirmationActions.Approve)
            {
                _bookingRequestsService.ApproveBookingRequest(id);
                result = "approved";
            }
            else
            {
                _bookingRequestsService.RejectBookingRequest(id);
                result = "rejected";
            }
            var context = Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<BookingHub>();
            context.Clients.Clients(BookingHub.Connections.Where(c=>c.UserId == request.CreateUser.Id.ToString()).Select(c=>c.ConnectionId).ToList()).sendNotification("Your request " + result);
            return Ok();
        }
    }
}
