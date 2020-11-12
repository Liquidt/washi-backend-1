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
    class DepartmentServiceTest
    {

        [Test]
        public async Task ListAsyncWhenNoDepartmentsReturnsEmptyCollection()
        {
            //Arrange
            var mockDepartmentRepository = GetDefaultIDepartmentRepositoryInstance();
            mockDepartmentRepository.Setup(u => u.ListAsync())
                .ReturnsAsync(new List<Department>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var service = new DepartmentService(mockDepartmentRepository.Object, mockUnitOfWork.Object);

            //Act
            List<Department> result = (List<Department>)await service.ListAsync();
            var departmentCount = result.Count;

            //Assert
            departmentCount.Should().Equals(0);
        }

        private Mock<IDepartmentRepository> GetDefaultIDepartmentRepositoryInstance()
        {
            return new Mock<IDepartmentRepository>();
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
