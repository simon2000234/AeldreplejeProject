using System;
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
                Name = "Christian",
                PasswordSalt = passwordSaltUserOne,
                PasswordHash = passwordHashUserOne,
                Email = "christiansEmail@email.com",
                ProfilePicture = "https://scontent-ams4-1.xx.fbcdn.net/v/t1.0-9/68397042_2373050946108579_1355476049231609856_n.jpg?_nc_cat=111&_nc_ohc=L-VxFCgmIOEAQkExKADS7GkFanYn-wlS1DtritGMIDMaz-F2F47jDBqdg&_nc_ht=scontent-ams4-1.xx&oh=d64bb5c81845f4af32142583c4d47f87&oe=5E89A221"
            }).Entity;
            var userNormal2 = ctx.Users.Add(new User()
            {
                IsAdmin = false,
                Name = "Richart",
                PasswordSalt = passwordSaltUserOne,
                PasswordHash = passwordHashUserOne
            }).Entity;
            var userNormal3 = ctx.Users.Add(new User()
            {
                IsAdmin = false,
                Name = "Casper",
                PasswordSalt = passwordSaltUserOne,
                PasswordHash = passwordHashUserOne
            }).Entity;

            var userAdmin = ctx.Users.Add(new User()
            {
                IsAdmin = true,
                Name = "Simon",
                PasswordSalt = passwordSaltUserTwo,
                PasswordHash = passwordHashUserTwo
            }).Entity;
            var SSA = ctx.Groups.Add(new Group()
            {
                Type = "SSA",
                Users = new List<User>
                {
                    userNormal,
                    userNormal2,
                    userNormal3
                }
            }).Entity;
            var SSH = ctx.Groups.Add(new Group()
            {
                Type = "SSH",
                Users = new List<User>
                {
                  userAdmin,
                }
            }).Entity;
            var UDD = ctx.Groups.Add(new Group()
            {
                Type = "UDD",
                Users = new List<User>
                {
                    userNormal2
                }
            }).Entity;

            var route1 = ctx.Routes.Add(new Route()
            {
                Name = "MA01",
                
            }).Entity;
            var route2 = ctx.Routes.Add(new Route()
            {
                Name = "MA02",
                
            }).Entity;
            var shift1 = ctx.Shifts.Add(new Shift()
            {
                Date = DateTime.Now,
                Route = route1,
                User = userNormal,
                TimeEnd = DateTime.MaxValue,
                TimeStart = DateTime.Today,
                ActiveRoute = true,
                RouteId = route1.Id
            }).Entity;

            var ps = ctx.PendingShifts.Add(new PendingShift()
            {
                Shift = shift1,
                Users = new List<UserPendingShift>()
                {
                    new UserPendingShift()
                    {
                        User = userNormal
                    }

                },
                ShiftId = shift1.Id
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