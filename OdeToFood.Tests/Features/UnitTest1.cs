using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFood.Models;
using System.Linq;

namespace OdeToFood.Tests.Features
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Computes_Result_For_One_Review()
        {
            var rater = new Restaurant()
                            .AddReviewsWithRatings(4)
                            .GetRater();

            var result = rater.ComputeResult(new SimpleRatingAlgorithm(), 10);

            Assert.AreEqual(4, result.Rating);
        }

        [TestMethod]
        public void Computes_Result_For_Two_Reviews()
        {
            var rater = new Restaurant()
                            .AddReviewsWithRatings(4, 8)
                            .GetRater();

            var result = rater.ComputeResult(new SimpleRatingAlgorithm(), 10);

            Assert.AreEqual(6, result.Rating);
        }

        [TestMethod]
        public void Computes_Weighted_Result_For_Two_Reviews()
        {
            var rater = new Restaurant()
                            .AddReviewsWithRatings(4, 8)
                            .GetRater();

            var result = rater.ComputeResult(new WeightedRatingAlgorithm(), 10);

            Assert.AreEqual(5, result.Rating);
        }

        [TestMethod]
        public void Computes_Result_For_Only_First_N_Reviews()
        {
            var rater = new Restaurant()
                            .AddReviewsWithRatings(1,1,1,10,10,10)
                            .GetRater();

            var result = rater.ComputeResult(new SimpleRatingAlgorithm(), 3);

            Assert.AreEqual(1, result.Rating);
        }
    }
}
