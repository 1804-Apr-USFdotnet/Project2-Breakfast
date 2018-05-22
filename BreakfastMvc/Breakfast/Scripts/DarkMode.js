$('#mode').change(function () {
    if ($(this).prop('checked')) {
        $('.wrapper').addClass('dark-mode');
    }
    else {
        $('.wrapper').removeClass('dark-mode');
    }
});