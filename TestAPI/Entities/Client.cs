﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Entities
{
    public class Client
    {
        public Int64 id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string dni { get; set; }
    }
}
