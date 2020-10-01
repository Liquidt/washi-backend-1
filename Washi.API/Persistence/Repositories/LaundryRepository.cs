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
    public class LaundryRepository : BaseRepository, ILaundryRepository
    {
        public LaundryRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Laundry>> ListAsync()
        {
            return await _context.Laundries.ToListAsync();
        }

        public async Task<Laundry> FindById(int id)
        {
            return await _context.Laundries.Include(a => a.User).FirstOrDefaultAsync(a => a.UserId == id);
        }

        public void Update(Laundry laundry)
        {
            _context.Laundries.Update(laundry);
        }

        public void Remove(Laundry laundry)
        {
            _context.Laundries.Remove(laundry);
        }
    }
}