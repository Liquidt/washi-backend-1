using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface ILaundryServiceMaterialRepository
    {
        Task<IEnumerable<LaundryServiceMaterial>> ListAsync();
        Task<IEnumerable<LaundryServiceMaterial>> ListByUserIdAsync(int userId);
        Task AddAsync(LaundryServiceMaterial laundryServiceMaterial);
        void Remove(LaundryServiceMaterial laundryServiceMaterial);
        void Update(LaundryServiceMaterial laundryServiceMaterial);
    }
}
