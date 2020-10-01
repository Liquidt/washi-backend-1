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
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
        }
        public async Task<Account> FindById(int id)
        {
            return await _context.Accounts.Include(a => a.User).FirstOrDefaultAsync(a => a.UserId== id);
        }

        public async Task<IEnumerable<Account>> ListAsync()
        {
            return await _context.Accounts.ToListAsync();
        }
    }
}
