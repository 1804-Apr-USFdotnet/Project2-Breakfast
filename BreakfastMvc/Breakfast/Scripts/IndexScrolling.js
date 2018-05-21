$( document ).ready( function() {
  // scrollTo('.Sidebar-links')		;
  scrollTo();
  scrollToTop();
});

function scrollTo () {
  $('.Sidebar a').click(function(e) {
      e.preventDefault();
      $('.Sidebar a').removeClass('active');
      $(this).addClass('active');
    
     var distanceTopToSection = $( '#' +  $(this).data('target')).offset().top;
    		 $( 'body, html' ).animate({scrollTop:distanceTopToSection }, 'slow');
  });
}