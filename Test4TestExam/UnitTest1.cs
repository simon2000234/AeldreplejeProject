using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AeldreplejeCore.Core.Application.Impl;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;
using Microsoft.IdentityModel.Tokens;
using Moq;
using Xunit;

namespace Test4TestExam
{
    public class UnitTest1
    {
        private IUserRepo moqUserRepo;
        private IPendingShiftRepo moqPendingShiftRepo;
        private NotificationService ns = new NotificationService();

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

            IList<Shift> shifts = new List<Shift>
            {
                new Shift
                {
                    ActiveRoute = true,
                    ShiftQualificationNumber = 1,
                    TimeStart = new DateTime(2023, 1, 1, 10, 0, 0),
                    TimeEnd = new DateTime(2023, 1, 1, 18, 0, 0),
                    Date = new DateTime(2023, 1, 1, 10, 0, 0),
                },
                new Shift
                {
                    ActiveRoute = true,
                    ShiftQualificationNumber = 1,
                    TimeStart = new DateTime(2023, 1, 2, 10, 0, 0),
                    TimeEnd = new DateTime(2023, 1, 2, 18, 0, 0),
                    Date = new DateTime(2023, 1, 2, 10, 0, 0),
                },
                new Shift
                {
                    ActiveRoute = true,
                    ShiftQualificationNumber = 1,
                    TimeStart = new DateTime(2023, 1, 3, 10, 0, 0),
                    TimeEnd = new DateTime(2023, 1, 3, 18, 0, 0),
                    Date = new DateTime(2023, 1, 3, 10, 0, 0),
                },
                new Shift
                {
                    ActiveRoute = true,
                    ShiftQualificationNumber = 2,
                    TimeStart = new DateTime(2023, 1, 4, 10, 0, 0),
                    TimeEnd = new DateTime(2023, 1, 4, 18, 0, 0),
                    Date = new DateTime(2023, 1, 4, 10, 0, 0),
                },
                new Shift
                {
                    ActiveRoute = true,
                    ShiftQualificationNumber = 2,
                    TimeStart = new DateTime(2023, 1, 5, 10, 0, 0),
                    TimeEnd = new DateTime(2023, 1, 5, 18, 0, 0),
                    Date = new DateTime(2023, 1, 5, 10, 0, 0),
                },
                new Shift
                {
                    ActiveRoute = true,
                    ShiftQualificationNumber = 2,
                    TimeStart = new DateTime(2023, 1, 6, 10, 0, 0),
                    TimeEnd = new DateTime(2023, 1, 6, 18, 0, 0),
                    Date = new DateTime(2023, 1, 6, 10, 0, 0),
                },
                new Shift
                {
                    ActiveRoute = true,
                    ShiftQualificationNumber = 3,
                    TimeStart = new DateTime(2023, 1, 7, 10, 0, 0),
                    TimeEnd = new DateTime(2023, 1, 7, 18, 0, 0),
                    Date = new DateTime(2023, 1, 7, 10, 0, 0),
                },
                new Shift
                {
                    ActiveRoute = true,
                    ShiftQualificationNumber = 3,
                    TimeStart = new DateTime(2023, 1, 8, 10, 0, 0),
                    TimeEnd = new DateTime(2023, 1, 8, 18, 0, 0),
                    Date = new DateTime(2023, 1, 8, 10, 0, 0),
                },
                new Shift
                {
                    ActiveRoute = true,
                    ShiftQualificationNumber = 3,
                    TimeStart = new DateTime(2023, 1, 9, 10, 0, 0),
                    TimeEnd = new DateTime(2023, 1, 9, 18, 0, 0),
                    Date = new DateTime(2023, 1, 9, 10, 0, 0),
                },
            };

            List<PendingShift> pshifts = new List<PendingShift>();
            for (int i = 1; i <= shifts.Count; i++)
            {
                pshifts.Add(new PendingShift
                {
                    Id = i,
                    Shift = shifts[i-1]
                });
            }

