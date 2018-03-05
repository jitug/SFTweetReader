using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterChallenge.Models;
using TwitterChallenge.Services;
using TwitterChallenge.Utility;

namespace TwitterChallenge.Configurations.Tests
{
    [TestClass()]
    public class FactoryTests
    {
        /// <summary>
        /// This is a positive test to get the object based on correct key
        /// </summary>
        [TestMethod()]        
        public void GetObjectTest()
        {
            //Arrange
            string getObjectFor = "configurationKeys";

            //Act
            var Object = Factory.GetObject<IConfigurationModel>(getObjectFor);

            //Assert
            Assert.IsTrue(Object is ConfigurationModel);
        }

        /// <summary>
        /// This is a negative test which throws an exception based on wrong keys
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(Unity.Exceptions.ResolutionFailedException), "A wrong string value was inappropriately passed.")]
        public void GetObjectNegativeTest()
        {
            //Arrange
            string getObjectFor = "khsdbvsdv";

            //Act
            var Object = Factory.GetObject<IConfigurationModel>(getObjectFor);
        }
    }
}