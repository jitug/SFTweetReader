
namespace TwitterChallenge.Services
{
    /// <summary>
    /// This Interface helps to develop mock configurations for this class, and also to provide decoupling.
    /// </summary>
    public interface IConfigurationModel
    {
        /// <summary>
        /// Consumer Key loaded from configuration, taken from Twitter Api settings for this application
        /// </summary>
        string ConsumerKey { get; }
        /// <summary>
        /// Consumer Secret loaded from configuration, taken from Twitter Api settings for this application
        /// </summary>
        string ConsumerSecret { get; }
        /// <summary>
        /// Access Token loaded from configuration, taken from Twitter Api settings for this application
        /// </summary>
        string AccessToken { get; }
        /// <summary>
        /// Access Token Secret loaded from configuration, taken from Twitter Api settings for this application
        /// </summary>
        string AccessTokenSecret { get; }
    }
}
