using ElectoralSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ElectoralSystem.Models
{
    public class Repository<T>: IRepository<T> where T: ElectionEntity
    {
        public ApplicationDbContext _context { get; set; }

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Repository()
        {
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }
        public T Get(int id)
        {
            var entity = _context.Set<T>().SingleOrDefault(e => e.Id == id);
            return entity;
        }
        public void AddOrUpdate(T item)
        {
            if(item.Id == 0)
            {
                Add(item);
            }
           Update(item);
        }
        private bool Add(T item)
        {
            try
            {
                _context.Set<T>().Add(item);
                return true;
            }
            catch (DataException)
            {
                throw new DataException("An unexpected error occured. Could not be added.");
            }
        }

        private bool Update(T item)
        {
            var entity = _context.Set<T>().SingleOrDefault(e => e.Id == item.Id);
            if (entity != null)
            {
                try
                {
                    _context.Set<T>().Add(entity);
                    return true;
                }
                catch (DataException)
                {
                    throw new DataException("An unexpected error occured. Could not update.");
                }
            }
            return false;
        }
        public void Remove(int id)
        {
            var entity = _context.Set<T>().SingleOrDefault(e => e.Id == id);
            if (entity != null)
            {
                try
                {
                    _context.Set<T>().Remove(entity);
                }
                catch(DataException)
                {
                    throw new DataException("An unexpected error occured. Could not delete.");
                }
            }
        }
        
        public void AddRange(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}