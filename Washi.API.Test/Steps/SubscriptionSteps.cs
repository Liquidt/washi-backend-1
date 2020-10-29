using FluentAssertions;
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
    public class SubscriptionSteps
    {
        public UserSubscriptionService userSubscriptionService;
        public SubscriptionService subscriptionService;
        public UserService userService;
        public User user = new User { Id = 1000, Email = "pepito123", Password = "asasas" };
        public Subscription subscription = new Subscription { Id = 1000, Name = "ultra premium", Price = 100, DurationInDays = 60 };
        public UserSubscription userSubscription = new UserSubscription { UserId = 1000, SubscriptionId= 1000, InitialDate = new DateTime(2020, 09, 01), EndingDate = new DateTime(2020, 11, 01) };
        public bool tiene = false;
        public async void CrearDatos()
        {
            await userService.SaveAsync(user);
            await subscriptionService.SaveAsync(subscription);
            await userSubscriptionService.SaveAsync(userSubscription);
        }

        [Given(@"The user has already bought a subscription")]
        public async void GivenTheUserHasAlreadyBoughtASubscription()
        {
            CrearDatos();
            IEnumerable<UserSubscription> lista = await userSubscriptionService.ListByUserIdAsync(user.Id);
            if (lista.Last().EndingDate >= DateTime.Now)
                tiene = true;
            else
                tiene = false;
        }

        [When(@"Trying to adquire another")]
        public async void WhenTryingToAdquireAnother()
        {
            if (!tiene)
            {
               UserSubscription userSubscription2 = new UserSubscription { UserId = 1000, SubscriptionId = 1000, InitialDate = DateTime.Now, EndingDate = new DateTime(2020, 12, 11) };
                await userSubscriptionService.SaveAsync(userSubscription2);
            }
        }
        

        [Then(@"The system tells the user, he/she has one active")]
        public void ThenTheSystemTellsTheUserHeSheHasOneActive()
        {
            Assert.That(userSubscriptionService.ListByUserIdAsync(user.Id).Result.ToList().Count == 1);
        }



        [Given(@"The user has not bought any subscription")]
        public async void GivenTheUserHasNotBoughtAnySubscription()
        {
            await userService.SaveAsync(new User { Id = 1001, Email = "pepito123", Password = "asasas" });
            IEnumerable<UserSubscription> lista = await userSubscriptionService.ListByUserIdAsync(user.Id);
            if (!lista.Any())
                tiene = false;
            else
                tiene = true;
        }
        [When(@"Trying to adquire a subscription")]
        public async void WhenTryingToAdquireASubscription()
        {
            await userSubscriptionService.SaveAsync(new UserSubscription { UserId = 1000, SubscriptionId = 1000, InitialDate = DateTime.Now, EndingDate = new DateTime(2020, 12, 11) });
        }
        [Then(@"The system registers the new subscription to his/her account")]
        public async void ThenTheSystemRegistersTheNewSubscriptionToHisHerAccount()
        {
            IEnumerable<UserSubscription> lista = await userSubscriptionService.ListByUserIdAsync(user.Id);
            Assert.That(lista.Count() == 1, Is.True);
        }



        [Given(@"the user wants to see all the subscriptions he/she had")]
        public void GivenTheUserWantsToSeeAllTheSubscriptionsHeSheHad()
        {
            CrearDatos();           
        }

        [When(@"trying to see his subscription")]
        public async void WhenTryingToSeeHisSubscription()
        {
            IEnumerable<UserSubscription> lista = await userSubscriptionService.ListByUserIdAsync(user.Id);
        }

        [Then(@"The system shows a list of the subscriptions")]
        public async void ThenTheSystemShowsAListOfTheSubscriptions()
        {
            IEnumerable<UserSubscription> lista = await userSubscriptionService.ListByUserIdAsync(user.Id);
            Assert.That(lista == userSubscriptionService.ListByUserIdAsync(user.Id));
        }
    }
}
