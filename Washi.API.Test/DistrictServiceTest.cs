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
    class DistrictServiceTest
    {

        [Test]
        public async Task ListAsyncWhenNoDistrictsReturnsEmptyCollection()
        {
            //Arrange
            var mockDistrictRepository = GetDefaultIDistrictRepositoryInstance();
            mockDistrictRepository.Setup(u => u.ListAsync())
                .ReturnsAsync(new List<District>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var service = new DistrictService(mockDistrictRepository.Object, mockUnitOfWork.Object);

            //Act
            List<District> result = (List<District>)await service.ListAll();
            var districtCount = result.Count;

            //Assert
            districtCount.Should().Equals(0);
        }

        private Mock<IDistrictRepository> GetDefaultIDistrictRepositoryInstance()
        {
            return new Mock<IDistrictRepository>();
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
