using System.Collections.Generic;
using System.IO;
using AeldreplejeCore.Core.Application.Validators;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Application.Impl
{
    public class TimeStartService: ITimeStartService
    {
        private ITimeStartRepo _tsRepo;
        private TimeStartServiceValidator validator;

        public TimeStartService(ITimeStartRepo timeStartRepo)
        {
            _tsRepo = timeStartRepo;
            validator = new TimeStartServiceValidator();
        }

        public TimeStart CreateTimeStart(TimeStart timeStart)
        {
            if (validator.Validate(timeStart))
            {
                return _tsRepo.CreateTimeStart(timeStart);
            }
            else
            {
                throw new InvalidDataException("Data is invalid, make sure to follow the format HH:mm");
            }
            
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
            if (validator.Validate(timeStart))
            {
                return _tsRepo.UpdateTimeStart(timeStart);
            }
            else
            {
                throw new InvalidDataException("Data is invalid, make sure to follow the format HH:mm");
            }
            
        }

        public TimeStart DeleteTimeStart(int id)
        {
            return _tsRepo.DeleteTimeStart(id);
        }
    }
}