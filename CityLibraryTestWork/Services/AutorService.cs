using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CityLibraryTestWork.Models;
using CityLibraryTestWork.Repository;

namespace CityLibraryTestWork.Services
{
    public class AutorService
    {
        private IRepository<Autor> _repository;

        public AutorService(LibraryDbContext context)
        {
            _repository = new AutorRepository(context);
        }

        public void AddAutor(Autor newItem)
        {
            _repository.Add(newItem);
        }

        public void AddAutor(FormCollection collection)
        {
            var item = _repository.Find(i=>i.FirstName.Equals(collection["FirstName"])&& i.SecondName.Equals(collection["SecondName"]));
            if (item == null)
            {
                item = new Autor {FirstName = collection["FirstName"], SecondName = collection["SecondName"]};
                _repository.Add(item);
            }
        }

        public void DeleteAutor(int id)
        {
            _repository.Delete(id);
        }

        public Autor GetAutor(int id)
        {
            return _repository.GetItem(id);
        }

        public IEnumerable<Autor> GetAutors()
        {
            return _repository.GetList();
        }

        public IEnumerable<Autor> GetAutors(Func<Autor, bool> filter)
        {
            return _repository.GetList(filter);
        }

        public void UpdateAutor(Autor item)
        {
            _repository.Update(item);
        }

        public void UpdateAutor(int id, FormCollection collection)
        {
            var publisher = _repository.GetItem(id);
            publisher.FirstName = collection["FirstName"];
            publisher.SecondName = collection["SecondName"];
            _repository.Update(publisher);
        }

        public Autor FindAutor(Func<Autor, bool> filter)
        {
            return _repository.Find(filter);
        }

    }
}