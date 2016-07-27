using OdeToFood.Models;
using OdeToFood.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        IOdeToFoodDB _db;

        public HomeController()
        {
            this._db = new OdeToFoodDB();
        }

        public HomeController(IOdeToFoodDB db)
        {
            this._db = db;
        }

        public ActionResult Autocomplete(string term)
        {
            var model = _db.Query<Restaurant>()
                .Where(restaurant => restaurant.Name.StartsWith(term))
                .Take(10)
                .Select(r => new { label = r.Name });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 60, VaryByHeader = "X-Requested-With", Location = OutputCacheLocation.Server)]
        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            var model = _db.Query<Restaurant>()
                .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                .Select( r => new RestaurantListViewModel {
                    Id = r.Id,
                    Name = r.Name,
                    City = r.City,
                    Country = r.Country,
                    CountOfReviews = r.Reviews.Count()})
                .ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
                return PartialView("_Restaurants", model);

            return View(model);
        }

        public ActionResult About()
        {
            var model = new AboutModel(){
                Name = "Scott",
                Location = "Maryland, USA"};
            
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if(_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}