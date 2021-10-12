using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Helpers
{
    public enum ApiMethods
    {
        [Description("api/Sales")]
        salesAll,
        [Description("api/Clients")]
        clientsAll
    }
}
