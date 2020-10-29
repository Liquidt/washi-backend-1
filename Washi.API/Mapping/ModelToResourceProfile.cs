using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Resources;

namespace Washi.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<PaymentMethod, PaymentMethodResource>();
            CreateMap<Service, ServiceResource>();
            CreateMap<Material, MaterialResource>();
            CreateMap<UserProfile, UserProfileResource>();
            CreateMap<Subscription, SubscriptionResource>();
            CreateMap<Country, CountryResource>();
            CreateMap<District, DistrictResource>();
            CreateMap<Department, DepartmentResource>();
            CreateMap<Currency, CurrencyResource>();
            CreateMap<CountryCurrency, CountryCurrencyResource>();
        }
    }
}
