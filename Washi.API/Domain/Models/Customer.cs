using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Domain.Models
{
    public class Customer : Account
    {
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
    }
}
