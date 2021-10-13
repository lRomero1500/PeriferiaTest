using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Services.Interfaces
{
    public interface IBaseService<T>where T : new()
    {
        public Task<List<T>> getAll();
        public Task<T> getById(Int64 id);
        public Task<T> createUpdate(Int64 id,T record);
        public Task<int> delete(Int64 id);
    }
}
