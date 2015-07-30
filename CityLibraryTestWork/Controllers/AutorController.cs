using System.Web.Mvc;
using CityLibraryTestWork.Models;
using CityLibraryTestWork.Repository;
using CityLibraryTestWork.Services;

namespace CityLibraryTestWork.Controllers
{
    public class AutorController : Controller
    {
        static LibraryDbContext _context = new LibraryDbContext();
        AutorService _autorService = new AutorService();
        // GET: Autor
        public ActionResult Index(string searchTerm = null)
        {
            return
                View(
                    _autorService.GetAutors(
                        item => searchTerm == null || (item.FirstName.StartsWith(searchTerm) || item.SecondName.StartsWith(searchTerm))));


        }

        // GET: Autor/Details/5
        public ActionResult Details(int id)
        {
            var item = _autorService.GetAutor(id);
            return View(item);
        }

        // GET: Autor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                _autorService.AddAutor(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Autor/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_autorService.GetAutor(id));
        }

        // POST: Autor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                _autorService.UpdateAutor(id, collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Autor/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_autorService.GetAutor(id));
        }

        // POST: Autor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                _autorService.DeleteAutor(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
    }
}
