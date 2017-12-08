/**
 * Created by Dev on 30-Dec-16.
 */
Number.prototype.formatMoney = function (c, d, t) {
    var n = this,
        c = isNaN(c = Math.abs(c)) ? 2 : c,
        d = d == undefined ? "." : d,
        t = t == undefined ? "," : t,
        s = n < 0 ? "-" : "",
        i = parseInt(n = Math.abs(+n || 0).toFixed(c)) + "",
        j = (j = i.length) > 3 ? j % 3 : 0;
    return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
};

if (!String.prototype.repeat) {
    String.prototype.repeat = function (num) {
        return new Array(num + 1).join(this);
    }
}
function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + "; " + expires;
}

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}
var modal = $('<div id="page-modal" class="fade modal ajax-form-modal in" role="dialog" tabindex="-1" aria-hidden="false">' +
    '<div class="modal-dialog">' +
    '<div class="modal-content">' +
    '<div class="modal-header">' +
    '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>' +
    '<h4 class="modal-title"></h4>' +
    '</div>' +
    '<div class="modal-body"></div>' +
    '</div>' +
    '</div>' +
    '</div>');
$('.ajax-form-modal:visible').remove();
$('body').append(modal);
function openModal(title, content) {
    modal.find('.modal-header .modal-title').text(title);
    modal.find('.modal-body').html(content);
    modal.modal({
        show: true,
        //backdrop: 'static',
        keyboard: false,
    });

    var _btnCloseModal = $('.btn-close-modal', modal);
    _btnCloseModal.each(function () {
        $(this).click(function () {
            setTimeout(function () {
                modal.modal('hide');
            }, 100);
        })
    });
}
(function ($) {
    /* spinner*/
    $.fn.spinner = function (e) {
        return $(this).each(function () {
            var _this = $(this);
            var add = $('.add', _this);
            var sub = $('.minus', _this);
            var input = _this.find('input');
            $(add).off('click').on('click', function () {
                if (input.attr('max') == undefined || input.attr('max') == '' || parseInt(input.val()) < parseInt(input.attr('max'))) {
                    input.val(parseInt(input.val(), 10) + 1).trigger('change');
                } else {
                    add.next("disabled", true);
                }
            });
            $(sub).off('click').on('click', function () {
                if (input.attr('min') == undefined || input.attr('min') == '' || (parseInt(input.val()) > parseInt(input.attr('min')))) {
                    var minInput = parseInt(input.val(), 10) - 1;

                    if (minInput <= 0) {
                        minInput = 0;
                    }

                    input.val(minInput).trigger('change');
                } else {
                    var minInput = ((input.attr('min') == undefined || input.attr('min') == '') ? 0 : input.attr('min'));
                    input.val(minInput).trigger('change');
                    ;
                    //sub.prev("disabled", true);
                }
            })
        });

    }

    /* hz js */
    $.extend({
        getProvince: function (opt) {
            var options = $.extend({}, opt);
            var elements = options.elements ? options.elements : {
                province: '#province',
                district: '#district',
                ward: '#ward'
            };

            var selected = options.selected ? options.selected : {
                province: '',
                district: '',
                ward: ''
            };

            var remote = options.remote ? options.remote : LT_ROOT_URL + '/site/ajax-get-province';

            var defaultText = {
                province: $(elements.province).html(),
                district: $(elements.district).html(),
                ward: $(elements.ward).html()
            };

            $.post(remote, {type: 'province', parentId: 0, level: 1, selectedId: selected.province}, function (res) {
                $(elements.province).html(res);
                $(elements.district).html(defaultText.district);
                $(elements.ward).html(defaultText.ward);
                if (selected.province != '' || selected.province > 0) {
                    $(elements.province).change();
                }
            });

            $(elements.province).change(function () {
                if ($(this).val() == '') {
                    $(elements.district).html(defaultText.district);
                } else {
                    $.post(remote, {
                        type: 'province',
                        parentId: $(this).val(),
                        level: 2,
                        selectedId: selected.district
                    }, function (res) {
                        $(elements.district).html(res);
                        $(elements.ward).html(defaultText.ward);
                        if (selected.district != '' || selected.district > 0) {
                            $(elements.district).change();
                        }
                    });
                }
            });

            $(elements.district).change(function () {
                if ($(this).val() == '') {
                    $(elements.ward).html(defaultText.ward);
                } else {
                    $.post(remote, {
                        type: 'province',
                        parentId: $(this).val(),
                        level: 3,
                        selectedId: selected.ward
                    }, function (res) {
                        $(elements.ward).html(res).change();
                    });
                }
            });
        },
        readFile: function (file) {
            if (typeof file === 'undefined') return null;

            var reader = new FileReader();
            var deferred = $.Deferred();

            reader.onload = function (event) {
                deferred.resolve(event.target.result);
            };

            reader.onerror = function () {
                deferred.reject(this);
            };

            reader.readAsDataURL(file);

            return deferred.promise();
        },
        hzDialogInit: function () {
            if ($('.hz-dialog').length === 0) {
                $('body').append('<div class="hz-dialog" title=""></div>');
            }
            $("body").on('click', '.btn-dialog-close', function () {
                $(this).closest(".hz-dialog").dialog('close');
            }).on('click', '.btn-redirect-cart', function () {
                $(this).closest(".hz-dialog").dialog('close');
            });
            return $('.hz-dialog');
        },
        hzAlert: function (title, msg) {
            var dialog = $.hzDialogInit();
            dialog.html(msg).dialog({
                title: title,
                resizable: false,
                modal: true,
                width: 400,
                dialogClass: 'fixed-dialog',
                show: {
                    effect: "fade",
                    duration: 200
                },
                buttons: {
                    close: {
                        text: 'Đóng',
                        class: 'btn hz-btn-warning btn-sm',
                        click: function () {
                            $(this).dialog('close');
                        }
                    }
                }
            });
        },
        hzConfirm: function (title, msg, buttons) {
            var dialog = $.hzDialogInit();
            dialog.attr('title', title)
                .html(msg)
                .dialog({
                    title: title,
                    resizable: false,
                    modal: true,
                    width: 400,
                    dialogClass: 'fixed-dialog',
                    show: {
                        effect: "fade",
                        duration: 200
                    },
                    buttons: buttons
                });
        },
        hzPrompt: function () {

        }
    });

    if (typeof $.fn.hzInputFile === 'undefined') {
        $.fn.hzInputFile = function (opt) {
            var options = $.extend({}, opt);

            var buttonClassName = options.class ? options.class : 'btn btn-default';

            var template = '<div class="input-item">' +
                '<i class="glyphicon glyphicon-open-file"></i>' +
                '<span class="file-label" id="label-{id}">Không có file được chọn</span>' +
                '</div>';

            this.css({
                opacity: 0,
                position: 'absolute',
                top: 0, right: 0,
                bottom: 0, left: 0,
                '-ms-filter': "progid:DXImageTransform.Microsoft.Alpha(Opacity=50)",
                filter: 'alpha(opacity=50)'
            }).each(function (e) {
                var _this = $(this);

                var id = e + 2108;
                _this.attr('data-id', id);

                if (_this.attr('type') == 'file') {
                    _this.wrapAll('<div class="' + buttonClassName + ' input-file-wrap" id="input-wrap-' + id + '" data-id="' + id + '"></div>');
                    _this.parent()
                        .append(template.replace('{id}', id));
                }

                $('body').append('<input type="hidden" id="val-hidden-' + id + '"/>');
            }).change(function () {
                var itemId = $(this).data('id');
                var btn = $('#label-' + itemId);
                var wrap = $('#input-wrap-' + itemId);
                var text = '';

                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#val-hidden-' + itemId).val(e.target.result);
                };
                reader.readAsDataURL($(this)[0].files[0]);

                var val = $(this).val().split('\\');
                var fileName = val[val.length - 1];
                if (typeof fileName != 'undefined') {
                    if (fileName.length > 20) {
                        fileName = fileName.substr(0, 5) + '...' + fileName.substr(fileName.length - 12, 12);
                    }
                    text += ' ' + fileName;
                } else {
                    text += ' Không có file được chọn';
                }
                btn.html(text);
            });

            $('.input-file-wrap')
                .popover({
                    trigger: 'hover',
                    title: 'Xem trước ảnh upload',
                    content: function () {
                        var itemId = $(this).data('id');
                        var itemVal = $('#val-hidden-' + itemId).val();
                        if (itemVal != '') {
                            return '<div class="responsive-img" style="background-color: #fff;"><img src="' + itemVal + '"></div>';
                        } else {
                            var itemSrc = $(this).find('input[type="file"]:first').data('src');
                            return itemSrc != '' ? '<div class="responsive-img" style="background-color: #fff;"><img src="' + itemSrc + '"></div>' : 'Chưa có ảnh được chọn';
                        }
                    },
                    container: 'body',
                    placement: 'right',
                    html: true
                });
        };
    }

    $('.hz-input-file').hzInputFile();

    $.fn.hzParseJSON = function (str) {
        if (!str) {
            str = this.val();
        }
        if (!str) return {};

        var result = $.parseJSON(str);
        if (typeof result !== 'object') {
            result = this.hzParseJSON(result);
            return false;
        }
        return result;
    };

    /* --hz-js*/

    $.fn.wrapLongTitle = function (options) {
        return this.each(function () {
            var plugin = $(this);
            plugin.maxTitleHeight = 36;

            if (typeof options !== "undefined" && typeof options.maxTitleHeight !== "undefined") {
                plugin.maxTitleHeight = options.maxTitleHeight;
            }
            plugin.init = function () {
                var h = $(plugin).height();
                var nt = $(plugin).html().trim();
                if (h > plugin.maxTitleHeight) {
                    while (true) {
                        if (h <= plugin.maxTitleHeight) {
                            break;
                        }
                        $(plugin).html(nt + ' ...');
                        h = $(plugin).height();
                        nt = nt.substring(0, nt.lastIndexOf(' '));
                    }
                }
            };
            plugin.init();
        });
    }
    $.fn.wrapLongTitleOneLine = function (options) {
        return this.each(function () {
            var plugin = $(this);
            plugin.maxTitleHeight = 18;

            if (typeof options !== "undefined" && typeof options.maxTitleHeight !== "undefined") {
                plugin.maxTitleHeight = options.maxTitleHeight;
            }
            plugin.init = function () {
                var h = $(plugin).height();
                var nt = $(plugin).html().trim();
                if (h > plugin.maxTitleHeight) {
                    while (true) {
                        if (h <= plugin.maxTitleHeight) {
                            break;
                        }
                        $(plugin).html(nt + ' ...');
                        h = $(plugin).height();
                        nt = nt.substring(0, nt.lastIndexOf(' '));
                    }
                }
            };
            plugin.init();
        });
    }

    $.fn.hzAddFavorite = function (opt) {
        var options = $.extend({}, opt);
        var _this = this,
            remote = options.remote ? options.remote : LT_ROOT_URL + '/favorite/ajax-add',
            remoteGet = options.remoteGet ? options.remoteGet : LT_ROOT_URL + '/favorite/ajax-get';

        _this.click(function (e) {
            e.preventDefault();
            var item = $(this);
            if (!item.hasClass('hz-disabled')) {
                var data = item.data();
                $.ajax({
                    url: remote,
                    data: data,
                    method: 'post',
                    xhrFields: {
                        withCredentials: true
                    }
                }).done(function (res) {
                    var htmlContent = '<div class="text-content bold success">Gian hàng đã được thêm vào danh sách yêu thích</div>';
                    if (res.status == 'success') {
                        openModal('Thông báo', htmlContent);
                        $('.hz-favorite[data-id="' + data.id + '"][data-type="' + data.type + '"]').attr('disabled', 'disabled');
                        item.addClass('hz-disabled');
                    }
                });

            } else {
                var htmlContent = '<div class="text-content bold primary">Gian hàng đã tồn tại trong danh sách yêu thích của khách hàng !</div>';
            }
            return false;
        });

        $(window).load(function () {
            var arrayId = [];
            var arrayType = [];
            _this.each(function (e) {
                var __this = $(this);
                arrayId.push(parseInt(__this.data('id')));
                arrayType.push(__this.data('type'));
            });
            var dataOnPage = {
                id: arrayId,
                type: arrayType,
                _csrf: yii.getCsrfToken()
            };

            if ($.isEmptyObject(dataOnPage.id) === false) {
                $.ajax({
                    url: remoteGet,
                    data: dataOnPage,
                    method: 'post',
                    xhrFields: {
                        withCredentials: true
                    }
                }).done(function (res) {
                    $.each(res, function (k, v) {
                        var item = $('.hz-favorite[data-id="' + v.id + '"][data-type="' + v.type + '"]');
                        item.attr("disabled", "disabled");
                        item.addClass('hz-disabled');
                    });
                });
            }
        });
    };

    $('.hz-favorite').hzAddFavorite();


    $.fn.selectFilter = function (options) {
        return this.each(function () {
            var _menu = $(this);
            var menuOption = $('.m-op', _menu);
            menuOption.each(function () {
                $(this).on('click', function () {
                    //alert($(this).attr('data-sort-type'));
                    $('body').addClass('has-active-menu');
                    $('#wrapper').addClass('has-slide-right');
                    $("#filter").addClass('is-active');
                    $("#c-mask").addClass('is-active');
                    $('#filter').showFilter($(this).attr('data-sort-type'));
                    closeMenuMobile();
                });
            });

        })
    }
    $.fn.showFilter = function (type) {
        var _this = $(this);

        switch (type) {
            case"SORT":
                _this.find('[data-filter-type="SORT"]').show();
                _this.find('[data-filter-type="FILTER"]').hide();
                break;
            case"FILTER":
                _this.find('[data-filter-type="SORT"]').hide();
                _this.find('[data-filter-type="FILTER"]').show();
                break;
            default:
                _this.find('[data-filter-type="SORT"]').hide();
                _this.find('[data-filter-type="FILTER"]').hide();
                break;
        }
    }
    var mask = document.querySelector('#c-mask');
    var maskProcess = function () {
        mask.addEventListener('click', function (e) {
            closeMenu(e);
        });
    }
    var closeMenu = function (e) {
        e.preventDefault();
        if ($('#c-mask').hasClass('is-active')) {
            $('body').removeClass('has-active-menu');
            $('#wrapper').removeClass('has-slide-left', 'has-slide-right');
            $("#c-menu-slide-left").removeClass('is-active');
            $("#filter").removeClass('is-active');
            $("#c-mask").removeClass('is-active');
        }
    }
    maskProcess();
    var closeMenuMobile = function () {
        var _buttonBack = $('.c-menu_back');
        _buttonBack.each(function () {
            $(this).on('click', function (e) {
                closeMenu(e);
            });
        })
    }


})(jQuery);

