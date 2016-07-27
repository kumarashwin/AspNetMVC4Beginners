namespace OdeToFood.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFoodDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OdeToFoodDB context)
        {
            context.Restaurants.AddOrUpdate(r => r.Name,
                new Restaurant { Name = "Sabatino's", City = "Baltimore", Country = "USA"},
                new Restaurant { Name = "Great Lake", City = "Chicago", Country = "USA" },
                new Restaurant
                {
                    Name = "Smaka",
                    City = "Gothenburg",
                    Country = "Sweden",
                    Reviews = new List<RestaurantReview> {
                        new RestaurantReview { Rating = 9, Body = "Great food!", ReviewerName = "Scott" }
                    }
                });

            //context.Reviews.AddOrUpdate(review => review.RestaurantId,
            //new RestaurantReview
            //{
            //    Rating = 9,
            //    Body = "Great food!",
            //    ReviewerName = "Scott",
            //    RestaurantId = context.Restaurants.Single(restaurant => restaurant.Name == "Smaka").Id
            //});

            for (int i = 0; i < 1000; i++)
            {
                context.Restaurants.AddOrUpdate(r => r.Name,
                    new Restaurant {
                        Name = i.ToString(),
                        City = "Nowhere",
                        Country = "USA"});
            }
        }
    }
}
