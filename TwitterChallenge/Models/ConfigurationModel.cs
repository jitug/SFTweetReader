using System.Configuration;
using TwitterChallenge.Services;

namespace TwitterChallenge.Models
{
    /// <summary>
    /// Twitter Api Configuration values loaded from the web configuration file
    /// </summary>
    public class ConfigurationModel : IConfigurationModel
    {
        /// <summary>
        /// Consumer key is essentially the twitter API key associated with the application to identify the client application
        /// </summary>
        public string ConsumerKey => ConfigurationManager.AppSettings["consumerKey"];
        /// <summary>
        /// Consumer secret is the client password that is used to authenticate with the twitter authentication server
        /// </summary>
        public string ConsumerSecret => ConfigurationManager.AppSettings["consumerSecret"];
        /// <summary>
        /// Access token is what is issued to the client once the client successfully authenticates itself (using the consumer key & secret). This access token defines the privileges of the client
        /// </summary>
        public string AccessToken => ConfigurationManager.AppSettings["accessToken"];
        /// <summary>
        /// Every time the client wants to access the end-user's data, the access token secret is sent with the access token as a password (similar to the consumer secret)
        /// </summary>
        public string AccessTokenSecret => ConfigurationManager.AppSettings["accessTokenSecret"];
    }
}
