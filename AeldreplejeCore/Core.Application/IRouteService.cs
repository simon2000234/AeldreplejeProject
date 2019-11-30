using System.Collections.Generic;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Application
{
    public interface IRouteService
    {
        List<Route> GetAllRoute();
        Route GetRoute(int id);
        Route CreateRoute(Route route);
        Route UpdateRoute(Route route);
        Route DeleteRoute(int id);
    }
}