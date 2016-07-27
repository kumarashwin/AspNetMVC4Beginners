using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public interface IOdeToFoodDB : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
    }

    public class OdeToFoodDB : DbContext, IOdeToFoodDB
    {
        public OdeToFoodDB() : base("OdeToFoodDB")
        {

        }

        public static OdeToFoodDB Create()
        {
            return new OdeToFoodDB();
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet <RestaurantReview> Reviews { get; set; }

        IQueryable<T> IOdeToFoodDB.Query<T>()
        {
            return Set<T>();
        }
    }
}