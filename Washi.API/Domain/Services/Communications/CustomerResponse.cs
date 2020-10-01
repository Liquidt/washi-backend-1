using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
    public class CustomerResponse : BaseResponse<Customer>
    {
        public CustomerResponse(string message) : base(message) { }

        public CustomerResponse(Customer customer) : base(customer) { }
    }
}
