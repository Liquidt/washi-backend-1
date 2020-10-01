using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface ILaundryRepository
    {
        Task<IEnumerable<Laundry>> ListAsync();
        Task<Laundry> FindById(int id);
        void Update(Laundry laundry);
        void Remove(Laundry laundry);
    }
}
