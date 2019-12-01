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
           return _context.PendingShifts
                .Include(p=> p.Shift)
                .Include(p=> p.Users)
                .ThenInclude(u => u.User)
                .ToList();
        }

        public PendingShift GetPendingShift(int id)
        {
            return _context.PendingShifts.Include(p => p.Shift).Include(p => p.Users).FirstOrDefault(ps => ps.Id == id);
        }

        public PendingShift CreatePendingShift(PendingShift pendingShift)
        {
            pendingShift.ShiftId = pendingShift.Shift.Id;
            _context.Attach(pendingShift).State = EntityState.Added;
            _context.SaveChanges();
            Shift shift = _context.Shifts.FirstOrDefault(s => s.Id == pendingShift.ShiftId);
            shift.PShift = pendingShift;
            _context.Attach(pendingShift).State = EntityState.Modified;
            _context.SaveChanges();
            return pendingShift;
        }

        public PendingShift UpdatePendingShift(PendingShift pendingShift)
        {
            var newUserList = new List<UserPendingShift>(pendingShift.Users);
            _context.Attach(pendingShift).State = EntityState.Modified;
            _context.Entry(pendingShift).Reference(ps => ps.Shift).IsModified = true;
            _context.UserPendingShifts.RemoveRange(
                _context.UserPendingShifts.Where(ups => ups.PendingShiftId == pendingShift.Id));

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