function standardlize_address(address) {
    var addr = address.address;
    // if (addr.address.indexOf(addr.ward) !== -1) {
    //     addr.address = addr.address.replace(addr.ward, '');
    // }
    //
    // if (addr.address.indexOf(addr.district) !== -1) {
    //     addr.address = addr.address.replace(addr.district, '');
    // }
    //
    // if (addr.address.indexOf(addr.province) !== -1) {
    //     addr.address = addr.address.replace(addr.province, '');
    // }

    addr.address = addr.address.replace('KTT', '');

    addr.province = addr.province.replace("TP ", "");

    addr.full = addr.address + ', ' + addr.ward + ', ' + addr.district + ', ' + addr.province;
    address.address = addr;
    // console.log(address);
    return address;
}

function ResizeScreenProductDetail() {
    var screenWidth = window.screen.width;
    if (screenWidth >= 768) {
        if ($('.fixScreen').length) {
            var pageWidth = $('.fixScreen').width();
            if ($('.column-left').length && $('.column-right').length) {
                var columRightWidth = Math.ceil(parseInt($('.column-right').width()));
                var columnLeftWidth = pageWidth - columRightWidth;
                if (columnLeftWidth > 0) {
                    $('.column-left').css({width: columnLeftWidth});
                }
            }
        }
    } else {
        if ($('.column-left').length) {
            $('.column-left').removeAttr('style');
        }
    }

}

function autoHeightProduct() {
    var screenWidth = window.screen.width;
    if (screenWidth >= 1024) {
        $('.autoResizeHeight').each(function(){
            var height=$(this).width();
            $(this).css({height: height});
        });
    }else{
        $('.autoResizeHeight').removeAttr('style');
    }

}
