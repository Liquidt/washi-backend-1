using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services.Communications;
using Washi.API.Services;

namespace Washi.API.Test.Steps
{
    [Binding]
    public class CheckPromotionsSteps
    {
        public User user;
        public Promotion promotion;
        public PromotionService promotionService;
        public UserService userService;
        public PromotionResponse prom;
        public LaundryServiceMaterial laundryServiceMaterial;
        public LaundryServiceMaterialService laundryServiceMaterialService;
        public ServiceMaterial serviceMaterial;
        public ServiceMaterialService serviceMaterialService;
        public Service service;
        public ServiceService serviceService;
        public Material material;
        public MaterialService materialService;

        [Given(@"a laundry service has not been used")]
        public async void GivenALaundryServiceHasNotBeenUsed()
        {
            user = new User { Id = 1000, Email = "pepito123", Password = "asasas" };
            await userService.SaveAsync(user);
        }

        [When(@"the information in this")]
        public async void WhenTheInformationInThis()
        {
            prom = await promotionService.GetByIdAsync(2000);
        }

        [Then(@"you can see that there are no promotions")]
        public void ThenYouCanSeeThatThereAreNoPromotions()
        {
            Assert.That(prom != null, Is.False);
        }


    }
}
