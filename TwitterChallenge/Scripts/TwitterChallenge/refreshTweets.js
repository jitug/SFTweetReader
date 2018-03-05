///This method is called on the load of '/Tweets/Timeline' page 
///and it calls the timeline action in every 60 seconds to fetch the latest 10 tweets
(function ($) {
    $(document).ready(function () {
        function RefreshTweets() {
            setTimeout(function () {
                $.ajax({
                    url: '/Tweets/Timeline',
                    type: 'get',
                    cache: false,
                    async: true,
                    success: function (result) {
                    }
                });
                RefreshTweets();
            }, 60000);
        }
        RefreshTweets();
    })
})(jQuery);