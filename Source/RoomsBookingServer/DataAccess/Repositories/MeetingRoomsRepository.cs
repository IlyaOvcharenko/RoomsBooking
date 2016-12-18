using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Data;
using Data.Entities;

namespace DataAccess.Repositories
{
    public class MeetingRoomsRepository : BaseEntityRepository<MeetingRoom>, IMeetingRoomsRepository
    {
        public IQueryable<MeetingRoom> GetAllRooms()
        {
            return DataContext.MeetingRooms.Include(r=>r.BookingRequests.Where(b=>b.DateTimeFrom.Date == DateTime.Today));   
        }

        public MeetingRoomsRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
