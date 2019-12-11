using System.Collections.Generic;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Application.Impl
{
    public class ActiveRouteService: IActiveRouteService
    {
        private IActiveRouteRepo arRepo;

        public ActiveRouteService(IActiveRouteRepo activeRouteRepo)
        {
            arRepo = activeRouteRepo;
        }

        public ActiveRoute CreateActiveRoute(ActiveRoute aRoute)
        {
            return arRepo.CreateActiveRoute(aRoute);
        }

        public List<ActiveRoute> GetAllActiveRoutes()
        {
            return arRepo.GetAllActiveRoutes();
        }

        public ActiveRoute GetActiveRoute(int id)
        {
            return arRepo.GetActiveRoute(id);
        }

        public ActiveRoute UpdateActiveRoute(ActiveRoute aRoute)
        {
            return arRepo.UpdateActiveRoute(aRoute);
        }

        public ActiveRoute DeleteActiveRoute(int id)
        {
            return arRepo.DeleteActiveRoute(id);
        }
    }

}