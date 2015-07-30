using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CityLibraryTestWork.Models;
using CityLibraryTestWork.Repository;

namespace CityLibraryTestWork.Services
{
    public class PublisherService
    {
        private IRepository<Publisher> _repository;

        public PublisherService(LibraryDbContext context)
        {
            _repository = new BaseRepository<Publisher>(context);
        }

        public void AddPublisher(Publisher newItem)
        {
            _repository.Add(newItem);
        }

        public void AddPublisher(FormCollection collection)
        {
            var publisher = _repository.Find(item => item.PublisherName.Equals(collection["PublisherName"]));
            if(publisher==null)
                _repository.Add(new Publisher { PublisherName = collection["PublisherName"] });
        }

        public void DeletePublisher(int id)
        {
            _repository.Delete(id);
        }

        public Publisher GetPublisher(int id)
        {
            return _repository.GetItem(id);
        }

        public IEnumerable<Publisher> GetPublishers()
        {
            return _repository.GetList();
        }

        public void UppdatePublisher(Publisher item)
        {
            _repository.Update(item);
        }

        public void UppdatePublisher(int id, FormCollection collection)
        {
            var publisher = _repository.GetItem(id);
            publisher.PublisherName = collection["PublisherName"];
            _repository.Update(publisher);
        }

        public Publisher FindPublisher(Func<Publisher, bool> filter)
        {
            return _repository.Find(filter);
        }

    }
}