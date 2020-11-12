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
    class PaymentMethodServiceTest
    {

        [Test]
        public async Task ListAsyncWhenNoCurrenciesReturnsEmptyCollection()
        {
            //Arrange
            var mockPaymentMethodRepository = GetDefaultIPaymentMethodRepositoryInstance();
            var mockUserPaymentMethodRepository = GetDefaultIUserPaymentMethodRepositoryInstance();
            mockPaymentMethodRepository.Setup(u => u.ListAsync())
                .ReturnsAsync(new List<PaymentMethod>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new PaymentMethodService(mockPaymentMethodRepository.Object, mockUnitOfWork.Object, mockUserPaymentMethodRepository.Object);

            //Act
            List<PaymentMethod> result = (List<PaymentMethod>)await service.ListAsync();
            var paymentMethodCount = result.Count;

            //Assert
            paymentMethodCount.Should().Equals(0);
        }

        private Mock<IPaymentMethodRepository> GetDefaultIPaymentMethodRepositoryInstance()
        {
            return new Mock<IPaymentMethodRepository>();
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
