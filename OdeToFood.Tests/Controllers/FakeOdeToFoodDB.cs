using System;
using System.Linq;
using OdeToFood.Models;
using System.Collections.Generic;

namespace OdeToFood.Tests.Controllers
{
    internal class FakeOdeToFoodDB : IOdeToFoodDB
    {
        public void Dispose()
        { }

        public IQueryable<T> Query<T>() where T : class
        {
            return Sets[typeof(T)] as IQueryable<T>;
        }

        public void AddSet<T>(IQueryable<T> objects)
        {
            Sets.Add(typeof(T), objects);
        }

        public Dictionary<Type, object> Sets = new Dictionary<Type, object>();
    }
}