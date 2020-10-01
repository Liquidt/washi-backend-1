using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services.Communications;

namespace Washi.API.Domain.Services
{
    public interface ILaundryService
    {
        Task<IEnumerable<Laundry>> ListAsync();
        Task<LaundryResponse> UpdateAsync(int id, Laundry laundry);
        Task<LaundryResponse> DeleteAsync(int id);
        Task<LaundryResponse> GetByIdAsync(int id);
    }
}
