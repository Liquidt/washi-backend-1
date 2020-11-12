using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services.Communications;
using Washi.API.Services;

namespace Washi.API.Test
{
    class UserProfileTest
    {

        [Test]
        public async Task ListAsyncWhenNoUserProfilesReturnsEmptyCollection()
        {
            //Arrange
            var mockUserProfileRepository = GetDefaultIUserProfileRepositoryInstance();
            mockUserProfileRepository.Setup(u => u.ListAsync())
                .ReturnsAsync(new List<UserProfile>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var service = new UserProfileService(mockUserProfileRepository.Object, mockUnitOfWork.Object);

            //Act
            List<UserProfile> result = (List<UserProfile>)await service.ListAsync();
            var userProfileCount = result.Count;

            //Assert
            userProfileCount.Should().Equals(0);
        }

        [Test]
        public async Task SavingWhenErrorReturnException()
        {
            //Arrange
            UserProfile profile = new UserProfile { };
            var mockUserProfileRepository = GetDefaultIUserProfileRepositoryInstance();
            mockUserProfileRepository.Setup(u => u.AddAsync(profile))
                .Throws(new Exception());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new UserProfileService(mockUserProfileRepository.Object, mockUnitOfWork.Object);

            //Act
            UserProfileResponse response = await service.SaveAsync(profile);
            var message = response.Message;
            //Assert
            message.Should().Contain("An error ocurred while saving the user profile");
        }

        private Mock<IUserProfileRepository> GetDefaultIUserProfileRepositoryInstance()
        {
            return new Mock<IUserProfileRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
