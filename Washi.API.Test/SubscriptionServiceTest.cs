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
    class SubscriptionServiceTest
    {

        [Test]
        public async Task ListAsyncWhenNoSubscriptionReturnsEmptyCollection()
        {
            //Arrange
            var mockSubscriptionRepository = GetDefaultISubscriptionRepositoryInstance();
            var mockUserSubscriptionRepository = GetDefaultIUserSubscriptionRepositoryInstance();
            mockSubscriptionRepository.Setup(u => u.ListAsync())
                .ReturnsAsync(new List<Subscription>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new SubscriptionService(mockSubscriptionRepository.Object, mockUnitOfWork.Object, mockUserSubscriptionRepository.Object);

            //Act
            List<Subscription> result = (List<Subscription>)await service.ListAsync();
            var subscriptionCount = result.Count;

            //Assert
            subscriptionCount.Should().Equals(0);
        }

        private Mock<ISubscriptionRepository> GetDefaultISubscriptionRepositoryInstance()
        {
            return new Mock<ISubscriptionRepository>();
        }
        private Mock<IUserSubscriptionRepository> GetDefaultIUserSubscriptionRepositoryInstance()
        {
            return new Mock<IUserSubscriptionRepository>();
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
