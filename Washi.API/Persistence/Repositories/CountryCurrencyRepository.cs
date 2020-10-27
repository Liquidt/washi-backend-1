using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Persistence.Contexts;
using Washi.API.Domain.Repositories;

namespace Washi.API.Persistence.Repositories
{
    public class CountryCurrencyRepository : BaseRepository, ICountryCurrencyRepository
    {
        public CountryCurrencyRepository(AppDbContext context) : base(context) { }
        public Task<CountryCurrency> FindByCountryCurrencyId(int countryCurrencyId)
        {
            throw new NotImplementedException();
        }

        public Task<CountryCurrency> FindByCountryIdAndCurrencyId(int countryId, int currencyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CountryCurrency>> ListByCountryIdAsync(int countryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CountryCurrency>> ListByCurrencyIdAsync(int currencyId)
        {
            throw new NotImplementedException();
        }
    }
}