            List<User> users = new List<User>
            {
                new User
                {
                    Id = 1,
                    IsAdmin = false,
                    Name = "Christian",
                    Email = "christiansEmail@email.com",
                    Group = groups[2],
                    ProfilePicture =
                        "https://scontent-ams4-1.xx.fbcdn.net/v/t1.0-9/68397042_2373050946108579_1355476049231609856_n.jpg?_nc_cat=111&_nc_ohc=L-VxFCgmIOEAQkExKADS7GkFanYn-wlS1DtritGMIDMaz-F2F47jDBqdg&_nc_ht=scontent-ams4-1.xx&oh=d64bb5c81845f4af32142583c4d47f87&oe=5E89A221"
                },
                new User
                {
                    Id = 2,
                    IsAdmin = false,
                    Name = "Richart",
                    Email = "richart@email.com",
                    ProfilePicture =
                        "https://scontent-ams4-1.xx.fbcdn.net/v/t1.0-9/13906839_10206396239896911_6785032534256698008_n.jpg?_nc_cat=100&_nc_ohc=NWUTbJTLB7oAQkf5171xXvT0S_v4pdlAB1wHR_kbXfXiZXd0kzXCiLjuA&_nc_ht=scontent-ams4-1.xx&oh=d38d30e968f89eff9eb1fe39ee3287c3&oe=5E68167D",
                    Group = groups[1]

                },
                new User
                {
                    Id = 3,
                    IsAdmin = false,
                    Name = "Casper",
                    Email = "casper@email.com",
                    ProfilePicture = "https://scontent-ams4-1.xx.fbcdn.net/v/t1.0-9/12524001_1549641258661056_8462488784370177517_n.png?_nc_cat=109&_nc_ohc=_uulefV7bhEAQmqusa2XXfvuZdh72xF92JjafAdGC2NjGXJZ0RGgy2z2w&_nc_ht=scontent-ams4-1.xx&oh=1c4928765d11ea4940a2a00321425a65&oe=5E6815A3",
                    Group = groups[0],
                },
                new User
                {
                    Id = 4,
                    IsAdmin = true,
                    Name = "Simon",
                    Email = "simon@email.com",
                    ProfilePicture = "https://imgix.bustle.com/elite-daily/2017/07/28103007/joffrey-game-of-thrones-choking.jpg?w=1020&h=574&fit=crop&crop=faces&auto=format&q=70",
                    Group = groups[0]
                },
            };

            Mock<IUserRepo> mockUserRepo = new Mock<IUserRepo>();
            mockUserRepo.Setup(mur => mur.GetAllUsers()).Returns(users);
            mockUserRepo.Setup(mur => mur.GetUser(It.IsAny<int>()))
                .Returns((int id) => users.FirstOrDefault(user => user.Id == id));
            Mock<IPendingShiftRepo> mockPendingShiftRepo = new Mock<IPendingShiftRepo>();
            mockPendingShiftRepo.Setup(mpsr => mpsr.GetAllPendingShift()).Returns(pshifts);
            mockPendingShiftRepo.Setup(mpsr => mpsr.GetPendingShift(It.IsAny<int>()))
                .Returns((int id) => pshifts.FirstOrDefault(pshift => pshift.Id == id));

            moqUserRepo = mockUserRepo.Object;
            moqPendingShiftRepo = mockPendingShiftRepo.Object;

        }


        public static IEnumerable<object[]> GetPShift()
        {
            PendingShift temp = new PendingShift
            {
                Shift = new Shift {ShiftQualificationNumber = 2}

            };
            User tempUser = new User
            {
                Group = new Group {Type = "SSH", QualificationNumber = 2}
            };
            User tempUser2 = new User
            {
                Group = new Group{Type = "SSA", QualificationNumber = 3}
            };

            var shifts = new List<object[]>
            {
                new object[]
                {
                    temp,
                    tempUser
                },
                new object[]
                {
                    temp,
                    tempUser2
                },

            };

            return shifts;
        }

        // IsUserQualified tests

        // Rød
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

            // Act

            Action act = () => ns.IsUserQualified(tempShift, tempUser);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        // Grøn
        [Theory]
        [MemberData(nameof(GetPShift))]
        public void IsUserQualified_UserGroupNotNullAndShiftQualificationLessOrEqualToUserQualification_True(PendingShift shift, User user)
        {
            // Arrange

            // Act
            var result =  ns.IsUserQualified(shift, user);

            // Assert
            Assert.True(result);
        }

        // Blå
        [Fact]
        public void IsUserQualified_UserGroupNotNullAndShiftQualificationGreaterThanUserQualification_False()
        {
            // Arrange
            var user = moqUserRepo.GetUser(1);
            var pshift = moqPendingShiftRepo.GetPendingShift(9);

            // Act
            var result = ns.IsUserQualified(pshift, user);

            // Assert
            Assert.False(result);
        }


        // IsUserAlreadyBooked tests

        // Rød - Mutli Conditions True/True
        [Fact]
        public void IsUserAlreadyBooked_UserAlreadyBooked_TimeStartWithinShiftPeriod_ReturnTrue()
        {
            // Arrange
            var user = moqUserRepo.GetUser(3);
            var pshift = moqPendingShiftRepo.GetPendingShift(1);
            user.Shifts = new List<Shift>
            {
                new Shift
                {
                    Date = pshift.Shift.Date,
                    TimeStart = pshift.Shift.TimeStart.AddHours(-1),
                    TimeEnd = pshift.Shift.TimeEnd
                },
            };

            // Act
            var result = ns.IsUserAlreadyBooked(pshift, user);

            // Assert
            Assert.True(result);
        }

