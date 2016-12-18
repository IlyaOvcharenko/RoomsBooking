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
            return DataContext.MeetingRooms;   
        }

        public MeetingRoomsRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
