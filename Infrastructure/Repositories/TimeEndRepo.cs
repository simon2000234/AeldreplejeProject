using System.Collections.Generic;
using System.Linq;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace AeldreplejeInfrastructure.Repositories
{
    public class TimeEndRepo: ITimeEndRepo
    {
        private AeldrePlejeContext _context;

        public TimeEndRepo(AeldrePlejeContext context)
        {
            _context = context;
        }

        public TimeEnd CreateTimeEnd(TimeEnd timeEnd)
        {
            _context.TimeEnds.Attach(timeEnd).State = EntityState.Added;
            _context.SaveChanges();
            return timeEnd;
        }

        public List<TimeEnd> GetAllTimeEnds()
        {
            return _context.TimeEnds
                .ToList();
        }

        public TimeEnd GetTimeEnd(int id)
        {
            return _context.TimeEnds
                .FirstOrDefault(te => te.id == id);
        }

        public TimeEnd UpdateTimeEnd(TimeEnd timeEnd)
        {
            _context.TimeEnds.Attach(timeEnd).State = EntityState.Modified;
            _context.SaveChanges();
            return timeEnd;
        }

        public TimeEnd DeleteTimeEnd(int id)
        {
            var deletedTimeEnd = _context.TimeEnds
                .Remove(new TimeEnd() {id = id}).Entity;
            _context.SaveChanges();
            return deletedTimeEnd;
        }
    }
}