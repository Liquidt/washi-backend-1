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
    class CountryCurrencyTest
    {
        [Test]
        public async Task ListByCountryIdAndCurrencyIdAsyncWhenNoCountryCurrenciesReturnsEmptyCollection()
        {
            //Arrange
            var mockCountryCurrencyRepository = GetDefaultICountryCurrencyRepositoryInstance();
            mockCountryCurrencyRepository.Setup(u => u.FindByCountryIdAndCurrencyId(1,1))
                .ReturnsAsync(new List<CountryCurrency>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var service = new CountryCurrencyService(mockCountryCurrencyRepository.Object, mockUnitOfWork.Object);

            //Act
            List<CountryCurrency> result = (List<CountryCurrency>)await service.ListByCountryIdAndCurrencyIdAsync(1,1);
            var countrycurrencyCount = result.Count;

            //Assert
            countrycurrencyCount.Should().Equals(0);
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
