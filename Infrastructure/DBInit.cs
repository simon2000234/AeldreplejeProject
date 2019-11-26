using AeldreplejeCore.Core.Entity;

namespace AeldreplejeInfrastructure
{
    public class DBInit
    {
        public static void SeedDB(AeldrePlejeContext ctx)
        {
            ctx.Database.EnsureCreated();

            string password = "password";
            byte[] passwordHashUserOne, passwordSaltUserOne, passwordHashUserTwo, passwordSaltUserTwo;

            CreatePasswordHash(password, out passwordHashUserOne, out passwordSaltUserOne);
            CreatePasswordHash(password, out passwordHashUserTwo, out passwordSaltUserTwo);

            var userNormal = ctx.Users.Add(new User()
            {
                IsAdmin = false,
                Name = "DabNormal",
                PasswordSalt = passwordSaltUserOne,
                PasswordHash = passwordHashUserOne
            }).Entity;

            var userAdmin = ctx.Users.Add(new User()
            {
                IsAdmin = true,
                Name = "DabAdmin",
                PasswordSalt = passwordSaltUserTwo,
                PasswordHash = passwordHashUserTwo
            }).Entity;

            ctx.SaveChanges();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}