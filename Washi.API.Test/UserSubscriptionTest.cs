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
    class UserSubscriptionTest
    {

        [Test]
        public async Task ListAsyncWhenNoUserSubscriptionReturnsEmptyCollection()
        {
            //Arrange
            var mockUserSubscriptionRepository = GetDefaultIUserSubscriptionRepositoryInstance();
            mockUserSubscriptionRepository.Setup(u => u.ListAsync())
                .ReturnsAsync(new List<UserSubscription>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new UserSubscriptionService(mockUserSubscriptionRepository.Object, mockUnitOfWork.Object);

            //Act
            List<UserSubscription> result = (List<UserSubscription>)await service.ListAsync();
            var userSubscriptionCount = result.Count;

            //Assert
            userSubscriptionCount.Should().Equals(0);
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
