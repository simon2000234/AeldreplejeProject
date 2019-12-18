using System.Collections.Generic;
using System.Linq;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace AeldreplejeInfrastructure.Repositories
{
    public class ShiftRepo : IShiftRepo
    {
        private AeldrePlejeContext _context;

        public ShiftRepo(AeldrePlejeContext context)
        {
            _context = context;
        }

        public List<Shift> GetAllShifts()
        {
            return _context.Shifts
                .Include(s => s.Route)
                .Include(s => s.User)
                .ToList();
        }

        public Shift GetShift(int id)
        {
            return _context.Shifts
                .Include(s => s.User)
                .Include(s => s.Route)
                .FirstOrDefault(s => s.Id == id);
        }

        public Shift CreateShift(Shift shift)
        {
            _context.Attach(shift).State = EntityState.Added;
            _context.SaveChanges();
            Route route = _context.Routes.FirstOrDefault(r => r.Id == shift.Route.Id);
            shift.Route = route;
            route.Shift = shift;
            shift.RouteId = route.Id;
            _context.Shifts.Attach(shift).State = EntityState.Modified;
            _context.SaveChanges();
            return shift;
        }

        public Shift UpdateShift(Shift shift)
        {
            _context.Attach(shift).State = EntityState.Modified;
            _context.Entry(shift).Reference(s => s.User).IsModified = true;
            _context.Entry(shift).Reference(s => s.Route).IsModified = true;
            _context.Entry(shift).Reference(s => s.PShift).IsModified = true;

            _context.SaveChanges();
            return shift;
        }

        public Shift DeleteShift(int id)
        {
            var shift = _context.Remove(new Shift { Id = id }).Entity;
            _context.SaveChanges();
            return shift;
        }
    }
}