        // Rød 2 - Mutli Conditions False/-
        [Fact]
        public void IsUserAlreadyBooked_UserAlreadyBooked_TimeStartLessThanCurrentTimeStart_ReturnFalse()
        {
            // Arrange
            var user = moqUserRepo.GetUser(3);
            var pshift = moqPendingShiftRepo.GetPendingShift(1);
            user.Shifts = new List<Shift>
            {
                new Shift
                {
                    Date = pshift.Shift.Date,
                    TimeStart = pshift.Shift.TimeStart.AddHours(1),
                    TimeEnd = pshift.Shift.TimeEnd
                },
            };

            // Act
            var result = ns.IsUserAlreadyBooked(pshift, user);

            // Assert
            Assert.False(result);
        }

        // Rød 3 - Mutli Conditions True/False
        [Fact]
        public void IsUserAlreadyBooked_UserAlreadyBooked_TimeStartLessThanCurrentTimeEnd_ReturnFalse()
        {
            // Arrange
            var user = moqUserRepo.GetUser(3);
            var pshift = moqPendingShiftRepo.GetPendingShift(1);
            user.Shifts = new List<Shift>
            {
                new Shift
                {
                    Date = pshift.Shift.Date,
                    TimeStart = pshift.Shift.TimeStart.AddHours(-2),
                    TimeEnd = pshift.Shift.TimeEnd.AddHours(-9)
                },
            };

            // Act
            var result = ns.IsUserAlreadyBooked(pshift, user);

            // Assert
            Assert.False(result);
        }

        // Lilla - Mutli Conditions True/True
        [Fact]
        public void IsUserAlreadyBooked_UserAlreadyBooked_TimeEndWithinShiftPeriod_ReturnTrue()
        {
            // Arrange
            var user = moqUserRepo.GetUser(3);
            var pshift = moqPendingShiftRepo.GetPendingShift(1);
            user.Shifts = new List<Shift>
            {
                new Shift
                {
                    Date = pshift.Shift.Date,
                    TimeStart = pshift.Shift.TimeStart,
                    TimeEnd = pshift.Shift.TimeEnd.AddHours(1)
                },
            };

            // Act
            var result = ns.IsUserAlreadyBooked(pshift, user);

            // Assert
            Assert.True(result);
        }

        // Lilla 2 - Mutli Conditions False/-
        [Fact]
        public void IsUserAlreadyBooked_UserAlreadyBooked_TimeEndLessThanCurrentTimeStart_ReturnFalse()
        {
            // Arrange
            var user = moqUserRepo.GetUser(3);
            var pshift = moqPendingShiftRepo.GetPendingShift(1);
            user.Shifts = new List<Shift>
            {
                new Shift
                {
                    Date = pshift.Shift.Date,
                    TimeStart = pshift.Shift.TimeStart.AddHours(12),
                    TimeEnd = pshift.Shift.TimeEnd
                },
            };

            // Act
            var result = ns.IsUserAlreadyBooked(pshift, user);

            // Assert
            Assert.False(result);
        }

        // Lilla 3 - Mutli Conditions True/False
        [Fact]
        public void IsUserAlreadyBooked_UserAlreadyBooked_TimeEndGreaterThanCurrentTimeEnd_ReturnFalse()
        {
            // Arrange
            var user = moqUserRepo.GetUser(3);
            var pshift = moqPendingShiftRepo.GetPendingShift(1);
            user.Shifts = new List<Shift>
            {
                new Shift
                {
                    Date = pshift.Shift.Date,
                    TimeStart = pshift.Shift.TimeStart,
                    TimeEnd = pshift.Shift.TimeEnd.AddHours(-1)
                },
            };

            // Act
            var result = ns.IsUserAlreadyBooked(pshift, user);

            // Assert
            Assert.False(result);
        }

        // Blå
        [Fact]
        public void IsUserAlreadyBooked_UserNotAlreadyBooked_NewShiftOutsideCurrentShiftsPeriod_ReturnFalse()
        {
            // Arrange
            var user = moqUserRepo.GetUser(3);
            var pshift = moqPendingShiftRepo.GetPendingShift(1);
            user.Shifts = new List<Shift>
            {
                new Shift
                {
                    Date = pshift.Shift.Date,
                    TimeStart = pshift.Shift.TimeStart.AddHours(10),
                    TimeEnd = pshift.Shift.TimeEnd.AddHours(10)
                },
            };

            // Act
            var result = ns.IsUserAlreadyBooked(pshift, user);

            // Assert
            Assert.False(result);
        }

