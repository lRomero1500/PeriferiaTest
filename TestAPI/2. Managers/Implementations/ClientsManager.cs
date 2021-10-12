using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Entities;
using TestAPI.Managers.Interfaces;
using Microsoft.EntityFrameworkCore;
using TestAPI.Services;

namespace TestAPI.Managers.Implementations
{
    public class ClientsManager : IClientsManager
    {
        private readonly Context _context;

        public ClientsManager(Context context)
        {
            _context = context;
        }

        public async Task<Client> createUpdate(Client record)
        {
            _context.Entry(record).State = record.id == 0 ? EntityState.Added : EntityState.Modified;

            return await _context.SaveChangesAsync() != 0 ? _context.clients.FirstOrDefault(clnt => clnt.id == record.id) : null;
        }

        public async Task<int> delete(long id)
        {
            var client = await getById(id);
            if (client == null)
                return -1;
            _context.clients.Remove(client);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Client>> getAll()
        {
            return await _context.clients.ToListAsync();
        }

        public async Task<Client> getById(long id)
        {
            return await _context.clients.FindAsync(id);
        }
    }
}
