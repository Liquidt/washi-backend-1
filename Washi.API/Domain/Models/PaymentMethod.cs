using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Domain.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
<<<<<<< HEAD

        //possible TODO: Add UserPaymentMethods
=======
        public List<UserPaymentMethod> UserPaymentMethods { get; set; }
>>>>>>> feature-user
    }
}
