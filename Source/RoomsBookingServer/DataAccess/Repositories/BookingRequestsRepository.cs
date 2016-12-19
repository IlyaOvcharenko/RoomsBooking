using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Data;
using Data.Entities;

namespace DataAccess.Repositories
{
    public class BookingRequestsRepository : BaseEntityRepository<BookingRequest>, IBookingRequestsRepository
    {
        public IQueryable<BookingRequest> GetAllBookingRequests()
        {
            return DataContext.BookingRequests.Include(r => r.MeetingRoom);
        }

        public override BookingRequest GetById(int id)
        {
            return DataContext.BookingRequests.Include(r => r.MeetingRoom).FirstOrDefault(e => e.Id == id);
        }

        public BookingRequestsRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
