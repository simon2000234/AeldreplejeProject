using System;
using System.IO;
using AeldreplejeCore.Core.Application.Impl;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;
using Moq;
using Xunit;

namespace TestCore.Core.Application.Impl
{
    public class RouteServiceTest
    {
        [Fact]
        public void CreateNullRouteThrowsException()
        {
            var routeRepo = new Mock<IRouteRepo>();

            var service = new RouteService(routeRepo.Object);

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateRoute(null));
            Assert.Equal("Route most not be null", ex.Message);

        }

        [Fact]
        public void CreateRouteWithNameNullThrowsException()
        {
            var routeRepo = new Mock<IRouteRepo>();

            var service = new RouteService(routeRepo.Object);

            var route = new Route()
            {
                Id = 1,
                Name = null
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateRoute(route));
            Assert.Equal("Route must have a name", ex.Message);
        }

        [Fact]
        public void CreateRouteWithNameEmptyThrowsException()
        {
            var routeRepo = new Mock<IRouteRepo>();

            var service = new RouteService(routeRepo.Object);

            var route = new Route()
            {
                Id = 1,
                Name = ""
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateRoute(route));
            Assert.Equal("Route must have a name", ex.Message);
        }


        [Fact]
        public void UpdateNullRouteThrowsException()
        {
            var routeRepo = new Mock<IRouteRepo>();

            var service = new RouteService(routeRepo.Object);

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateRoute(null));
            Assert.Equal("Route most not be null", ex.Message);

        }

        [Fact]
        public void UpdateRouteWithNameNullThrowsException()
        {
            var routeRepo = new Mock<IRouteRepo>();

            var service = new RouteService(routeRepo.Object);

            var route = new Route()
            {
                Id = 1,
                Name = null
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateRoute(route));
            Assert.Equal("Route must have a name", ex.Message);
        }

        [Fact]
        public void UpdateRouteWithNameEmptyThrowsException()
        {
            var routeRepo = new Mock<IRouteRepo>();

            var service = new RouteService(routeRepo.Object);

            var route = new Route()
            {
                Id = 1,
                Name = ""
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateRoute(route));
            Assert.Equal("Route must have a name", ex.Message);
        }

        [Fact]
        public void UpdateRouteWithNegativeOrZeroIdThrowsException()
        {
            var routeRepo = new Mock<IRouteRepo>();

            var service = new RouteService(routeRepo.Object);

            var route = new Route()
            {
                Id = -1,
                Name = "Name"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.UpdateRoute(route));
            Assert.Equal("Route must have a valid positive id to update", ex.Message);
        }
    }
}