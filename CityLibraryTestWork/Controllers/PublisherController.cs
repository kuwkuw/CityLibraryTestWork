using System.Web.Mvc;
using CityLibraryTestWork.Models;
using CityLibraryTestWork.Services;

namespace CityLibraryTestWork.Controllers
{
    public class PublisherController : Controller
    {
        static LibraryDbContext _context = new LibraryDbContext();
        PublisherService _publiserService = new PublisherService(_context); 
        // GET: Publisher
        public ActionResult Index()
        {
            return View(_publiserService.GetPublishers());
        }

        // GET: Publisher/Details/5
        public ActionResult Details(int id)
        {
            return View(_publiserService.GetPublisher(id));
        }

        // GET: Publisher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publisher/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                _publiserService.AddPublisher(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Publisher/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_publiserService.GetPublisher(id));
        }

        // POST: Publisher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                _publiserService.UppdatePublisher(id, collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Publisher/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Publisher/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _publiserService.DeletePublisher(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
//            _context.Dispose();
            base.Dispose(disposing);
        }
    }
}
