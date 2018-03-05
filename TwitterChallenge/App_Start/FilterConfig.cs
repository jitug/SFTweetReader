using System.Web.Mvc;

namespace TwitterChallenge
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //This filter helps in throwing any error caused by a controller or action and opens the default error page in case of error.
            filters.Add(new HandleErrorAttribute());
        }
    }
}
