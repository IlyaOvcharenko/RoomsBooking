using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Dto;
using BusinessLogic.Paging;
using Data.Entities;

namespace BusinessLogic
{
    public interface IBookingRequestsService : IDisposable
    {
        EntityDataPage<BookingRequestDto> GetBookingRequestsPage(int pageNumber, int pageSize);

        BookingRequestDto GetBookingRequest(int id);

        void ApproveBookingRequest(int id);

        void RejectBookingRequest(int id);
    }

    
}