        // Grøn
        [Fact]
        public void IsUserAlreadyBooked_UserNotAlreadyBooked_NewShiftOnDifferentDay_ReturnFalse()
        {
            // Arrange
            var user = moqUserRepo.GetUser(3);
            var pshift = moqPendingShiftRepo.GetPendingShift(1);
            user.Shifts = new List<Shift>
            {
                new Shift
                {
                    Date = pshift.Shift.Date.AddDays(1),
                    TimeStart = pshift.Shift.TimeStart,
                    TimeEnd = pshift.Shift.TimeEnd
                },
            };

            // Act
            var result = ns.IsUserAlreadyBooked(pshift, user);

            // Assert
            Assert.False(result);
        }

        // Gul
        [Fact]
        public void IsUserAlreadyBooked_UserNotAlreadyBooked_UserHasNoShfits_ReturnFalse()
        {
            // Arrange
            var user = moqUserRepo.GetUser(3);
            var pshift = moqPendingShiftRepo.GetPendingShift(1);
            user.Shifts = new List<Shift>();

            // Act
            var result = ns.IsUserAlreadyBooked(pshift, user);

            // Assert
            Assert.False(result);
        }


        // HasTooManyShifts tests

        // Rød Multi Conditions True/True
        [Fact]
        public void HasTooManyShifts_UserHasMaximumShifts_ReturnTrue()
        {
            // Arrange
            var user = moqUserRepo.GetUser(3);
            var newPShift = moqPendingShiftRepo.GetPendingShift(5);
            var pshifts = moqPendingShiftRepo.GetAllPendingShift();
            user.Shifts = new List<Shift>();
            foreach (var pshift in pshifts)
            {
                user.Shifts.Add(pshift.Shift);
            }

            // Act
            var result = ns.HasTooManyShifts(user, newPShift.Shift.Date, 5); // Max 5 shifts in a week

            // Assert
            Assert.True(result);
        }

        // Rød 2 - Multi Conditions False/-
        [Fact]
        public void HasTooManyShifts_NewShiftDifferentWeek_ReturnFalse()
        {
            // Arrange
            var user = moqUserRepo.GetUser(3);
            var newPShift = moqPendingShiftRepo.GetPendingShift(5);
            var pshifts = moqPendingShiftRepo.GetAllPendingShift();
            user.Shifts = new List<Shift>();
            foreach (var pshift in pshifts)
            {
                user.Shifts.Add(pshift.Shift);
            }

            // Act
            var result = ns.HasTooManyShifts(user, newPShift.Shift.Date.AddDays(14), 5); // Max 5 shifts in a week

            // Assert
            Assert.False(result);
        }

        // Rød 3 - Multi Conditions True/False
        [Fact]
        public void HasTooManyShifts_NewShiftDifferentYear_ReturnFalse()
        {
            // Arrange
            var user = moqUserRepo.GetUser(3);
            var newPShift = moqPendingShiftRepo.GetPendingShift(5);
            var pshifts = moqPendingShiftRepo.GetAllPendingShift();
            user.Shifts = new List<Shift>();
            foreach (var pshift in pshifts)
            {
                user.Shifts.Add(pshift.Shift);
            }

            // Act
            var result = ns.HasTooManyShifts(user, newPShift.Shift.Date.AddYears(1), 5); // Max 5 shifts in a week

            // Assert
            Assert.False(result);
        }

        // Grøn
        [Fact]
        public void HasTooManyShifts_UserDoesNotHaveMaxShifts_ReturnFalse()
        {
            // Arrange
            var user = moqUserRepo.GetUser(3);
            var newPShift = moqPendingShiftRepo.GetPendingShift(5);
            var pshifts = moqPendingShiftRepo.GetAllPendingShift();
            user.Shifts = new List<Shift>();
            foreach (var pshift in pshifts)
            {
                user.Shifts.Add(pshift.Shift);
            }

            // Act
            var result = ns.HasTooManyShifts(user, newPShift.Shift.Date.AddYears(1).AddDays(14), 10); // Max 10 shifts in a week

            // Assert
            Assert.False(result);
        }

        // Blå
        [Fact]
        public void HasTooManyShifts_UserHasZeroShiftsAndMaxShiftBiggerThanZero_ReturnFalse()
        {
            // Arrange
            var user = moqUserRepo.GetUser(3);
            var newPShift = moqPendingShiftRepo.GetPendingShift(5);
            user.Shifts = new List<Shift>();

            // Act
            var result = ns.HasTooManyShifts(user, newPShift.Shift.Date, 1); // Max 10 shifts in a week

            // Assert
            Assert.False(result);
        }
    }
}
