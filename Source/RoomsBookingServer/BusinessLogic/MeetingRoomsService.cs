using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Paging;
using Data.Entities;
using DataAccess.Repositories;

namespace BusinessLogic
{
    public class MeetingRoomsService : IMeetingRoomsService
    {
        private readonly IMeetingRoomsRepository _roomsRepository; 
        public MeetingRoomsService(IMeetingRoomsRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }
        public EntityDataPage<MeetingRoom> GetMeetingRoomsPage(int pageNumber, int pageSize)
        {
            var query = _roomsRepository.GetAllRooms()
                .OrderBy(r => r.RoomNumber);
            var count = query.Count();
            var list = query.Skip(pageSize * pageNumber)
                    .Take(pageSize)
                    .ToList();
            return new EntityDataPage<MeetingRoom>
            {
                EntityCount = count,
                List = list,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

        }

        public void Dispose()
        {
            _roomsRepository?.Dispose();
        }
    }
}
