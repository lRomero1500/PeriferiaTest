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
        public async Task<Client> createUpdate(Int64 id, Client record)
        {
            if (id != 0)
            {
                return await _httpClient.
                    Request(EnumDescription.GetDescription(ApiMethods.clientsAll) + "/" + id).
                    PutJsonAsync(record).
                    ReceiveJson<Client>();
            }
            return await _httpClient.
                Request(EnumDescription.GetDescription(ApiMethods.clientsAll)).
                PostJsonAsync(record).
                ReceiveJson<Client>();
        }

        public async Task<int> delete(long id)
        {
            return await _httpClient.
                Request(EnumDescription.GetDescription(ApiMethods.clientsAll) + '/' + id).
                DeleteAsync().
                ReceiveJson<int>();
        }

        public async Task<List<Client>> getAll()
        {
            return await _httpClient.
                Request(EnumDescription.GetDescription(ApiMethods.clientsAll)).
                GetAsync().
                ReceiveJson<List<Client>>();
        }

        public async Task<Client> getById(long id)
        {
            return  await _httpClient.
                Request(EnumDescription.GetDescription(ApiMethods.clientsAll) + '/' + id).
                GetAsync().
                ReceiveJson<Client>();
        }
    }
}
