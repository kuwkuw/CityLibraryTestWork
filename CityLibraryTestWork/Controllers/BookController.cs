using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CityLibraryTestWork.Models;
using CityLibraryTestWork.Repository;
using CityLibraryTestWork.Services;
using WebGrease;

namespace CityLibraryTestWork.Controllers
{
    public class BookController : Controller
    {

        BookService _bookService = new BookService();

        // GET: Book
        public ActionResult Index(string searchTermBook = null, string searchTermAutroFirstName=null, string searchTermAutroSecondName = null)
        {
            var items = _bookService.GetBooks(searchTermBook, searchTermAutroFirstName, searchTermAutroSecondName);
            
            if(Request.IsAjaxRequest())
                return PartialView("_booksPartial", items);

            return View(items);
        }



        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View(_bookService.GetBook(id));
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            _bookService.AddBook(collection);
            try
            {
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_bookService.GetBook(id));
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                _bookService.UpdateBook(id, collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _bookService.DeleteBook(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
