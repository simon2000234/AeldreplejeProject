using System;
using System.IO;
using AeldreplejeCore.Core.Application.Impl;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;
using Moq;
using Xunit;

namespace TestCore.Core.Application.Impl
{
    public class ShiftServiceTest
    {
        [Fact]
        public void CreateNullShiftThrowsException()
        {
            var shiftRepo = new Mock<IShiftRepo>();

            var service = new ShiftService(shiftRepo.Object);

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateShift(null));
            Assert.Equal("Shift most not be null", ex.Message);

        }

        [Fact]
        public void CreateShiftWithPastDateThrowsException()
        {
            var shiftRepo = new Mock<IShiftRepo>();

            var service = new ShiftService(shiftRepo.Object);

            var shift = new Shift()
            {
                Id = 1,
                ActiveRoute = true,
                Date = DateTime.MinValue
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateShift(shift));
            Assert.Equal("Shift's date most be after now", ex.Message);

        }

        [Fact]
        public void CreateShiftWithTimeStartOlderThenTimeEndThrowsException()
        {
            var shiftRepo = new Mock<IShiftRepo>();

            var service = new ShiftService(shiftRepo.Object);

            var shift = new Shift()
            {
                Id = 1,
                ActiveRoute = true,
                Date = DateTime.Now.AddDays(10),
                TimeStart = DateTime.Now.AddDays(2),
                TimeEnd = DateTime.Now.AddDays(1)
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateShift(shift));
            Assert.Equal("Shift's TimeStart must be before TimeEnd", ex.Message);

        }

        [Fact]
        public void CreateShiftWithPastTimeStartThrowsException()
        {
            var shiftRepo = new Mock<IShiftRepo>();

            var service = new ShiftService(shiftRepo.Object);

            var shift = new Shift()
            {
                Id = 1,
                ActiveRoute = true,
                Date = DateTime.Now.AddDays(666),
                TimeStart = DateTime.MinValue,
                TimeEnd = DateTime.Now.AddDays(3)
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateShift(shift));
            Assert.Equal("Shift's time start must be after now", ex.Message);

        }

        [Fact]
        public void CreateShiftWithPastTimeEndThrowsException()
        {
            var shiftRepo = new Mock<IShiftRepo>();

            var service = new ShiftService(shiftRepo.Object);

            var shift = new Shift()
            {
                Id = 1,
                ActiveRoute = true,
                Date = DateTime.Now.AddDays(666),
                TimeStart = DateTime.MinValue,
                TimeEnd = DateTime.MinValue.AddDays(3)
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateShift(shift));
            Assert.Equal("Shift's time end must be after now", ex.Message);

        }

        [Fact]
        public void UpdateNullShiftThrowsException()
        {
            var shiftRepo = new Mock<IShiftRepo>();

            var service = new ShiftService(shiftRepo.Object);

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateShift(null));
            Assert.Equal("Shift most not be null", ex.Message);

        }

        [Fact]
        public void UpdateShiftWithPastDateThrowsException()
        {
            var shiftRepo = new Mock<IShiftRepo>();

            var service = new ShiftService(shiftRepo.Object);

            var shift = new Shift()
            {
                Id = 1,
                ActiveRoute = true,
                Date = DateTime.MinValue
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateShift(shift));
            Assert.Equal("Shift's date most be after now", ex.Message);

        }

        [Fact]
        public void UpdateShiftWithTimeStartOlderThenTimeEndThrowsException()
        {
            var shiftRepo = new Mock<IShiftRepo>();

            var service = new ShiftService(shiftRepo.Object);

            var shift = new Shift()
            {
                Id = 1,
                ActiveRoute = true,
                Date = DateTime.Now.AddDays(10),
                TimeStart = DateTime.Now.AddDays(2),
                TimeEnd = DateTime.Now.AddDays(1)
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateShift(shift));
            Assert.Equal("Shift's TimeStart must be before TimeEnd", ex.Message);

        }

        [Fact]
        public void UpdateShiftWithPastTimeStartThrowsException()
        {
            var shiftRepo = new Mock<IShiftRepo>();

            var service = new ShiftService(shiftRepo.Object);

            var shift = new Shift()
            {
                Id = 1,
                ActiveRoute = true,
                Date = DateTime.Now.AddDays(666),
                TimeStart = DateTime.MinValue,
                TimeEnd = DateTime.Now.AddDays(3)
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateShift(shift));
            Assert.Equal("Shift's time start must be after now", ex.Message);

        }

        [Fact]
        public void UpdateShiftWithPastTimeEndThrowsException()
        {
            var shiftRepo = new Mock<IShiftRepo>();

            var service = new ShiftService(shiftRepo.Object);

            var shift = new Shift()
            {
                Id = 1,
                ActiveRoute = true,
                Date = DateTime.Now.AddDays(666),
                TimeStart = DateTime.MinValue,
                TimeEnd = DateTime.MinValue.AddDays(3)
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateShift(shift));
            Assert.Equal("Shift's time end must be after now", ex.Message);

        }

        [Fact]
        public void UpdateShiftWithNegativeOrZeroIdThrowsException()
        {
            var shiftRepo = new Mock<IShiftRepo>();

            var service = new ShiftService(shiftRepo.Object);

            var shift = new Shift()
            {
                Id = -1,
                ActiveRoute = true,
                Date = DateTime.Now.AddDays(666),
                TimeStart = DateTime.Now.AddDays(1),
                TimeEnd = DateTime.Now.AddDays(3)
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateShift(shift));
            Assert.Equal("Shift must a valid positive id", ex.Message);

        }
    }
}