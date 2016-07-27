using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Tests.Controllers
{
    class TestData
    {
        public static IQueryable<Restaurant> Restaurants
        {
            get
            {
                var restaurants = new List<Restaurant>();
                for (int i = 0; i < 100; i++)
                {
                    restaurants.Add(new Restaurant().AddReviewsWithRatings(4));
                }

                return restaurants.AsQueryable();
            }
        }

    }
}
