$(document).ready(function () {
    $('#mode').on('change', function () {
        if ($(this).prop('checked')) {
            $('.wrapper').addClass('dark-mode');
            $('.wrapper').removeClass('light-mode');
            $('*').addClass('dark-mode-text');
            $('*').removeClass('light-mode-text');

        }
        else {
            $('.wrapper').removeClass('dark-mode');
            $('.wrapper').addClass('light-mode');
            $('*').removeClass('dark-mode-text');
            $('*').addClass('light-mode-text');
        }
    });
});