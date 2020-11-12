using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Services;

namespace Washi.API.Test
{
    class ServiceMaterialServiceTest
    {

        [Test]
        public async Task ListAsyncWhenNoServiceMaterialsReturnsEmptyCollection()
        {
            //Arrange
            var mockServiceMaterialRepository = GetDefaultIServiceMaterialRepositoryInstance();
            var mockMaterialRepository = GetDefaultIMaterialRepositoryInstance();
            mockServiceMaterialRepository.Setup(u => u.ListAsync())
                .ReturnsAsync(new List<ServiceMaterial>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new ServiceMaterialService(mockMaterialRepository.Object, mockServiceMaterialRepository.Object, mockUnitOfWork.Object);

            //Act
            List<ServiceMaterial> result = (List<ServiceMaterial>)await service.ListAsync();
            var serviceMaterialCount = result.Count;

            //Assert
            serviceMaterialCount.Should().Equals(0);
        }

        private Mock<IServiceMaterialRepository> GetDefaultIServiceMaterialRepositoryInstance()
        {
            return new Mock<IServiceMaterialRepository>();
        }

        private Mock<IMaterialRepository> GetDefaultIMaterialRepositoryInstance()
        {
            return new Mock<IMaterialRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
