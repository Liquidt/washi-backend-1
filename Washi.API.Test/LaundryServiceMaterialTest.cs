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
    class LaundryServiceMaterialTest
    {
        [Test]
        public async Task ListAsyncWhenNoLaundryServiceMaterialReturnsEmptyCollection()
        {
            //Arrange
            var mockLaundryServiceMaterialRepository = GetDefaultILaundryServiceMaterialRepositoryInstance();
            var mockUserProfileRepository = GetDefaultIUserProfileRepositoryInstance();
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            mockLaundryServiceMaterialRepository.Setup(u => u.ListAsync())
                .ReturnsAsync(new List<LaundryServiceMaterial>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new LaundryServiceMaterialService(mockLaundryServiceMaterialRepository.Object, mockUserProfileRepository.Object,mockUserRepository.Object, mockUnitOfWork.Object);

            //Act
            List<LaundryServiceMaterial> result = (List<LaundryServiceMaterial>)await service.ListAsync();
            var laundryServiceMaterialCount = result.Count;

            //Assert
            laundryServiceMaterialCount.Should().Equals(0);
        }

        private Mock<ILaundryServiceMaterialRepository> GetDefaultILaundryServiceMaterialRepositoryInstance()
        {
            return new Mock<ILaundryServiceMaterialRepository>();
        }

        private Mock<IUserProfileRepository> GetDefaultIUserProfileRepositoryInstance()
        {
            return new Mock<IUserProfileRepository>();
        }

        private Mock<IUserRepository> GetDefaultIUserRepositoryInstance()
        {
            return new Mock<IUserRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
