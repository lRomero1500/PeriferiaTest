﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Entities
{
    public class Sales
    {
        public Int64 id { get; set; }
        public Client client { get; set; }
        public Product product { get; set; }
        public int quantity { get; set; }
        public float totalAmount { get; set; }
    }
}