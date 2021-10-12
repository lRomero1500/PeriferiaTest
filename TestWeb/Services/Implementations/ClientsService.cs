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
    public class ClientsService : IClientsService
    {
        private IFlurlClient _httpClient;

        public ClientsService(IFlurlClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<Client> createUpdate(Client record)
        {
            throw new NotImplementedException();
        }

        public Task<int> delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Client>> getAll()
        {
            return await _httpClient.
                Request(EnumDescription.GetDescription(ApiMethods.clientsAll)).
                GetAsync().
                ReceiveJson<List<Client>>();
        }

        public Task<Client> getById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
