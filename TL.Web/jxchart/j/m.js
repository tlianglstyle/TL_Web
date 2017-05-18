$(function () {
    $('#bt-lang').toggle(function () {
        $('#box-languages').stop().slideDown(300);
    }, function () {
        $('#box-languages').stop().slideUp(200);
    });
    setTimeout(function () {
        $("#page").siblings("span").css({
            position: "fixed",
            position: "fixed",
            bottom: "0px",
            left: "0px",
            opacity: "0",
            "z-index": "10000"
        });
    }, 3000);
})