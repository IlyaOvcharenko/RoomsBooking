using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Paging;
using Data.Entities;

namespace BusinessLogic
{
    public interface IMeetingRoomsService : IDisposable
    {
        EntityDataPage<MeetingRoom> GetMeetingRoomsPage(int pageNumber, int pageSize);
    }
}
