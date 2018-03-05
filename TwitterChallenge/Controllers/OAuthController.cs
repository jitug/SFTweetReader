using System.Threading.Tasks;
using System.Web.Mvc;
using LinqToTwitter;
using TwitterChallenge.Services;
using TwitterChallenge.Utility;

namespace TwitterChallenge.Controllers
{
    /// <summary>
    /// Application authorization logic 
    /// </summary>
    public class OAuthController : Controller
    {
        /// <summary>
        /// Used to lock process from other threads
        /// </summary>
        private static readonly object SyncLock = new object();

        /// <summary>
        /// Dependency is loaded from unity container for configurations defined at Web.config
        /// </summary>
        private const string ConfigurationName = "configurationKeys";
        private IConfigurationModel _Configuration = Factory.GetObject<IConfigurationModel>(ConfigurationName);
        
        /// <summary>
        /// Configuration values for authorization of the application.
        /// </summary>
        public IConfigurationModel Configuration
        {
            get => _Configuration;
            set => _Configuration = value;
        }

        /// <summary>
        /// This method implements a single user authorizer for the application, it authenticates twitter with a single user.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (TempData["authKey"] == null)
            {
                ViewResult actionResult = AuthorizeApplication() as ViewResult;
                if(actionResult.ViewName == "Error")
                    return actionResult;
            }

            return RedirectToAction("Timeline", "Tweets");
        }

        /// <summary>
        /// This method implements a single user authorizer, it does not require user to enter his twitter credentials.
        /// </summary>
        /// <returns>Returns a View with error or success, depending on if authorization is successful.</returns>
        public ActionResult AuthorizeApplication()
        {
            //Referred linqtotwitter documentation for the authorization , 
            //tried SessionStateAuthorizer and InMemoryAuthorizer before finalizing on SingleUserAuthorizer
            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = Configuration.ConsumerKey,
                    ConsumerSecret = Configuration.ConsumerSecret,
                    AccessToken = Configuration.AccessToken,
                    AccessTokenSecret = Configuration.AccessTokenSecret
                }
            };

            if (TempData["authKey"] == null)
            {
                // lock to avoid race conditions
                lock (SyncLock)
                {
                    if (TempData["authKey"] == null)
                    {
                        TaskStatus taskStatus = auth.AuthorizeAsync().Status;

                        if (taskStatus == TaskStatus.Faulted)
                        {
                            TempData["authKey"] = null;
                            return View("Error");
                        }

                        if (taskStatus == TaskStatus.RanToCompletion)
                        {
                            TempData["authKey"] = auth;
                        }
                    }
                }
            }

            return View();
        }        
    }
}
