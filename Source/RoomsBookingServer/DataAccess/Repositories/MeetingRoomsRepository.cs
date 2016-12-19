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
    public class MeetingRoomsRepository : BaseEntityRepository<MeetingRoom>, IMeetingRoomsRepository
    {
        public IQueryable<MeetingRoom> GetAllRooms()
        {

            return DataContext.MeetingRooms.Include(r => r.BookingRequests);
        }

        public MeetingRoomsRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
