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
using Web.Common;

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

            if (action == RequestsConfirmationActions.Approve)
            {
                _bookingRequestsService.ApproveBookingRequest(id);
            }
            else
            {
                _bookingRequestsService.RejectBookingRequest(id);
            }
            return Ok();
        }
    }
}
