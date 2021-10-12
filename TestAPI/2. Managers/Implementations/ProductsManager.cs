using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Entities;
using TestAPI.Managers.Interfaces;
using Microsoft.EntityFrameworkCore;
using TestAPI.Services;

namespace TestAPI.Managers.Implementations
{
    public class ProductsManager : IProductsManager
    {
        private readonly Context _context;

        public ProductsManager(Context context)
        {
            _context = context;
        }
        public async Task<Product> createUpdate(Product record)
        {
            _context.Entry(record).State = record.id == 0 ? EntityState.Added : EntityState.Modified;

            return await _context.SaveChangesAsync() != 0 ? _context.products.FirstOrDefault(clnt => clnt.id == record.id) : null;
        }

        public async Task<int> delete(long id)
        {
            var product = await getById(id);
            if (product == null)
                return -1;
            _context.products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> getAll()
        {
            return await _context.products.ToListAsync();
        }

        public async Task<Product> getById(long id)
        {
            return await _context.products.FindAsync(id);
        }
    }
}
