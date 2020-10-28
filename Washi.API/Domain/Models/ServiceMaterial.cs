using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Domain.Models
{
    public class ServiceMaterial
    {
        public string Name { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
    }
}
