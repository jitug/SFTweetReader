using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TwitterChallenge.Models
{
    /// <summary>
    /// This is a list of all the properties in the tweets.
    /// </summary>
    public class TweetViewModel
    {
        /// <summary>
        /// user name of the user in the tweet
        /// </summary>
        [DisplayName("User Name")]
        public string UserName { get; set; }

        /// <summary>
        /// Screen Name of user in the tweet
        /// </summary>
        [DisplayName("Screen Name")]
        public string ScreenName { get; set; }

        /// <summary>
        /// Image url of the User
        /// </summary>
        [DisplayName("Image")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Tweet text with Image or other links
        /// </summary>
        [DisplayName("Tweet")]
        public string Text { get; set; }

        /// <summary>
        /// Retweet count of the current tweet
        /// </summary>
        [DisplayName("RetweetCount")]
        public int RetweetCount { get; set; }

        /// <summary>
        /// Tweet Date
        /// </summary>
        [DisplayName("Tweet Date")]
        public DateTime TweetDate { get; set; }
    }
}