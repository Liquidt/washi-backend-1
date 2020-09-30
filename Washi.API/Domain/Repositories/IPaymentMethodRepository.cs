using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface IPaymentMethodRepository
    {
        Task<IEnumerable<PaymentMethod>> ListAsync();
        Task AddSync(PaymentMethod user);
        Task<PaymentMethod> FindById(int id);
        void Update(PaymentMethod user);
        void Remove(PaymentMethod user);
    }
}
