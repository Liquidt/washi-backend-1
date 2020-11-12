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
    class CurrencyServiceTest
    {
        [Test]
        public async Task ListAsyncWhenNoCurrenciesReturnsEmptyCollection()
        {
            //Arrange
            var mockCurrencyRepository = GetDefaultICurrencyRepositoryInstance();
            var mockCountryCurrencyRepository = GetDefaultICountryCurrencyRepositoryInstance();
            mockCurrencyRepository.Setup(u => u.ListAsync())
                .ReturnsAsync(new List<Currency>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new CurrencyService(mockCurrencyRepository.Object, mockCountryCurrencyRepository.Object, mockUnitOfWork.Object);

            //Act
            List<Currency> result = (List<Currency>)await service.ListAsync();
            var currencyCount = result.Count;

            //Assert
            currencyCount.Should().Equals(0);
        }

        private Mock<ICurrencyRepository> GetDefaultICurrencyRepositoryInstance()
        {
            return new Mock<ICurrencyRepository>();
        }

        private Mock<ICountryCurrencyRepository> GetDefaultICountryCurrencyRepositoryInstance()
        {
            return new Mock<ICountryCurrencyRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
