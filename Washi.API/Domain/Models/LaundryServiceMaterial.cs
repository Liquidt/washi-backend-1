using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Domain.Models
{
    public class LaundryServiceMaterial
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        //public DateTime TimeEstimated { get; set; }
        public float Discount { get; set; }
        public float Rating { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ServiceMaterialId { get; set; }
        public ServiceMaterial ServiceMaterial { get; set; }
    }
}
