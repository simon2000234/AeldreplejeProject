﻿using System;
using System.IO;
using AeldreplejeCore.Core.Application.Impl;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;
using Xunit;
using Moq;
namespace TestCore.Core.Application.Impl
{
    public class UserServiceTest
    {
        [Fact]
        public void CreateNullUserThrowsException()
        {
            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateUser(null));
            Assert.Equal("User most not be null", ex.Message);

        }

        [Fact]
        public void CreateUserWithEmptyNameThrowsException()
        {
            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            var user = new User()
            {
                Name = "",
                Email = "Email@email.com",
                Id = 1,
                IsAdmin = true,
                Role = "Normal",
                ProfilePicture = "whatthefuck.jpg"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateUser(user));
            Assert.Equal("User must have a name", ex.Message);

        }
        [Fact]
        public void CreateUserWithNullNameThrowsException()
        {
            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            var user = new User()
            {
                Name = null,
                Email = "Email@email.com",
                Id = 1,
                IsAdmin = true,
                Role = "Normal",
                ProfilePicture = "whatthefuck.jpg"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateUser(user));
            Assert.Equal("User must have a name", ex.Message);

        }

        [Fact]
        public void CreateUserWithNullEmailThrowsException()
        {
            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            var user = new User()
            {
                Name = "Dabdab",
                Email = null,
                Id = 1,
                IsAdmin = true,
                Role = "Normal",
                ProfilePicture = "whatthefuck.jpg"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateUser(user));
            Assert.Equal("User must have an Email", ex.Message);

        }

        [Fact]
        public void CreateUserWithEmptyEmailThrowsException()
        {
            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            var user = new User()
            {
                Name = "Dabdab",
                Email = "",
                Id = 1,
                IsAdmin = true,
                Role = "Normal",
                ProfilePicture = "whatthefuck.jpg"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateUser(user));
            Assert.Equal("User must have an Email", ex.Message);

        }

        [Fact]
        public void CreateUserWithNoAddInEmailThrowsException()
        {
            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            var user = new User()
            {
                Name = "Dabdab",
                Email = "Emailemail.com",
                Id = 1,
                IsAdmin = true,
                Role = "Normal",
                ProfilePicture = "whatthefuck.jpg"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateUser(user));
            Assert.Equal("User must have an @ in the Email", ex.Message);

        }

        [Fact]
        public void CreateUserWithNoDotInEmailThrowsException()
        {
            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            var user = new User()
            {
                Name = "Dabdab",
                Email = "Email@emailcom",
                Id = 1,
                IsAdmin = true,
                Role = "Normal",
                ProfilePicture = "whatthefuck.jpg"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateUser(user));
            Assert.Equal("User must end with .something in the Email", ex.Message);

        }

        [Fact]
        public void CreateUserWithMultipleAddsInTheirEmailThrowsException()
        {
            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            var user = new User()
            {
                Name = "Dabdab",
                Email = "E@mail@email.com",
                Id = 1,
                IsAdmin = true,
                Role = "Normal",
                ProfilePicture = "whatthefuck.jpg"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateUser(user));
            Assert.Equal("User's email may only have one @ in them", ex.Message);

        }

        [Fact]
        public void CreateUserWithNullGroupThrowsException()
        {
            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            var user = new User()
            {
                Name = "Dabdab",
                Email = "Email@email.com",
                Id = 1,
                IsAdmin = true,
                Role = "Normal",
                ProfilePicture = "whatthefuck.jpg",
                Group = null
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateUser(user));
            Assert.Equal("User must have a group", ex.Message);

        }

        /*[Fact]
        public void CreateUserWithGroupTheGroupShouldExistThrowsException()
        {
            var group = new Group()
            {
                Id = 1,
                Type = "VinVin"
            };

            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            var user = new User()
            {
                Name = "Dabdab",
                Email = "Email@email.com",
                Id = 1,
                IsAdmin = true,
                Role = "Normal",
                ProfilePicture = "whatthefuck.jpg",
                Group = group
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateUser(user));
            //orderRepo.Verify(x => x.Create(It.IsAny<Order>()), Times.Once);
            Assert.Equal(1, 2);

        }*/

