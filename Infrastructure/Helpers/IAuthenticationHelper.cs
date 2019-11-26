using AeldreplejeCore.Core.Entity;

namespace AeldreplejeInfrastructure.Helpers
{
    public interface IAuthenticationHelper
    {
        string GenerateToken(User user);

    }
}