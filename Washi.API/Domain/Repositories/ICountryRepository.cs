using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    interface ICountryRepository
    {
        Task<IEnumerable<Country>> ListAsync();
    }
}
