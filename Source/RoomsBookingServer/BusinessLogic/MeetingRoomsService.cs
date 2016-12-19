using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Dto;
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
        public EntityDataPage<MeetingRoomDto> GetMeetingRoomsPage(int pageNumber, int pageSize)
        {
            var query = _roomsRepository.GetAllRooms().Select(
                    r =>
                        new MeetingRoomDto
                        {
                            Id = r.Id,
                            NumberOfSeats = r.NumberOfSeats,
                            RoomNumber = r.RoomNumber,
                            IsBoardAvailable = r.IsBoardAvailable,
                            IsProjectorAvailable = r.IsProjectorAvailable,
                            BookingRequests = r.BookingRequests.Where(b => b.IsApproved.HasValue && b.IsApproved.Value && b.DateTimeFrom >= DateTime.Today)
                        })
                .OrderBy(r => r.RoomNumber);
            var count = query.Count();
            var list = query.Skip(pageSize * pageNumber)
                    .Take(pageSize)
                    .ToList();
            return new EntityDataPage<MeetingRoomDto>
            {
                EntityCount = count,
                List = list,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

        }

        public MeetingRoom Get(int id)
        {
            return _roomsRepository.GetById(id);
        }

        public void Create(MeetingRoom entity)
        {
            _roomsRepository.Add(entity);
            _roomsRepository.SaveChanges();
        }

        public void Update(MeetingRoom entity)
        {
            _roomsRepository.Update(entity);
            _roomsRepository.SaveChanges();
        }

        public void Dispose()
        {
            _roomsRepository?.Dispose();
        }
    }
}
