using System.Collections.Generic;
using System.Linq;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace AeldreplejeInfrastructure.Repositories
{
    public class ActiveRouteRepo: IActiveRouteRepo
    {
        private AeldrePlejeContext _context;
        public ActiveRouteRepo(AeldrePlejeContext context)
        {
            _context = context;
        }


        public ActiveRoute CreateActiveRoute(ActiveRoute aRoute)
        {
            _context.ActiveRoutes.Attach(aRoute).State = EntityState.Added;
            _context.SaveChanges();
            return aRoute;
        }

        public List<ActiveRoute> GetAllActiveRoutes()
        {
            return _context.ActiveRoutes
                .ToList();
        }

        public ActiveRoute GetActiveRoute(int id)
        {
            return _context.ActiveRoutes
                .FirstOrDefault(ar => ar.id == id);
        }

        public ActiveRoute UpdateActiveRoute(ActiveRoute aRoute)
        {
            _context.ActiveRoutes.Attach(aRoute).State = EntityState.Modified;
            _context.SaveChanges();
            return aRoute;
        }

        public ActiveRoute DeleteActiveRoute(int id)
        {
            var deletedARoute = _context.Remove(new ActiveRoute() { id = id }).Entity;
            _context.SaveChanges();
            return deletedARoute;
        }
    }
}