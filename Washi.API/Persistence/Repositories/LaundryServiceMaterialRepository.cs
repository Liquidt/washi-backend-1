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
    public class LaundryServiceMaterialRepository : BaseRepository, ILaundryServiceMaterialRepository
    {
        public LaundryServiceMaterialRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsync(LaundryServiceMaterial laundryServiceMaterial)
        {
            await _context.LaundryServiceMaterials.AddAsync(laundryServiceMaterial);
        }

        public async Task<IEnumerable<LaundryServiceMaterial>> ListAsync()
        {
            return await _context.LaundryServiceMaterials.ToListAsync();
        }

        public Task<IEnumerable<LaundryServiceMaterial>> ListByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public void Remove(LaundryServiceMaterial laundryServiceMaterial)
        {
            throw new NotImplementedException();
        }

        public void Update(LaundryServiceMaterial laundryServiceMaterial)
        {
            throw new NotImplementedException();
        }
    }
}
