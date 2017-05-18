function RGBToHex(rgb) {
    var regexp = /[0-9]{0,3}/g;
    var re = rgb.match(regexp);
    var hexColor = "#";
    var hex = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F"];
    for (var i = 0; i < re.length; i++) {
        var r = null, c = re[i], l = c;
        var hexAr = [];
        while (c > 16) {
            r = c % 16;
            c = c / 16 >> 0;
            hexAr.push(hex[r]);
        }
        hexAr.push(hex[c]);
        if (l < 16 && l != "") {
            hexAr.push(0);
        }
        hexColor += hexAr.reverse().join("");
    }
    return hexColor;
}

function parastr(a) {
    var b = new RegExp("(^|&)" + a + "=([^&]*)(&|$)"), c = window.location.search.substr(1).match(b);
    return null != c ? unescape(c[2]) : null;
}

function getString(objarr) {
    var typeNO = objarr.length;
    var tree = "[";
    for (var i = 0; i < typeNO; i++) {
        tree += "[";
        tree += "'" + objarr[i][0] + "',";
        tree += "'" + objarr[i][1] + "'";
        tree += "]";
        if (i < typeNO - 1) {
            tree += ",";
        }
    }
    tree += "]";
    return tree;
}

function parastrtrans(a) {
    var b, c, d;
    return window.location.href.indexOf("?") > 0 ? parastr(a) : (b = window.location.href.indexOf("article") + 7,
    c = window.location.href.indexOf(".aspx"), d = window.location.href.substring(b, c),
    parseInt(d));
}

function GetRandomNum(a, b) {
    var c = b - a, d = Math.random();
    return a + Math.round(d * c);
}

function getMousePos(a) {
    return {
        x: a.pageX || a.clientX + document.body.scrollLeft,
        y: a.pageY || a.clientY + document.body.scrollTop
    };
}

function getElementPos(a) {
    return {
        x: a.offsetParent ? a.offsetLeft + arguments.callee(a.offsetParent).x : a.offsetLeft,
        y: a.offsetParent ? a.offsetTop + arguments.callee(a.offsetParent).y : a.offsetTop
    };
}

function getBrowserSize() {
    var a = 0, b = 0;
    return window.innerWidth ? a = window.innerWidth : document.body && document.body.clientWidth && (a = document.body.clientWidth),
    window.innerHeight ? b = window.innerHeight : document.body && document.body.clientHeight && (b = document.body.clientHeight),
    document.documentElement && document.documentElement.clientHeight && document.documentElement.clientWidth && (b = document.documentElement.clientHeight,
    a = document.documentElement.clientWidth), {
        w: a,
        h: b
    };
}

function getBrowser() {
    return navigator.userAgent.indexOf("MSIE") > 0 ? "MSIE" : (isFirefox = navigator.userAgent.indexOf("Firefox") > 0) ? "Firefox" : (isSafari = navigator.userAgent.indexOf("Safari") > 0) ? "Safari" : (isCamino = navigator.userAgent.indexOf("Camino") > 0) ? "Camino" : (isMozilla = navigator.userAgent.indexOf("Gecko/") > 0) ? "Gecko" : void 0;
}

var htmlEncode = function (a) {
    var c, b = [];
    for (c = 0; c < a.length; c++) b[c] = a.charCodeAt(c);
    return "&#" + b.join(";&#") + ";";
}, htmlDecode = function (a) {
    return a.replace(/&#(x)?([^&]{1,5});?/g, function (a, b, c) {
        return String.fromCharCode(parseInt(c, b ? 16 : 10));
    });
};

