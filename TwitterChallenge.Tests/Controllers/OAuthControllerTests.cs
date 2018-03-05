using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using TwitterChallenge.Services;
using TwitterChallenge.TestUtility;

namespace TwitterChallenge.Controllers.Tests
{
    [TestClass()]
    public class OAuthControllerTests
    {
        /// <summary>
        /// Test the index method with wrong key values
        /// </summary>
        [TestMethod()]
        public void TestIndexByPassingWrongorEmptyKeys()
        {
            // Arrange
            Mock<IConfigurationModel> configuration = TestHelper.GetMockedConfiguration();
            OAuthController controller = new OAuthController();
            controller.Configuration = configuration.Object;

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        /// <summary>
        /// Test the index action method with correct Key values
        /// </summary>
        [TestMethod()]
        public void TestIndexByPassingCorrectConfigurationValues()
        {
            // Arrange
            OAuthController controller = new OAuthController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// Test Authorization with correct keys
        /// </summary>
        [TestMethod()]
        public void TestAuthorizationWithCorrectKeys()
        {
            // Arrange
            OAuthController controller = new OAuthController();

            // Act
            ViewResult result = controller.AuthorizeApplication() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual("Error", result.ViewName);
        }

        /// <summary>
        /// Test Authorization with wrong keys
        /// </summary>
        [TestMethod()]
        public void TestAuthorizationWithWrongorEmptyKeys()
        {
            // Arrange
            Mock<IConfigurationModel> configuration = TestHelper.GetMockedConfiguration();
            OAuthController controller = new OAuthController();
            controller.Configuration = configuration.Object;

            // Act
            ViewResult result = controller.AuthorizeApplication() as ViewResult;

            // Assert
            Assert.AreEqual("Error",result.ViewName);
        }
    }
}