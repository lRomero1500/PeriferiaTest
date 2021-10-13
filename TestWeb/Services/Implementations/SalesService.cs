using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Helpers;
using TestWeb.Models;
using TestWeb.Services.Interfaces;

namespace TestWeb.Services.Implementations
{
    public class SalesService : ISalesService
    {
        private IFlurlClient _httpClient;

        public SalesService(IFlurlClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<Sales> createUpdate(Int64 id, Sales record)
        {
            throw new NotImplementedException();
        }

        public Task<int> delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Sales>> getAll()
        {
            var x= EnumDescription.GetDescription(ApiMethods.salesAll);
            return await _httpClient.
                Request(EnumDescription.GetDescription(ApiMethods.salesAll)).
                GetAsync().
                ReceiveJson<List<Sales>>();
        }

        public Task<Sales> getById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
