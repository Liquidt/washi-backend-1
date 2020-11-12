using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services;
using Washi.API.Services;

namespace Washi.API.Test
{
    class OrderDetailserviceTest
    {
        [Test]
        public async Task ListAsyncWhenNoOrderDetailsReturnsEmptyCollection()
        {
            //Arrange
            var mockOrderDetailRepository = GetDefaultIOrderDetailRepositoryInstance();
            mockOrderDetailRepository.Setup(u => u.ListAsync())
                .ReturnsAsync(new List<OrderDetail>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new OrderDetailService(mockOrderDetailRepository.Object, mockUnitOfWork.Object);

            //Act
            List<OrderDetail> result = (List<OrderDetail>)await service.ListAsync();
            var orderDetailCount = result.Count;

            //Assert
            orderDetailCount.Should().Equals(0);
        }


        private Mock<IOrderDetailRepository> GetDefaultIOrderDetailRepositoryInstance()
        {
            return new Mock<IOrderDetailRepository>();
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
