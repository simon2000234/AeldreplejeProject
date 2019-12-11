using System.Collections.Generic;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Application
{
    public interface ITimeEndService
    {
        TimeEnd CreateTimeEnd(TimeEnd timeEnd);
        List<TimeEnd> GetAllTimeEnds();
        TimeEnd GetTimeEnd(int id);
        TimeEnd UpdateTimeEnd(TimeEnd timeEnd);
        TimeEnd DeleteTimeEnd(int id);
    }
}