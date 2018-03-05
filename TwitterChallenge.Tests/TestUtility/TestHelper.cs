using Moq;
using System.Web.Mvc;
using TwitterChallenge.Controllers;
using TwitterChallenge.Services;

namespace TwitterChallenge.TestUtility
{
    public class TestHelper
    {
        /// <summary>
        /// This is a helper method to provide Tempdata context to the test
        /// </summary>
        public static TempDataDictionary AuthorizeApplication()
        {
            OAuthController controller = new OAuthController();
            controller.TempData = new TempDataDictionary();
            var result = controller.AuthorizeApplication() as ViewResult;

            return (TempDataDictionary)result.TempData;
        }

        /// <summary>
        /// This is a helper method to provide mocked configuration information to the test
        /// </summary>
        public static Mock<IConfigurationModel> GetMockedConfiguration()
        {
            Mock<IConfigurationModel> configuration = new Mock<IConfigurationModel>();
            configuration.SetupGet(x => x.ConsumerKey).Returns("");
            configuration.SetupGet(x => x.ConsumerSecret).Returns("");
            configuration.SetupGet(x => x.AccessToken).Returns("");
            configuration.SetupGet(x => x.AccessTokenSecret).Returns("");
            return configuration;
        }
    }
}
