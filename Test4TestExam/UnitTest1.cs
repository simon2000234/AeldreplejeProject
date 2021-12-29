using System;
using System.Collections;
using System.Collections.Generic;
using AeldreplejeCore.Core.Application.Impl;
using AeldreplejeCore.Core.Entity;
using Xunit;

namespace Test4TestExam
{
    public class UnitTest1
    {

        public UnitTest1()
        {
            IList<Group> groups = new List<Group>
            {
                new Group
                {
                    Type = "SSA",
                    QualificationNumber = 3,
                },
                new Group
                {
                    Type = "SSH",
                    QualificationNumber = 2,
                },
                new Group
                {
                    Type = "UDD",
                    QualificationNumber = 1
                }
            };

            IList<User> users = new List<User>
            {
                new User
                {
                    IsAdmin = false,
                    Name = "Christian",
                    Email = "christiansEmail@email.com",
                    Group = groups[0],
                    ProfilePicture =
                        "https://scontent-ams4-1.xx.fbcdn.net/v/t1.0-9/68397042_2373050946108579_1355476049231609856_n.jpg?_nc_cat=111&_nc_ohc=L-VxFCgmIOEAQkExKADS7GkFanYn-wlS1DtritGMIDMaz-F2F47jDBqdg&_nc_ht=scontent-ams4-1.xx&oh=d64bb5c81845f4af32142583c4d47f87&oe=5E89A221"
                },
                new User
                {
                    IsAdmin = false,
                    Name = "Richart",
                    Email = "richart@email.com",
                    ProfilePicture =
                        "https://scontent-ams4-1.xx.fbcdn.net/v/t1.0-9/13906839_10206396239896911_6785032534256698008_n.jpg?_nc_cat=100&_nc_ohc=NWUTbJTLB7oAQkf5171xXvT0S_v4pdlAB1wHR_kbXfXiZXd0kzXCiLjuA&_nc_ht=scontent-ams4-1.xx&oh=d38d30e968f89eff9eb1fe39ee3287c3&oe=5E68167D",
                    Group = groups[2]

                },
                new User
                {
                    IsAdmin = false,
                    Name = "Casper",
                    Email = "casper@email.com",
                    ProfilePicture = "https://scontent-ams4-1.xx.fbcdn.net/v/t1.0-9/12524001_1549641258661056_8462488784370177517_n.png?_nc_cat=109&_nc_ohc=_uulefV7bhEAQmqusa2XXfvuZdh72xF92JjafAdGC2NjGXJZ0RGgy2z2w&_nc_ht=scontent-ams4-1.xx&oh=1c4928765d11ea4940a2a00321425a65&oe=5E6815A3",
                    Group = groups[0],
                },
                new User
                {
                    IsAdmin = true,
                    Name = "Simon",
                    Email = "simon@email.com",
                    ProfilePicture = "https://imgix.bustle.com/elite-daily/2017/07/28103007/joffrey-game-of-thrones-choking.jpg?w=1020&h=574&fit=crop&crop=faces&auto=format&q=70",
                    Group = groups[1]
                },
            };
        }

        [Fact]
        public void Test1()
        {

        }


        public static IEnumerable<object[]> GetPShift()
        {
            var shifts = new List<object[]>
            {
                new object[]
                {
                    new PendingShift
                    {
                        Shift = new Shift {ShiftQualificationNumber = 2}

                    },
                    new User
                    {
                        Group = { Type = "SSH", QualificationNumber = 2}
                    }
                },
                new object[]
                {
                    new PendingShift
                    {
                        Shift = new Shift {ShiftQualificationNumber = 2}

                    },
                    new User
                    {
                        Group = { Type = "SSA", QualificationNumber = 3}
                    }
                },

            };

            return shifts;
        }

        // IsUserQualified tests
        [Fact]
        public void IsUserQualified_UserGroupIsNull_ThrowException()
        {
            // Arrange
            PendingShift tempShift = new PendingShift
            {
                Shift = new Shift {ShiftQualificationNumber = 2}

            };
            User tempUser = new User
            {
                Group = null
            };
            NotificationService ns = new NotificationService();

            // Act

            Action act = () => ns.IsUserQualified(tempShift, tempUser);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Theory]
        [MemberData(nameof(GetPShift))]
        public void IsUserQualified_UserGroupNotNullAndShiftQualificationLessOrEqualToUserQualification_True(PendingShift shift, User user)
        {
            // Arrange

            NotificationService ns = new NotificationService();

            // Act

            var result =  ns.IsUserQualified(shift, user);

            // Assert
            Assert.True(result);
        }
    }
}
