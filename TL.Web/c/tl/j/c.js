(function ($) {
    //page:<ul id="my_page"></ul>
    //demo: $.mypage({ control:"#my_page" sumrows: 123, pagesize: 10 });
    //control:"#my_page",
    //sumrows: 101,    import to set
    //pageid: 1
    //pagesize: 10
    //maxpage: 6
    //height: 17
    //minWidth: 17
    //color: "gray"
    //bgColor: "white"
    //borderColor: "#E7ECF0"
    //fontSize: 13
    //bold: true
    //hover_color: "black"
    //hover_bgColor: "#E7ECF0"
    //hover_fontsize: 13
    //hover_borderColor: "#E7ECF0"
    //show_start: true
    //show_prev: true
    //show_next: true
    //show_end: true
    //show_sumPages: true
    //show_sumRows: true
    //pname_pageid: "pageid"
    //pname_pagesize: "pagesize"
    //url: window.location.href
    $.UItoTop = function (options) {
        var defaults = {
            text: '回到顶部',
            min: 200,
            inDelay: 600,
            outDelay: 400,
            containerID: '#toTop',
            containerHoverID: '#toTopHover',
            scrollSpeed: 0, /*1200*/
            easingType: 'linear'
        };

        var settings = $.extend(defaults, options);
        var containerIDhash = settings.containerID;
        var containerHoverIdHash = settings.containerHoverID;

        $('body').append('<a href="#" id="' + settings.containerID + '" title="' + settings.text + '">' + settings.text + '</a>');
        $(containerIDhash).hide().click(function () {
            if (settings.scrollSpeed == 0)
                $('html, body').attr("scrollTop", 0);
            else
                $('html, body').animate({ scrollTop: 0 }, settings.scrollSpeed, settings.easingType);

            $('#' + settings.containerHoverID, this).stop().animate({ 'opacity': 0 }, settings.inDelay, settings.easingType);
            return false;
        })
		.prepend('<span id="' + settings.containerHoverID + '"></span>')
		.hover(function () {
		    $(containerHoverIdHash, this).stop().animate({
		        'opacity': 1
		    }, 600, 'linear');
		}, function () {
		    $(containerHoverIdHash, this).stop().animate({
		        'opacity': 0
		    }, 700, 'linear');
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
                $(containerIDhash).fadeIn(settings.inDelay);
            else
                $(containerIDhash).fadeOut(settings.Outdelay);
        });

    };
    $.tl_page_slider = function (options) {
        var defaults = {
            control: "#my_page",
            sumrows: 211,         //import to set
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
            bold: true,
            hover_color: "black",
            hover_bgColor: "#E7ECF0",
            hover_fontsize: 13,
            hover_borderColor: "#E7ECF0",
            show_start: true,
            show_prev: true,
            show_next: true,
            show_end: true,
            show_sumPages: true,
            show_sumRows: true,
            show_pageInput: true,
            pname_pageid: "pageid",
            pname_pagesize: "pagesize",
            url: window.location.href.split('?')[0],
            request: false,
            fun: function (index) { }
        };

        var settings = $.extend(defaults, options);
        var request = settings.request;
        var url = settings.url;
        var pname_pageid = settings.pname_pageid;
        var pname_pagesize = settings.pname_pagesize;
        var pageid = settings.pageid;
        var reg = new RegExp("(^|&)" + pname_pageid + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) pageid = parseInt(unescape(r[2]));
        var control = settings.control;
        var pagesize = settings.pagesize;
        var pageMaxCount = settings.pageMaxCount;
        var sumrows = settings.sumrows;
        var maxpage = settings.maxpage;
        var height = settings.height;
        var minWidth = settings.minWidth;
        var radius = settings.radius;
        var setPosition = settings.setPosition;
        var color = settings.color;         //css
        var bgColor = settings.bgColor;
        var borderColor = settings.borderColor;
        var fontSize = settings.fontSize;
        var bold = settings.bold;
        var hover_color = settings.hover_color;
        var hover_bgColor = settings.hover_bgColor;
        var hover_fontsize = settings.hover_fontsize;
        var hover_borderColor = settings.hover_borderColor;
        var show_start = settings.show_start;
        var show_prev = settings.show_prev;
        var show_next = settings.show_next;
        var show_end = settings.show_end;
        var show_sumPages = settings.show_sumPages;
        var show_sumRows = settings.show_sumRows;
        var show_pageInput = settings.show_pageInput;



        var d1 = parseInt(sumrows / pagesize);
        var d2 = parseInt(sumrows % pagesize > 0 ? 1 : 0);
        var pagecount = d1 + d2;
        if (pagecount < pageMaxCount)
            pageMaxCount = pagecount;
        var li_w = (minWidth + (minWidth - fontSize) * 2 + 5); //other_width
        var li_h = (height + (height - fontSize) * 2 + 3); //other_height
        var isPageInit = false;
        if (sumrows > pagesize) {
            load_page();
            if (pageid > pagecount) pageid = pagecount;
            else if (pageid < 0) pageid = 1;
            page_url(pageid);
        }
        function load_page() {
            var content = '';
            if (show_start) content += "<li class=\"start-page\">首页</li>";
            if (show_prev) content += "<li class=\"prev-page\">上一页</li>";
            content += '<div style="width:' + (li_w * pageMaxCount + 2) + 'px;height:' + li_h + 'px;position:relative;overflow:hidden;margin:0px;padding:0px;float:left;">';
            content += '<ul class="page-slider" style="width:' + (li_w + 2) * pagecount + 'px;height:' + li_h + 'px;position:absolute;left:0px;top:0px;margin:0px;padding:0px;">';
            for (var i = 1; i <= pagecount; i++) {
                content += '<li' + (i == pageid ? ' class="page-currentpage"' : "") + ' pagevalue="' + i + '">' + i + '</li>';
            }
            content += '</ul>';
            content += '</div>';
            if (pagecount > 1 && show_next) content += "<li class=\"next-page\">下一页</li>";
            if (show_end) content += "<li class=\"end-page\">末页</li>";

            var sumdb = "<div style=\"font-size:" + fontSize + "px;padding-top:" + (height - fontSize + 1) + "px;margin-left:3px;float:left;font-family:宋体;color:" + color + "\">共";
            if (show_sumPages) sumdb += "" + pagecount + "页";
            if (show_sumRows) sumdb += (show_sumPages ? "," : "") + sumrows + "条数据";
            if (show_pageInput) sumdb += '&nbsp;<input type="text" style="border:1px solid ' + color + ';display:none;height:' + fontSize + 'px;width:20px;margin:0px" class="page-input" /><a style="color:' + color + ';cursor:pointer;margin:0px 2px 0px 0px;display:none;" title="关闭" class="page-input-close">关闭</a><a style="color:' + color + ';cursor:pointer;border:1px solid ' + borderColor + ';padding:2px;" class="page-change" title="跳转">跳转</a>';
            sumdb += "</div>";
            if (show_sumPages || show_sumRows || show_pageInput)
                content += sumdb;

            content += "<div style=\"clear:both;\"></div>";
            $(control).append(content);
        }
        function page_url(page_id) {
            if (request) {
                page_content(page_id);
            }
            else {
                if (!isPageInit) {
                    page_content(page_id); isPageInit = true;
                } else {
                    url = url + "?" + pname_pageid + "=" + page_id + "&" + pname_pagesize + "=" + pagesize;
                    if (setPosition != "") {
                        url += "#" + setPosition;
                    }
                    window.location.href = url;
                }
            }
        }
        function page_content(page_id) {
            $(".page-currentpage").removeClass("page-currentpage");
            $("" + control + " li[pagevalue=" + (page_id) + "]").addClass("page-currentpage");

            $("" + control + " li[pagevalue=" + (page_id) + "]").css({ "background-color": hover_bgColor, "font-weight": bold ? "bold" : "normal" });
            $("" + control + " li:not(.page-more):not(.page-currentpage)").css({ "background-color": bgColor, "font-weight": "normal" })
                .afterbind("mousemove", function () { $(this).css({ "background-color": hover_bgColor, "color": hover_color, "font-size": hover_fontsize, "border": ("1px solid " + hover_borderColor).toString(), "font-weight": bold ? "bold" : "normal" }); })
                .afterbind("mouseout", function () { $(this).css({ "background-color": bgColor, "color": color, "font-size": fontSize, "border": ("1px solid " + borderColor).toString(), "font-weight": "normal" }); });

            if (page_id <= pagecount - (pageMaxCount - 1)) {
                $(".page-slider").stop(true, false).animate({ left: -li_w * (page_id - 1) }, 200);
            } else if (pagecount > pageMaxCount) {
                $(".page-slider").stop(true, false).animate({ left: -li_w * (pagecount - pageMaxCount) }, 200);
            }
            //                if (page_id == pagecount) { $(".next-page").hide_point(); $(".end-page").hide_point(); }
            //                else { $(".next-page").show_point(); $(".end-page").show_point(); }

            //                if (page_id == 1) { $(".prev-page").hide_point(); $(".start-page").hide_point(); }
            //                else { $(".prev-page").show_point(); $(".start-page").show_point(); }

            if (page_id == pagecount) { $(".next-page").opn(); $(".end-page").opn(); }
            else { $(".next-page").opy(); $(".end-page").opy(); }

            if (page_id == 1) { $(".prev-page").opn(); $(".start-page").opn(); }
            else { $(".prev-page").opy(); $(".start-page").opy(); }

            settings.fun(page_id);
        }
        var edit_true = false;
        $(".page-change").afterbind("click", function () {
            if (!edit_true) {
                $(this).siblings(".page-input").show();
                $(this).siblings(".page-input-close").show();

                edit_true = true;
            } else {
                if ($(".page-input").val() != null && parseInt($(".page-input").val()) > 0) {
                    if (parseInt($(".page-input").val()) > pagecount) { pageid = pagecount; $(".page-input").val(pagecount); }
                    else pageid = $(".page-input").val();
                }
                page_url(pageid);
            }
        });
        $(".page-input-close").afterbind("click", function () { $(this).siblings(".page-input").hide(); $(this).hide(); edit_true = false; });
        $(control + " li")
        .click(function () {
            if ($(this).hasClass("start-page")) { pageid = 1; page_url(pageid); }
            else if ($(this).hasClass("prev-page")) { if (pageid > 1) { pageid = parseInt(pageid - 1); page_url(pageid); } }
            else if ($(this).hasClass("next-page")) { if (pageid < pagecount) { pageid = parseInt(pageid) + 1; page_url(pageid); } }
            else if ($(this).hasClass("end-page")) { pageid = pagecount; page_url(pageid); }
            else if ($(this).hasAttr("pagevalue")) { pageid = $(this).attr("pagevalue"); page_url(pageid); }
        })
        .css({ "border": "1px solid " + borderColor,
            "float": "left", "height": (height + "px").toString(), "list-style": "none outside none",
            "padding-top": ((height - fontSize) + "px"), "padding-right": ((minWidth - fontSize) + "px"),
            "padding-bottom": ((height - fontSize) + "px"), "padding-left": ((minWidth - fontSize) + "px"),
            "font-size": fontSize, "font-family": "宋体",
            "min-width": (minWidth + "px").toString(), "text-align": "center", "color": color,
            "margin-left": "3px", "cursor": "pointer", "border-radius": (radius + "px " + radius + "px " + radius + "px " + radius + "px").toString()
        })
        .each(function () {
            if ($(this).hasClass("page-currentpage")) {
                $(this).css({ "background-color": hover_bgColor, "font-weight": bold ? "bold" : "normal" });
                $("" + control + " li:not(.page-more):not(.page-currentpage)").css({ "background-color": bgColor, "font-weight": "normal" })
                            .afterbind("mousemove", function () { $(this).css({ "background-color": hover_bgColor, "color": hover_color, "font-size": hover_fontsize, "border": ("1px solid " + hover_borderColor).toString(), "font-weight": bold ? "bold" : "normal" }); })
                            .afterbind("mouseout", function () { $(this).css({ "background-color": bgColor, "color": color, "font-size": fontSize, "border": ("1px solid " + borderColor).toString(), "font-weight": "normal" }); });
            }
            if ($(this).hasClass("start-page") || $(this).hasClass("end-page")) {
                $(this).css("width", (fontSize * 2 + 2).toString() + "px");
            } else if ($(this).hasClass("prev-page") || $(this).hasClass("next-page")) {
                $(this).css("width", (fontSize * 3 + 3).toString() + "px");
            }
        });


    };
    $.tl_page_request = function (options) {
        var defaults = {
            control: "#my_page",
            sumrows: 101,         //import to set
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
            bold: true,
            hover_color: "black",
            hover_bgColor: "#E7ECF0",
            hover_fontsize: 13,
            hover_borderColor: "#E7ECF0",
            show_start: true,
            show_prev: true,
            show_next: true,
            show_end: true,
            show_sumPages: true,
            show_sumRows: true,
            pname_pageid: "pageid",
            pname_pagesize: "pagesize",
            url: window.location.href.split('?')[0],
            request: false,
            fun: function (index) { }
        };

        var settings = $.extend(defaults, options);
        var request = settings.request;
        var url = settings.url;
        var pname_pageid = settings.pname_pageid;
        var pname_pagesize = settings.pname_pagesize;
        var pageid = settings.pageid;
        var reg = new RegExp("(^|&)" + pname_pageid + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) pageid = parseInt(unescape(r[2]));
        var control = settings.control;
        var pagesize = settings.pagesize;
        var sumrows = settings.sumrows;
        var maxpage = settings.maxpage;
        var height = settings.height;
        var minWidth = settings.minWidth;
        var setPosition = settings.setPosition;
        var color = settings.color;         //css
        var bgColor = settings.bgColor;
        var borderColor = settings.borderColor;
        var fontSize = settings.fontSize;
        var bold = settings.bold;
        var hover_color = settings.hover_color;
        var hover_bgColor = settings.hover_bgColor;
        var hover_fontsize = settings.hover_fontsize;
        var hover_borderColor = settings.hover_borderColor;
        var show_start = settings.show_start;
        var show_prev = settings.show_prev;
        var show_next = settings.show_next;
        var show_end = settings.show_end;
        var show_sumPages = settings.show_sumPages;
        var show_sumRows = settings.show_sumRows;


        var d1 = parseInt(sumrows / pagesize);
        var d2 = parseInt(sumrows % pagesize > 0 ? 1 : 0);
        var pagecount = d1 + d2;

        if (sumrows > pagesize) load_page();
        function load_page() {
            var hasLoadCurrent = false;

            if (show_start) $(control).append("<li class=\"start-page\">首页</li>");
            if (pageid > 1 && show_prev) { $(control).append("<li class=\"prev-page\">上一页</li>"); }
            for (var i = (pageid <= maxpage ? 0 : pageid - maxpage); i < pagecount; i++) {
                if (i < (pageid <= maxpage ? maxpage : (pageid < pagecount ? pageid : pageid - 1))) {
                    if (i == pageid - 1) { $(control).append("<li class=\"page-currentpage\">" + (i + 1) + "</li>"); hasLoadCurrent = true; }
                    else { $(control).append("<li>" + (i + 1) + "</li>"); }
                }
                else { $(control).append("<span class=\"page-more\" style=\"float:left;margin-left:5px;color:gray;\">...</span>"); i = pagecount; }
            }
            if (!hasLoadCurrent) {
                $(control).append("<li class=\"page-currentpage\">" + pageid + "</li>");
            }
            //if (pageid < pagecount) $(control).append("<li>" + pagecount + "</li>");
            if (pageid < pagecount && show_next) { $(control).append("<li class=\"next-page\">下一页</li>"); }
            if (show_end) $(control).append("<li class=\"end-page\">末页</li>");

            var sumdb = "<div style=\"font-size:" + fontSize + "px;padding-top:" + (height - fontSize) + "px;margin-left:3px;float:left;font-family:宋体;\">共";
            if (show_sumPages) sumdb += "" + pagecount + "页";
            if (show_sumRows) sumdb += (show_sumPages ? "," : "") + sumrows + "条数据";
            sumdb += "</div>";
            sumdb += "<div style=\"clear:both;\"></div>";
            if (show_sumPages || show_sumRows)
                $(control).append(sumdb);
        }
        function page_url(page_id) {
            if (request) {
                settings.fun(page_id);
            }
            else {
                url = url + "?" + pname_pageid + "=" + page_id + "&" + pname_pagesize + "=" + pagesize;
                if (setPosition != "") {
                    url += "#" + setPosition;
                }
                window.location.href = url;
            }
        }

        $(control + " li")
        .click(function () {
            if ($(this).hasClass("start-page")) { page_url(1); }
            else if ($(this).hasClass("prev-page")) { page_url(pageid - 1); }
            else if ($(this).hasClass("next-page")) { page_url(pageid + 1); }
            else if ($(this).hasClass("end-page")) { page_url(pagecount); }
            else { page_url($(this).text()); }
        })
        .css({ "border": "1px solid " + borderColor,
            "float": "left", "height": (height + "px").toString(), "list-style": "none outside none",
            "padding-top": ((height - fontSize) + "px"), "padding-right": ((height - fontSize) + "px"),
            "padding-bottom": ((height - fontSize) + "px"), "padding-left": ((height - fontSize) + "px"),
            "font-size": fontSize, "font-family": "宋体",
            "min-width": (minWidth + "px").toString(), "text-align": "center", "color": color,
            "margin-left": "3px", "cursor": "pointer", "border-radius": (height + "px " + height + "px " + height + "px " + height + "px").toString()
        })
        .each(function () {
            if ($(this).hasClass("page-currentpage")) {
                $(this).css("background-color", hover_bgColor)
                            .siblings(control + " li:not(.page-more)").css("background-color", bgColor)
                            .mousemove(function () { $(this).css({ "background-color": hover_bgColor, "color": hover_color, "font-size": hover_fontsize, "border": ("1px solid " + hover_borderColor).toString(), "font-weight": bold ? "bold" : "normal" }); })
                            .mouseout(function () { $(this).css({ "background-color": bgColor, "color": color, "font-size": fontSize, "border": ("1px solid " + borderColor).toString(), "font-weight": "normal" }); });
            }
            if ($(this).hasClass("start-page") || $(this).hasClass("end-page")) {
                $(this).css("width", (fontSize * 2 + 20).toString() + "px");
            } else if ($(this).hasClass("prev-page") || $(this).hasClass("next-page")) {
                $(this).css("width", (fontSize * 3 + 20).toString() + "px");
            }
        });


    };
    $.tl_tip = function (options) {
        var defaults = {
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
            bold: false,
            radius: 5,
            shadow: 20,
            position: "left",
            url: "js/tooltip_left.gif"
        };
        var settings = $.extend(defaults, options);
        var attr_name = settings.attr_name;
        var width_name = settings.width_name;
        var min_width = settings.min_width;
        var min_height = settings.min_height;
        var color = settings.color;
        var borderColor = settings.borderColor;
        var borderWidth = settings.borderWidth;
        var bgColor = settings.bgColor;
        var fontSize = settings.fontSize;
        var fontFamily = settings.fontFamily;
        var bold = settings.bold;
        var radius = settings.radius;
        var shadow = settings.shadow;
        var position = settings.position;
        var url = settings.url;

        var current_tooltip;
        $("[" + attr_name + "]").css("position", "relative");
        $("[" + attr_name + "]").afterbind("mousemove", function () {
            current_tooltip = $(this);
            if (current_tooltip.children(".tip_div").length == 0) {
                var tip_div = "<div class='tip_div' style='box-shadow:0 0 " + shadow + "px 0  " + borderColor + ";color:" + color + ";border-radius:" + radius + "px " + radius + "px " + radius + "px " + radius + "px;border:1px solid " + borderColor + ";padding:5px;background-color:" + bgColor + ";font-size:" + fontSize + "px;font-weight:" + (bold ? "bold" : "normal") + ";font-family:" + fontFamily + ";min-height:" + min_height + "px;min-width:" + min_width + "px;text-align:left;display:none;position:absolute;";
                if (typeof (current_tooltip.attr(width_name)) != "undefined") {
                    tip_div += "width:" + current_tooltip.attr(width_name) + "px;";
                }
                var tip_left = "<div style='position: absolute; width: 5px; height: 40px; background-repeat: no-repeat; background-image: url(&quot;" + url + "&quot;); top: 1px; left: -5px;'></div>";
                tip_div += "'>" + current_tooltip.attr(attr_name) + tip_left + "</div>";
                current_tooltip.append(tip_div);
            }
            setTimeout(function () {
                var left = current_tooltip.width();
                current_tooltip.children(".tip_div").css({ "left": left + 5, "top": 0 });
                if (!current_tooltip.children(".tip_div").is(":animated")) {
                    current_tooltip.children(".tip_div").fadeIn(300);
                }
                //                if (current_tooltip.children(".tip_div").is(":animated")) {
                //                    current_tooltip.children(".tip_div").stop(false).fadeIn(500);
                //                } else {
                //                    current_tooltip.children(".tip_div").fadeIn(500);
                //                }

            }, 0);
        }).afterbind("mouseout", function () {
            setTimeout(function () {
                if (!current_tooltip.children(".tip_div").is(":animated")) {
                    current_tooltip.children(".tip_div").fadeOut();
                }
            }, 0);

        });
    };
    $.tl_slider = function (options) {
        var defaults = {
            slider: ".slider-content",
            slider_num: ".slider-num"
        };
        var settings = $.extend(defaults, options);
        var slider = settings.slider;
        var slider_num = settings.slider_num;
        var count = $(slider_num + " > li").length;
        var index = 0;
        var slide_Timer;
        $(slider_num + " > li").mouseover(function () {
            index = $(slider_num + " > li").index(this);
            show(index);
        }).eq(0).mouseover();
        $(slider).hover(function () {
            clearInterval(slide_Timer);
        }, function () {
            slide_Timer = setInterval(function () {
                show(index);
                index++;
                if (index == count) { index = 0; }
            }, 2000);
        }).trigger("mouseleave");
        function show(index) {
            $(slider).stop(true, false).animate({ left: -300 * index }, 500);
            $(slider_num + " li").removeClass("on").eq(index).addClass("on");
        }
    };

    //回调函数
    $.aa = function (options) {
        var opts = $.extend(defaults, options);
        var defaults = {
            fun: function () { }
        };
        opts.fun();
    };

})(jQuery);
(function ($) {
    $.fn.extend({
        "l": function (value) { if (value == undefined) return this.css("left"); else return this.css("left", value + 'px'); },
        "t": function (value) { if (value == undefined) return this.css("top"); else return this.css("top", value + 'px'); },
        "w": function (value) { if (value == undefined) return this.width(); else return this.width(value + 'px'); },
        "h": function (value) { if (value == undefined) return this.height(); else return this.height(value + 'px'); },
        "op": function (value) { if (value == undefined) return this.css("opacity"); else return this.css("opacity", value); },
        "bgPosition": function (x,y) {  return this.css("background-position", x + "px" + " " + y + "px"); },
        "opy": function () { return this.css("opacity", 1); },
        "opn": function () { return this.css("opacity", 0.3); },
        "hasAttr": function (value) { if (typeof ($(this).attr(value)) == "undefined") return false; return true; },
        "visibility": function (value) { if (value == undefined) return this.css("visibility"); else return this.css("visibility", value); },
        "a" : function (a,b) { if(b==undefined) return this.animate(a);else return this.animate(a,b); },
        "show_point": function () { this.css("visibility", "inherit"); },
        "hide_point": function () { this.css("visibility", "hidden "); }
    });
    $.extend($.fn, {
        afterbind: function (type, fn, fn2) {
            var self = this, q;
            if ($.isFunction(type))
                fn2 = fn, fn = type, type = undefined;
            $.each($.afterbind.queries, function (i, query) {
                if (self.selector == query.selector && self.context == query.context &&
				type == query.type && (!fn || fn.$lqguid == query.fn.$lqguid) && (!fn2 || fn2.$lqguid == query.fn2.$lqguid))
                    return (q = query) && false;
            });
            q = q || new $.afterbind(this.selector, this.context, type, fn, fn2);
            q.stopped = false;
            q.run();
            return this;
        },

        expire: function (type, fn, fn2) {
            var self = this;
            if ($.isFunction(type))
                fn2 = fn, fn = type, type = undefined;
            $.each($.afterbind.queries, function (i, query) {
                if (self.selector == query.selector && self.context == query.context &&
				(!type || type == query.type) && (!fn || fn.$lqguid == query.fn.$lqguid) && (!fn2 || fn2.$lqguid == query.fn2.$lqguid) && !this.stopped)
                    $.afterbind.stop(query.id);
            });
            return this;
        }
    });

    $.afterbind = function (selector, context, type, fn, fn2) {
        this.selector = selector;
        this.context = context || document;
        this.type = type;
        this.fn = fn;
        this.fn2 = fn2;
        this.elements = [];
        this.stopped = false;
        this.id = $.afterbind.queries.push(this) - 1;
        fn.$lqguid = fn.$lqguid || $.afterbind.guid++;
        if (fn2) fn2.$lqguid = fn2.$lqguid || $.afterbind.guid++;
        return this;
    };

    $.afterbind.prototype = {
        stop: function () {
            var query = this;

            if (this.type)
                this.elements.unbind(this.type, this.fn);
            else if (this.fn2)
                this.elements.each(function (i, el) {
                    query.fn2.apply(el);
                });
            this.elements = [];
            this.stopped = true;
        },

        run: function () {
            if (this.stopped) return;
            var query = this;

            var oEls = this.elements,
			els = $(this.selector, this.context),
			nEls = els.not(oEls);
            this.elements = els;

            if (this.type) {
                nEls.bind(this.type, this.fn);
                if (oEls.length > 0)
                    $.each(oEls, function (i, el) {
                        if ($.inArray(el, els) < 0)
                            $.event.remove(el, query.type, query.fn);
                    });
            }
            else {
                nEls.each(function () {
                    query.fn.apply(this);
                });
                if (this.fn2 && oEls.length > 0)
                    $.each(oEls, function (i, el) {
                        if ($.inArray(el, els) < 0)
                            query.fn2.apply(el);
                    });
            }
        }
    };

    $.extend($.afterbind, {
        guid: 0,
        queries: [],
        queue: [],
        running: false,
        timeout: null,

        checkQueue: function () {
            if ($.afterbind.running && $.afterbind.queue.length) {
                var length = $.afterbind.queue.length;
                while (length--)
                    $.afterbind.queries[$.afterbind.queue.shift()].run();
            }
        },

        pause: function () {
            $.afterbind.running = false;
        },

        play: function () {
            $.afterbind.running = true;
            $.afterbind.run();
        },

        registerPlugin: function () {
            $.each(arguments, function (i, n) {
                if (!$.fn[n]) return;
                var old = $.fn[n];
                $.fn[n] = function () {
                    var r = old.apply(this, arguments);
                    $.afterbind.run();
                    return r;
                }
            });
        },

        run: function (id) {
            if (id != undefined) {
                if ($.inArray(id, $.afterbind.queue) < 0)
                    $.afterbind.queue.push(id);
            }
            else
                $.each($.afterbind.queries, function (id) {
                    if ($.inArray(id, $.afterbind.queue) < 0)
                        $.afterbind.queue.push(id);
                });
            if ($.afterbind.timeout) clearTimeout($.afterbind.timeout);
            $.afterbind.timeout = setTimeout($.afterbind.checkQueue, 20);
        },

        stop: function (id) {
            if (id != undefined)
                $.afterbind.queries[id].stop();
            else
                $.each($.afterbind.queries, function (id) {
                    $.afterbind.queries[id].stop();
                });
        }
    });
    $.afterbind.registerPlugin('append', 'prepend', 'after', 'before', 'wrap', 'attr', 'removeAttr', 'addClass', 'removeClass', 'toggleClass', 'empty', 'remove');

    $(function () { $.afterbind.play(); });
    var init = $.prototype.init;
    $.prototype.init = function (a, c) {
        var r = init.apply(this, arguments);
        if (a && a.selector)
            r.context = a.context, r.selector = a.selector;
        if (typeof a == 'string')
            r.context = c || document, r.selector = a;
        return r;
    };
    $.prototype.init.prototype = $.prototype;

})(jQuery);