using System;
using System.IO;
using AeldreplejeCore.Core.Application.Impl;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;
using Moq;
using Xunit;

namespace TestCore.Core.Application.Impl
{
    public class GroupServiceTest
    {
        [Fact]
        public void CreateNullGroupThrowsException()
        {
            var groupRepo = new Mock<IGroupRepo>();

            var service = new GroupService(groupRepo.Object);

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateGroup(null));
            Assert.Equal("Group most not be null", ex.Message);

        }

        [Fact]
        public void CreateGroupWithTypeNullThrowsException()
        {
            var groupRepo = new Mock<IGroupRepo>();

            var service = new GroupService(groupRepo.Object);

            var group = new Group()
            {
                Id = 1,
                Type = null
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateGroup(group));
            Assert.Equal("Group must have a type", ex.Message);
        }

        [Fact]
        public void CreateGroupWithTypeEmptyThrowsException()
        {
            var groupRepo = new Mock<IGroupRepo>();

            var service = new GroupService(groupRepo.Object);

            var group = new Group()
            {
                Id = 1,
                Type = ""
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateGroup(group));
            Assert.Equal("Group must have a type", ex.Message);
        }


        [Fact]
        public void UpdateNullGroupThrowsException()
        {
            var groupRepo = new Mock<IGroupRepo>();

            var service = new GroupService(groupRepo.Object);

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateGroup(null));
            Assert.Equal("Group most not be null", ex.Message);

        }

        [Fact]
        public void UpdateGroupWithTypeNullThrowsException()
        {
            var groupRepo = new Mock<IGroupRepo>();

            var service = new GroupService(groupRepo.Object);

            var group = new Group()
            {
                Id = 1,
                Type = null
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateGroup(group));
            Assert.Equal("Group must have a type", ex.Message);
        }

        [Fact]
        public void UpdateGroupWithTypeEmptyThrowsException()
        {
            var groupRepo = new Mock<IGroupRepo>();

            var service = new GroupService(groupRepo.Object);

            var group = new Group()
            {
                Id = 1,
                Type = ""
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateGroup(group));
            Assert.Equal("Group must have a type", ex.Message);
        }

        [Fact]
        public void UpdateGroupWithNegativeOrZeroIdThrowsException()
        {
            var groupRepo = new Mock<IGroupRepo>();

            var service = new GroupService(groupRepo.Object);

            var group = new Group()
            {
                Id = -1,
                Type = "Type"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateGroup(group));
            Assert.Equal("Group must have a valid positive id to update", ex.Message);
        }
    }
}