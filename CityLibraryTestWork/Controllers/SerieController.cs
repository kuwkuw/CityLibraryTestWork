using System.Web.Mvc;
using CityLibraryTestWork.Models;
using CityLibraryTestWork.Services;

namespace CityLibraryTestWork.Controllers
{
    public class SerieController : Controller
    {

        SerieService _serieService = new SerieService(); 
        // GET: Serie
        public ActionResult Index()
        {
            return View(_serieService.GetSeries());
        }

        // GET: Serie/Details/5
        public ActionResult Details(int id)
        {
            return View(_serieService.GetSerie(id));
        }

        // GET: Serie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Serie/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                _serieService.AddSerie(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Serie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Serie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                _serieService.UpdateSerie(id, collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Serie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Serie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _serieService.DeleteSerie(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
