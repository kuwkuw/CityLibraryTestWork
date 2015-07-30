using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CityLibraryTestWork.Models;
using CityLibraryTestWork.Repository;

namespace CityLibraryTestWork.Services
{
    public class BookService
    {
        private IRepository<Book> _bookRepository;
        AutorService _autoService;
        PublisherService _publisherService;
        SerieService _serieService;

        public BookService()
        {
            _bookRepository = new BaseRepository<Book>();
            _autoService = new AutorService();
            _publisherService = new PublisherService();
            _serieService = new SerieService();
        }

        public void AddBook(Book newItem)
        {
            _bookRepository.Add(newItem);
        }
        public void AddBook(FormCollection collection)
        {
            var book = new Book();
            var autor = _autoService.FindAutor(item => item.FirstName.Equals(collection["FirstName"]) && item.SecondName.Equals(collection["SecondName"]));
            var publisher = _publisherService.FindPublisher(item => item.PublisherName.Equals(collection["PublisherName"]));
            var serie = _serieService.FindSerie(item => item.SerieName.Equals(collection["SerieName"]));

            if (autor == null)
                autor = new Autor { FirstName = collection["FirstName"], SecondName = collection["SecondName"] };

            if (publisher == null)
                publisher = new Publisher { PublisherName = collection["PublisherName"] };

            if (serie == null)
                serie = new Serie { SerieName = collection["SerieName"] };

            book.Autor = autor;
            book.Title = collection["Title"];

            book.Serie = serie;
            book.Publisher = publisher;


            _bookRepository.Add(book);
        }
        
        public void DeleteBook(int id)
        {
            _bookRepository.Delete(id);
        }

        public Book GetBook(int id)
        {
            return _bookRepository.GetItem(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _bookRepository.GetList();
        }
        public IEnumerable<Book> GetBooks(string title, string autorFirstName, string autorSecondName)
        {
            IEnumerable<Book> item;
            using (var context = new LibraryDbContext())
            {
                item = context
                    .Books
                    .Include(book=>book.Autor)
                    .Where(
                        i =>
                            (title == null || i.Title.StartsWith(title)) &&
                            (autorFirstName == null || i.Autor.FirstName.StartsWith(autorFirstName)) &&
                            (autorSecondName == null || i.Autor.SecondName.StartsWith(autorSecondName))).ToList();
            }
            return item;
        }

        public void UpdateBook(Book item)
        {
            _bookRepository.Update(item);
        }

        public void UpdateBook(int id, FormCollection collection)
        {
            var book = _bookRepository.GetItem(id);

            book.Autor.FirstName = collection["FirstName"];
            book.Autor.SecondName = collection["SecondName"];
            book.Title = collection["Title"];
            book.Serie.SerieName = collection["SerieName"];
            book.Publisher.PublisherName = collection["PublisherName"];

            _bookRepository.Update(book);
        }

        public Book FindBook(Func<Book, bool> filter)
        {
            return _bookRepository.Find(filter);
        }
    }
}