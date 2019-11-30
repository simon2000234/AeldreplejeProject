using System.Collections.Generic;
using System.Linq;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace AeldreplejeInfrastructure.Repositories
{
    public class PendingShiftRepo: IPendingShiftRepo
    {
        private AeldrePlejeContext _context;

        public PendingShiftRepo(AeldrePlejeContext context)
        {
            _context = context;
        }
        public List<PendingShift> GetAllPendingShift()
        {
           return _context.PendingShifts.ToList();
        }

        public PendingShift GetPendingShift(int id)
        {
            return _context.PendingShifts.FirstOrDefault(ps => ps.Id == id);
        }

        public PendingShift CreatePendingShift(PendingShift pendingShift)
        {
            _context.Attach(pendingShift).State = EntityState.Added;
            _context.SaveChanges();
            return pendingShift;
        }

        public PendingShift UpdatePendingShift(PendingShift pendingShift)
        {
            _context.Attach(pendingShift).State = EntityState.Modified;
            _context.SaveChanges();
            return pendingShift;
        }

        public PendingShift DeletePendingShift(int id)
        {
            var pendingShift = _context.Remove(new PendingShift { Id = id }).Entity;
            _context.SaveChanges();
            return pendingShift;
        }
    }
}