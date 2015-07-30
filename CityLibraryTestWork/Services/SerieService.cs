using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CityLibraryTestWork.Models;
using CityLibraryTestWork.Repository;

namespace CityLibraryTestWork.Services
{
    public class SerieService
    {
        private IRepository<Serie> _repository;

        public SerieService(LibraryDbContext context)
        {
            _repository = new BaseRepository<Serie>(context);
        }

        public void AddSerie(Serie newItem)
        {
            _repository.Add(newItem);
        }

        public void AddSerie(FormCollection collection)
        {
            var serie = _repository.Find(item => item.SerieName.Equals(collection["SerieName"]));
            if(serie==null)
                _repository.Add(new Serie { SerieName = collection["SerieName"] });
        }

        public void DeleteSerie(int id)
        {
            _repository.Delete(id);
        }

        public Serie GetSerie(int id)
        {
            return _repository.GetItem(id);
        }

        public IEnumerable<Serie> GetSeries()
        {
            return _repository.GetList();
        }

        public void UpdateSerie(Serie item)
        {
            _repository.Update(item);
        }

        public void UpdateSerie(int id, FormCollection collection)
        {
            var serie = _repository.GetItem(id);
            serie.SerieName = collection["SerieName"];
            _repository.Update(serie);
        }

        public Serie FindSerie(Func<Serie, bool> filter)
        {
            return _repository.Find(filter);
        }
    }
}