using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    interface ICountryCurrencyRepository
    {
        Task<CountryCurrency> FindByCountryCurrencyId(int countryCurrencyId);
        Task<IEnumerable<CountryCurrency>> ListByCountryIdAsync(int countryId);
        Task<IEnumerable<CountryCurrency>> ListByCurrencyIdAsync(int currencyId);
        Task<IEnumerable<CountryCurrency>> FindByCountryIdAndCurrencyId(int countryId, int currencyId);
    }
}
