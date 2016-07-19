using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        //[ChildActionOnly]
        //public ActionResult BestReview()
        //{
        //    var bestReview = _reviews.OrderByDescending(r => r.Rating);

        //    return PartialView("_Review", bestReview.First());
        //}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //public ActionResult Edit(int id)
        //{
        //    var review = _reviews.Single(r => r.Id == id);

        //    return View(review);
        //}

        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    var review = _reviews.Single(r => r.Id == id);

        //    if (TryUpdateModel(review))
        //    {
        //        // .. make changes in DB ..
        //        return RedirectToAction("Index");
        //    }
        //    return View(review);
        //}

        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /*
        #region SeedData
        static List<RestaurantReview> _reviews = new List<RestaurantReview>(){
            new RestaurantReview{
                Id = 1,
                Name = "Cinnamon Club",
                City = "London",
                Country = "UK",
                Rating = 10},

            new RestaurantReview{
                Id = 2,
                Name = "Marrakesh",
                City = "D.C.",
                Country = "USA",
                Rating = 10},
             
            new RestaurantReview{
                Id = 3,
                Name = "The House of Elliot",
                City = "Ghent",
                Country = "Belgium",
                Rating = 10}};
        #endregion
        */
    }
}