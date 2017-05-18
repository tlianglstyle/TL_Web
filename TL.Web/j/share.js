$(function () {
    $('[lazy-src]').imglazyload();
    $('.find_album_list .ui_picwrap').hover(function () {
        $(this).op(0.9);
    }, function () {
        $(this).op(1);
    });

    var settings = {
        min: 200,
        containerID: 'toTops'
    };

    var containerIDhash = settings.containerID;
    $("#toTops").click(function () {
        $('html, body').animate({ scrollTop: 0 }, 200);
    });

    $(window).scroll(function () {
        var sd = $(window).scrollTop();
        if (typeof document.body.style.maxHeight === "undefined") {
            $(containerIDhash).css({
                'top': $(window).scrollTop() + $(window).height() - 50
            });
        }
        if (sd > settings.min)
            $("#" + containerIDhash).addClass('scaleTop');
        else
            $("#" + containerIDhash).removeClass('scaleTop');
    });
    $('#toTops .item3 a').hover(function () {
        $(this).a({ left: -50 }, 150);
    }, function () {
        $(this).a({ left: 0 }, 150);
    });
})