jQuery.easing.jswing = jQuery.easing.swing, jQuery.extend(jQuery.easing, {
    def: "easeOutQuad",
    swing: function (a, b, c, d, e) {
        return jQuery.easing[jQuery.easing.def](a, b, c, d, e);
    },
    easeInQuad: function (a, b, c, d, e) {
        return d * (b /= e) * b + c;
    },
    easeOutQuad: function (a, b, c, d, e) {
        return -d * (b /= e) * (b - 2) + c;
    },
    easeInOutQuad: function (a, b, c, d, e) {
        return (b /= e / 2) < 1 ? d / 2 * b * b + c : -d / 2 * (--b * (b - 2) - 1) + c;
    },
    easeInCubic: function (a, b, c, d, e) {
        return d * (b /= e) * b * b + c;
    },
    easeOutCubic: function (a, b, c, d, e) {
        return d * ((b = b / e - 1) * b * b + 1) + c;
    },
    easeInOutCubic: function (a, b, c, d, e) {
        return (b /= e / 2) < 1 ? d / 2 * b * b * b + c : d / 2 * ((b -= 2) * b * b + 2) + c;
    },
    easeInQuart: function (a, b, c, d, e) {
        return d * (b /= e) * b * b * b + c;
    },
    easeOutQuart: function (a, b, c, d, e) {
        return -d * ((b = b / e - 1) * b * b * b - 1) + c;
    },
    easeInOutQuart: function (a, b, c, d, e) {
        return (b /= e / 2) < 1 ? d / 2 * b * b * b * b + c : -d / 2 * ((b -= 2) * b * b * b - 2) + c;
    },
    easeInQuint: function (a, b, c, d, e) {
        return d * (b /= e) * b * b * b * b + c;
    },
    easeOutQuint: function (a, b, c, d, e) {
        return d * ((b = b / e - 1) * b * b * b * b + 1) + c;
    },
    easeInOutQuint: function (a, b, c, d, e) {
        return (b /= e / 2) < 1 ? d / 2 * b * b * b * b * b + c : d / 2 * ((b -= 2) * b * b * b * b + 2) + c;
    },
    easeInSine: function (a, b, c, d, e) {
        return -d * Math.cos(b / e * (Math.PI / 2)) + d + c;
    },
    easeOutSine: function (a, b, c, d, e) {
        return d * Math.sin(b / e * (Math.PI / 2)) + c;
    },
    easeInOutSine: function (a, b, c, d, e) {
        return -d / 2 * (Math.cos(Math.PI * b / e) - 1) + c;
    },
    easeInExpo: function (a, b, c, d, e) {
        return 0 == b ? c : d * Math.pow(2, 10 * (b / e - 1)) + c;
    },
    easeOutExpo: function (a, b, c, d, e) {
        return b == e ? c + d : d * (-Math.pow(2, -10 * b / e) + 1) + c;
    },
    easeInOutExpo: function (a, b, c, d, e) {
        return 0 == b ? c : b == e ? c + d : (b /= e / 2) < 1 ? d / 2 * Math.pow(2, 10 * (b - 1)) + c : d / 2 * (-Math.pow(2, -10 * --b) + 2) + c;
    },
    easeInCirc: function (a, b, c, d, e) {
        return -d * (Math.sqrt(1 - (b /= e) * b) - 1) + c;
    },
    easeOutCirc: function (a, b, c, d, e) {
        return d * Math.sqrt(1 - (b = b / e - 1) * b) + c;
    },
    easeInOutCirc: function (a, b, c, d, e) {
        return (b /= e / 2) < 1 ? -d / 2 * (Math.sqrt(1 - b * b) - 1) + c : d / 2 * (Math.sqrt(1 - (b -= 2) * b) + 1) + c;
    },
    easeInElastic: function (a, b, c, d, e) {
        var f = 1.70158, g = 0, h = d;
        return 0 == b ? c : 1 == (b /= e) ? c + d : (g || (g = .3 * e), h < Math.abs(d) ? (h = d,
        f = g / 4) : f = g / (2 * Math.PI) * Math.asin(d / h), -(h * Math.pow(2, 10 * (b -= 1)) * Math.sin((b * e - f) * 2 * Math.PI / g)) + c);
    },
    easeOutElastic: function (a, b, c, d, e) {
        var f = 1.70158, g = 0, h = d;
        return 0 == b ? c : 1 == (b /= e) ? c + d : (g || (g = .3 * e), h < Math.abs(d) ? (h = d,
        f = g / 4) : f = g / (2 * Math.PI) * Math.asin(d / h), h * Math.pow(2, -10 * b) * Math.sin((b * e - f) * 2 * Math.PI / g) + d + c);
    },
    easeInOutElastic: function (a, b, c, d, e) {
        var f = 1.70158, g = 0, h = d;
        return 0 == b ? c : 2 == (b /= e / 2) ? c + d : (g || (g = e * .3 * 1.5), h < Math.abs(d) ? (h = d,
        f = g / 4) : f = g / (2 * Math.PI) * Math.asin(d / h), 1 > b ? -.5 * h * Math.pow(2, 10 * (b -= 1)) * Math.sin((b * e - f) * 2 * Math.PI / g) + c : .5 * h * Math.pow(2, -10 * (b -= 1)) * Math.sin((b * e - f) * 2 * Math.PI / g) + d + c);
    },
    easeInBack: function (a, b, c, d, e, f) {
        return void 0 == f && (f = 1.70158), d * (b /= e) * b * ((f + 1) * b - f) + c;
    },
    easeOutBack: function (a, b, c, d, e, f) {
        return void 0 == f && (f = 1.70158), d * ((b = b / e - 1) * b * ((f + 1) * b + f) + 1) + c;
    },
    easeInOutBack: function (a, b, c, d, e, f) {
        return void 0 == f && (f = 1.70158), (b /= e / 2) < 1 ? d / 2 * b * b * (((f *= 1.525) + 1) * b - f) + c : d / 2 * ((b -= 2) * b * (((f *= 1.525) + 1) * b + f) + 2) + c;
    },
    easeInBounce: function (a, b, c, d, e) {
        return d - jQuery.easing.easeOutBounce(a, e - b, 0, d, e) + c;
    },
    easeOutBounce: function (a, b, c, d, e) {
        return (b /= e) < 1 / 2.75 ? d * 7.5625 * b * b + c : 2 / 2.75 > b ? d * (7.5625 * (b -= 1.5 / 2.75) * b + .75) + c : 2.5 / 2.75 > b ? d * (7.5625 * (b -= 2.25 / 2.75) * b + .9375) + c : d * (7.5625 * (b -= 2.625 / 2.75) * b + .984375) + c;
    },
    easeInOutBounce: function (a, b, c, d, e) {
        return e / 2 > b ? .5 * jQuery.easing.easeInBounce(a, 2 * b, 0, d, e) + c : .5 * jQuery.easing.easeOutBounce(a, 2 * b - e, 0, d, e) + .5 * d + c;
    }
}), function (a) {
    a.UItoTop = function (b) {
        var c = {
            text: "回到顶部",
            min: 200,
            inDelay: 600,
            outDelay: 400,
            containerID: "#toTop",
            containerHoverID: "#toTopHover",
            scrollSpeed: 0,
            easingType: "linear"
        }, d = a.extend(c, b), e = d.containerID, f = d.containerHoverID;
        a("body").append('<a href="#" id="' + d.containerID + '" title="' + d.text + '">' + d.text + "</a>"),
        a(e).hide().click(function () {
            return 0 == d.scrollSpeed ? a("html, body").attr("scrollTop", 0) : a("html, body").animate({
                scrollTop: 0
            }, d.scrollSpeed, d.easingType), a("#" + d.containerHoverID, this).stop().animate({
                opacity: 0
            }, d.inDelay, d.easingType), !1;
        }).prepend('<span id="' + d.containerHoverID + '"></span>').hover(function () {
            a(f, this).stop().animate({
                opacity: 1
            }, 600, "linear");
        }, function () {
            a(f, this).stop().animate({
                opacity: 0
            }, 700, "linear");
        }), a(window).scroll(function () {
            var b = a(window).scrollTop();
            "undefined" == typeof document.body.style.maxHeight && a(e).css({
                position: "absolute",
                top: a(window).scrollTop() + a(window).height() - 50
            }), b > d.min ? a(e).fadeIn(d.inDelay) : a(e).fadeOut(d.Outdelay);
        });
    }, a.tl_page_slider = function (b) {
        function R() {
            var c, d, b = "";
            for (E && (b += '<li class="start-page">首页</li>'), F && (b += '<li class="prev-page">上一页</li>'),
            b += '<div style="width:' + (O * o + 2) + "px;height:" + P + 'px;position:relative;overflow:hidden;margin:0px;padding:0px;float:left;">',
            b += '<ul class="page-slider" style="width:' + (O + 2) * N + "px;height:" + P + 'px;position:absolute;left:0px;top:0px;margin:0px;padding:0px;">',
            c = 1; N >= c; c++) b += "<li" + (c == j ? ' class="page-currentpage"' : "") + ' pagevalue="' + c + '">' + c + "</li>";
            b += "</ul>", b += "</div>", N > 1 && G && (b += '<li class="next-page">下一页</li>'),
            H && (b += '<li class="end-page">末页</li>'), d = '<div style="font-size:' + y + "px;padding-top:" + (r - y + 1) + "px;margin-left:3px;float:left;font-family:宋体;color:" + v + '">共',
            I && (d += "" + N + "页"), J && (d += (I ? "," : "") + p + "条数据"), K && (d += '&nbsp;<input type="text" style="border:1px solid ' + v + ";display:none;height:" + y + 'px;width:20px;margin:0px" class="page-input" /><a style="color:' + v + ';cursor:pointer;margin:0px 2px 0px 0px;display:none;" title="关闭" class="page-input-close">关闭</a><a style="color:' + v + ";cursor:pointer;border:1px solid " + x + ';padding:2px;" class="page-change" title="跳转">跳转</a>'),
            d += "</div>", (I || J || K) && (b += d), b += '<div style="clear:both;"></div>',
            a(m).append(b);
        }
        function S(a) {
            e ? f ? T(a) : Q ? d.fun(a) : Q = !0 : Q ? (g = g + "?" + h + "=" + a + "&" + i + "=" + n,
            "" != u && (g += "#" + u), window.location.href = g) : (T(a), Q = !0);
        }
        function T(b) {
            a(".page-currentpage").removeClass("page-currentpage"), a("" + m + " li[pagevalue=" + b + "]").addClass("page-currentpage"),
            a("" + m + " li[pagevalue=" + b + "]").css({
                "background-color": B,
                "font-weight": z ? "bold" : "normal"
            }), a("" + m + " li:not(.page-more):not(.page-currentpage)").css({
                "background-color": w,
                "font-weight": "normal"
            }).afterbind("mousemove", function () {
                a(this).css({
                    "background-color": B,
                    color: A,
                    "font-size": C,
                    border: ("1px solid " + D).toString(),
                    "font-weight": z ? "bold" : "normal"
                });
            }).afterbind("mouseout", function () {
                a(this).css({
                    "background-color": w,
                    color: v,
                    "font-size": y,
                    border: ("1px solid " + x).toString(),
                    "font-weight": "normal"
                });
            }), N - (o - 1) >= b ? a(".page-slider").stop(!0, !1).animate({
                left: -O * (b - 1)
            }, 200) : N > o && a(".page-slider").stop(!0, !1).animate({
                left: -O * (N - o)
            }, 200), b == N ? (a(".next-page").opn(), a(".end-page").opn()) : (a(".next-page").opy(),
            a(".end-page").opy()), 1 == b ? (a(".prev-page").opn(), a(".start-page").opn()) : (a(".prev-page").opy(),
            a(".start-page").opy()), d.fun(b);
        }
        var m, n, o, p, r, s, t, u, v, w, x, y, z, A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, U, c = {
            control: "#my_page",
            sumrows: 211,
            pageid: 1,
            pagesize: 10,
            pageMaxCount: 5,
            maxpage: 6,
            height: 17,
            minWidth: 17,
            radius: 5,
            setPosition: "",
            color: "#403f3f",
            bgColor: "white",
            borderColor: "#E7ECF0",
            fontSize: 13,
            bold: !0,
            hover_color: "black",
            hover_bgColor: "#E7ECF0",
            hover_fontsize: 13,
            hover_borderColor: "#E7ECF0",
            show_start: !0,
            show_prev: !0,
            show_next: !0,
            show_end: !0,
            show_sumPages: !0,
            show_sumRows: !0,
            show_pageInput: !0,
            pname_pageid: "pageid",
            pname_pagesize: "pagesize",
            url: window.location.href.split("?")[0],
            request: !1,
            animate: !1,
            fun: function () { }
        }, d = a.extend(c, b), e = d.request, f = d.animate, g = d.url, h = d.pname_pageid, i = d.pname_pagesize, j = d.pageid, k = new RegExp("(^|&)" + h + "=([^&]*)(&|$)"), l = window.location.search.substr(1).match(k);
        null != l && (j = parseInt(unescape(l[2]))), m = d.control, n = d.pagesize, o = d.pageMaxCount,
        p = d.sumrows, d.maxpage, r = d.height, s = d.minWidth, t = d.radius, u = d.setPosition,
        v = d.color, w = d.bgColor, x = d.borderColor, y = d.fontSize, z = d.bold, A = d.hover_color,
        B = d.hover_bgColor, C = d.hover_fontsize, D = d.hover_borderColor, E = d.show_start,
        F = d.show_prev, G = d.show_next, H = d.show_end, I = d.show_sumPages, J = d.show_sumRows,
        K = d.show_pageInput, L = parseInt(p / n), M = parseInt(p % n > 0 ? 1 : 0), N = L + M,
        o > N && (o = N), O = s + 2 * (s - y) + 5, P = r + 2 * (r - y) + 3, Q = !1, p > n && (R(),
        j > N ? j = N : 0 > j && (j = 1), f || S(j)), U = !1, a(".page-change").afterbind("click", function () {
            U ? (null != a(".page-input").val() && parseInt(a(".page-input").val()) > 0 && (parseInt(a(".page-input").val()) > N ? (j = N,
            a(".page-input").val(N)) : j = a(".page-input").val()), S(j)) : (a(this).siblings(".page-input").show(),
            a(this).siblings(".page-input-close").show(), U = !0);
        }), a(".page-input-close").afterbind("click", function () {
            a(this).siblings(".page-input").hide(), a(this).hide(), U = !1;
        }), a(m + " li").click(function () {
            a(this).hasClass("start-page") ? (j = 1, S(j)) : a(this).hasClass("prev-page") ? j > 1 && (j = parseInt(j - 1),
            S(j)) : a(this).hasClass("next-page") ? N > j && (j = parseInt(j) + 1, S(j)) : a(this).hasClass("end-page") ? (j = N,
            S(j)) : a(this).hasAttr("pagevalue") && (j = a(this).attr("pagevalue"), S(j));
        }).css({
            border: "1px solid " + x,
            "float": "left",
            height: (r + "px").toString(),
            "list-style": "none outside none",
            "padding-top": r - y + "px",
            "padding-right": s - y + "px",
            "padding-bottom": r - y + "px",
            "padding-left": s - y + "px",
            "font-size": y,
            "font-family": "宋体",
            "min-width": (s + "px").toString(),
            "text-align": "center",
            color: v,
            "margin-left": "3px",
            cursor: "pointer",
            "border-radius": (t + "px " + t + "px " + t + "px " + t + "px").toString()
        }).each(function () {
            a(this).hasClass("page-currentpage") && (a(this).css({
                "background-color": B,
                "font-weight": z ? "bold" : "normal"
            }), a("" + m + " li:not(.page-more):not(.page-currentpage)").css({
                "background-color": w,
                "font-weight": "normal"
            }).afterbind("mousemove", function () {
                a(this).css({
                    "background-color": B,
                    color: A,
                    "font-size": C,
                    border: ("1px solid " + D).toString(),
                    "font-weight": z ? "bold" : "normal"
                });
            }).afterbind("mouseout", function () {
                a(this).css({
                    "background-color": w,
                    color: v,
                    "font-size": y,
                    border: ("1px solid " + x).toString(),
                    "font-weight": "normal"
                });
            })), a(this).hasClass("start-page") || a(this).hasClass("end-page") ? a(this).css("width", (2 * y + 2).toString() + "px") : (a(this).hasClass("prev-page") || a(this).hasClass("next-page")) && a(this).css("width", (3 * y + 3).toString() + "px");
        });
    }, a.tl_page_request = function (b) {
        function K() {
            var c, d, b = !1;
            for (B && a(l).append('<li class="start-page">首页</li>'), i > 1 && C && a(l).append('<li class="prev-page">上一页</li>'),
            c = o >= i ? 0 : i - o; J > c; c++) (o >= i ? o : J > i ? i : i - 1) > c ? c == i - 1 ? (a(l).append('<li class="page-currentpage">' + (c + 1) + "</li>"),
            b = !0) : a(l).append("<li>" + (c + 1) + "</li>") : (a(l).append('<span class="page-more" style="float:left;margin-left:5px;color:gray;">...</span>'),
            c = J);
            b || a(l).append('<li class="page-currentpage">' + i + "</li>"), J > i && D && a(l).append('<li class="next-page">下一页</li>'),
            E && a(l).append('<li class="end-page">末页</li>'), d = '<div style="font-size:' + v + "px;padding-top:" + (p - v) + 'px;margin-left:3px;float:left;font-family:宋体;">共',
            F && (d += "" + J + "页"), G && (d += (F ? "," : "") + n + "条数据"), d += "</div>",
            d += '<div style="clear:both;"></div>', (F || G) && a(l).append(d);
        }
        function L(a) {
            e ? d.fun(a) : (f = f + "?" + g + "=" + a + "&" + h + "=" + m, "" != r && (f += "#" + r),
            window.location.href = f);
        }
        var l, m, n, o, p, q, r, s, t, u, v, w, x, y, z, A, B, C, D, E, F, G, H, I, J, c = {
            control: "#my_page",
            sumrows: 101,
            pageid: 1,
            pagesize: 10,
            maxpage: 6,
            height: 17,
            minWidth: 17,
            setPosition: "",
            color: "gray",
            bgColor: "white",
            borderColor: "#E7ECF0",
            fontSize: 13,
            bold: !0,
            hover_color: "black",
            hover_bgColor: "#E7ECF0",
            hover_fontsize: 13,
            hover_borderColor: "#E7ECF0",
            show_start: !0,
            show_prev: !0,
            show_next: !0,
            show_end: !0,
            show_sumPages: !0,
            show_sumRows: !0,
            pname_pageid: "pageid",
            pname_pagesize: "pagesize",
            url: window.location.href.split("?")[0],
            request: !1,
            fun: function () { }
        }, d = a.extend(c, b), e = d.request, f = d.url, g = d.pname_pageid, h = d.pname_pagesize, i = d.pageid, j = new RegExp("(^|&)" + g + "=([^&]*)(&|$)"), k = window.location.search.substr(1).match(j);
        null != k && (i = parseInt(unescape(k[2]))), l = d.control, m = d.pagesize, n = d.sumrows,
        o = d.maxpage, p = d.height, q = d.minWidth, r = d.setPosition, s = d.color, t = d.bgColor,
        u = d.borderColor, v = d.fontSize, w = d.bold, x = d.hover_color, y = d.hover_bgColor,
        z = d.hover_fontsize, A = d.hover_borderColor, B = d.show_start, C = d.show_prev,
        D = d.show_next, E = d.show_end, F = d.show_sumPages, G = d.show_sumRows, H = parseInt(n / m),
        I = parseInt(n % m > 0 ? 1 : 0), J = H + I, n > m && K(), a(l + " li").click(function () {
            a(this).hasClass("start-page") ? L(1) : a(this).hasClass("prev-page") ? L(i - 1) : a(this).hasClass("next-page") ? L(i + 1) : a(this).hasClass("end-page") ? L(J) : L(a(this).text());
        }).css({
            border: "1px solid " + u,
            "float": "left",
            height: (p + "px").toString(),
            "list-style": "none outside none",
            "padding-top": p - v + "px",
            "padding-right": p - v + "px",
            "padding-bottom": p - v + "px",
            "padding-left": p - v + "px",
            "font-size": v,
            "font-family": "宋体",
            "min-width": (q + "px").toString(),
            "text-align": "center",
            color: s,
            "margin-left": "3px",
            cursor: "pointer",
            "border-radius": (p + "px " + p + "px " + p + "px " + p + "px").toString()
        }).each(function () {
            a(this).hasClass("page-currentpage") && a(this).css("background-color", y).siblings(l + " li:not(.page-more)").css("background-color", t).mousemove(function () {
                a(this).css({
                    "background-color": y,
                    color: x,
                    "font-size": z,
                    border: ("1px solid " + A).toString(),
                    "font-weight": w ? "bold" : "normal"
                });
            }).mouseout(function () {
                a(this).css({
                    "background-color": t,
                    color: s,
                    "font-size": v,
                    border: ("1px solid " + u).toString(),
                    "font-weight": "normal"
                });
            }), a(this).hasClass("start-page") || a(this).hasClass("end-page") ? a(this).css("width", (2 * v + 20).toString() + "px") : (a(this).hasClass("prev-page") || a(this).hasClass("next-page")) && a(this).css("width", (3 * v + 20).toString() + "px");
        });
    }, a.tl_tip = function (b) {
        var l, m, n, o, p, q, s, t, c = {
            attr_name: "tip",
            width_name: "tip_width",
            min_height: 20,
            min_width: 20,
            color: "black",
            borderColor: "#D2D2D2",
            borderWidth: 1,
            bgColor: "white",
            fontSize: 13,
            fontFamily: "宋体",
            bold: !1,
            radius: 5,
            shadow: 20,
            position: "left",
            url: "js/tooltip_left.gif"
        }, d = a.extend(c, b), e = d.attr_name, f = d.width_name, g = d.min_width, h = d.min_height, i = d.color, j = d.borderColor;
        d.borderWidth, l = d.bgColor, m = d.fontSize, n = d.fontFamily, o = d.bold, p = d.radius,
        q = d.shadow, d.position, s = d.url, a("[" + e + "]").css("position", "relative"),
        a("[" + e + "]").afterbind("mousemove", function () {
            var b, c;
            t = a(this), 0 == t.children(".tip_div").length && (b = "<div class='tip_div' style='box-shadow:0 0 " + q + "px 0  " + j + ";color:" + i + ";border-radius:" + p + "px " + p + "px " + p + "px " + p + "px;border:1px solid " + j + ";padding:5px;background-color:" + l + ";font-size:" + m + "px;font-weight:" + (o ? "bold" : "normal") + ";font-family:" + n + ";min-height:" + h + "px;min-width:" + g + "px;text-align:left;display:none;position:absolute;",
            "undefined" != typeof t.attr(f) && (b += "width:" + t.attr(f) + "px;"), c = "<div style='position: absolute; width: 5px; height: 40px; background-repeat: no-repeat; background-image: url(&quot;" + s + "&quot;); top: 1px; left: -5px;'></div>",
            b += "'>" + t.attr(e) + c + "</div>", t.append(b)), setTimeout(function () {
                var a = t.width();
                t.children(".tip_div").css({
                    left: a + 5,
                    top: 0
                }), t.children(".tip_div").is(":animated") || t.children(".tip_div").fadeIn(300);
            }, 0);
        }).afterbind("mouseout", function () {
            setTimeout(function () {
                t.children(".tip_div").is(":animated") || t.children(".tip_div").fadeOut();
            }, 0);
        });
    }, a.tl_slider = function (b) {
        function j(b) {
            a(e).stop(!0, !1).animate({
                left: -300 * b
            }, 500), a(f + " li").removeClass("on").eq(b).addClass("on");
        }
        var i, c = {
            slider: ".slider-content",
            slider_num: ".slider-num"
        }, d = a.extend(c, b), e = d.slider, f = d.slider_num, g = a(f + " > li").length, h = 0;
        a(f + " > li").mouseover(function () {
            h = a(f + " > li").index(this), j(h);
        }).eq(0).mouseover(), a(e).hover(function () {
            clearInterval(i);
        }, function () {
            i = setInterval(function () {
                j(h), h++, h == g && (h = 0);
            }, 2e3);
        }).trigger("mouseleave");
    }, a.aa = function (b) {
        var c = a.extend(d, b), d = {
            fun: function () { }
        };
        c.fun();
    };
} (jQuery), function (a) {
    a.fn.extend({
        l: function (a) {
            return void 0 == a ? this.css("left") : this.css("left", a + "px");
        },
        t: function (a) {
            return void 0 == a ? this.css("top") : this.css("top", a + "px");
        },
        r: function (a) {
            return void 0 == a ? this.css("right") : this.css("right", a + "px");
        },
        b: function (a) {
            return void 0 == a ? this.css("bottom") : this.css("bottom", a + "px");
        },
        w: function (a) {
            return void 0 == a ? this.width() : this.width(a + "px");
        },
        h: function (a) {
            return void 0 == a ? this.height() : this.height(a + "px");
        },
        op: function (a) {
            return void 0 == a ? this.css("opacity") : this.css("opacity", a);
        },
        bgPosition: function (a, b) {
            return this.css("background-position", a + "px" + " " + b + "px");
        },
        opy: function () {
            return this.css("opacity", 1);
        },
        opn: function () {
            return this.css("opacity", .3);
        },
        hasAttr: function (b) {
            return "undefined" == typeof a(this).attr(b) ? !1 : !0;
        },
        visibility: function (a) {
            return void 0 == a ? this.css("visibility") : this.css("visibility", a);
        },
        a: function (a, b) {
            return void 0 == b ? this.animate(a) : this.animate(a, b);
        },
        show_point: function () {
            this.css("visibility", "inherit");
        },
        hide_point: function () {
            this.css("visibility", "hidden ");
        }
    }), a.extend(a.fn, {
        afterbind: function (b, c, d) {
            var f, e = this;
            return a.isFunction(b) && (d = c, c = b, b = void 0), a.each(a.afterbind.queries, function (a, g) {
                return e.selector != g.selector || e.context != g.context || b != g.type || c && c.$lqguid != g.fn.$lqguid || d && d.$lqguid != g.fn2.$lqguid ? void 0 : (f = g) && !1;
            }), f = f || new a.afterbind(this.selector, this.context, b, c, d), f.stopped = !1,
            f.run(), this;
        },
        expire: function (b, c, d) {
            var e = this;
            return a.isFunction(b) && (d = c, c = b, b = void 0), a.each(a.afterbind.queries, function (f, g) {
                e.selector != g.selector || e.context != g.context || b && b != g.type || c && c.$lqguid != g.fn.$lqguid || d && d.$lqguid != g.fn2.$lqguid || this.stopped || a.afterbind.stop(g.id);
            }), this;
        }
    }), a.afterbind = function (b, c, d, e, f) {
        return this.selector = b, this.context = c || document, this.type = d, this.fn = e,
        this.fn2 = f, this.elements = [], this.stopped = !1, this.id = a.afterbind.queries.push(this) - 1,
        e.$lqguid = e.$lqguid || a.afterbind.guid++, f && (f.$lqguid = f.$lqguid || a.afterbind.guid++),
        this;
    }, a.afterbind.prototype = {
        stop: function () {
            var a = this;
            this.type ? this.elements.unbind(this.type, this.fn) : this.fn2 && this.elements.each(function (b, c) {
                a.fn2.apply(c);
            }), this.elements = [], this.stopped = !0;
        },
        run: function () {
            var b, c, d, e;
            this.stopped || (b = this, c = this.elements, d = a(this.selector, this.context),
            e = d.not(c), this.elements = d, this.type ? (e.bind(this.type, this.fn), c.length > 0 && a.each(c, function (c, e) {
                a.inArray(e, d) < 0 && a.event.remove(e, b.type, b.fn);
            })) : (e.each(function () {
                b.fn.apply(this);
            }), this.fn2 && c.length > 0 && a.each(c, function (c, e) {
                a.inArray(e, d) < 0 && b.fn2.apply(e);
            })));
        }
    }, a.extend(a.afterbind, {
        guid: 0,
        queries: [],
        queue: [],
        running: !1,
        timeout: null,
        checkQueue: function () {
            if (a.afterbind.running && a.afterbind.queue.length) for (var b = a.afterbind.queue.length; b--; ) a.afterbind.queries[a.afterbind.queue.shift()].run();
        },
        pause: function () {
            a.afterbind.running = !1;
        },
        play: function () {
            a.afterbind.running = !0, a.afterbind.run();
        },
        registerPlugin: function () {
            a.each(arguments, function (b, c) {
                if (a.fn[c]) {
                    var d = a.fn[c];
                    a.fn[c] = function () {
                        var b = d.apply(this, arguments);
                        return a.afterbind.run(), b;
                    };
                }
            });
        },
        run: function (b) {
            void 0 != b ? a.inArray(b, a.afterbind.queue) < 0 && a.afterbind.queue.push(b) : a.each(a.afterbind.queries, function (b) {
                a.inArray(b, a.afterbind.queue) < 0 && a.afterbind.queue.push(b);
            }), a.afterbind.timeout && clearTimeout(a.afterbind.timeout), a.afterbind.timeout = setTimeout(a.afterbind.checkQueue, 20);
        },
        stop: function (b) {
            void 0 != b ? a.afterbind.queries[b].stop() : a.each(a.afterbind.queries, function (b) {
                a.afterbind.queries[b].stop();
            });
        }
    }), a.afterbind.registerPlugin("append", "prepend", "after", "before", "wrap", "attr", "removeAttr", "addClass", "removeClass", "toggleClass", "empty", "remove"),
    a(function () {
        a.afterbind.play();
    });
    var b = a.prototype.init;
    a.prototype.init = function (a, c) {
        var d = b.apply(this, arguments);
        return a && a.selector && (d.context = a.context, d.selector = a.selector), "string" == typeof a && (d.context = c || document,
        d.selector = a), d;
    }, a.prototype.init.prototype = a.prototype;
} (jQuery), function (a) {
    a.fn.imglazyload = function (b) {
        var c = a.extend({
            attr: "lazy-src",
            container: window,
            event: "scroll",
            fadeIn: !1,
            threshold: 0,
            vertical: !0
        }, b), d = c.event, e = c.vertical, f = a(c.container), g = c.threshold, h = a.makeArray(a(this)), i = "imglazyload_offset", j = e ? "top" : "left", k = e ? "scrollTop" : "scrollLeft", l = e ? f.height() : f.width(), m = f[k](), n = l + m, o = {
            init: function (a) {
                return a >= m && n + g >= a;
            },
            scroll: function (a) {
                var b = f[k]();
                return a >= b && l + b + g >= a;
            },
            resize: function (a) {
                var b = f[k](), c = e ? f.height() : f.width();
                return a >= b && c + b + g >= a;
            }
        }, p = function (b, d) {
            var k, l, m, n, p, e = 0, g = !1;
            for (d ? "scroll" !== d && "resize" !== d && (g = !0) : d = "init"; e < h.length; e++) k = !1,
            m = h[e], n = a(m), p = n.attr(c.attr), p && m.src !== p && (l = n.data(i), void 0 === l && (l = n.offset()[j],
            n.data(i, l)), k = g || o[d](l), k && (m.src = p, n.is("img") || n.css("background-image", "url(" + p + ")"),
            c.fadeIn && n.hide().fadeIn(), n.removeData(i), h.splice(e--, 1)));
            h.length || (b ? b.unbind(d, q) : f.unbind(c.event, q), a(window).unbind("resize", q),
            h = null);
        }, q = function (b) {
            p(a(this), b.type);
        };
        return f = "scroll" === d ? f : a(this), f.bind(d, q), a(window).bind("resize", q),
        p(), this;
    };
} (jQuery);

jQuery.cookie = function (name, value, options) {
    if (typeof value != "undefined") {
        options = options || {};
        if (value === null) {
            value = "";
            options.expires = -1;
        }
        var expires = "";
        if (options.expires && (typeof options.expires == "number" || options.expires.toUTCString)) {
            var date;
            if (typeof options.expires == "number") {
                date = new Date();
                date.setTime(date.getTime() + options.expires * 24 * 60 * 60 * 1e3);
            } else {
                date = options.expires;
            }
            expires = ";expires=" + date.toUTCString();
        }
        var path = options.path ? ";path=" + options.path : "";
        var domain = options.domain ? ";domain=" + options.domain : "";
        var secure = options.secure ? ";secure" : "";
        document.cookie = [name, "=", encodeURIComponent(value), expires, path, domain, secure].join("");
    } else {
        var cookieValue = null;
        if (document.cookie && document.cookie != "") {
            var cookies = document.cookie.split(";");
            for (var i = 0; i < cookies.length; i++) {
                var cookie = jQuery.trim(cookies[i]);
                if (cookie.substring(0, name.length + 1) == name + "=") {
                    cookieValue = decodeURIComponent(cookie.substring(name.length + 1));
                    break;
                }
            }
        }
        return cookieValue;
    }
};