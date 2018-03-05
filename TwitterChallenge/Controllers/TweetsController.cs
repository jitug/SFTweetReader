using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TwitterChallenge.Models;
using LinqToTwitter;
using TwitterChallenge.Utility;

namespace TwitterChallenge.Controllers
{
    /// <summary>
    /// This class generate the tweets if the application is authorized
    /// </summary>
    public class TweetsController : Controller
    {
        /// <summary>
        /// Filter to query twitter by screen name
        /// </summary>
        private const string _screenName = "salesforce";
        /// <summary>
        /// Filter to query twitter to fetch the top no of rows
        /// </summary>
        private const int _topNoOfRows = 10;
        /// <summary>
        /// Filter to query twitter with status type
        /// </summary>
        private const StatusType _statusType = StatusType.User;

        /// <summary>
        /// This Method gets the tweets from a users timeline, if authourized, else sends back for authorization.
        /// Referred linqtotwitter documentation for developing the method
        /// </summary>
        /// <returns>Tweets data model</returns>
        [ActionName("Timeline")]
        public async Task<ActionResult> TimelineAsync()
        {
            if (TempData["authKey"] == null)
            {
                return RedirectToAction("Index", "OAuth");
            }

            var tweets =
                await
                (from tweet in (new TwitterContext((IAuthorizer)TempData["authKey"])).Status
                    where tweet.Type == _statusType &&
                    tweet.ScreenName == _screenName
                 select new TweetViewModel
                    {
                        UserName = tweet.User.Name,
                        ScreenName = "@" + tweet.User.ScreenNameResponse,
                        ImageUrl = tweet.User.ProfileImageUrl,
                        Text = tweet.TextAsHtml(),
                        RetweetCount = tweet.RetweetCount,
                        TweetDate = tweet.CreatedAt
                    })
                .Take(_topNoOfRows)
                .ToListAsync();

            return View(tweets);         
        }
    }
}
