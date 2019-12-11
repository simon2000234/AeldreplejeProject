using System.Collections.Generic;
using System.Linq;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace AeldreplejeInfrastructure.Repositories
{
    public class TimeStartRepo: ITimeStartRepo
    {
        private AeldrePlejeContext _context;
        public TimeStartRepo(AeldrePlejeContext context)
        {
            _context = context;
        }

        public TimeStart CreateTimeStart(TimeStart timeStart)
        {
            _context.TimeStarts.Attach(timeStart).State = EntityState.Added;
            _context.SaveChanges();
            return timeStart;
        }

        public List<TimeStart> GetAllTimeStarts()
        {
            return _context.TimeStarts
                .ToList();
        }

        public TimeStart GetTimeStart(int id)
        {
            return _context.TimeStarts
                .FirstOrDefault(ts => ts.id == id);
        }

        public TimeStart UpdateTimeStart(TimeStart timeStart)
        {
            _context.TimeStarts.Attach(timeStart).State = EntityState.Modified;
            _context.SaveChanges();
            return timeStart;
        }

        public TimeStart DeleteTimeStart(int id)
        {
            var deletedTimeStart = _context.TimeStarts.Remove(new TimeStart() {id = id}).Entity;
            _context.SaveChanges();
            return deletedTimeStart;
        }
    }
}