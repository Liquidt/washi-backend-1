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
    class OrderStatusServiceTest
    {

        [Test]
        public async Task ListAsyncWhenNoOrderStatusReturnsEmptyCollection()
        {
            //Arrange
            var mockOrderStatusRepository = GetDefaultIOrderStatusRepositoryInstance();
            mockOrderStatusRepository.Setup(u => u.ListAsync())
                .ReturnsAsync(new List<OrderStatus>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new OrderStatusService(mockOrderStatusRepository.Object,mockUnitOfWork.Object);

            //Act
            List<OrderStatus> result = (List<OrderStatus>)await service.ListAsync();
            var orderStatusCount = result.Count;

            //Assert
            orderStatusCount.Should().Equals(0);
        }

        private Mock<IOrderStatusRepository> GetDefaultIOrderStatusRepositoryInstance()
        {
            return new Mock<IOrderStatusRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
