using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Models
{
    public class JsonResponse<T> where T : new()
    {
        public string msg { get; set; }
        public bool error { get; set; }
        public T data { get; set; }
        public string redirect { get; set; }
    }
}
