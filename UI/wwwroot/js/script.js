$(document).ready((function () {
	function t() {
		 if ($(".tpl23-main-slider").length > 0) {
			 $(".tpl23-main-slider-item").each((
				 function(t, o) {
					 let l = $(o).attr("data-large-url"),
						 s = $(o).attr("data-middle-url"),
						 a = $(o).attr("data-mobile-url");
					 $(window).width() >= 1025 ? $(o).css({ "background-image": "url(" + l + ")" }) : $(window).width() >= 992 && $(window).width() < 1025 ? $(o).css({ "background-image": "url(" + s + ")" }) : $(o).css({ "background-image": "url(" + a + ")" })
				 }))
		 }
	}
	$(".b-ths-search").each((
			function(t) {
				t.stopPropagation,
					$(this).is(":visible") ? ($(this).attr("id", "oem_search"),
					$(this).find(".b-input-search").attr("id", "oem"),
					$(this).find(".b-input-search").attr("name", "oem")) : ($(this).attr("id", ""), $(this).find(".b-input-search").attr("id", ""),
						$(this).find(".b-input-search").attr("name", ""))
		})),
		$(".search-history").on("click", (function() {
				 $(".search-history-popup").addClass("show")
			})), $(".tpl23-header-mobile-menu").on("click", (function() {
				 $(".tpl23-mobv-nav").addClass("show")
				})), $(".tpl23-btn-catalog").on("click", (function() {
				 $(this).toggleClass("decor")
			})),
		$(".tpl23-btn-catalog-desktop").on("click", (function () {
			$(".tpl23-catalog-dropdown-desktop").toggleClass("show-catalog"),
				$(".tpl23-catalog-title").first().addClass("active-tab"),
				$(".tpl23-catalog-menu").first().addClass("active-tab")
		})),
		$(".tpl23-btn-catalog-mobile").on("click", (function() {
				 $(".tpl23-catalog-dropdown-mobile").toggleClass("slow"), setTimeout((function() {
					 let t = $(".tpl23-catalog-dropdown-mobile").prop("scrollHeight"),
						 o = parseInt($(window).height()) - "170"; o < t ? ($(".tpl23-catalog-dropdown-mobile").css("max-height", o + "px"), console.log("2133")) : ($(".tpl23-catalog-dropdown-mobile").css("max-height", "inherit"), console.log("999999"))
				 }), 10)
			})),
		$(".tpl23-catalog-dropdown-desktop .tpl23-catalog-title").on("click", (
			function() {
				$(".tpl23-catalog-title").first().removeClass("active-tab"),
					$(".tpl23-catalog-menu").first().removeClass("active-tab");
				let t = $(this).attr("data-tpl23-cat-name"); $("[data-tpl23-cat-block]").removeClass("active"),
					$("[data-tpl23-cat-name]").removeClass("active"),
					$(this).addClass("active"),
					$("[data-tpl23-cat-block=" + t + "]").addClass("active")
			})),
		$(".tpl23-catalog-wrapper-mobile .tpl23-catalog-title").on("click", (function(t) {
			let o = $(this).attr("data-tpl23-cat-name");
			$(this).hasClass("active") ? ($(this).removeClass("active"),
				$("[data-tpl23-cat-block=" + o + "]").hide("fast", (function() {
					 $(this).css("display", "none")
				}))) : ($("[data-tpl23-cat-name]").removeClass("active"),
					$("[data-tpl23-cat-block]").css("display", "none"),
					$(this).addClass("active"),
					$("[data-tpl23-cat-block=" + o + "]").show("fast", (function() {
						 $(this).css("display", "flex")
					})))
		})),
		$(".tpl23-btn-catalog-desktop").on("click", (
			function () {
				$(".tpl23-catalog-dropdown-desktop").toggleClass("show"),
					$("[data-tpl23-cat-block]").removeClass("active"),
					$("[data-tpl23-cat-name]").removeClass("active")
			})),
		$(".tpl23-btn-catalog-mobile").on("click", (
			function() {
				$(".tpl23-catalog-wrapper-mobile .tpl23-catalog-dropdown").toggleClass("show"),
					$("[data-tpl23-cat-block]").removeClass("active"),
					$("[data-tpl23-cat-name]").removeClass("active")
			})),
		$(".tpl23-main-slider").slick({
			slidesToShow: 1,
			autoplay: !0,
			autoplaySpeed: 2e3,
			dots: !0,
			arrows: !0,
			nextArrow: '<div class="slick-next slick-arrow"><svg width="50" height="50" viewBox="0 0 50 50" fill="none" xmlns="http://www.w3.org/2000/svg"><rect width="50" height="50" rx="25" fill="white"/><path d="M24 30L27.8462 25L24 20" stroke="black" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/></svg></div>', prevArrow: '<div class="slick-prev slick-arrow"><svg width="50" height="50" viewBox="0 0 50 50" fill="none" xmlns="http://www.w3.org/2000/svg"><rect width="50" height="50" rx="25" fill="white"/><path d="M27 20L23.1538 25L27 30" stroke="black" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/></svg></div>'
		}),
		$(".tpl23-reccomendation-slider").slick({
			slidesToShow: 1,
			autoplay: !0,
			autoplaySpeed: 2e3,
			dots: !0,
			arrows: !0,
			nextArrow: '<div class="slick-next slick-arrow"><svg width="50" height="50" viewBox="0 0 50 50" fill="none" xmlns="http://www.w3.org/2000/svg"><rect width="50" height="50" rx="25" fill="white"/><path d="M24 30L27.8462 25L24 20" stroke="black" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/></svg></div>', prevArrow: '<div class="slick-prev slick-arrow"><svg width="50" height="50" viewBox="0 0 50 50" fill="none" xmlns="http://www.w3.org/2000/svg"><rect width="50" height="50" rx="25" fill="white"/><path d="M27 20L23.1538 25L27 30" stroke="black" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/></svg></div>'
		}),
		$(".tpl-23-special-offer-slider").slick({
			slidesToShow: 6,
			autoplay: !0,
			autoplaySpeed: 2e3,
			dots: !1,
			arrows: !0,
			nextArrow: '<div class="slick-next slick-arrow"><svg width="50" height="50" viewBox="0 0 50 50" fill="none" xmlns="http://www.w3.org/2000/svg"><rect width="50" height="50" rx="25" fill="white"/><path d="M24 30L27.8462 25L24 20" stroke="black" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/></svg></div>', prevArrow: '<div class="slick-prev slick-arrow"><svg width="50" height="50" viewBox="0 0 50 50" fill="none" xmlns="http://www.w3.org/2000/svg"><rect width="50" height="50" rx="25" fill="white"/><path d="M27 20L23.1538 25L27 30" stroke="black" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/></svg></div>', responsive: [{ breakpoint: 1920, settings: { slidesToShow: 6 } }, { breakpoint: 1199, settings: { slidesToShow: 4 } }, { breakpoint: 767, settings: { slidesToShow: 3 } }, { breakpoint: 576, settings: { slidesToShow: 2 } }]
		}), t(), $(window).on("resize", (function () {
			$(".b-ths-search").each((function (t) {
				t.stopPropagation, $(this).is(":visible") ? ($(this).attr("id", "oem_search"),
					$(this).find(".b-input-search").attr("id", "oem"),
					$(this).find(".b-input-search").attr("name", "oem")) : ($(this).attr("id", ""), $(this).find(".b-input-search").attr("id", ""), $(this).find(".b-input-search").attr("name", ""))
			})),
				$("[data-tpl23-cat-block]").removeClass("active"),
				$("[data-tpl23-cat-name]").removeClass("active"),
				$(".tpl23-catalog-dropdown").removeClass("show-catalog"),
				$(".tpl23-catalog-dropdown").removeClass("show"),
				$(".tpl23-btn-catalog").removeClass("decor"), t(),
				$(".tpl23-mobv-nav").removeClass("show"),
				$(window).width() > 767 ? ($(".tpl23-footer-menu-title").siblings("ul").css("display", "block"),
				$(".tpl23-mobv-catalog").hide(),
				$("body").css("overflow", "auto"),
				$(".tpl23-catalog-dropdown").removeClass("show-catalog"),
				$(".tpl23-catalog-dropdown").removeClass("show")) : ($(".tpl23-footer-menu-title").siblings("ul").css("display", "none"),
					$(".tpl23-catalog-dropdown").addClass("show"),
					$(".tpl23-catalog-dropdown").show())
		})),
		$(".tpl23-mob-contacts .nav-item-dropdown").on("click", (function(t) {
			t.preventDefault(),
				$(this).children(".dropdown-menu").show()
		})),
		$(".tpl23-footer-menu-title").on("click", (function() {
			$(window).width() <= 767 && ("block" == $(this).siblings("ul").css("display") ? ($(".tpl23-footer-menu-title").siblings("ul").hide(),
				$(this).siblings("ul").css("display", "none"),
				$(this).removeClass("menu-show")) : ($(".tpl23-footer-menu-title").siblings("ul").hide(),
				$(".tpl23-footer-menu-title").removeClass("menu-show"),
				$(this).siblings("ul").css("display", "block"),
				$(this).addClass("menu-show")))
		})),
		$(window).width() > 767 && ($(".tpl23-catalog-menu").attr("display", "none"),
			$(".tpl23-catalog-menu.active").attr("display", "flex")),
		$(".tpl23-mobv-nav-close").on("click", (function(t) {
			 t.preventDefault(), $(".tpl23-mobv-nav").removeClass("show")
		})), $(".tpl23-mobv-footer-nav-item-catalog").on("click", (function() {
			$(".tpl23-mobv-catalog").show(),
				$("body").css("overflow", "hidden")
		})), $(".tpl23-btn-catalog-close").on("click", (function() {
			$(".tpl23-mobv-catalog").hide(),
				$("body").css("overflow", "auto")
		})), $(window).on("scroll", (function() {
			var t = $(".tpl23-header-mobile-menu-sticky-wrapper").offset().top;
			$(this).scrollTop() > t && $(".tpl23-header-mobile").addClass("sticky"), $(this).scrollTop() <= 70 && $(".tpl23-header-mobile").removeClass("sticky")
		})),
		$(".shp-list").on("click", (function () { return !0 }))
}));


var isIE = /*@cc_on!@*/false || !!document.documentMode; //from https://stackoverflow.com/questions/9847580/how-to-detect-safari-chrome-ie-firefox-and-opera-browser
if (isIE) {
	var s = document.createElement('script')
	s.type = "text/javascript"
	s.src = "/polyfill.min.js"
	document.head.appendChild(s)
}