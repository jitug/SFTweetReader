///This method is called on the load of '/Tweets/Timeline' page 
///and it is called on every key stroke to search the displayed list of tweets.
//refered to the web to develop the below method
(function ($) {
    $(document).ready(function () {
        var rows = jQuery('li');
        $('#search').keyup(function () {
            var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();

            rows.show().filter(function () {
                var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                return !~text.indexOf(val);
            }).hide();
        });
    })
})(jQuery);