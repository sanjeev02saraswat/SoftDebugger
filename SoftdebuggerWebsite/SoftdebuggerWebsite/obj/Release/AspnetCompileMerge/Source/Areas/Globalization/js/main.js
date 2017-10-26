$(document).ready(function() {
	/*back to top js*/
	// browser window scroll (in pixels) after which the "back to top" link is shown
	var offset = 300,
		//browser window scroll (in pixels) after which the "back to top" link opacity is reduced
		offset_opacity = 1200,
		//duration of the top scrolling animation (in ms)
		scroll_top_duration = 700,
		//grab the "back to top" link
		$back_to_top = $('.bt-top');

	//hide or show the "back to top" link
	$(window).scroll(function(){
		( $(this).scrollTop() > offset ) ? $back_to_top.addClass('cd-is-visible') : $back_to_top.removeClass('cd-is-visible cd-fade-out');
		if( $(this).scrollTop() > offset_opacity ) { 
			$back_to_top.addClass('cd-fade-out');
		}
	});

	//smooth scroll to top
	$back_to_top.on('click', function(event){
		event.preventDefault();
		$('body,html').animate({
			scrollTop: 0 ,
		 	}, scroll_top_duration
		);
	});

	//Third Party suppliers filters tabs

	//$(".partner-ftab-container").hide(); //Hide all content
	$(".partner-filter-ul .prtnr-filter-li:first").addClass("prtnr-active").show(); //Activate first tab
	$(".partner-ftab-container:first").show(); //Show first tab content

	//On Click Event
	$(".partner-filter-ul .prtnr-filter-li").click(function() {
		
		$(".partner-filter-ul .prtnr-filter-li").removeClass("prtnr-active"); //Remove any "active" class
		$(this).addClass("prtnr-active"); //Add "active" class to selected tab
		//$(".partner-ftab-container").hide(); //Hide all tab content

		var activeTab = $(this).find("a").attr("href"); //Find the href attribute value to identify the active tab + content
		$(activeTab).fadeIn(800); //Fade in the active ID content

		var aTag = $(activeTab);
		$('html,body').animate({scrollTop: aTag.offset().top-125},800);

		return false;
	});
	
	//Third Party suppliers filters position
	if($(window).width() >= 767){

		// sticky nav
		$(window).scroll(function() {
			if ($(this).scrollTop() > 560){  
				$('.partner-filter-section').addClass("stickynav");
				//$('.bullet_train').addClass("stickynav_con"); responsive correction
			}
			else{
				$('.partner-filter-section').removeClass("stickynav");
				//$('.bullet_train').removeClass("stickynav_con");
			}
		});

	}
	
	
});

/* ========== Push Menu =================== */
$(function() {
	var items = $('.overlapblackbg, .slideLeft');
	var wsmenucontent = $('.wsmenucontent');
	
	var menuopen = function() {
	$(items).removeClass('menuclose').addClass('menuopen');
						}
	var menuclose = function() { 
	$(items).removeClass('menuopen').addClass('menuclose');
	}

	$('#navToggle').click(function(){
		if (wsmenucontent.hasClass('menuopen')) {$(menuclose)}
		else {$(menuopen)}
	});
	wsmenucontent.click(function(){
		if (wsmenucontent.hasClass('menuopen')) {$(menuclose)}
	});
	
	$('#navToggle,.overlapblackbg').on('click', function(){
	$('.wsmenucontainer').toggleClass( "mrginleft" );
	});

	$('.wsmenu-list li').has('.wsmenu-submenu, .wsmenu-submenu-sub, .wsmenu-submenu-sub-sub').prepend('<span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span>');
	
	//$('.wsmenu-list li').has('.halfdiv').prepend('<span class="wsmenu-click"><i class="wsmenu-arrow"></i></span>');
	
	$('.wsmenu-list li').has('.megamenu').prepend('<span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span>');
		
	$('.wsmenu-mobile').click(function(){
		$('.wsmenu-list').slideToggle('slow');
	});
	$('.wsmenu-click').click(function(){
	//alert($('.mobile-sub.wsmenu-list li ul.wsmenu-submenu').hide());
	$(this).siblings('.wsmenu-submenu').slideToggle('slow');
	$(this).children('.wsmenu-arrow').toggleClass('wsmenu-rotate');
	$(this).siblings('.wsmenu-submenu-sub').slideToggle('slow');
	$(this).siblings('.wsmenu-submenu-sub-sub').slideToggle('slow');
	$(this).siblings('.megamenu').slideToggle('slow');
		
	});

});