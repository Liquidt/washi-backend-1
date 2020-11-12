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
    class CountryServiceTest
    {

        [Test]
        public async Task ListAsyncWhenNoCountriesReturnsEmptyCollection()
        {
            //Arrange
            var mockCountryRepository = GetDefaultICountryRepositoryInstance();
            var mockCountryCurrencyRepository = GetDefaultICountryCurrencyRepositoryInstance();
            mockCountryRepository.Setup(u => u.ListAsync())
                .ReturnsAsync(new List<Country>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var service = new CountryService(mockCountryRepository.Object,mockCountryCurrencyRepository.Object, mockUnitOfWork.Object);

            //Act
            List<Country> result = (List<Country>)await service.ListAsync();
            var countryCount = result.Count;

            //Assert
            countryCount.Should().Equals(0);
        }

        private Mock<ICountryRepository> GetDefaultICountryRepositoryInstance()
        {
            return new Mock<ICountryRepository>();
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
