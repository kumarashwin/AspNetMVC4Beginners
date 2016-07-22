﻿using OdeToFood.Models;
using OdeToFood.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDB _db = new OdeToFoodDB();

        public ActionResult Autocomplete(string term)
        {
            var model = _db.Restaurants
                .Where(restaurant => restaurant.Name.StartsWith(term))
                .Take(10)
                .Select(r => new { label = r.Name });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            var model = _db.Restaurants
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