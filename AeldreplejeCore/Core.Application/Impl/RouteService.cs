using System.Collections.Generic;
using AeldreplejeCore.Core.Application.Validators;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Application.Impl
{
    public class RouteService: IRouteService
    {
        private IRouteRepo _routeRepo;

        public RouteService(IRouteRepo routeRepo )
        {
           _routeRepo = routeRepo;
        }

        public List<Route> GetAllRoute()
        {
            return _routeRepo.GetAllRoute();
        }

        public Route GetRoute(int id)
        {
            return _routeRepo.GetRoute(id);
        }

        public Route CreateRoute(Route route)
        {
            RouteServiceValidator.ValidateRoute(route);
            return _routeRepo.CreateRoute(route);
        }

        public Route UpdateRoute(Route route)
        {
            RouteServiceValidator.ValidateUpdateRoute(route);
            return _routeRepo.UpdateRoute(route);
        }

        public Route DeleteRoute(int id)
        {
            return _routeRepo.DeleteRoute(id);
        }
    }
}