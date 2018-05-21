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

function scrollToTop () {
  var backToTop = $('.backToTop');
  var showBackTotop = $(window).height();
  backToTop.hide();
  
  var children = $(".Sidebar li").children(); 
  var tab = []; 
  for (var i=0; i < children.length; i++) {
    console.log(children[i]);
    var child = children[i];
    var ahref = $(child).attr('href'); 
    console.log(ahref);
    tab.push(ahref);
  }
  

  $(window).scroll( function() {
    var windowScrollTop = $(window).scrollTop();
    if( windowScrollTop > showBackTotop  ) {
      backToTop.fadeIn('slow');
    } else {
      backToTop.fadeOut('slow');
    }
    
    var windowHeight = $(window).height(); 
    var docHeight = $(document).height();

    for (var i=0; i < tab.length; i++) {
        var link = tab[i];
        var divPos = $(link).offset().top; 
        var divHeight = $(link).height(); 
        if (windowScrollTop >= divPos && windowScrollTop < (divPos + divHeight)) {
            $(".Sidebar a[href='" + link + "']").addClass("active");
        } else {
            $(".Sidebar a[href='" + link + "']").removeClass("active");
        }
    }

    if(windowScrollTop + windowHeight == docHeight) {
        if (!$(".Sidebar li:last-child a").hasClass("active")) {
            var navActive = $(".active").attr("href");
            $(".Sidebar a[href='" + navActive + "']").removeClass("active");
            $(".Sidebar li:last-child a").addClass("active");
        }
    }
  });

  backToTop.click( function(e) {
    e.preventDefault();
    $(' .Sidebar li a ').removeClass( 'active' );
    $(' .Sidebar li a:first ').addClass( 'active' );
    $(' body, html ').animate( {scrollTop : 0}, 'slow' );
  });
}