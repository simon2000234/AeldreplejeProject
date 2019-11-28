using System.Collections.Generic;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeInfrastructure
{
    public class DBInit
    {
        public static void SeedDB(AeldrePlejeContext ctx)
        {
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
            /*var groupDab = ctx.Groups.Add(new Group()
            {
                Type = "Dab",
                Users = new List<User>
                {
                    userAdmin,
                    userNormal
                }
            });*/

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