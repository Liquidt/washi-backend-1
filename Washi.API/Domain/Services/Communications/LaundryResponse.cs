using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
    public class LaundryResponse : BaseResponse<Laundry>
    {
        public LaundryResponse(string message) : base(message) { }

        public LaundryResponse(Laundry laundry) : base(laundry) { }
    }
}
