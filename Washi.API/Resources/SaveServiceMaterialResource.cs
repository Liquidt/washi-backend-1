using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Resources
{
    public class SaveServiceMaterialResource
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
    }
}
