using System.IO;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Application.Validators
{
    public class RouteServiceValidator
    {
        public static void ValidateRoute(Route route)
        {
            if (route == null)
            {
                throw new InvalidDataException("Route most not be null");
            }

            if (string.IsNullOrEmpty(route.Name))
            {
                throw new InvalidDataException("Route must have a name");
            }
        }

        public static void ValidateUpdateRoute(Route route)
        {
            ValidateRoute(route);

            if (route.Id < 1)
            {
                throw new InvalidDataException("Route must have a valid positive id to update");
            }
        }

    }
}