        [Fact]
        public void UpdateNullUserThrowsException()
        {
            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateUser(null));
            Assert.Equal("User most not be null", ex.Message);

        }

        [Fact]
        public void UpdateUserWithEmptyNameThrowsException()
        {
            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            var user = new User()
            {
                Name = "",
                Email = "Email@email.com",
                Id = 1,
                IsAdmin = true,
                Role = "Normal",
                ProfilePicture = "whatthefuck.jpg"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateUser(user));
            Assert.Equal("User must have a name", ex.Message);

        }
        [Fact]
        public void UpdateUserWithNullNameThrowsException()
        {
            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            var user = new User()
            {
                Name = null,
                Email = "Email@email.com",
                Id = 1,
                IsAdmin = true,
                Role = "Normal",
                ProfilePicture = "whatthefuck.jpg"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateUser(user));
            Assert.Equal("User must have a name", ex.Message);

        }

        [Fact]
        public void UpdateUserWithNullEmailThrowsException()
        {
            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            var user = new User()
            {
                Name = "Dabdab",
                Email = null,
                Id = 1,
                IsAdmin = true,
                Role = "Normal",
                ProfilePicture = "whatthefuck.jpg"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateUser(user));
            Assert.Equal("User must have an Email", ex.Message);

        }

        [Fact]
        public void UpdateUserWithEmptyEmailThrowsException()
        {
            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            var user = new User()
            {
                Name = "Dabdab",
                Email = "",
                Id = 1,
                IsAdmin = true,
                Role = "Normal",
                ProfilePicture = "whatthefuck.jpg"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateUser(user));
            Assert.Equal("User must have an Email", ex.Message);

        }

        [Fact]
        public void UpdateUserWithNoAddInEmailThrowsException()
        {
            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            var user = new User()
            {
                Name = "Dabdab",
                Email = "Emailemail.com",
                Id = 1,
                IsAdmin = true,
                Role = "Normal",
                ProfilePicture = "whatthefuck.jpg"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateUser(user));
            Assert.Equal("User must have an @ in the Email", ex.Message);

        }

        [Fact]
        public void UpdateUserWithNoDotInEmailThrowsException()
        {
            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            var user = new User()
            {
                Name = "Dabdab",
                Email = "Email@emailcom",
                Id = 1,
                IsAdmin = true,
                Role = "Normal",
                ProfilePicture = "whatthefuck.jpg"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateUser(user));
            Assert.Equal("User must end with .something in the Email", ex.Message);

        }

        [Fact]
        public void UpdateUserWithMultipleAddsInTheirEmailThrowsException()
        {
            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            var user = new User()
            {
                Name = "Dabdab",
                Email = "E@mail@email.com",
                Id = 1,
                IsAdmin = true,
                Role = "Normal",
                ProfilePicture = "whatthefuck.jpg"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateUser(user));
            Assert.Equal("User's email may only have one @ in them", ex.Message);

        }

        [Fact]
        public void UpdateUserWithNegativeOrZeroIdThrowsException()
        {
            var group = new Group()
            {
                Id = 1,
                Type = "VinVin"
            };

            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            var user = new User()
            {
                Name = "Dabdab",
                Email = "Email@email.com",
                Id = -1,
                IsAdmin = true,
                Role = "Normal",
                ProfilePicture = "whatthefuck.jpg",
                Group = group
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateUser(user));
            Assert.Equal("User must have a valid positive id to update", ex.Message);
        }

        [Fact]
        public void UpdateUserWithNullGroupThrowsException()
        {

            var userRepo = new Mock<IUserRepo>();

            var service = new UserService(userRepo.Object);

            var user = new User()
            {
                Name = "Dabdab",
                Email = "Email@email.com",
                Id = 1,
                IsAdmin = true,
                Role = "Normal",
                ProfilePicture = "whatthefuck.jpg",
                Group = null
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateUser(user));
            Assert.Equal("User must have a group", ex.Message);

        }
    }
}