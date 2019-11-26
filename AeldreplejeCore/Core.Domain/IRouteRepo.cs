using System.Collections.Generic;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Domain
{
    public interface IRouteRepo
    {
        List<Route> GetAllRoute();
        Route GetRoute(int id);
        Route CreateRoute(Route route);
        Route UpdateRoute(Route route);
        Route DeleteRoute(int id);
    }
}