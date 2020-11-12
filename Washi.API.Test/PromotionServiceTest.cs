using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Persistence.Repositories;
using Washi.API.Services;

namespace Washi.API.Test
{
    class PromotionServiceTest
    {

        [Test]
        public async Task ListAsyncWhenNoPromotionsReturnsEmptyCollection()
        {
            //Arrange
            var mockPromotionRepository = GetDefaultIPromotionRepositoryInstance();
            mockPromotionRepository.Setup(u => u.ListAsync())
                .ReturnsAsync(new List<Promotion>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new PromotionService(mockPromotionRepository.Object, mockUnitOfWork.Object);

            //Act
            List<Promotion> result = (List<Promotion>)await service.ListAsync();
            var promotionCount = result.Count;

            //Assert
            promotionCount.Should().Equals(0);
        }

        private Mock<IPromotionRepository> GetDefaultIPromotionRepositoryInstance()
        {
            return new Mock<IPromotionRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
