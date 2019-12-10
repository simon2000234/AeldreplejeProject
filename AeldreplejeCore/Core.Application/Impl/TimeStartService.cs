using System.Collections.Generic;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Application.Impl
{
    public class TimeStartService: ITimeStartService
    {
        private ITimeStartRepo _tsRepo;

        public TimeStartService(ITimeStartRepo timeStartRepo)
        {
            _tsRepo = timeStartRepo;
        }

        public TimeStart CreateTimeStart(TimeStart timeStart)
        {
            return _tsRepo.CreateTimeStart(timeStart);
        }

        public List<TimeStart> GetAllTimeStarts()
        {
            return _tsRepo.GetAllTimeStarts();
        }

        public TimeStart GetTimeStart(int id)
        {
            return _tsRepo.GetTimeStart(id);
        }

        public TimeStart UpdateTimeStart(TimeStart timeStart)
        {
            return _tsRepo.UpdateTimeStart(timeStart);
        }

        public TimeStart DeleteTimeStart(int id)
        {
            return _tsRepo.DeleteTimeStart(id);
        }
    }
}