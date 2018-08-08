using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ElectoralSystem.Models
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T Get(int id);

        void AddOrUpdate(T item);
        void AddRange(IEnumerable<T> items);

        void Remove(int id);
        void RemoveRange(IEnumerable<int> ids);
    }
}