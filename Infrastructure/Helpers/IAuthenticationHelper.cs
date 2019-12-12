using AeldreplejeCore.Core.Entity;

namespace AeldreplejeInfrastructure.Helpers
{
    public interface IAuthenticationHelper
    {
        string GenerateToken(User user);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

    }
}