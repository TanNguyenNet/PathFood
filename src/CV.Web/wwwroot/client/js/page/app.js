﻿var swiper = new Swiper('.swiper',
    {
        pagination: '.swiper-pagination',
        paginationClickable: true,
        autoplay: 10000
    });
var swiper1 = new Swiper('.swiper1', {
    slidesPerView: 4,
    slidesPerColumn: 1
});
$(".filter-list li span").on("click", function () {
    var filter = $(this).html().toLowerCase();
    var slidesxcol;
    $(".filter-list li span").removeClass("active");
    $(this).addClass("active");

    if (filter == "vi") {
        $("[data-filter]").removeClass("non-swiper-slide").addClass("swiper-slide").show();
        if ($(".swiper-slide").length > 6)
            slidesxcol = 3;
        else slidesxcol = 1;
        swiper.destroy();
        swiper = new Swiper('.swiper-container1', {
            pagination: '.swiper-pagination',
            slidesPerView: 3,
            slidesPerColumn: slidesxcol,
            paginationClickable: true,
            spaceBetween: 30
        });
    }
    else {
        $(".swiper-slide").not("[data-filter='" + filter + "']").addClass("non-swiper-slide").removeClass("swiper-slide").hide();
        $("[data-filter='" + filter + "']").removeClass("non-swiper-slide").addClass("swiper-slide").attr("style", null).show();
        console.log($(".swiper-slide").length)
        if ($(".swiper-slide").length > 6)
            slidesxcol = 3;
        else slidesxcol = 1;
        swiper.destroy();
        swiper = new Swiper('.swiper-container', {
            pagination: '.swiper-pagination',
            slidesPerView: 3,
            slidesPerColumn: slidesxcol,
            paginationClickable: true,
            spaceBetween: 30
        });
    }
});
var swiper2 = new Swiper('.swiper2', {
    slidesPerView: 5,
    spaceBetween: 30,
    autoplay: 10000
});
var swiper3 = new Swiper('.swiper3', {
    autoplay: 5000
});
$('header .mobile-menu').meanmenu();

$('select').each(function () {
    var $this = $(this), numberOfOptions = $(this).children('option').length;

    $this.addClass('select-hidden');
    $this.wrap('<div class="select"></div>');
    $this.after('<div class="select-styled"></div>');

    var $styledSelect = $this.next('div.select-styled');
    $styledSelect.text($this.children('option').eq(0).text());

    var $list = $('<ul />', {
        'class': 'select-options'
    }).insertAfter($styledSelect);

    for (var i = 0; i < numberOfOptions; i++) {
        $('<li />', {
            text: $this.children('option').eq(i).text(),
            rel: $this.children('option').eq(i).val()
        }).appendTo($list);
    }

    var $listItems = $list.children('li');

    $styledSelect.click(function (e) {
        e.stopPropagation();
        $('div.select-styled.active').not(this).each(function () {
            $(this).removeClass('active').next('ul.select-options').hide();
        });
        $(this).toggleClass('active').next('ul.select-options').toggle();
    });

    $listItems.click(function (e) {
        e.stopPropagation();
        $styledSelect.text($(this).text()).removeClass('active');
        $this.val($(this).attr('rel'));
        $list.hide();
        //console.log($this.val());
    });

    $(document).click(function () {
        $styledSelect.removeClass('active');
        $list.hide();
    });
});

$(".accordion_head").click(function () {
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