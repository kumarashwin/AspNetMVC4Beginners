using System.Collections.Generic;
using OdeToFood.Models;

namespace OdeToFood.Tests.Features
{
    public interface IRatingAlgorithm
    {
        RatingResult Compute(IList<RestaurantReview> list);
    }
}