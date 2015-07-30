using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibraryTestWork.Repository
{
    interface IRepository<T>
    {
        IEnumerable<T> GetList();
        IEnumerable<T> GetList(Func<T, bool> filter);
        T GetItem(int id);
        void Update(T item);
        void Delete(int id);
        void Add(T newItem);
        T Find(Func<T, bool> filter);

    }
}
