using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserProfile UserProfile { get; set; }
        public List<UserPaymentMethod> UserPaymentMethods { get; set; }
        public List<UserSubscription> UserSubscriptions { get; set; }
        public List<Order> Orders { get; set; }
        public List<LaundryServiceMaterial> LaundryServiceMaterials { get; set; }
    }
}
