﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Resources
{
    public class OrderResource
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderStatusId { get; set; }
        public int DeliveryAddress { get; set; }
        public int OrderAmount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public DateTime DeliveryDate { get; set; }

    }
}
