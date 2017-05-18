var p_url = "";
var pList = { id: 0, count: 0, slider: false }; //选择的相册
var c_sort = "#photo_list";
var show = false;
var p_w = 179; //197;
var p_h = 179; // 197;
var p_w_s = 5; //5行
var p_h_s = 3; //3列
var m = 18; //1;
var c = null; //li单元对象
var p = { w: 0, h: 0, l: 0, t: 0, iw: 0, ih: 0, id: 0 };
var page = { index: 0, sum: 0, count: 15 };
var share = { ids: "", title: "", desc: "", pics: "", summary: "" };
$(function () {
    if (paratemeters != '') {
        var arr_p = paratemeters.split('.');
        pList.id = parseInt(arr_p[0]); //相册id,2
        p.id = parseInt(arr_p[1]); //相片id,1
        pList.count = parseInt(arr_p[2]); //照片数量,36
        pList.slider = false;
        p_h = p_h;
        page.index = 0;
        page.sum = 0;
        if (pList.id != undefined && pList.id != 0 && pList.count != undefined && pList.count != 0) {
            var p_this = $('[v=' + pList.id + ']');
            pList.id = p_this.attr('v');
            share.title = p_this.attr('t') || "TliangL";
            share.desc = p_this.attr('d') || "TliangL";
            share.summary = p_this.attr('s') || "TliangL";

            page.sum = parseInt(pList.count / page.count) + parseInt(pList.count % page.count > 0 ? 1 : 0);
            $('#photo_page').html("");
            for (var i = 1; i <= page.sum; i++) {
                $('#photo_page').append('<a title="' + i + '" v="' + i + '" class="c"><div></div></a>');
            }
            $('#photo_control').a({ left: -1024 }, 0);
            $(c_sort).find('li').remove();
            setTimeout(function () {
                photo_list(0);
                if (nav_status == 1) {
                    $('#nav').stop().a({ top: -40 }, 200);
                    $('#nav_bg').stop().a({ height: 0 }, 200);
                    setTimeout(function () { nav_control(true); setTimeout(function () { pList.slider = true; }, 0); }, 100);
                }
            }, 0);
        }
        setTimeout(function () {
            $('.nav_open').css('top', '-90px');
            if (pList.slider) {
                $('.nav_open').hide().delay(1100).t(-90);
                if (!$(c_sort + " li").is(':animated')) {
                    //alert(pList.slider);
                    c = $(c_sort + " li:eq(" + (p.id - 1) + ")");
                    share.ids = pList.id + "." + c.attr('v') + "." + pList.count;
                    share.pics = 'http://www.tliangl.com/p/p/' + pList.id + '/' + c.attr('v') + '.jpg';

                    c.children('img:eq(1)').attr('src', '/p/p/' + pList.id + '/' + c.attr('v') + '.jpg');
                    if (!light) {
                        //强行关闭nav,防止弹出nav_control
                        $('#nav').stop().a({ top: -40 }, 200);
                        $('#nav_bg').stop().a({ height: 0 }, 200);
                        nav_control(false);
                        nav_light(true);
                        light_open();
                    }
                    c.children('img:eq(0)').hide();
                    p.t = parseFloat(c.t());
                    p.l = parseFloat(c.l());
                    p.w = parseFloat(c.w());
                    p.h = parseFloat(c.h());
                    p.iw = parseFloat(c.children('img:eq(1)').css('max-width'));
                    p.ih = parseFloat(c.children('img:eq(1)').css('max-height'));
                    c.a({ left: -38, top: 0, width: 1034, height: 1024 }, 500);
                    c.css('z-index', 999).children('img:eq(1)').show().css({ "max-width": "1034px", "max-height": "1024px" });
                    $('#photo_tool').delay(500).slideDown(200);
                    c.siblings().fadeOut(500);
                    c.removeClass('x_1').removeClass('x_2').removeClass('x_3').removeClass('x_4'); //放大后禁止触发随机旋转事件
                    c.removeClass('x_m'); //放大后禁止触发hover事件
                    show = true;
                }
            }




        }, 1000);
    }

    index = 4;
    $('.nav_' + index).bgPosition(nav_bg[index].x, nav_bg[index].y).a({ left: 0 }, 150); ;
    $('#photos ul li').hover(function () {
        if ($(this).hasClass('itme_2_2')) {
            $(this).op(1).find('div').stop().a({ top: 370 }, 100);
        } else {
            $(this).op(1).find('div').stop().a({ top: 170 }, 100);
        }
        //$(this).siblings().op(0.7);
    }, function () {
        if ($(this).hasClass('itme_2_2')) {
            $(this).find('div').stop().a({ top: 405 }, 100);
            if ($(this).hasClass('y')) {
                $(this).find('img:eq(0)').t(-405).stop().a({ top: 0 }, 500);
                $(this).find('img:eq(1)').t(0).stop().a({ top: 405 }, 500);
                $(this).removeClass("y").addClass("n");
            } else {
                $(this).find('img:eq(0)').t(0).stop().a({ top: -405 }, 500);
                $(this).find('img:eq(1)').t(405).stop().a({ top: 0 }, 500);
                $(this).removeClass("n").addClass("y");
            }
        }
        else {
            $(this).find('div').stop().a({ top: 202 }, 100);
            if ($(this).hasClass('y')) {
                $(this).find('img:eq(0)').t(-202).stop().a({ top: 0 }, 500);
                $(this).find('img:eq(1)').t(0).stop().a({ top: 202 }, 500);
                $(this).removeClass("y").addClass("n");
            } else {
                $(this).find('img:eq(0)').t(0).stop().a({ top: -202 }, 500);
                $(this).find('img:eq(1)').t(202).stop().a({ top: 0 }, 500);
                $(this).removeClass("n").addClass("y");
            }
        }
    });
    $('#photo_show ul li').hover(function () {
        $(this).find('a').stop().a({ top: 10 }, 100);
    }, function () {
        $(this).find('a').stop().a({ top: 20 }, 100);
    });
    $('#photos ul li,#photo_show ul li').afterbind('click', function () {
        pList.count = $(this).attr('c');
        if (pList.count.toString() != "0") {
            pList.id = $(this).attr('v');
            share.title = $(this).attr('t') || "";
            share.desc = $(this).attr('d') || "";
            share.summary = $(this).attr('s') || "";
            pList.slider = false;
            p_h = $(this).attr('h') != null ? parseFloat($(this).attr('h')) : p_h;
            page.index = 0;
            page.sum = 0;
            if (pList.id != undefined && pList.id != 0 && pList.count != undefined && pList.count != 0) {

                page.sum = parseInt(pList.count / page.count) + parseInt(pList.count % page.count > 0 ? 1 : 0);
                $('#photo_page').html("");
                for (var i = 1; i <= page.sum; i++) {
                    $('#photo_page').append('<a title="' + i + '" v="' + i + '" class="c"><div></div></a>');
                }
                $('#photo_control').a({ left: -1024 }, 500);
                $(c_sort).find('li').remove();
                setTimeout(function () {
                    photo_list(500);
                    if (nav_status == 1) {
                        $('#nav').stop().a({ top: -40 }, 200);
                        $('#nav_bg').stop().a({ height: 0 }, 200);
                        setTimeout(function () { nav_control(true); setTimeout(function () { pList.slider = true; }, 1100); }, 1000);
                    }
                }, 500);
            }
        }
    });
    $('#photo_back').click(function () {
        if (!$('.nav_open').is(':animated') && !$('.nav_light').is(':animated')) {
            nav_status = 0; nav_open();
            nav_light(false);
            light_close();
            $('#photo_control').a({ left: 0 }, 500);
            $('#photo_tool').fadeOut(500);
        }
    });

    $(c_sort + " li").afterbind('click', function () {
        if (pList.slider) {
            $('.nav_open').hide().delay(1100).t(-90);
            if (!$(c_sort + " li").is(':animated')) {
                if (!show) {
                    share.ids = pList.id + "." + $(this).attr('v') + "." + pList.count;
                    share.pics = 'http://www.tliangl.com/p/p/' + pList.id + '/' + $(this).attr('v') + '.jpg';
                    $(this).children('img:eq(1)').attr('src', '/p/p/' + pList.id + '/' + $(this).attr('v') + '.jpg');
                    if (!light) {
                        //强行关闭nav,防止弹出nav_control
                        $('#nav').stop().a({ top: -40 }, 200);
                        $('#nav_bg').stop().a({ height: 0 }, 200);
                        nav_control(false);
                        nav_light(true);
                        light_open();
                    }
                    c = $(this);
                    c.children('img:eq(0)').hide();
                    p.t = parseFloat(c.t());
                    p.l = parseFloat(c.l());
                    p.w = parseFloat(c.w());
                    p.h = parseFloat(c.h());
                    p.iw = parseFloat(c.children('img:eq(1)').css('max-width'));
                    p.ih = parseFloat(c.children('img:eq(1)').css('max-height'));
                    c.a({ left: -38, top: 0, width: 1034, height: 1024 }, 500);
                    c.css('z-index', 999).children('img:eq(1)').show().css({ "max-width": "1034px", "max-height": "1024px" });
                    $('#photo_tool').delay(500).slideDown(200);
                    c.siblings().fadeOut(500);
                    c.removeClass('x_1').removeClass('x_2').removeClass('x_3').removeClass('x_4'); //放大后禁止触发随机旋转事件
                    c.removeClass('x_m'); //放大后禁止触发hover事件
                    show = true;
                }
                else {
                    $(c_sort + " li").show();
                    c.a({ left: p.l, top: p.t, width: p.w, height: p.h }, 500);
                    $('#photo_tool').slideUp(200);
                    c.delay(500).siblings().fadeIn(500);
                    setTimeout(function () {
                        c.css('z-index', 1);
                        c.children('img:eq(1)').css({ "max-width": p.iw, "max-height": p.ih }).hide().attr('src', '').prev().show(); ;
                    }, 510);
                    $(this).addClass('x_m'); //禁止放大后触发hover事件
                    $(this).addClass('x_' + GetRandomNum(1, 4));  //重新触发随机旋转事件
                    show = false;
                }
            }
        }
    });
    $("#photo_page a").afterbind('click', function () {
        $(this).addClass('c').siblings().removeClass('c');
        page.index = parseInt($(this).attr('v'));
        photo_list(500);
    });
    $('#photo_tool .close').click(function () {
        c.siblings().hide().fadeIn(500);
        setTimeout(function () {
            c.css('z-index', 2).children('img:eq(1)').css({ "max-width": p.iw, "max-height": p.ih }).delay(500).css('z-index', 2).hide().attr('src', '').prev().show();
            c.a({ left: p.l, top: p.t, width: p.w, height: p.h }, 500);
            $('#photo_tool').fadeOut(500);
            c.addClass('x_m'); //禁止放大后触发hover事件
            c.addClass('x_' + GetRandomNum(1, 4));  //重新触发随机旋转事件
            show = false;
        }, 0);
    }).next().click(function () {
        if (pList.slider && !$(c_sort + " li").is(":animated") && show) {
            if ($(c_sort).children().index(c) + 1 < $('#photo_list li').length) {
                c.a({ left: -1024 }, 150);
                //预加载大图
                c.next().children('img:eq(1)').attr('src', '/p/p/' + pList.id + '/' + c.next().attr('v') + '.jpg').show().prev().hide();
                show = false; //防止重复点击
                setTimeout(function () {
                    c.css('z-index', 1).children('img:eq(1)').css({ "max-width": "190px", "max-height": "190px" }).hide().attr('src', '').prev().show();
                    c.hide().css({ left: p.l, top: p.t, width: p.w, height: p.h }).addClass('x_' + GetRandomNum(1, 4));  //重新触发随机旋转事件;
                    setTimeout(function () {
                        c = c.next();
                        share.ids = pList.id + "." + c.attr('v') + "." + pList.count;
                        share.pics = 'http://www.tliangl.com/p/p/' + pList.id + '/' + c.attr('v') + '.jpg';
                        p.t = parseFloat(c.t());
                        p.l = parseFloat(c.l());
                        p.w = parseFloat(c.w());
                        p.h = parseFloat(c.h());
                        p.iw = parseFloat(c.children('img').css('max-width'));
                        p.ih = parseFloat(c.children('img').css('max-height'));
                        c.css({ left: 1024, top: 0, width: 1034, height: 1024 });
                        c.show().a({ left: -38, top: 0 }, 300);
                        c.removeClass('x_1').removeClass('x_2').removeClass('x_3').removeClass('x_4'); //放大后禁止触发随机旋转事件
                        c.css('z-index', 999).children('img:eq(1)').css({ "max-width": "1034px", "max-height": "1024px" });
                        $('#photo_tool').delay(200).slideDown(200);
                        c.siblings().fadeOut(400);
                        show = true;
                    }, 100);
                }, 200);
            }
            else {
                if (page.index < page.sum) {
                    page.index++;
                    photo_list(500);
                }
            }
        }
    }).next().click(function () {
        if (pList.slider && !$(c_sort + " li").is(":animated") && show) {
            if ($(c_sort).children().index(c) > 0) {
                c.a({ left: 1024 }, 150);
                //预加载大图
                c.prev().children('img:eq(1)').attr('src', '/p/p/' + pList.id + '/' + c.next().attr('v') + '.jpg').show().prev().hide();
                show = false;

                setTimeout(function () {
                    c.css('z-index', 1).children('img:eq(1)').css({ "max-width": "190px", "max-height": "190px" }).hide().attr('src', '').prev().show();
                    c.hide().css({ left: p.l, top: p.t, width: p.w, height: p.h });
                    setTimeout(function () {
                        c = c.prev();
                        share.ids = pList.id + "." + c.attr('v') + "." + pList.count;
                        share.pics = 'http://www.tliangl.com/p/p/' + pList.id + '/' + c.attr('v') + '.jpg';
                        p.t = parseFloat(c.t());
                        p.l = parseFloat(c.l());
                        p.w = parseFloat(c.w());
                        p.h = parseFloat(c.h());
                        p.iw = parseFloat(c.children('img:eq(1)').css('max-width'));
                        p.ih = parseFloat(c.children('img:eq(1)').css('max-height'));
                        c.css({ left: -1024, top: 0 });
                        c.show().a({ left: -38, top: 0, width: 1034, height: 1024 }, 300);
                        c.removeClass('x_1').removeClass('x_2').removeClass('x_3').removeClass('x_4'); //放大后禁止触发随机旋转事件
                        c.css('z-index', 999).children('img:eq(1)').css({ "max-width": "1034px", "max-height": "1024px" });
                        $('#photo_tool').delay(200).slideDown(200);
                        c.siblings().fadeOut(400);
                        show = true;
                    }, 100);
                }, 200);
            }
            else {
                if (page.index > 1) {
                    page.index--;
                    photo_list(500);
                }
            }
        }
    });
    $('.share').click(function () {
        if (share.ids.length > 5) {
            var url = '';
            var i = $('.share').index($(this));
            switch (i) {
                case 0:
                    url = 'http://www.douban.com/share/service?href=http://www.tliangl.com/' + share.ids + '.aspx' + '&name=' + share.title + '&text=' + share.desc + '&image=' + share.pics;
                    break;
                case 1:

                    url = 'http://share.v.t.qq.com/index.php?c=share&a=index&url=http://www.tliangl.com/' + share.ids + '.aspx' + '&title=' + share.desc + '&pic=' + share.pics;
                    break;
                case 2:
                    url = 'http://service.weibo.com/share/share.php?url=http://www.tliangl.com/' + share.ids + '.aspx' + '&title=' + share.desc + '&pic=' + share.pics;
                    break;
                case 3:
                    url = 'http://sns.qzone.qq.com/cgi-bin/qzshare/cgi_qzshare_onekey?url=http://www.tliangl.com/' + share.ids + '.aspx' + '&title=' + share.title + '&desc=' + share.desc + '&summary=' + share.summary + '&site=&pics=' + share.pics;
                    break;
            }
            window.open(url);
        } else {//图片为放大时
            if (!show) {
                var url = '';
                var i = $('.share').index($(this));
                var ids = "photos";
                var title = "谭亮小盆友的相册";
                var desc = "谭亮小盆友的相册";
                var summary = "谭亮小盆友的相册";
                var pics = "";
                switch (i) {
                    case 0:
                        url = 'http://www.douban.com/share/service?href=http://www.tliangl.com/' + ids + '.aspx' + '&name=' + title + '&text=' + desc + '&image=' + pics;
                        break;
                    case 1:

                        url = 'http://share.v.t.qq.com/index.php?c=share&a=index&url=http://www.tliangl.com/' + ids + '.aspx' + '&title=' + desc + '&pic=' + pics;
                        break;
                    case 2:
                        url = 'http://service.weibo.com/share/share.php?url=http://www.tliangl.com/' + ids + '.aspx' + '&title=' + desc + '&pic=' + pics;
                        break;
                    case 3:
                        url = 'http://sns.qzone.qq.com/cgi-bin/qzshare/cgi_qzshare_onekey?url=http://www.tliangl.com/' + ids + '.aspx' + '&title=' + title + '&desc=' + desc + '&summary=' + summary + '&site=&pics=' + pics;
                        break;
                }
                window.open(url);
            }
        }
    });
    var OriginImage = new Image();
    function GetImageWidth(oImage) {
        if (OriginImage.src != oImage.src) OriginImage.src = oImage.src;
        return OriginImage.width;
    }
    function GetImageHeight(oImage) {
        if (OriginImage.src != oImage.src) OriginImage.src = oImage.src;
        return OriginImage.height;
    }
    function photo_list(atime) {
        $('#photo_page a:eq(' + (page.index < 2 ? 0 : page.index - 1) + ')').addClass('c').siblings().removeClass('c');
        $('#photo_tool').hide(); //.fadeOut(500); 
        show = false;
        if (page.index == 0) {
            var html_li = "";
            var pLength = 0;
            if (page.sum == 1) {
                pLength = pList.count;
            } else {
                pLength = page.count;
            }
            for (var i = 1; i <= pLength; i = i + 1) {//保证随机数的随机性i
                html_li += "<li class='x_m x_" + (GetRandomNum(1, 3) + i % 2) + "' v='" + i + "'><img url=\"http://tliangl.com/" + pList.id + "." + i + "." + pList.count + ".aspx\" src=\"/p/p/" + pList.id + "/" + (i) + "_min.jpg\" /><img class=\"max none\" src=\"\" /></li>";
            }
            $(c_sort).html(html_li);
            $(c_sort + " li").w(p_w).h(p_h);
            $(c_sort + " li:animated").stop(true, false);
            var arr = new Array();
            var i = 0;
            $(c_sort + " li").hide().each(function () {
                arr[i] = $(this).attr("v"); i++;
            });
            for (var a = 0; a < arr.length; a++) {
                var o = $(c_sort + " li[v=" + arr[a] + "]");
                var t = 0, l = 0;
                t = m + (p_h + m) * (parseInt((a) / p_w_s));
                l = m + (p_w + m) * (parseInt((a + 1) % p_w_s) == 0 ? (p_w_s - 1) : parseInt(a % p_w_s));
                o.show();
                //   var ii =
                o.a({ top: t, left: l}, atime);

            }
        }
        else {
            var html_li = "";
            var pLength = 0;
            if (page.sum == 1) {
                pLength = pList.count;
            } else {
                if (page.index < page.sum) {
                    pLength = page.count;
                } else {
                    pLength = pList.count - (page.sum - 1) * page.count;
                }
            }
            for (var i = 1 + (page.index - 1) * page.count; i <= (page.index - 1) * page.count + pLength; i = i + 1) {//保证随机数的随机性i
                html_li += "<li class='x_m x_" + (GetRandomNum(1, 3) + i % 2) + "' v='" + i + "'><img url=\"http://tliangl.com/" + pList.id + "." + i + "." + pList.count + ".aspx\" src=\"/p/p/" + pList.id + "/" + (i) + "_min.jpg\" /><img class=\"max none\" src=\"\" /></li>";
            }
            $(c_sort).html(html_li);
            $(c_sort + " li").w(p_w).h(p_h).l(0).t(55 * (page.index - 1));
            $(c_sort + " li:animated").stop(true, false);
            var arr = new Array();
            var i = 0;
            $(c_sort + " li").hide().each(function () {
                arr[i] = $(this).attr("v"); i++;
            });
            for (var a = 0; a < arr.length; a++) {
                var o = $(c_sort + " li[v=" + arr[a] + "]");
                var t = 0, l = 0;
                t = m + (p_h + m) * (parseInt((a) / p_w_s));
                l = m + (p_w + m) * (parseInt((a + 1) % p_w_s) == 0 ? (p_w_s - 1) : parseInt(a % p_w_s));
                o.show();
                //                        var old_t = 55 * (page.index - 1);
                //                        var temp_t = 0;
                //                        if (t > old_t) {
                //                            temp_t = old_t + (t - old_t) / 5;
                //                        } else {
                //                            temp_t = old_t - (old_t - t) / 5;
                //                        }
                //                        o.a({ top: temp_t, left: l }, 400).delay(300).a({ top: t, left: l }, 100);
                o.delay(130).a({ top: t, left:  l}, atime);
            }
        }
        //图片竖直居中
        //                $(c_sort + " li").each(function () {
        //                    var c_li = $(this);
        //                    var new_image = new Image();
        //                    new_image.src = c_li.children('img:eq(0)').attr('src');
        //                    new_image.onload = function () {
        //                        $('#ss').html(new_image.width);
        //                        c_li.attr('h', parseFloat(c_li.t()) + (1 - new_image.height / new_image.width) * p_h / 2);
        //                        if (new_image.height < new_image.width) {
        //                            c_li.t(parseFloat(c_li.t()) + (1 - new_image.height / new_image.width) * p_h / 2);
        //                        }
        //                    }
        //                });
    }
})