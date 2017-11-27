$(document).ready( function(){

    $.each($('li.itemmenu ul'), function (i, o) {

        if ($(o).find('li').size()==0) {
            $(o).remove();
        }
    })
})(jQuery);