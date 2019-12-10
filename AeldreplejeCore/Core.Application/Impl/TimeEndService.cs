using System.Collections.Generic;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Application.Impl
{
    public class TimeEndService: ITimeEndService
    {
        private ITimeEndRepo _teRepo;

        public TimeEndService(ITimeEndRepo timeEndRepo)
        {
            _teRepo = timeEndRepo;
        }

        public TimeEnd CreateTimeEnd(TimeEnd timeEnd)
        {
            return _teRepo.CreateTimeEnd(timeEnd);
        }

        public List<TimeEnd> GetAllTimeEnds()
        {
            return _teRepo.GetAllTimeEnds();
        }

        public TimeEnd GetTimeEnd(int id)
        {
            return _teRepo.GetTimeEnd(id);
        }

        public TimeEnd UpdateTimeEnd(TimeEnd timeEnd)
        {
            return _teRepo.UpdateTimeEnd(timeEnd);
        }

        public TimeEnd DeleteTimeEnd(int id)
        {
            return _teRepo.DeleteTimeEnd(id);
        }
    }
}