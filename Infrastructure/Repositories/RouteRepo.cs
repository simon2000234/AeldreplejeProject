using System.Collections.Generic;
using System.Linq;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace AeldreplejeInfrastructure.Repositories
{
    public class RouteRepo: IRouteRepo
    {
        
        private AeldrePlejeContext _context;

        public RouteRepo(AeldrePlejeContext context)
        {
            _context = context;
        }
        
        public List<Route> GetAllRoute()
        {
            return _context.Routes.Include(r => r.Shift).ToList();
        }

        public Route GetRoute(int id)
        {
            return _context.Routes.Include(r => r.Shift).FirstOrDefault(r => r.Id == id);
        }

        public Route CreateRoute(Route route)
        {
            if (route.Shift != null)
            {
                route.Shift = _context.Shifts.FirstOrDefault(s => s.Id == route.Shift.Id);
                route.Shift.RouteId = route.Id;
            }
            _context.Attach(route).State = EntityState.Added;
            _context.SaveChanges();
            return route;
        }

        public Route UpdateRoute(Route route)
        {
            _context.Attach(route).State = EntityState.Modified;
            _context.SaveChanges();
            return route;
        }

        public Route DeleteRoute(int id)
        {
            var route = _context.Remove(new Route { Id = id }).Entity;
            _context.SaveChanges();
            return route;
        }
    }
}