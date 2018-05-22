$(document).ready(function () {
    $('#mode').on('change', function () {
        if ($(this).prop('checked')) {
            $('.wrapper').addClass('dark-mode');
            $('.wrapper').removeClass('light-mode');
            $('*').addClass('dark-mode-text');
            $('*').removeClass('light-mode-text');
            $('.city').addClass('dark-mode-element');
            $('.searchbar').addClass('dark-mode-element');
            $('.city').removeClass('light-mode-element');
            $('.searchbar').removeClass('light-mode-element');

        }
        else {
            $('.wrapper').removeClass('dark-mode');
            $('.wrapper').addClass('light-mode');
            $('*').removeClass('dark-mode-text');
            $('*').addClass('light-mode-text');
            $('.city').addClass('light-mode-element');
            $('.searchbar').addClass('light-mode-element');
            $('.city').removeClass('dark-mode-element');
            $('.searchbar').removeClass('dark-mode-element');
        }
    });
});