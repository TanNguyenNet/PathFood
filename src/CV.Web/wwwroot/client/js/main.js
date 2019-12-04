$(document).ready(function(){
  //banner slider
  var swiper = new Swiper('.swiper',
    {
        pagination: '.swiper-pagination',
        paginationClickable: true,
        autoplay: 10000
    });
    //home-blog
    var swiper5 = new Swiper('.swiper5', {
      slidesPerView: 5,
      spaceBetween: 30,
      breakpoints: {
        1024: {
            slidesPerView: 5
        },
        991: {
            slidesPerView: 4
        },
        990: {
            slidesPerView: 3
        },
        576: {
            slidesPerView: 2
        },
        320: {
            slidesPerView: 1
        }
      }
  });
  //blog-swiper
  var swiper6 = new Swiper('.swiper6', {
    slidesPerView: 4,
    spaceBetween: 30,
    // autoplay: 10000,
    breakpoints: {
      1024: {
          slidesPerView: 5
      },
      991: {
          slidesPerView: 4
      },
      990: {
          slidesPerView: 3
      },
      576: {
          slidesPerView: 2
      },
      320: {
          slidesPerView: 2
      }
    }
  });

    var swiper2 = new Swiper('.swiper2', {
      slidesPerView: 7,
      spaceBetween: 0,
      autoplay: 10000,
      breakpoints: {
        1024: {
            slidesPerView: 5
        },
        991: {
            slidesPerView: 4
        },
        990: {
            slidesPerView: 4
        },
        576: {
            slidesPerView: 4
        },
        320: {
            slidesPerView: 4
        }
      }
    });
    var swiper3 = new Swiper('.swiper3', {
      autoplay: 5000
    });
    $('header .mobile-menu').meanmenu();

    // $('select').each(function(){
    //   var $this = $(this), numberOfOptions = $(this).children('option').length;

    //   $this.addClass('select-hidden');
    //   $this.wrap('<div class="select"></div>');
    //   $this.after('<div class="select-styled"></div>');

    //   var $styledSelect = $this.next('div.select-styled');
    //   $styledSelect.text($this.children('option').eq(0).text());

    //   var $list = $('<ul />', {
    //       'class': 'select-options'
    //   }).insertAfter($styledSelect);

    //   for (var i = 0; i < numberOfOptions; i++) {
    //       $('<li />', {
    //           text: $this.children('option').eq(i).text(),
    //           rel: $this.children('option').eq(i).val()
    //       }).appendTo($list);
    //   }

    //   var $listItems = $list.children('li');

    //   $styledSelect.click(function(e) {
    //       e.stopPropagation();
    //       $('div.select-styled.active').not(this).each(function(){
    //           $(this).removeClass('active').next('ul.select-options').hide();
    //       });
    //       $(this).toggleClass('active').next('ul.select-options').toggle();
    //   });

    //   $listItems.click(function(e) {
    //       e.stopPropagation();
    //       $styledSelect.text($(this).text()).removeClass('active');
    //       $this.val($(this).attr('rel'));
    //       $list.hide();
    //       //console.log($this.val());
    //   });

    //   $(document).click(function() {
    //       $styledSelect.removeClass('active');
    //       $list.hide();
    //   });
    // });
    //pagination

    var c = document.querySelector('.pagination');
    var indexs = Array.from(document.querySelectorAll('.index'));
    var cur = -1;
    indexs.forEach(function (index, i) {
      index.addEventListener('click', function (e) {
        // clear
        c.className = 'pagination';
        void c.offsetWidth; // Reflow

        c.classList.add('open');
        c.classList.add("i".concat(i + 1));

        if (cur > i) {
          c.classList.add('flip');
        }

        cur = i;
      });
    });
    // new product selection
    $('#pr-option').on("change", function(){
      var opVal = $(this).val();
      if (opVal == 2) {
        // $(".new-product ul").removeClass("display-product");
        $("[data-change='"+opVal+"']").removeClass("non-display-product").addClass("display-product");
        $("[data-change='"+1+"']").removeClass("display-product").addClass("non-display-product");
        $(".new-product .function").removeClass("non-display-product").addClass("display-product");
        $(".new-product .field").removeClass("display-product").addClass("non-display-product");
        // $(".new-product ul").addClass("display-product");
      }else {
        // $(".new-product ul").removeClass("display-product");
        $("[data-change='"+opVal+"']").removeClass("non-display-product").addClass("display-product");
         $("[data-change='"+2+"']").removeClass("display-product").addClass("non-display-product");
         $(".new-product .field").removeClass("non-display-product").addClass("display-product");
        $(".new-product .function").removeClass("display-product").addClass("non-display-product");
      }
    });
    var swiper1 = new Swiper('.swiper1', {
      autoHeight: true,
      slidesPerView: 4,
      slidesPerColumn: 1,
      breakpoints: {
          1024: {
              slidesPerView: 4
          },
          991: {
              slidesPerView: 3
          },
          990: {
              slidesPerView:2
          },
          576: {
              slidesPerView: 1
          },
          320: {
              slidesPerView: 1
          }
      },
      spaceBetween: 30
    });
    // $(".news .filter-list li").on('click', function() {
    //   var filter = $(this).attr("value");
    //   filterList1(filter);
    // });

    // //home blog
    // function filterList1(value) {
    //   var list = $(".swiper5 .img-content");
    //   $(list).fadeOut("fast");
    //   if (value == "all") {
    //     $(".swiper5").find(".img-content").each(function (i) {
    //       $(this).delay(200).slideDown("fast");
    //     });
    //   } else {
    //     //Notice this *=" <- This means that if the data-category contains multiple options, it will find them
    //     //Ex: data-category="Cat1, Cat2"
    //     $(".swiper5").find("[data-filter*=" + value + "]").each(function (i) {
    //       $(this).delay(200).slideDown("fast");
    //     });
    //   }
    // }
    //new product slider & filter
    $(".filter-list li").on("click", function(){
      var filter = $(this).attr("value");
      $(".filter-list li").removeClass("active");
      $(this).addClass("active");

      if(filter=="tin-thi-truong" || filter=="tin-noi-bo"){
        $("[data-filter]").removeClass("non-swiper-slide").addClass("swiper-slide").show();
        swiper5 = new Swiper('.swiper5', {
          slidesPerView: 5,
          spaceBetween: 30
        });
      }
      else {
      $(".swiper5 .swiper-slide").not("[data-filter='"+filter+"']").addClass("non-swiper-slide").removeClass("swiper-slide").hide();
        $("[data-filter='"+filter+"']").removeClass("non-swiper-slide").addClass("swiper-slide").attr("style", null).show();
        // console.log($(".swiper-slide").length)
        swiper5 = new Swiper('.swiper5', {
          slidesPerView: 5,
          spaceBetween: 30
        });
      }
    });
    //product tabs 
    var tabs =  $(".tabs li a");
  
    tabs.click(function() {
      var content = this.hash.replace('/','');
      tabs.removeClass("active");
      $(this).addClass("active");
      $(".aside-nav").find('ul').hide();
      $(content).fadeIn(200);
    });

  //QA filter
    // $(".qa-wrap li").on('click', (function(event){
    //   var target = $( event.target );
    //   $(".qa-wrap li").removeClass("active");
    //   $(this).addClass("active");

    //   var filter = $(this).attr("value");

    //   if(target.is ("li")){
    //     $(".QA-content .wrap").filter(function(){

    //     console.log("ádasdasdasd " + filter);
    //       return $(this).data("filter").split(",").indexOf(filter) == -1;
    //     }).hide();
    //   } else {
    //     $(".QA-content .wrap").show();
    //   }
    // }));

    $(".qa-wrap li").on('click', function() {
      $(".qa-wrap li").removeClass("active");
      $(this).addClass("active");
      var filter = $(this).attr("value");
      filterList(filter);
    });

    //News filter function
    function filterList(value) {
      var list = $(".QA-content .wrap");
      $(list).fadeOut("fast");
      if (value == "all") {
        $(".QA-content").find(".wrap").each(function (i) {
          $(this).delay(200).slideDown("fast");
        });
      } else {
        //Notice this *=" <- This means that if the data-category contains multiple options, it will find them
        //Ex: data-category="Cat1, Cat2"
        $(".QA-content").find("[data-filter*=" + value + "]").each(function (i) {
          $(this).delay(200).slideDown("fast");
        });
      }
    }
    //scroll top
    $("button.scroll-top").click(function(){
      $(window).scrollTop(0);
    });
    //QA arrcordian
    $(".accordion_head").click(function() {
      if ($('.accordion_body').is(':visible')) {
        $(".accordion_body").slideUp(300);
        $(".plusminus").text('+');
      }
      if ($(this).next(".accordion_body").is(':visible')) {
        $(this).next(".accordion_body").slideUp(300);
        $(this).children(".plusminus").text('+');
      } else {
        $(this).next(".accordion_body").slideDown(300);
        $(this).children(".plusminus").text('+');
      }
    });
    /*****************************/
    /* click icon menu */
    /*****************************/
    $('.icon-search-menu').on('click', function (event) {
      event.preventDefault();
      $('.yolo-search-wrapper').toggleClass('show');
    });
    $('.yolo-search-wrapper .close').on('click', function (event) {
      event.preventDefault();
      $('.yolo-search-wrapper').removeClass('show');
    });

});
