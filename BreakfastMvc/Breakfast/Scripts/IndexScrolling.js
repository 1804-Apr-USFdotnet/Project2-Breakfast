$( document ).ready( function() {
  // scrollTo('.Sidebar-links')		;
  scrollTo();
});

function scrollTo () {
    $('.Sidebar-navItem a').click(function(e) {
      e.preventDefault();
        $('.Sidebar-navItem a').removeClass('active');
      $(this).addClass('active');
    
     var distanceTopToSection = $($(this).data('target')).offset().top;
    		 $( 'body, html' ).animate({scrollTop:distanceTopToSection }, 'slow');
  });
}