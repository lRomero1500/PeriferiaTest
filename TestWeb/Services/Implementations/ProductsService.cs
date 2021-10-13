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
    public class ProductsService : IProductsService
    {
        private IFlurlClient _httpClient;

        public ProductsService(IFlurlClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Product> createUpdate(long id, Product record)
        {
            if (id != 0)
            {
                return await _httpClient.
                    Request(EnumDescription.GetDescription(ApiMethods.productsAll) + "/" + id).
                    PutJsonAsync(record).
                    ReceiveJson<Product>();
            }
            return await _httpClient.
                Request(EnumDescription.GetDescription(ApiMethods.productsAll)).
                PostJsonAsync(record).
                ReceiveJson<Product>();
        }

        public async Task<int> delete(long id)
        {
            return await _httpClient.
                Request(EnumDescription.GetDescription(ApiMethods.productsAll) + '/' + id).
                DeleteAsync().
                ReceiveJson<int>();
        }

        public async Task<List<Product>> getAll()
        {
            return await _httpClient.
               Request(EnumDescription.GetDescription(ApiMethods.productsAll)).
               GetAsync().
               ReceiveJson<List<Product>>();
        }

        public async Task<Product> getById(long id)
        {
            return await _httpClient.
                Request(EnumDescription.GetDescription(ApiMethods.productsAll) + '/' + id).
                GetAsync().
                ReceiveJson<Product>();
        }
    }
}
