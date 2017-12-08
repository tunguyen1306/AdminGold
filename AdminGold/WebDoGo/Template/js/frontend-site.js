$(function () {
    /*  ---------------- SPINNER --------------------------------------------*/

}, jQuery);
$(document).ready(function () {
    /* -------------------------- SEARCH ----------------------------- */
    $('#search').on('click', '.s-options li a', function (e) {
        e.preventDefault();
        var _sUrl = $(this).attr('href');
        var _sText = $(this).text();
        var _this = $(this).parents('li:first');
        if (_this.hasClass('active')) {
            return false;
        } else {
            _this.parent().find('li').removeClass('active');
            _this.addClass('active');
            var _formSearch = _this.parents('form:first');
            _formSearch.attr('action', _sUrl);
            _formSearch.find('#lblSearch').html(_sText);
        }
    })

    $('#m-search').submit(function (event) {
        event.stopImmediatePropagation();
        event.preventDefault();
        var a = $('.s-options li.active a');
        var _val = $('#txtSearchKeyWord').val();
        if (a && _val) {
            var url = a.attr('href'),
                type = a.attr('data-type');
            url += '?keyword=' + _val;
            window.location = url;
        }
        return false;
    });

    /*--------------------------------------MENU HOVER ---------------------------------------------------*/

    var $menu = $("#categories #main-mn");

    // jQuery-menu-aim: <meaningful part of the example>
    // Hook up events to be fired on menu row activation.
    $menu.menuAim({
        activate: activateSubmenu,
        deactivate: deactivateSubmenu,
        exitMenu: function () {
            //console.log("Exit menu triggered");
            return true; //this new line added by aftab
        } /* added by aftab alam*/
    });
    // jQuery-menu-aim: </meaningful part of the example>

    // jQuery-menu-aim: the following JS is used to show and hide the submenu
    // contents. Again, this can be done in any number of ways. jQuery-menu-aim
    // doesn't care how you do this, it just fires the activate and deactivate
    // events at the right times so you know when to show and hide your submenus.
    function activateSubmenu(row) {

        var $row = $(row, $menu),
            submenuId = $row.data("submenuId"),
            $submenu = $("#" + submenuId, $menu),
            height = $menu.parents('.categories:first').outerHeight(),
            width = $menu.closest('.container').innerWidth() - 30;
        // Show the submenu
        $submenu.css({
            display: "block",
            top: 0,
            left: 190,  // main should overlay submenu
            height: height,  // padding for main dropdown's arrow
            width: width - 380,
            position: "absolute",

        });


        // Keep the currently activated row's highlighted look
        $row.children("a").addClass("mn-active");
        $('body .overlay').css({
            display: "block",
            width: "100%",
            height: "100%",
        });
    }

    function deactivateSubmenu(row) {

        var $row = $(row, $menu),
            submenuId = $row.data("submenuId"),
            $submenu = $("#" + submenuId, $menu);

        // Hide the submenu and remove the row's highlighted look
        $submenu.css("display", "none");
        $row.find("a").removeClass("mn-active");
        $('body .overlay').css({
            display: "none",
        });
    }

    /* MENU FILTER */
    if ($("#mv-filter").length) {
        $("#mv-filter").affix({
            offset: {
                top: function () {
                    return (this.bottom = $('#header').outerHeight(true))
                }
            }
        });
        $("#mv-filter").selectFilter();
    }

    /*-----------------------------------------------BANNER -------------------------------------------*/
    if ($('.slider-primary').length > 0) {
        $('.slider-primary').on('init', function (slick) {
            $('.slider-primary').css("overflow", "visible");
        }).slick({
            lazyLoad: 'ondemand',
            autoplay: true,
            autoplaySpeed: 5000,
            //dots: true,
        });
        $('.slider-primary').show();
    }
    if ($('.slider-product-highlight').length > 0) {
        $('.slider-product-highlight').slick({
            infinite: true,
            slidesToShow: 6,
            slidesToScroll: 6,
            responsive: [
                {
                    breakpoint: 1024,
                    settings: {
                        slidesToShow: 4,
                        slidesToScroll: 4,
                        infinite: true,
                        dots: false
                    }
                },
                {
                    breakpoint: 768,
                    settings: {
                        slidesToShow: 3,
                        slidesToScroll: 3,
                        dots: false
                    }
                },
                {
                    breakpoint: 480,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 2,
                        dots: false
                    }
                }
            ]
        });
    }
    if ($('.slide-shop-inner').length > 0) {
        $('.slide-shop-inner').each(function () {
            $(this).slick({
                infinite: true,
                slidesToShow: 5,
                slidesToScroll: 5,
                responsive: [
                    {
                        breakpoint: 768,
                        settings: {
                            slidesToShow: 4,
                            slidesToScroll: 4
                        }
                    },
                    {
                        breakpoint: 480,
                        settings: {
                            slidesToShow: 3,
                            slidesToScroll: 3
                        }
                    }
                ]
            });
        })
    }
    if ($('.slider-shop').length > 0) {
        $('.slider-shop').each(function () {
            var item = parseInt($(this).attr('data-show-item'));
            if (item) {
                $(this).slick({
                    infinite: true,
                    slidesToShow: item,
                    slidesToScroll: 1
                });
            }
        });
    }

    //Clone menu
    $('body #wrapper').prepend('<nav id="c-menu-slide-left" class="c-menu c-menu-slide-left"></div>');
    $("#categories #main-mn").clone().appendTo("#c-menu-slide-left");
    var mask = document.querySelector('#c-mask');

    $(".open-m-menu").on('click', function () {
        $('body').addClass('has-active-menu');
        $('#wrapper').addClass('has-slide-left');
        $("#c-menu-slide-left").addClass('is-active');
        $("#c-mask").addClass('is-active');
    })
    mask.addEventListener('click', function (e) {
        e.preventDefault();
        if ($(this).hasClass('is-active')) {
            $('body').removeClass('has-active-menu');
            $('#wrapper').removeClass('has-slide-left');
            $("#c-menu-slide-left").removeClass('is-active');
            $("#c-mask").removeClass('is-active');
        }
    });
    $('.box .v-category').on('click', function (e) {
        e.preventDefault();
        if ($(this).hasClass('active')) {
            $(this).removeClass('active');
        } else {
            $(this).addClass('active');
        }
        var _box = $(this).parents('.box:first');
        var _cat = $('.view-all-categories', _box);
        if (_cat.hasClass('is-show')) {
            _cat.removeClass('is-show');
        } else {
            _cat.addClass('is-show');
        }
    });
    /*--- select type search --*/
    $('#search').on('click', '.s-options li a', function (e) {
        e.preventDefault();
        var _sUrl = $(this).attr('href');
        var _sText = $(this).text();
        var _this = $(this).parents('li:first');
        if (!_this.hasClass('active')) {
            _this.parent().find('li').removeClass('active');
            _this.addClass('active');
            var _formSearch = _this.parents('form:first');
            _formSearch.attr('action', _sUrl);
            _formSearch.find('#lblSearch').html(_sText);
            $('#search .dropdown-toggle').dropdown("toggle")
        }
    })

    $('#m-search').submit(function (event) {
        event.stopImmediatePropagation();
        event.preventDefault();
        // var a = $('.s-options li.active a');
        // var _val = $('#txtSearchKeyWord').val();
        // if (a && _val) {
        //     var url = a.attr('href'),
        //         type = a.attr('data-type');
        //     url += '?keyword=' + _val;
        //     window.location = url;
        // }
        return false;
    });
    /*-----------------Tool tip ------*/
    $('[data-toggle="tooltip"]').tooltip({
        template: '<div class="tooltip" role="tooltip"><div class="tooltip-arrow"></div><div class="tooltip-inner"></div></div>'
    })
    $('.v-tooltip-info')
        .mouseover(function () {
            var _parent = $(this).parent();
            if (_parent.find('.tooltip-info').length > 0) {
                _parent.find('.tooltip-info').show();
            }

        })
        .mouseout(function () {
            $('.tooltip-info').hide();
        });
    /*------ FILTER -----*/
    $(".toggleMenu").click(function (e) {
        e.preventDefault();
        var _parent = $(this).parent();
        var _parent = $(this).parent();
        $(this).toggleClass("active");
        _parent.find(".nav").toggle();
    });
    $('.filter .fi-collapse .filter-toggle').on('click', function (e) {
        e.preventDefault();
        if ($(this).hasClass('is-close')) {
            $(this).removeClass('is-close');
            $(this).find('i').removeClass('glyphicon-menu-down').addClass('glyphicon-menu-up');
        } else {
            $(this).addClass('is-close');
            $(this).find('i').removeClass('glyphicon-menu-up').addClass('glyphicon-menu-down');
        }
        var _parent = $(this).parent()
        if (_parent.hasClass('full')) {
            _parent.removeClass('full');
        } else {
            _parent.addClass('full');
        }

    });
    $('.box-whole-sale img.checkbox-sale-type').click(function () {
        var urlSaleType = $(this).attr('data-url');
        var _this = $(this);
        if (_this.hasClass('active')) {
            _this.removeClass('active');
        } else {
            _this.addClass('active');
        }

        var wholesale = $('.box-whole-sale img#sale-wholesale').hasClass('active');
        var retail = $('.box-whole-sale img#sale-retail').hasClass('active');
        var type = 'all';
        if (wholesale && retail) {
            type = 'all';
        } else if (wholesale) {
            type = 'wholesale';
        } else if (retail) {
            type = 'retail';
        }
        if (type !== 'all') {
            if (urlSaleType.indexOf('?') !== -1) {
                urlSaleType = urlSaleType.replace('?saleType=wholesale', '');
                urlSaleType = urlSaleType.replace('?saleType=retail', '');
                urlSaleType = urlSaleType.replace('&saleType=wholesale', '');
                urlSaleType = urlSaleType.replace('&saleType=retail', '');
                urlSaleType += '&saleType=' + type;
            } else {
                urlSaleType += '?saleType=' + type;
            }
        } else {
            urlSaleType = urlSaleType.replace('?saleType=wholesale', '');
            urlSaleType = urlSaleType.replace('?saleType=retail', '');
            urlSaleType = urlSaleType.replace('&saleType=wholesale', '');
            urlSaleType = urlSaleType.replace('&saleType=retail', '');
        }
        urlSaleType = $(location).attr('href', urlSaleType);
    });
    /* Product Slider select */
    if (('.img-more.show-slide').length) {
        $('.img-more.show-slide').slick({
            slidesToScroll: 1,
            dots: false,
            //variableWidth: true,
            centerMode: false,
            //centerPadding: '0px',
            focusOnSelect: true,
            slidesToShow: 5,
            arrows: true,
            autoplay: false,
            infinite: false,
            responsive: [
                {
                    breakpoint: 1024,
                    settings: {
                        slidesToShow: 4,
                        variableWidth: true,
                        slidesToScroll: 1,
                        infinite: true,
                        dots: false,
                        centerMode: false,
                        arrows: true,
                    },
                    breakpoint: 768,
                    settings: {
                        arrows: false,
                        variableWidth: true,
                        centerMode: false,
                        centerPadding: '0px',
                        slidesToShow: 3,
                        slidesToScroll: 1,
                        arrows: true,
                    },
                    breakpoint: 480,
                    settings: {
                        arrows: false,
                        variableWidth: true,
                        centerMode: false,
                        centerPadding: '0px',
                        slidesToShow: 2,
                        slidesToScroll: 1,
                        arrows: true,
                    }
                },

            ]
        }).on('click', '.img-more-item', function (event) {
            $(this).find('a').trigger("click");
            $('.img-more-item').removeClass('slick-current');
            $('.img-more-item').removeClass('slick-active');
            $(this).addClass('slick-current slick-active');
        }).on('click', '.slick-arrow', function () {
            var currentSlide = $('.img-more.show-slide').slick('slickCurrentSlide');
            var obj = $('.img-more.show-slide').find('.slick-active.slick-current[data-slick-index="' + currentSlide + '"]');
            if (obj.length === 1) {
                var img = obj.find('a').trigger("click");
                $('.img-more-item').removeClass('slick-current');
                $('.img-more-item').removeClass('slick-active');
                obj.addClass('slick-current slick-active');
            }
        });

    }

    /*-------------- Xử lý text -----------------*/
    $('.text-line').wrapLongTitle();
    $('.text-in-line').wrapLongTitleOneLine();

    /*---------------SCROLL TO TOP -----*/
    $("#scroll-to-top").hide();
    $(function () {
        $(window).scroll(function () {
            if ($(this).scrollTop() > 100) {
                $('#scroll-to-top').fadeIn();
            } else {
                $('#scroll-to-top').fadeOut();
            }
        });
        $('#scroll-to-top').click(function () {
            $('body,html').animate({
                scrollTop: 0
            }, 500);
            return false;
        });
    });
    /*--------------------- EMAIL SUBSCRIBE ------------------------- */
    $('.footer').on('submit', 'form#registerEmail', function (e) {
        var formData = new FormData(this);
        e.preventDefault();
        e.stopImmediatePropagation();
        var urlAjax = LT_ROOT_URL + $(this).attr('action');
        $.ajax({
            url: urlAjax,
            type: "POST",
            dataType: "JSON",
            async: false,
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                //if (data.status == "success") {
                $('form#registerEmail').remove();
                $('.register-new-feed').append('<p>Bạn đã đăng ký nhận thông tin khuyến mãi thành công.<br/> Thông tin của bạn sẽ được giữ kín tuyệt đối, và bạn có thể hủy đăng ký bất cứ lúc nào.</p>')
                //} else {
                //    if (data.message) {
                //
                //    }
                //}
            }
        });
    });
    $('.spinner').spinner();

    /*--------------------- XÓA SẢN PHẨM YÊU THÍCH ------------------------- */
    $(".remove-favorite-product").click(function (e) {
        e.preventDefault();
        var _this = $(this);
        var productId = _this.attr('data-id');
        var urlFavorite = _this.attr('href');
        //ajax remove product favorite
        jQuery.post(urlFavorite, {'productId': productId}).done(function (data) {
            if (data && data.status == "error" && data.url) {
                location.href = data.url;
            } else if (data.status == "pass") {
                //remove khoi product
                alert('Xóa sản phẩm khỏi danh sách yêu thích thành công !')
                _this.closest('.product-favorited').remove();
            }
        });
        return false;
    });

    /*---- SET HEIGHT DETAIL PAGE ------*/
    autoHeightProduct();
    window.addEventListener('resize', function (event) {
        // do stuff here
        autoHeightProduct();
    });
    $('.viewExtend').each(function () {
        if ($(this).height() > 150) {
            $(this).addClass('short');
        }
    });
    $('.quoteExpand').each(function () {
        $(this).click(function () {
            var _expanded = $(this).parents('.viewExtend:first');
            if (_expanded.length && _expanded.hasClass('short')) {
                _expanded.removeClass('short');
            }
        });
    });

    var zoomProductWidth = 480;
    var zoomProductHeight = 420;
    if ($('#productInfo').length > 0) {
        zoomProductWidth = $('#productInfo').outerWidth();
    }
    if (zoomProductWidth < zoomProductHeight) {
        zoomProductHeight = zoomProductWidth;
    }
    if ($('.prdZoom').length > 0) {

        $(".prdZoom").elevateZoom({
            gallery: 'zoom-gallery',
            cursor: 'pointer',
            galleryActiveClass: 'active',
            imageCrossfade: true,
            loadingIcon: '/images/xloading.gif',
            zoomWindowWidth: zoomProductWidth,
            zoomWindowHeight: zoomProductHeight,
            borderSize: 1,
            zoomWindowOffetx: 16

        });

//pass the images to Fancybox
        $(".prdZoom").bind("click", function (e) {
            var ez = $('.prdZoom').data('elevateZoom');
            $.fancybox(ez.getGalleryList());
            return false;
        });
    }

});
