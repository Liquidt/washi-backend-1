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
        [Given(@"you want to know what offers you can use")]
        public async void GivenYouWantToKnowWhatOffersYouCanUse()
        {
            user = new User { Id = 1000, Email = "pepito123", Password = "asasas" };
            laundryServiceMaterial = new LaundryServiceMaterial { Id = 1, LaundryId = 2, ServiceMaterialId = 1, Price = Convert.ToDecimal(15.00), Description = "Lavado al agua común de nuestros especialistas en máquinas de lavado.", EstimatedDeliveryTimeInDays = 1 };
            serviceMaterial = new ServiceMaterial { Id = 1, ServiceId = 1, MaterialId = 1 };
            service = new Service { Id = 1, Name = "Lavado al agua" };
            material = new Material { Id = 1, Name = "Algodón" };
            promotion = new Promotion { Id = 1000, InitialDate = DateTime.Now, EndingDate = DateTime.Now.AddDays(15), DiscountPercentage = 20, LaundryServiceMaterialId = 1000 };
            await promo

        }
        
        [When(@"to request service from a laundry")]
        public async void WhenToRequestServiceFromALaundry()
        {
            prom = await promotionService.GetByIdAsync(1000);
        }
        
        [Then(@"you can see all the promotions that are available")]
        public void ThenYouCanSeeAllThePromotionsThatAreAvailable()
        {
            
            Assert.That(prom != null , Is.True);
        }

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
