var id = 0;
$(function () {
    id = parastr("id");
    $('#tid').val(id);
    $(".top_count > b").html('(' + $('#info_reply .list li').length + ')');
    if ($('#info_reply .list li').length == 0) {
        $('#info_reply .top_reply_bg,#info_reply > .content').hide();
    }

    $('#reply_form').form({
        onSubmit: function () {
            if (!$("#replyContent").val()) {
                alert("请填写评论内容！");
                return false;
            }
        },
        success: function (data) {
            if (data == "1") {
                $("#replyContent").val("");
                alert('评论成功!');
                window.location.href = window.location.href;
            } else {
                alert("评论失败!");
            }
        }
    });
    $("#reply_form .btn_submit").click(function () {
        $('#reply_form').submit();
    });
    bind_emotion();
    $(".addFace").afterbind('click', function (event) {
        $(".reply-emotion").css({ "left": getMousePos(event).x + "px", "top": getMousePos(event).y + 25 + "px" }).fadeIn(400);
    });
    $(".reply-emotion ul img").afterbind('click', function (event) {
        var c = $('#replyContent')
        c.val(c.val() + "[" + $(this).attr("url") + "]");
        $(".reply-emotion").hide();
    });
    $(".reply-emotion-close").afterbind('click', function (event) {
        $(".reply-emotion").fadeOut(400);
    });
    $.tl_slider = function (options) {
        var defaults = {
            slider: ".reply-emotion-content > ul",
            slider_num: ".reply-emotion-header > ul"
        };
        var settings = $.extend(defaults, options);
        var slider = settings.slider;
        var slider_num = settings.slider_num;
        var count = $(slider_num + " > li").length;
        var index = 0;
        var slide_Timer;
        $(slider + " > li").afterbind('click', function (event) {
            var index_status = $(slider + " > li").index(this);
            $(slider_num + " > li").eq(index_status).mousemove();
        });
        $(slider_num + " > li").afterbind('click', function (event) {
            index = $(slider_num + " > li").index(this);

            show(index);
        }).eq(0).click();
        function show(index) {
            $(slider).stop(true, false).animate({ left: -860 * index }, 500);
            var d = $(slider + " > li > div").eq(index);
            var s = d.parent().siblings().children();
            s.css("border", "2px solid white");

            //var li = $(slider_num + " li").removeClass("on_y").removeClass("on_n").eq(index);
            var li = $(slider_num + " li").eq(index);
            li.css("border-bottom", "3px solid green");

            d.css("border", "2px solid #c8fcd6");
            li.siblings().css("border-bottom", "3px solid #C8FCD6");




        }
    };
    $.tl_slider();
})
function numFour(n) {
    n = parseInt(n);
    if (n < 10)
        return "000" + n;
    else if (n < 100)
        return "00" + n;
    else if (n < 1000)
        return "0" + n;
    else
        return "0000";
}
function bind_emotion() {
    var html = "";
    for (var i = 1; i <= 55; i++) {//84
        html += '<li><img index="' + i + '" url="jx2/j_' + numFour(i) + '" src="/j/editor/dialogs/emotion/images/jx2/j_' + numFour(i) + '.gif"></li>';
    }
    $(".reply-emotion-content > ul > li > ul:eq(0)").html(html);
    html = "";
    for (var i = 1; i <= 55; i++) {//63
        html += '<li><img index="' + i + '" url="bobo/b_' + numFour(i) + '" src="/j/editor/dialogs/emotion/images/bobo/b_' + numFour(i) + '.gif"></li>';
    }
    $(".reply-emotion-content > ul > li > ul:eq(1)").html(html);
    html = "";
    for (var i = 1; i <= 20; i++) {
        html += '<li><img index="' + i + '" url="babycat/c_' + numFour(i) + '" src="/j/editor/dialogs/emotion/images/babycat/C_' + numFour(i) + '.gif"></li>';
    }
    $(".reply-emotion-content > ul > li > ul:eq(2)").html(html);
    html = "";
    for (var i = 1; i <= 52; i++) {
        html += '<li><img index="' + i + '" url="ldw/w_' + numFour(i) + '" src="/j/editor/dialogs/emotion/images/ldw/w_' + numFour(i) + '.gif"></li>';
    }
    $(".reply-emotion-content > ul > li > ul:eq(3)").html(html);
    html = "";
    for (var i = 1; i <= 40; i++) {
        html += '<li><img index="' + i + '" url="tsj/t_' + numFour(i) + '" src="/j/editor/dialogs/emotion/images/tsj/t_' + numFour(i) + '.gif"></li>';
    }
    $(".reply-emotion-content > ul > li > ul:eq(4)").html(html);
    html = "";
    for (var i = 1; i <= 40; i++) {
        html += '<li><img index="' + i + '" url="youa/y_' + numFour(i) + '" src="/j/editor/dialogs/emotion/images/youa/y_' + numFour(i) + '.gif"></li>';
    }
    $(".reply-emotion-content > ul > li > ul:eq(5)").html(html);
}
$(function () {
    index = 1;
    $('.nav_' + index).bgPosition(nav_bg[index].x, nav_bg[index].y).stop().a({ left: 0 }, 150);



    var settings = {
        min: 200,
        inDelay: 600,
        outDelay: 400,
        containerID: 'toTops',
        scrollSpeed: 200, /*1200*/
        easingType: 'linear'
    };

    var containerIDhash = settings.containerID;
    $("#toTops").hide().click(function () {
        $('html, body').animate({ scrollTop: 0 }, 200);
    });

    $(window).scroll(function () {
        var sd = $(window).scrollTop();
        if (typeof document.body.style.maxHeight === "undefined") {
            $(containerIDhash).css({
                'position': 'absolute',
                'top': $(window).scrollTop() + $(window).height() - 50
            });
        }
        if (sd > settings.min)
            $("#" + containerIDhash).fadeIn(settings.inDelay);
        else
            $("#" + containerIDhash).fadeOut(settings.Outdelay);
    });
    $('#toTops .item3 a').hover(function () {
        $(this).a({ left: -80 }, 150);
    }, function () {
        $(this).a({ left: 0 }, 150);
    });
})