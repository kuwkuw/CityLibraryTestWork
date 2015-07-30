using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityLibraryTestWork.Models;
using System.Data.Entity;

namespace CityLibraryTestWork.Repository
{
    public class BaseRepository<T> : IRepository<T> where T: class
    {
        private LibraryDbContext _context;

        public BaseRepository(LibraryDbContext context) {
            _context = context;
        }

        public void Add(T newItem)
        {
            _context.Set<T>().Add(newItem);
            _context.SaveChanges();
        }


        public T Find(Func<T, bool> filter)
        {
            return _context.Set<T>().FirstOrDefault(filter);
        }

        public void Delete(int id)
        {
            var item = GetItem(id);
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        

        public T GetItem(int id)
        {
           return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetList()
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> GetList(Func<T, bool> filter)
        {
            return _context.Set<T>().Where(filter);
        }

        public virtual void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
