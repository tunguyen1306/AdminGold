jQuery(function($) {
    

        var vi = getCookie("vi");

        if (vi != null && vi !== "") {
            if (vi === "1") {
                setCookie("vi", 1, 365);
                $('.clvi').removeClass('hidden');
               
               
                $('.clen').addClass('hidden');
                $('.MenuLan').removeClass('active');
                $('.MenuLanVi').addClass('active');
                $('.MenuLanEn').removeClass('active');

            }
            if (vi === "2") {
                setCookie("vi", 2, 365);
                $('.clvi').addClass('hidden');
                $('.clen').removeClass('hidden');
                $('.MenuLan').removeClass('active');
                $('.MenuLanEn').addClass('active');
                $('.MenuLanVi').removeClass('active');
            }

        } else {
            setCookie("vi", 1, 365);
        }
        $('#hdlang').val(vi);
        $('#btnVn').click(function() {
            setCookie("vi", 1, 365);
            $('.clvi').removeClass('hidden');
            $('.clen').addClass('hidden');
            $('.MenuLan').removeClass('active');
            $('.MenuLanVi').addClass('active');
            $('.MenuLanEn').removeClass('active');

        });
        $('#btnEn').click(function() {

            setCookie("vi", 2, 365);
            $('.clvi').addClass('hidden');
            $('.clen').removeClass('hidden');
            $('.MenuLan').removeClass('active');
            $('.MenuLanEn').addClass('active');
            $('.MenuLanVi').removeClass('active');

        });


    });

    function setCookie(cname, cvalue, exdays) {
        var d = new Date();
        d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
        var expires = "expires=" + d.toUTCString();
        document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
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