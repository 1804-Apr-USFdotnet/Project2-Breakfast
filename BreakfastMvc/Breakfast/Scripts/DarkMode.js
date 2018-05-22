$(document).ready(function () {
    $('#mode').on('change', function () {
        if ($(this).prop('checked')) {
            $('.wrapper').addClass('dark-mode');
            $('.wrapper').removeClass('light-mode');
        }
        else {
            $('.wrapper').removeClass('dark-mode');
            $('.wrapper').addClass('light-mode');
        }
    });
});