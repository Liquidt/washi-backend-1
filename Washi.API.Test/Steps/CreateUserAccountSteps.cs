using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Washi.API.Domain.Models;
using Washi.API.Services;

namespace Washi.API.Test.Steps
{
    [Binding]
    public class CreateUserAccountSteps
    {
        public bool existUser = false;
        public UserService userService;
        [Given(@"it is required to confirm the registration of a user")]
        public async void GivenItIsRequiredToConfirmTheRegistrationOfAUser()
        {
            var user = await userService.GetByIdAsync(1005);
            if (user != null)
                existUser = true;
            else
                existUser = false;
        }
        
        [When(@"the user finishes filling in their registration data")]
        public async void WhenTheUserFinishesFillingInTheirRegistrationData()
        {
            if(!existUser)
                await userService.SaveAsync(new User { Id = 1005, Email = "anonimus@hotmail.com", Password = "hola1234" });
        }
        
        [Then(@"A confirmation message is then sent to the email you used\.")]
        public async void ThenAConfirmationMessageIsThenSentToTheEmailYouUsed_()
        {
            bool exist;
            if (await userService.GetByIdAsync(1005) != null)
                exist = true;
            else
                exist = false;
            Assert.That(exist == true, Is.True);
        }
    }
}
