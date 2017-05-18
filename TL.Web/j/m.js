var index = 1;

var nav_status = 1;

var light = false;

var nav_bg = [ {
    x:1,
    y:1
}, {
    x:0,
    y:0 - 5
}, {
    x:1,
    y:-184 - 5
}, {
    x:1,
    y:-313 - 5
}, {
    x:1,
    y:-248 - 5
}, {
    x:1,
    y:-737 - 5
} ];

$(function() {
    $("a").focus(function() {
        this.blur();
    });
    $("#nav #nav_menubar div").hover(function() {
        if (index == $("#nav #nav_menubar div").index(this) + 1) {
            $(this).children("a").stop().a({
                left:-57
            }, 150);
        } else {
            $(this).children("a").stop().a({
                left:0
            }, 150);
        }
    }, function() {
        if (index == $("#nav #nav_menubar div").index(this) + 1) {
            $(this).children("a").stop().a({
                left:0
            }, 150);
        } else {
            $(this).children("a").stop().a({
                left:-57
            }, 150);
        }
    });
    var a = "search";
    $("#nav #nav_search .input_text").focus(function() {
        if ($(this).val() == a) {
            $(this).val("");
        }
        $("#nav #nav_search").addClass("focus").find(".input_text").a({
            width:120
        }, 200);
    }).blur(function() {
        if ($(this).val() == "") {
            $(this).val(a);
        }
        $("#nav #nav_search").removeClass("focus").find(".input_text").a({
            width:70
        }, 200);
    });
    $(".nav_close").click(function() {
        nav_close();
    });
    $(".nav_open").click(function() {
        setCookie("nav_status", "open");
        nav_open();
    }).mousemove(function() {
        if (!$(".nav_open").is(":animated")) {
            if (nav_status == 0) {
                $(".nav_open").stop().a({
                    top:14
                }, 100);
            }
            setTimeout(function() {
                if (nav_status == 0) {
                    $(".nav_open").stop().a({
                        top:17
                    }, 100);
                }
                setTimeout(function() {
                    if (nav_status == 0) {
                        $(".nav_open").stop().a({
                            top:14
                        }, 100);
                    }
                    setTimeout(function() {
                        if (nav_status == 0) {
                            $(".nav_open").stop().a({
                                top:17
                            }, 100);
                        }
                    }, 100);
                }, 100);
            }, 100);
        }
    });
    $(".nav_light").click(function() {
        if (!light) {
            light_open();
        } else {
            light_close();
        }
    }).mousemove(function() {
        if (!$(".nav_light").is(":animated")) {
            $(".nav_light").stop().a({
                top:14
            }, 100);
            setTimeout(function() {
                $(".nav_light").stop().a({
                    top:17
                }, 100);
                setTimeout(function() {
                    $(".nav_light").stop().a({
                        top:14
                    }, 100);
                    setTimeout(function() {
                        $(".nav_light").stop().a({
                            top:17
                        }, 100);
                    }, 100);
                }, 100);
            }, 100);
        }
    });
    $(".topic_tool .close").click(function() {
        $(this).parent().parent().slideUp();
    });
    $(".indexlogo").mousedown(function() {
        $(this).css("margin-top", "2px");
        $(document).mouseup(function() {
            $(".indexlogo").css("margin-top", "0px");
        });
    });
    setTimeout(function() {
        $("body").w(document.body.scrollWidth);
    }, 5e3);
    setTimeout(function() {
        $("#page").next().next("span:eq(0)").css({
            position:"fixed",
            position:"fixed",
            bottom:"0px",
            left:"0px",
            opacity:"0",
            "z-index":"10000"
        });
    }, 1e4);
});

function nav_close() {
    if (nav_status == 1) {
        $("#nav").stop().a({
            top:-40
        }, 200);
        $("#nav_bg").stop().a({
            height:0
        }, 200);
        nav_control(true);
    }
}

function nav_open() {
    if (nav_status == 0) {
        nav_status = 1;
        nav_control(false);
        setTimeout(function() {
            $("#nav").stop().a({
                top:0
            }, 200);
            $("#nav_bg").stop().a({
                height:39
            }, 200);
        }, 200);
    }
}

function nav_control(a) {
    if (a) {
        setTimeout(function() {
            $(".nav_open").show().stop().a({
                top:30
            }, 300);
            setTimeout(function() {
                $(".nav_open").stop().a({
                    top:10
                }, 200);
                setTimeout(function() {
                    $(".nav_open").stop().a({
                        top:23
                    }, 150);
                    setTimeout(function() {
                        $(".nav_open").stop().a({
                            top:15
                        }, 100);
                        setTimeout(function() {
                            $(".nav_open").stop().a({
                                top:20
                            }, 100);
                            setTimeout(function() {
                                $(".nav_open").stop().a({
                                    top:17
                                }, 100);
                                nav_status = 0;
                            }, 100);
                        }, 100);
                    }, 150);
                }, 200);
            }, 300);
        }, 200);
    } else {
        $(".nav_open").stop().a({
            top:-90
        }, 300);
    }
}

function light_close() {
    $("body").removeClass("c");
    $(".nav_light").removeClass("c");
    light = false;
}

function light_open() {
    $("body").addClass("c");
    $(".nav_light").addClass("c");
    light = true;
}

function nav_light(a) {
    if (a) {
        setTimeout(function() {
            $(".nav_light").show().stop().a({
                top:30
            }, 300);
            setTimeout(function() {
                $(".nav_light").stop().a({
                    top:10
                }, 200);
                setTimeout(function() {
                    $(".nav_light").stop().a({
                        top:23
                    }, 150);
                    setTimeout(function() {
                        $(".nav_light").stop().a({
                            top:15
                        }, 100);
                        setTimeout(function() {
                            $(".nav_light").stop().a({
                                top:20
                            }, 100);
                            setTimeout(function() {
                                $(".nav_light").stop().a({
                                    top:17
                                }, 100);
                                nav_status = 0;
                            }, 100);
                        }, 100);
                    }, 150);
                }, 200);
            }, 300);
        }, 200);
    } else {
        $(".nav_light").stop().a({
            top:-100
        }, 300);
    }
}

function setCookie(a, c) {
    var b = 30;
    var d = new Date();
    d.setTime(d.getTime() + b * 24 * 60 * 60 * 1e3);
    document.cookie = a + "=" + escape(c) + ";expires=" + d.toGMTString();
}

function getCookie(c) {
    var d = document.cookie.split("; ");
    for (var b = 0; b < d.length; b++) {
        var a = d[b].split("=");
        if (a[0] == c) {
            return unescape(a[1]);
        }
    }
}

function addCookie(e, a, d) {
    var f = e + "=" + escape(a);
    if (d > 0) {
        var c = new Date();
        var b = d * 3600 * 1e3;
        c.setTime(c.getTime() + b);
        f += "; expires=" + c.toGMTString();
    }
    document.cookie = f;
}

