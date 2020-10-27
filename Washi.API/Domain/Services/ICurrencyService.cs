using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services
{
    interface ICurrencyService
    {
        Task<IEnumerable<Currency>> ListAsync();
        Task<IEnumerable<Currency>> ListByCountryIdAsync(int countryId);
    }
}
