using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Entities;
using TestAPI.Managers.Interfaces;
using TestAPI.Services;

namespace TestAPI.Managers.Implementations
{
    public class SalesManager : ISalesManager
    {
        private readonly Context _context;

        public SalesManager(Context context)
        {
            _context = context;
        }
        public async Task<Sales> createUpdate(Sales record)
        {
            _context.Entry(record).State = record.id == 0 ? EntityState.Added : EntityState.Modified;

            return await _context.SaveChangesAsync() != 0 ? _context.sales.FirstOrDefault(clnt => clnt.id == record.id) : null;
        }

        public Task<int> delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Sales>> getAll()
        {
            return await _context.sales.ToListAsync();
        }

        public async Task<Sales> getById(long id)
        {
            return await _context.sales.FindAsync(id);
        }
    }
}
