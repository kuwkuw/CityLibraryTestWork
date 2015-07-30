using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityLibraryTestWork.Models;
using System.Data.Entity;
using WebGrease.Css.Extensions;

namespace CityLibraryTestWork.Repository
{
    public class BaseRepository<T> : IRepository<T> where T: class
    {
//        private LibraryDbContext _context;
//
//        public BaseRepository(LibraryDbContext context) {
//            _context = context;
//        }

        public void Add(T newItem)
        {
            using (var context = new LibraryDbContext())
            {
                context.Set<T>().Add(newItem);
                context.SaveChanges();
            }
//            _context.Set<T>().Add(newItem);
//            _context.SaveChanges();
        }


        public T Find(Func<T, bool> filter)
        {
            T list;
            using (var context = new LibraryDbContext())
            {
                list = context.Set<T>().FirstOrDefault(filter);
            }
            return list;
//            return _context.Set<T>().FirstOrDefault(filter);
        }

        public void Delete(int id)
        {
            var item = GetItem(id);
            using (var context = new LibraryDbContext())
            {
                context.Entry(item).State = EntityState.Deleted;
                context.SaveChanges();
            }
//            _context.Set<T>().Remove(item);
//            _context.SaveChanges();
            
        }

        public T GetItem(int id)
        {
            T item;
            using (var context = new LibraryDbContext())
            {
                item = context.Set<T>().Find(id);
            }
            return item;
//            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetList()
        {
            IEnumerable<T> list;
            using (var context = new LibraryDbContext())
            {
                list = context.Set<T>();
            }
            return list;
//            return _context.Set<T>();
        }

        public IEnumerable<T> GetList(Func<T, bool> filter)
        {
            IEnumerable<T> list;
            using (var context = new LibraryDbContext())
            {
                list = context.Set<T>().Where(filter).ToList();
            }
            return list;
//            return _context.Set<T>().Where(filter).ToList();
        }

        public virtual void Update(T item)
        {
            using (var context = new LibraryDbContext())
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }
//            _context.Entry(item).State = EntityState.Modified;
//            _context.SaveChanges();
            
        }
    }
}
