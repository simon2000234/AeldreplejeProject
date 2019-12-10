using System.Collections.Generic;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Domain
{
    public interface IActiveRouteRepo
    {
        ActiveRoute CreateActiveRoute(ActiveRoute aRoute);
        List<ActiveRoute> GetAllActiveRoutes();
        ActiveRoute GetActiveRoute(int id);
        ActiveRoute UpdateActiveRoute(ActiveRoute aRoute);
        ActiveRoute DeleteActiveRoute(int id);
    }
}