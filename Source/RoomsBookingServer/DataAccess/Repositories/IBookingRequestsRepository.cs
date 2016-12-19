using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace DataAccess.Repositories
{
    public interface IBookingRequestsRepository : IBaseEntityRepository<BookingRequest>
    {
        IQueryable<BookingRequest> GetAllBookingRequests();
    }

    
}
