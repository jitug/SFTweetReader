using TwitterChallenge.Models;
using TwitterChallenge.Services;
using Unity;

namespace TwitterChallenge.Utility
{
    /// <summary>
    /// This class implements Unity to resolve dependency
    /// </summary>
    /// <typeparam name="T">Interface for which the Object is expected</typeparam>
    public static class Factory
    {
        /// <summary>
        /// Unity container.
        /// </summary>
        private static IUnityContainer container;

        /// <summary>
        /// This constructor will be called only once, when this class is first accessed, it is used for initializing the unity container.
        /// </summary>
        static Factory()
        {
            Initialize();
        }

        /// <summary>
        /// Intiliazes and registers the Unity container.
        /// </summary>
        private static void Initialize()
        {
            container = new UnityContainer();
            container.RegisterType<IConfigurationModel, ConfigurationModel>("configurationKeys");
        }

        /// <summary>
        /// This method provides the actual object instance for the Interface
        /// </summary>
        /// <param name="configuration">The filtering on the container is done on the basis of this parameter</param>
        /// <returns></returns>
        public static T GetObject<T>(string configuration)
        {
            if (container == null)
            {
                Initialize();
            }
            return (T)container.Resolve<T>(configuration);
        }
    }
}