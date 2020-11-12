using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Services;

namespace Washi.API.Test
{
    class ServiceServiceTest
    {

        [Test]
        public async Task ListAsyncWhenNoServicesReturnsEmptyCollection()
        {
            //Arrange
            var mockServiceRepository = GetDefaultIServiceRepositoryInstance();
            mockServiceRepository.Setup(u => u.ListAsync())
                .ReturnsAsync(new List<Service>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new ServiceService(mockServiceRepository.Object, mockUnitOfWork.Object);

            //Act
            List<Service> result = (List<Service>)await service.ListAsync();
            var serviceCount = result.Count;

            //Assert
            serviceCount.Should().Equals(0);
        }

        private Mock<IServiceRepository> GetDefaultIServiceRepositoryInstance()
        {
            return new Mock<IServiceRepository>();
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
