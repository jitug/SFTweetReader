using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;
using TwitterChallenge.Models;
using TwitterChallenge.TestUtility;

namespace TwitterChallenge.Controllers.Tests
{
    [TestClass()]
    public class TweetsControllerTests
    {
        /// <summary>
        /// Test case to check when no tweets are returned
        /// </summary>
        [TestMethod()]
        public void WhenReturnNoTweets()
        {
            //Arrange    
            TweetsController controller = new TweetsController();

            // Act
            var result = controller.TimelineAsync().Result as ViewResult;

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// Test case to check when all 10 tweets are returned
        /// </summary>
        [TestMethod()]
        public void WhenReturnAllTweets()
        {
            //Arrange
            TweetsController controller = new TweetsController();
            controller.TempData = new TempDataDictionary();
            controller.TempData = TestHelper.AuthorizeApplication();

            // Act            
            var result = controller.TimelineAsync().Result as ViewResult;
            var model = (List<TweetViewModel>)(result.Model);          
            
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(10, model.Count);
        }        
    }
}