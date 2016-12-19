using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Dto;
using BusinessLogic.Paging;
using Data.Entities;
using DataAccess.Repositories;

namespace BusinessLogic
{
    public class BookingRequestsService : IBookingRequestsService
    {
        private readonly IBookingRequestsRepository _bookingRequestRepository; 
        public BookingRequestsService(IBookingRequestsRepository bookingRequestRepository)
        {
            _bookingRequestRepository = bookingRequestRepository;
        }
        public void Dispose()
        {
            _bookingRequestRepository?.Dispose();
        }

        public EntityDataPage<BookingRequestDto> GetBookingRequestsPage(int pageNumber, int pageSize)
        {
            var query = _bookingRequestRepository.GetAll()
                .OrderByDescending(r => r.DateTimeFrom).Select(r=>new BookingRequestDto
                {
                    Id = r.Id,
                    DateTimeFrom = r.DateTimeFrom,
                    DateTimeTo = r.DateTimeTo,
                    CreateDateTime = r.CreateDateTime,
                    CreateUser = r.CreateUser,
                    IsApproved = r.IsApproved,
                    MeetingRoomNumber = r.MeetingRoom.RoomNumber
                });
            var count = query.Count();
            var list = query.Skip(pageSize * pageNumber)
                    .Take(pageSize)
                    .ToList();
            return new EntityDataPage<BookingRequestDto>
            {
                EntityCount = count,
                List = list,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public BookingRequestDto GetBookingRequest(int id)
        {
            var request = _bookingRequestRepository.GetById(id);
            return new BookingRequestDto
            {
                Id = request.Id,
                DateTimeFrom = request.DateTimeFrom,
                DateTimeTo = request.DateTimeTo,
                CreateDateTime = request.CreateDateTime,
                CreateUser = request.CreateUser,
                IsApproved = request.IsApproved,
                MeetingRoomNumber = request.MeetingRoom.RoomNumber
            };
        }

        public void ApproveBookingRequest(int id)
        {
            var request = _bookingRequestRepository.GetById(id);
            request.IsApproved = true;
            _bookingRequestRepository.SaveChanges();
        }

        public void RejectBookingRequest(int id)
        {
            var request = _bookingRequestRepository.GetById(id);
            request.IsApproved = false;
            _bookingRequestRepository.SaveChanges();
        }
    }
}
