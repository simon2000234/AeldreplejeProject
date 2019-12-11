using System;
using System.IO;
using AeldreplejeCore.Core.Application.Impl;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;
using Moq;
using Xunit;

namespace TestCore.Core.Application.Impl
{
    public class TimeStartServiceTest
    {
        [Fact]
        public void CreateNullTimeStartThrowException()
        {
            var tsRepo = new Mock<ITimeStartRepo>();
            var tsService = new TimeStartService(tsRepo.Object);

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                tsService.CreateTimeStart(null));
            Assert.Equal("TimeStart can't be null", ex.Message);
        }
        [Fact]
        public void CreateTimeStartWithEmptyTimeThrowsException()
        {
            var tsRepo = new Mock<ITimeStartRepo>();
            var tsService = new TimeStartService(tsRepo.Object);

            var timeStart = new TimeStart()
            {
                id = 1,
                timeStart = ""
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                tsService.CreateTimeStart(timeStart));
            Assert.Equal("TimeStart can't be empty", ex.Message);

        }
        [Fact]
        public void CreateTimeStartIncorrectLengthTooLongThrowException()
        {
            var tsRepo = new Mock<ITimeStartRepo>();
            var tsService = new TimeStartService(tsRepo.Object);

            var timeStart = new TimeStart()
            {
                id = 1,
                timeStart = "666666"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                tsService.CreateTimeStart(timeStart));
            Assert.Equal("TimeStart string is too long/short, follow format HH:mm", ex.Message);
        }
        [Fact]
        public void CreateTimeStartIncorrectLengthTooShortThrowException()
        {
            var tsRepo = new Mock<ITimeStartRepo>();
            var tsService = new TimeStartService(tsRepo.Object);

            var timeStart = new TimeStart()
            {
                id = 1,
                timeStart = "4444"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                tsService.CreateTimeStart(timeStart));
            Assert.Equal("TimeStart string is too long/short, follow format HH:mm", ex.Message);
        }
        [Fact]
        public void CreateTimeStartNotNumbersThrowException()
        {
            var tsRepo = new Mock<ITimeStartRepo>();
            var tsService = new TimeStartService(tsRepo.Object);

            var timeStart = new TimeStart()
            {
                id = 1,
                timeStart = "hh:mm"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                tsService.CreateTimeStart(timeStart));
            Assert.Equal("TimeStart string has to be numbers", ex.Message);
        }
        [Fact]
        public void CreateTimeStartIncorrectFormatThrowException()
        {
            var tsRepo = new Mock<ITimeStartRepo>();
            var tsService = new TimeStartService(tsRepo.Object);

            var timeStart = new TimeStart()
            {
                id = 1,
                timeStart = "24355"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                tsService.CreateTimeStart(timeStart));
            Assert.Equal("TimeStart string has to be in format of HH:mm (ex 09:45)", ex.Message);
        }
        [Fact]
        public void CreateTimeStartWithIncorrectMinutesOutsideBoundThrowException()
        {
            var tsRepo = new Mock<ITimeStartRepo>();
            var tsService = new TimeStartService(tsRepo.Object);

            var timeStart = new TimeStart()
            {
                id = 1,
                timeStart = "23:60"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                tsService.CreateTimeStart(timeStart));
            Assert.Equal("TimeStart string minutes has to be 00-59", ex.Message);
        }
        [Fact]
        public void CreateTimeStartWithIncorrectMinutesOutsideLowerBoundThrowException()
        {
            var tsRepo = new Mock<ITimeStartRepo>();
            var tsService = new TimeStartService(tsRepo.Object);

            var timeStart = new TimeStart()
            {
                id = 1,
                timeStart = "23:-1"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                tsService.CreateTimeStart(timeStart));
            Assert.Equal("TimeStart string minutes has to be 00-59", ex.Message);
        }
        [Fact]
        public void CreateTimeStartWithIncorrectHoursOutsideBoundThrowException()
        {
            var tsRepo = new Mock<ITimeStartRepo>();
            var tsService = new TimeStartService(tsRepo.Object);

            var timeStart = new TimeStart()
            {
                id = 1,
                timeStart = "24:45"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                tsService.CreateTimeStart(timeStart));
            Assert.Equal("TimeStart string hours has to be 00-23", ex.Message);
        }
        [Fact]
        public void CreateTimeStartWithIncorrectHoursOutsideLowerBoundThrowException()
        {
            var tsRepo = new Mock<ITimeStartRepo>();
            var tsService = new TimeStartService(tsRepo.Object);

            var timeStart = new TimeStart()
            {
                id = 1,
                timeStart = "-1:45"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                tsService.CreateTimeStart(timeStart));
            Assert.Equal("TimeStart string hours has to be 00-23", ex.Message);
        }
    }
}