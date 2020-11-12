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
    class UserPaymentMethodTest
    {

        [Test]
        public async Task ListAsyncWhenNoUserPaymentMethodsReturnsEmptyCollection()
        {
            //Arrange
            var mockUserPaymentMethodRepository = GetDefaultIUserPaymentMethodRepositoryInstance();
            mockUserPaymentMethodRepository.Setup(u => u.ListAsync())
                .ReturnsAsync(new List<UserPaymentMethod>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new UserPaymentMethodService(mockUserPaymentMethodRepository.Object, mockUnitOfWork.Object);

            //Act
            List<UserPaymentMethod> result = (List<UserPaymentMethod>)await service.ListAsync();
            var userPaymentMethodCount = result.Count;

            //Assert
            userPaymentMethodCount.Should().Equals(0);
        }

        private Mock<IUserPaymentMethodRepository> GetDefaultIUserPaymentMethodRepositoryInstance()
        {
            return new Mock<IUserPaymentMethodRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
