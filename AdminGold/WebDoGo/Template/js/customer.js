$(document).ready(function () {
    if (user.isGuest === true) {
        $('#show-user-top .login-signup').show();
        $('#login-box-isguest').show();
    } else {
        var tmpHoldHtml = '';
        if (user.wallet_temphold_balance) {
            tmpHoldHtml = ' | Đang tạm giữ: <b class="txt-red">' + user.wallet_temphold_balance.formatMoney(0, ',', '.') + '</b>';
        }
        $('#show-user-top .hello-user').html('Xin chào, <strong><a href="' + LT_ROOT_URL +
            '/my-account/index" title="' + user.username + '">' +
            user.username + '</a></strong> (Số dư: <b class="txt-red">' + user.wallet_balance.formatMoney(0, ',', '.') +
            'đ</b>' + tmpHoldHtml + ' | <a class="user-logout fa fa-power-off" data-method="post" href="' + LT_ROOT_URL + '/user/logout" title="Đăng xuất"></a>)');
        $('#show-user-top .login-signup').hide();
        $('#login-box-islogin').show();
        var htmlLogined = '';
        htmlLogined += '<a class="login active user-logined" href="' +
            LT_ROOT_URL +
            '/my-account/index" title="' +
            user.username + '">Xin chào, <b>' +
            user.username + '</b></a>' +
            '<br/>Số dư: <b class="txt-red">' + user.wallet_balance.formatMoney(0, ",", ".") + 'đ</b>' +
            '<br/>(<a href="/wallet/my-account/recharge" style="color: #00a7d0" title="Nạp tiền vào ví điện tử">Nạp thêm tiền</a>)';
        if (user.wallet_temphold_balance) {
            htmlLogined += '<br/> Đang tạm giữ: <b class="txt-red">' + user.wallet_temphold_balance.formatMoney(0, ',', '.') + 'đ</b>';
        }

        $('#login-box-islogin .login-title').html(htmlLogined);

        //Ajax Notification
        var notificationHtml = '';
        $.post(LT_ROOT_URL + '/notification/notify', function (data) {
            $('#show-notification-new .notify-content').append(data.html);
            $('#show-notification-new .item-notify').html('<span class="glyphicon glyphicon-globe" aria-hidden="true"></span>Thông báo (' + data.unread + ')');
        });

    }
    // Hiển thị số lượng sản phẩm trong giỏ hàng
    $('#booking-quantity').text(parseInt(cart.quantity).formatMoney(0, ',', '.'));
});