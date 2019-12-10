using System.Collections.Generic;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Application
{
    public interface ITimeStartService
    {
        TimeStart CreateTimeStart(TimeStart timeStart);
        List<TimeStart> GetAllTimeStarts();
        TimeStart GetTimeStart(int id);
        TimeStart UpdateTimeStart(TimeStart timeStart);
        TimeStart DeleteTimeStart(int id);
    }
}