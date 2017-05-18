var animate_login = false;
$(function () {
    setCookie('qq_login', null);
    if (1 == 2) {
        if (parastr('code') != null && parastr('code').length > 0) {
            alert('2');
            alert(parastr('code'));
            var url = "https://graph.qq.com/oauth2.0/token?";
            var appid = "100515616";
            var appkey = "c13453f2de1276ecfc9c29c806661a4c";
            var AuthorizationCode = ""; //用户的openid。
            var access_token = "";
            AuthorizationCode = parastr('code');
            url += "grant_type=authorization_code";
            url += "&client_id=" + appid;
            url += "&client_secret=" + appkey;
            url += "&code=" + AuthorizationCode;
            url += "&redirect_uri=www.tliangl.com/login.aspx";
            $.ajax({
                type: "get",
                url: url,
                success: function (data) {
                    if (data.length == 32) {
                        alert('3');
                        access_token = data;
                        url = "https://graph.qq.com/user/get_user_info?";
                        url += "oauth_consumer_key=" + appid;
                        url += "&access_token=" + access_token;
                        url += "&openid=" + AuthorizationCode;
                        url += "&format=json";
                        $.ajax({
                            type: "get",
                            url: url,
                            success: function (data) {
                                alert(data);
                                data = eval('(' + data + ')');
                                alert(data);
                            }
                        });
                    } else {
                        window.location.href = "login.aspx";
                    }
                }
            });
        }
    }

    $('#login-email-address').val('');
    $('#login-password').val('');
    $('#email-address').val('');
    $('#yourname').val('');
    $('#password-new').val('');
    $('#password-confirm').val('');
    $('#telephone').val('');
    $('#city').val('http://');
    $('#form_login').form({
        onSubmit: function () {
        },
        success: function (data) {
            if (data == "1") {
                //alert("登录成功!");
                window.location = "/default.aspx";
                //history.go(-1);
            } else {
                alert("用户名或密码错误!");
            }
        }
    });
    $('#form_register').form({
        onSubmit: function () {
        },
        success: function (data) {
            if (data == "2") {
                alert("已存在相同的用户名!"); return false;
            }
            else if (data == "1") {
                alert("注册成功!");
                history.go(-1);
            } else {
                alert("系统出错!");
            }
        }
    });
    $('.login').click(function () {
        if (!$('#login-email-address').val()) {
            $('#login-email-address').focus();
            return false;
        }
        if (!$('#login-password').val()) {
            $('#login-password').focus();
            return false;
        }
        $('#form_login').submit();
    });
    $('.register').click(function () {
        if (!$('#email-address').val() || $('#email-address').val().length < 4) {
            $('#email-address').focus(); alert('用户名需大于4个字符.');
            return false;
        }
        if (!$('#yourname').val() || $('#yourname').val().length < 1) {
            $('#yourname').focus(); alert('姓名不能为空.');
            return false;
        }
        if (!$('#password-new').val() || $('#password-new').val().length < 4) {
            $('#password-new').focus(); alert('密码需大于4个字符.');
            return false;
        }
        if (!$('#password-confirm').val() || $('#password-confirm').val().length < 4) {
            $('#password-confirm').focus(); alert('密码需大于4个字符.');
            return false;
        }
        if ($('#password-new').val() != $('#password-confirm').val()) {
            $('#password-confirm').focus(); alert('密码不一致.');
            return false;
        }
        $('#form_register').submit();
    });
    $('.login_back').click(function () {
        animate_login = true;
        $('.left-slider').stop().a({ top: 0 }, 300);
        setTimeout(function () { animate_login = false; }, 300);
        setCookie('qq_login', null);
        QC.Login.signOut();
    });
})