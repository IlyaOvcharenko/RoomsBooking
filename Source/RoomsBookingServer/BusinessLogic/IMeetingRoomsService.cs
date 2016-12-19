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
    public interface IMeetingRoomsService : IDisposable
    {
        EntityDataPage<MeetingRoomDto> GetMeetingRoomsPage(int pageNumber, int pageSize);
    }
}
