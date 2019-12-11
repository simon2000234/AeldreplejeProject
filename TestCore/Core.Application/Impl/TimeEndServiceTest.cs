using System;
using System.IO;
using AeldreplejeCore.Core.Application.Impl;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;
using Moq;
using Xunit;

namespace TestCore.Core.Application.Impl
{
    public class TimeEndServiceTest
    {
        [Fact]
        public void CreateNullTimeStopThrowException()
        {
            var teRepo = new Mock<ITimeEndRepo>();
            var teService = new TimeEndService(teRepo.Object);

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                teService.CreateTimeEnd(null));
            Assert.Equal("TimeEnd can't be null", ex.Message);
        }
        [Fact]
        public void CreateTimeEndWithEmptyTimeThrowsException()
        {
            var teRepo = new Mock<ITimeEndRepo>();
            var teService = new TimeEndService(teRepo.Object);

            var timeEnd = new TimeEnd()
            {
                id = 1,
                timeEnd = ""
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                teService.CreateTimeEnd(timeEnd));
            Assert.Equal("TimeEnd can't be empty", ex.Message);

        }
        [Fact]
        public void CreateTimeEndIncorrectLengthTooLongThrowException()
        {
            var teRepo = new Mock<ITimeEndRepo>();
            var teService = new TimeEndService(teRepo.Object);

            var timeEnd = new TimeEnd()
            {
                id = 1,
                timeEnd = "666666"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                teService.CreateTimeEnd(timeEnd));
            Assert.Equal("TimeEnd string is too long/short, follow format HH:mm", ex.Message);
        }
        [Fact]
        public void CreateTimeEndIncorrectLengthTooShortThrowException()
        {
            var teRepo = new Mock<ITimeEndRepo>();
            var teService = new TimeEndService(teRepo.Object);

            var timeEnd = new TimeEnd()
            {
                id = 1,
                timeEnd = "4444"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                teService.CreateTimeEnd(timeEnd));
            Assert.Equal("TimeEnd string is too long/short, follow format HH:mm", ex.Message);
        }
        [Fact]
        public void CreateTimeEndNotNumbersThrowException()
        {
            var teRepo = new Mock<ITimeEndRepo>();
            var teService = new TimeEndService(teRepo.Object);

            var timeEnd = new TimeEnd()
            {
                id = 1,
                timeEnd = "hh:mm"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                teService.CreateTimeEnd(timeEnd));
            Assert.Equal("TimeEnd string has to be numbers", ex.Message);
        }
        [Fact]
        public void CreateTimeEndIncorrectFormatThrowException()
        {
            var teRepo = new Mock<ITimeEndRepo>();
            var teService = new TimeEndService(teRepo.Object);

            var timeEnd = new TimeEnd()
            {
                id = 1,
                timeEnd = "24355"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                teService.CreateTimeEnd(timeEnd));
            Assert.Equal("TimeEnd string has to be in format of HH:mm (ex 09:45)", ex.Message);
        }
        [Fact]
        public void CreateTimeEndWithIncorrectMinutesOutsideBoundThrowException()
        {
            var teRepo = new Mock<ITimeEndRepo>();
            var teService = new TimeEndService(teRepo.Object);

            var timeEnd = new TimeEnd()
            {
                id = 1,
                timeEnd = "23:60"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                teService.CreateTimeEnd(timeEnd));
            Assert.Equal("TimeEnd string minutes has to be 00-59", ex.Message);
        }
        [Fact]
        public void CreateTimeEndWithIncorrectMinutesOutsideLowerBoundThrowException()
        {
            var teRepo = new Mock<ITimeEndRepo>();
            var teService = new TimeEndService(teRepo.Object);

            var timeEnd = new TimeEnd()
            {
                id = 1,
                timeEnd = "23:-1"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                teService.CreateTimeEnd(timeEnd));
            Assert.Equal("TimeEnd string minutes has to be 00-59", ex.Message);
        }
        [Fact]
        public void CreateTimeEndWithIncorrectHoursOutsideBoundThrowException()
        {
            var teRepo = new Mock<ITimeEndRepo>();
            var teService = new TimeEndService(teRepo.Object);

            var timeEnd = new TimeEnd()
            {
                id = 1,
                timeEnd = "24:45"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                teService.CreateTimeEnd(timeEnd));
            Assert.Equal("TimeEnd string hours has to be 00-23", ex.Message);
        }
        [Fact]
        public void CreateTimeEndWithIncorrectHoursOutsideLowerBoundThrowException()
        {
            var teRepo = new Mock<ITimeEndRepo>();
            var teService = new TimeEndService(teRepo.Object);

            var timeEnd = new TimeEnd()
            {
                id = 1,
                timeEnd = "-1:45"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                teService.CreateTimeEnd(timeEnd));
            Assert.Equal("TimeEnd string hours has to be 00-23", ex.Message);
        }
    }
}