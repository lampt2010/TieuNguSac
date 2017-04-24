
//Main menu
jQuery(function($) {
  $('.main_menu').reaktion({navIcon: '<i class="fa fa-bars"></i>',
    arrowIcon: '<i class="fa fa-angle-down"></i>',
    arrowsToggleOnly: false});
});

/*****************************************************************/
//tabs toggle 
var action = 'click';
var speed = "500";
//Document.Ready
jQuery(function($){
  //Question handler
  $('.ts_content li.ts_title').on(action, function(){
    //gets next element
    //opens .a of selected question
  $(this).next().slideToggle(speed).siblings('.ts_content li.ts_info').slideUp();
    //Grab img from clicked question
  var fa = $(this).children('span');
    //Remove Rotate class from all images except the active
    $('.ts_togle').not(fa).removeClass('icon_toogle');
    //toggle rotate class
    fa.toggleClass('icon_toogle');

  });//End on click

});//End Ready
 
/**********************************************************************/
 (function(){
  //Main slider
  var swiper = new Swiper('.home_slider_box', {
    nextButton: '.m_slider_bt_next',
    prevButton: '.m_slider_bt_prev',
    slidesPerView: 1,
    paginationClickable: true,
    loop: true,
    keyboardControl: true,
    speed: 10000,
    autoplay: true,
    effect: 'fade',
  });
  // Slide show room
   var swiper = new Swiper('.show_room_box', {
    nextButton: '.showroom_bt_next',
        prevButton: '.showroom_bt_prev',
        slidesPerView: 1,
        paginationClickable: true,
        // spaceBetween: 15,
        loop: true,
        keyboardControl: true,
        speed: 600,
   });
  //Slide đối tác
  var swiper = new Swiper('.doitac_box', {
    nextButton: '.doitac_bt_next',
        prevButton: '.doitac_bt_prev',
        slidesPerView: 8,
        paginationClickable: true,
        spaceBetween: 15,
        loop: true,
        keyboardControl: true,
        speed: 600,
        breakpoints: {
          // when window width is <= 320px
      320: {
        slidesPerView: 2,
      },
      // when window width is <= 480px
      480: {
        slidesPerView: 3,
      },
      // when window width is <= 640px
      640: {
        slidesPerView: 4,
      },
      // when window width is <= 991px
      991: {
        slidesPerView: 5,
      },
      // when window width is <= 1199px
      1199: {
        slidesPerView: 7,
      }
    }
  });

  //Chi tiết sản phẩm image slide
  var swiper = new Swiper('.list_img_chitiet', {
    nextButton: '.ctsp_bt_next',
    prevButton: '.ctsp_bt_prev',
    slidesPerView: 1,
    paginationClickable: true,
    loop: true,
    keyboardControl: true,
    speed: 600,
  });
  //Relate video
  var swiper = new Swiper('.relate_video_box', {
    nextButton: '.r_video_bt_next',
      prevButton: '.r_video_bt_prev',
      slidesPerView: 5,
      paginationClickable: true,
      spaceBetween: 15,
      loop: true,
      keyboardControl: true,
      speed: 600,
      breakpoints: {
        // when window width is <= 320px
      480: {
        slidesPerView: 1,
      },
      // when window width is <= 640px
      640: {
        slidesPerView: 2,
      },
      // when window width is <= 991px
      991: {
        slidesPerView: 3,
      },
      1199: {
        slidesPerView: 4,
      }
    }
  });

})(jQuery);


/*************************************************************/
//Back to top

if ($('#back-to-top').length) {
  var scrollTrigger = 100, // px
      backToTop = function () {
          var scrollTop = $(window).scrollTop();
          if (scrollTop > scrollTrigger) {
              $('#back-to-top').addClass('show');
          } else {
              $('#back-to-top').removeClass('show');
          }
      };
  backToTop();
  $(window).on('scroll', function () {
      backToTop();
  });
  $('#back-to-top').on('click', function (e) {
      e.preventDefault();
      $('html,body').animate({
          scrollTop: 0
      }, 700);
  });
}

//Print
function printFunction() {
    window.print();
}



