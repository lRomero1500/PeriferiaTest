using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Managers.Interfaces
{
    public interface IBaseManager<T>where T : new()
    {
        public Task<List<T>> getAll();
        public Task<T> getById(Int64 id);
        public Task<T> createUpdate(T record);
        public Task<int> delete(Int64 id);
    }
}
