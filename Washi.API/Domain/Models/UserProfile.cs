using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Domain.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public District District { get; set; }
        public int DistrictId { get; set; }
    }
}
