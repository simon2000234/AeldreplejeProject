using System.Collections.Generic;
using System.IO;
using AeldreplejeCore.Core.Application.Validators;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Application.Impl
{
    public class TimeEndService: ITimeEndService
    {
        private ITimeEndRepo _teRepo;
        private TimeEndServiceValidator validator;

        public TimeEndService(ITimeEndRepo timeEndRepo)
        {
            _teRepo = timeEndRepo;
            validator = new TimeEndServiceValidator();
        }

        public TimeEnd CreateTimeEnd(TimeEnd timeEnd)
        {
            if (validator.Validate(timeEnd))
            { 
                return _teRepo.CreateTimeEnd(timeEnd);
            }
            else
            {
                throw new InvalidDataException("Invalid Data, follow the format HH:mm (ex 09:45)");
            }
            
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
            if (validator.Validate(timeEnd))
            {
                return _teRepo.UpdateTimeEnd(timeEnd);
            }
            else
            {
                throw new InvalidDataException("Invalid Data, follow the format HH:mm (ex 09:45)");
            }
        }

        public TimeEnd DeleteTimeEnd(int id)
        {
            return _teRepo.DeleteTimeEnd(id);
        }
    }
}