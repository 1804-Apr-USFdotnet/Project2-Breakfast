$(document).ready(function () {
    var tabs = $(".tabs li a");
    tabs.click(function () {
        var content = this.hash.replace('/', '');
        tabs.removeClass("active");
        $(this).addClass("active");
        $("#content").find('p').hide();
        $("#content").find('.wrapper-settings').hide();
        //$(content).fadeIn(200);
        $(content).show();
        $(content).find('.wrapper-settings').fadeIn(200);

    });
});