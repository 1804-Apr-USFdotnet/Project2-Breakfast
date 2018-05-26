$(document).ready(function () {
    $('#mode').on('change', function () {
        if ($(this).prop('checked')) {
            $('.weather-wrapper .wrapper').addClass('dark-mode');
            $('.weather-wrapper .wrapper').removeClass('light-mode');
            $('.weather-wrapper *').addClass('dark-mode-text');
            $('.weather-wrapper *').removeClass('light-mode-text');
            $('.city').addClass('dark-mode-element');
            $('.searchbar').addClass('dark-mode-element');
            $('.city').removeClass('light-mode-element');
            $('.searchbar').removeClass('light-mode-element');
        }
        else {
            $('.weather-wrapper .wrapper').removeClass('dark-mode');
            $('.weather-wrapper .wrapper').addClass('light-mode');
            $('.weather-wrapper *').removeClass('dark-mode-text');
            $('.weather-wrapper *').addClass('light-mode-text');
            $('.city').addClass('light-mode-element');
            $('.searchbar').addClass('light-mode-element');
            $('.city').removeClass('dark-mode-element');
            $('.searchbar').removeClass('dark-mode-element');
        }
    });
});