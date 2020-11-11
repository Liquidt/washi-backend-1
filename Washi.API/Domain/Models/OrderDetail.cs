using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Domain.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }

        //**************************
        //TODO: LaundryServiceMaterial relation
        //**************************

        public byte rating { get; set; }
    }
}
