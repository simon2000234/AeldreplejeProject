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
                Email = "richart@email.com",
                ProfilePicture = "https://scontent-ams4-1.xx.fbcdn.net/v/t1.0-9/13906839_10206396239896911_6785032534256698008_n.jpg?_nc_cat=100&_nc_ohc=NWUTbJTLB7oAQkf5171xXvT0S_v4pdlAB1wHR_kbXfXiZXd0kzXCiLjuA&_nc_ht=scontent-ams4-1.xx&oh=d38d30e968f89eff9eb1fe39ee3287c3&oe=5E68167D",
                PasswordSalt = passwordSaltUserOne,
                PasswordHash = passwordHashUserOne
            }).Entity;
            var userNormal3 = ctx.Users.Add(new User()
            {
                IsAdmin = false,
                Name = "Casper",
                Email = "casper@email.com",
                ProfilePicture =  "https://scontent-ams4-1.xx.fbcdn.net/v/t1.0-9/12524001_1549641258661056_8462488784370177517_n.png?_nc_cat=109&_nc_ohc=_uulefV7bhEAQmqusa2XXfvuZdh72xF92JjafAdGC2NjGXJZ0RGgy2z2w&_nc_ht=scontent-ams4-1.xx&oh=1c4928765d11ea4940a2a00321425a65&oe=5E6815A3"
                ,PasswordSalt = passwordSaltUserOne,
                PasswordHash = passwordHashUserOne
            }).Entity;

            var userAdmin = ctx.Users.Add(new User()
            {
                IsAdmin = true,
                Name = "Simon",
                Email = "simon@email.com",
                ProfilePicture = "https://imgix.bustle.com/elite-daily/2017/07/28103007/joffrey-game-of-thrones-choking.jpg?w=1020&h=574&fit=crop&crop=faces&auto=format&q=70",
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

            var ar = ctx.ActiveRoutes.Add(new ActiveRoute()
            {
                Name = "MA01"
            }).Entity;
            var ar2 = ctx.ActiveRoutes.Add(new ActiveRoute()
            {
                Name = "MA02"
            }).Entity;
            var ar3 = ctx.ActiveRoutes.Add(new ActiveRoute()
            {
                Name = "MA03"
            }).Entity;
            var ar4 = ctx.ActiveRoutes.Add(new ActiveRoute()
            {
                Name = "MA10"
            }).Entity;

            var ts = ctx.TimeStarts.Add(new TimeStart()
            {
                timeStart = "15:00"
            }).Entity;
            var ts2 = ctx.TimeStarts.Add(new TimeStart()
            {
                timeStart = "15:30"
            }).Entity;
            var ts3 = ctx.TimeStarts.Add(new TimeStart()
            {
                timeStart = "16:00"
            }).Entity;
            var ts4 = ctx.TimeStarts.Add(new TimeStart()
            {
                timeStart = "16:30"
            }).Entity;

            var te = ctx.TimeEnds.Add(new TimeEnd()
            {
                timeEnd = "23:00"
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