"use strict";

$(window).on('load',function() {

	/* Preloader */
	$(".preloader").delay(500).fadeOut("slow");

	/* Check Scroll for navbar */
	checkScroll();

	/* Check Hash for open-positions */
	if( location.hash && location.hash.length && $('#job-list').length) {
		var hash = decodeURIComponent(location.hash.substr(1));
		var query = "#tab-" + hash;
		$('#job-list a[href="'+query+'"]').tab('show')
	}
});

$(window).on("scroll", function () {
	/* Check Scroll for navbar */
	checkScroll();
});

$('#landingModal').on("scroll", function () {
	/* Check Scroll for navbar */
	checkModalScroll();
});

function checkScroll(){
	var scroll = $(window).scrollTop();

	if (scroll >= 100) {
		$(".navbar").addClass("bg-scroll");
		$(".scroll-to-top").fadeIn(300);
	} else {
		$(".navbar").removeClass("bg-scroll");
		$(".scroll-to-top").fadeOut(300);
	}
}

function checkModalScroll(){
	var scroll = $('#landingModal').scrollTop();

	if (scroll >= 100) {
		$(".modal-scroll-to-top").fadeIn(300);
	} else {
		$(".modal-scroll-to-top").fadeOut(300);
	}
}

$(document).on( "click", "a.mobile-nav-show", function(event) {
	event.preventDefault();
	$("html").addClass("mobile-nav-open")
	$("body").addClass("mobile-nav-open")
	$(".navbar-brand").css("opacity",0)
});

$(document).on( "click", "a.mobile-nav-hide", function(event) {
	event.preventDefault();
	$("html").removeClass("mobile-nav-open")
	$("body").removeClass("mobile-nav-open")
	$(".navbar-brand").css("opacity",1)
});

if( $('video').length ) {
	var bLazy = new Blazy({
		success: function(element){
			setTimeout(function(){
				$(".video-loader").hide();
			}, 200);
		}
	});
}

$(document).ready(function() {

	'use strict';

	// Homepage discover now action
	$('.discover-now').on("click", function () {
		$('html, body').stop().animate({
			scrollTop: $($(this).attr('href')).offset().top - 70
		}, 1000);
		return false;
	});

	// Parallax
	$('.parallax-window').parallax({
		zIndex: -100,
	});

	// Scroll to top
	$(".scroll-to-top").on('click', function() {
		var target = $(this).attr('data-target');
		$('html, body').animate({
			scrollTop: $(target).offset().top
		}, 1000);
	});

	$(".modal-scroll-to-top").on('click', function() {
		$('#landingModal').animate({
			scrollTop: 0
		}, 1000);
	});

	//Career slider
	if( $('.swiper-container').length ) {
		var jobSwiper = new Swiper('.swiper-container', {
			autoplay: {
				delay: 6000,
			},
			speed: 500,
			navigation: {
				nextEl: '.career-control-right',
				prevEl: '.career-control-left',
			},
			roundLengths: true,
			slidesPerView: 3,
			spaceBetween: 30,
			grabCursor: true,
			breakpoints: {
				992: {
					slidesPerView: 1
				},
				1199: {
					slidesPerView: 2
				}
			}
		});
	}

	/* Open Positions initially scrolled to job listings section on mobile */
	if( $('#nav-tabContent').length  && $(window).width() < 992) {
		$('html, body').stop().animate({
			scrollTop: $("#nav-tabContent").offset().top - 100
		}, 500);
	}

	/* Open Positions Filter */

	$('#job-list a').on('click', function (e) {
		var target = $(this).attr("href").split("-")[1];
		location.hash = target;

		$('html, body').stop().animate({
			scrollTop: $("#nav-tabContent").offset().top - 100
		}, 500);
	});
});
