using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Entities;

namespace TestAPI.Services
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        public DbSet<Product> products { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Sales> sales { get; set; }
    }
}
