using OdeToFood.Models;
using OdeToFood.Tests.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Tests
{
    public static class TestExtensions
    {
        public static Restaurant AddReviewsWithRatings(this Restaurant restaurant, params int[] ratings)
        {
            restaurant.Reviews = ratings
                .Select(r => new RestaurantReview { Rating = r })
                .ToList();

            return restaurant;
        }

        public static RestaurantRater GetRater(this Restaurant restaurant) =>
            new RestaurantRater(restaurant);

    }
}
