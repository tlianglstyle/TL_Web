var f_c = -1, f_t = -1, o = -1, s = "";
var sumrows = 0;
var requestid = 1; //请求编号
var columns = [0, 0, 0, 315, 230, 180];
var requestcolumns = 4; //请求列数
var requestsize = 0; //一次请求的数量
var requestcount = 10; //请求次数
var pageid = 1;
var pagesize = 0;
$(function () {



    if (role) {
        $('#btn_add').show();
    } else {
        $('#btn_add').remove();
    }
    f_c = parastr('f_c');
    f_t = parastr('f_t');
    o = parastr('o');
    requestcolumns = parastr('t');
    pageid = parastr('pageid');
    pagesize = parastr('pagesize');
    if (f_c == null || f_c == -1) {
        f_c = -1;
        $('#filter-color ul li:eq(0)').addClass('c');
    }
    if (f_t == null || f_t == -1) {
        f_t = -1;
        $('#filter-category ul li:eq(0)').addClass('c');
    }
    if (o == null || o == -1) {
        o = -1;
        $('.item-order a[v=' + 1 + ']').addClass('c');
    } else {
        $('.item-order a[v=' + o + ']').addClass('c');
    }
    if (requestcolumns == null || requestcolumns == -1) {
        requestcolumns = 4;
    } else {
    }
    requestsize = requestcolumns * 1;
    pagesize = requestsize * requestcount;
    if (pageid == null) {
        pageid = 1;
    }
    if (pagesize == null) {
        pagesize = 100;
    }

    $('#list > div:gt(' + (requestcolumns - 1) + ')').remove();
    $('#list').addClass('columns' + requestcolumns);


    bind(true);
    $('#filter-color ul li').click(function () {
        f_c = $(this).attr('v');
        url();
    });
    $('#filter-category ul li').click(function () {
        f_t = $(this).attr('v');
        url();
    });
    $('.item-order a').click(function () {
        o = $(this).attr('v');
        url();
    });
    $('#list > div .block_i').afterbind('mouseenter', function (e) {
        if (!$(this).children('.block_op').is(":animated")) {
            var m = getMousePos(e);
            var i = $(this).parent();
            var w = columns[requestcolumns];
            var lt = $(this).offset();
            var lb = i.find('.url').offset();
            var h = lb.top - lt.top;
            var temp = 50;
            if (m.x < lt.left + temp && m.y > lt.top + temp && m.y < lt.top + h - temp) {
                $(this).children('.block_op').stop().show().op(1).t(0).l(-w).a({ left: 0 }, 200);
            } else if (m.x > lt.left + w - 20 && m.y > lt.top + temp && m.y < lt.top + h - temp) {
                $(this).children('.block_op').stop().show().op(1).op(1).t(0).l(w).a({ left: 0 }, 200);
            } else if (m.y < lt.top + temp) {
                $(this).children('.block_op').stop().show().op(1).l(0).t(-h).a({ top: 0 }, 200);
            } else if (m.y > lt.top + h - temp) {
                $(this).children('.block_op').stop().show().op(1).l(0).t(h).a({ top: 0 }, 200);
            }
        }
    });
    $('#list > div .block_i').afterbind('mouseleave', function (e) {
        var m = getMousePos(e);
        var i = $(this).parent();
        var w = columns[requestcolumns];
        var lt = $(this).offset();
        var lb = i.find('.url').offset();
        var h = lb.top - lt.top;
        var temp = 0;
        if (m.x > lt.left + w) {
            $(this).children('.block_op').stop().show().a({ left: w + 10 }, 200);
        } else if (m.x < lt.left) {
            $(this).children('.block_op').stop().show().a({ left: -w - 10 }, 200);
        } else if (m.y > lb.top - 20) {
            $(this).children().show().a({ top: h }, 200);
        } else if (m.y < lt.top) {
            $(this).children('.block_op').stop().show().a({ top: -h }, 200);
        } else {

        }
    });
    var del_control = null;
    $('#list > div p .del').afterbind('click', function () {
        if (confirm('确定删除吗?')) {
            del_control = $(this).parent().parent();
            $.ajax({
                type: "get",
                url: "/service/action.ashx?action=DeleteResource&list=" + del_control.attr('v'),
                success: function (data) {
                    //alert('删除成功!');
                    del_control.fadeOut(500).delay(500).remove();
                }
            });
        }
    });
    $('#list > div .block_i .share').afterbind('click', function () {
        alert('ok');
    });

    //$('#list > div .block_i .block_op a').afterbind('mouseout', function () { return false; });
})

var browser = getBrowser();
var reset = 0;
var surplusHeight = 800;
var pageTran = false;
var load = false;
window.onscroll = function () {
    if (reset == 0) {
        var topAll = (browser == "Firefox") ? document.documentElement.scrollHeight : document.body.scrollHeight;
        var top_top = document.body.scrollTop || document.documentElement.scrollTop;
        var result = topAll - top_top;
        //$('#ss').html(document.documentElement.scrollTop + '-' + document.documentElement.scrollHeight);
        if (result < surplusHeight + 200 && sumrows != 0) {
            if (requestid < requestcount) {
                if (!pageTran) {//防止添加重复的page标签
                    pageTran = true;
                    $('.loading').show();
                    reset = 1;
                    setTimeout(function () {
                        requestid++;
                        bind(false);
                    }, 1000);
                    //window.scrollTo(0, document.body.scrollHeight);
                    setTimeout(function () {
                        pageTran = false;
                        if (load) load = false;
                    }, 1000); //防止bind请求重合
                }

            } else {
                $('#my_page').show();
            }
        }
    } else {
        setTimeout(function () { reset = 0; }, 1000);
    }
};
function bind(load) {

    $.ajax({
        type: "get",
        url: "/service/service.ashx?action=GetResource&rid=" + requestid + "&rsize=" + requestsize + "&pid=" + pageid + "&psize=" + pagesize + "&f_c=" + f_c + "&f_t=" + f_t + "&o=" + o,
        success: function (data) {
            data = eval('(' + data + ')');
            sumrows = data.total;
            if (sumrows == 0) {

            }
            if (load) {
                $.tl_page_slider({ pageid: pageid, pagesize: pagesize, sumrows: sumrows, fun: function (index) {
                    pageid = index;
                    url();
                }, request: true
                });
                $('#my_page').hide();
            }
            if (data.rows.length > 0) {
                for (var i = 0; i < data.rows.length; i++) {
                    var content = '<div v=' + data.rows[i].id + ' class="load">';
                    content += '<div class="block_i">';
                    content += '<a target="_blank" href="resource_details.aspx?id=' + data.rows[i].id + '">';
                    content += '<img src="r/img/' + data.rows[i].id + '.jpg" width="240" height="136"></a>';
                    content += '<div class="bg"></div>';
                    content += '<div class="block_op"><a class="title" target="_blank" href="resource_details.aspx?id=' + data.rows[i].id + '">' + data.rows[i].name + '</a>' + (role ? '<a class="edit" target="_blank" href="resource_edit.aspx?id=' + data.rows[i].id + '" title="编辑"></a>' : '') + '<a class="share" title="喜欢"></a></div>';
                    content += '</div>';
                    content += '<p>';
                    //content += '<span class="replys" title="' + data.rows[i].replys + '人评论">' + data.rows[i].replys + '</span>';
                    content += '<span class="hits" title="' + data.rows[i].clicks + '次浏览">' + data.rows[i].clicks + '</span>';
                    content += '<span class="heats" title="' + data.rows[i].commends + '人推荐">' + data.rows[i].commends + '</span>';
                    content += '<a class="url" target="_blank" href="' + data.rows[i].url + '" class="link_url" target="_blank" title="在新的页面直接打开该网站">&nbsp;</a>';
                    if (role) {
                        content += '<a target="_blank" href="resource_edit.aspx?id=' + data.rows[i].id + '">编辑</a>&nbsp;<a class="del">删除</a>';
                    }
                    content += '</p>';
                    content += '</div>';
                    content += '';
                    content += '';
                    content += '';

                    var bindIndex = 0;

                    if (load) {
                        //按顺序加载
                        bindIndex = (i + 1) % requestcolumns == 0 ? requestcolumns - 1 : (i + 1) % requestcolumns - 1;
                    } else {
                        //按图片高度加载
                        var colTop = 100000;
                        $('#list > div').each(function () {
                            if ($(this).children('div:last').offset().top < colTop) {
                                colTop = $(this).children('div:last').offset().top;
                                bindIndex = $('#list > div').index($(this));
                            }
                        });
                    }
                    $('#list > div:eq(' + bindIndex + ')').append(content);
                    $('#list > div > div.load').fadeIn(1000).delay(1000).removeClass('load');

                    $('.loading').hide();
                }
            }
            else {
                $('.loading').hide();
            }
        },
        error: function () {
            alert("数据读取错误！");
        }
    });

}
function url() {
    window.location.href = "resources.aspx?pageid=" + pageid + "&pagesize=" + requestcolumns * requestcount + "&f_c=" + f_c + "&f_t=" + f_t + "&o=" + o + "&t=" + requestcolumns;
}
$(function () {
    index = 3;
    $('.nav_' + index).bgPosition(nav_bg[index].x, nav_bg[index].y).stop().a({ left: 0 }, 150);



    $("#color-more").toggle(function () {
        $(this).css("background-position", "-5px -165px");
        $("#filter-color ul").css("height", "auto");
    }, function () {
        $(this).css("background-position", "-5px -146px");
        $("#filter-color ul").a({ height: 47 }, 200);
    });
    $("#category-more").toggle(function () {
        $(this).css("background-position", "-5px -165px");
        $("#filter-category ul").css({ "max-height": "200px", "height": "100%" });
    }, function () {
        $(this).css("background-position", "-5px -146px");
        $("#filter-category ul").a({ height: 70 }, 200);
    });
    $(".checkbox-category").toggle(function () {
        $(this).css("background-position", "0 -209px");
    }, function () {
        $(this).css("background-position", "0 -192px");
    });
    $(".checkbox-filter").toggle(function () {
        $(this).css("background-position", "0 -209px");
    }, function () {
        $(this).css("background-position", "0 -192px");
    });
    $(".checkbox-category-all").toggle(function () {
        $(".checkbox-category").css("background-position", "0 -209px");
    }, function () {
        $(".checkbox-category").css("background-position", "0 -192px");
    });
    $(".checkbox-filter-all").toggle(function () {
        $(".checkbox-filter").css("background-position", "0 -209px");
    }, function () {
        $(".checkbox-filter").css("background-position", "0 -192px");
    });
    $("#filter_1_ul").show();
    $("#filter-filter #filter-filter-ul").children("li").click(function () {
        $('#' + $(this).attr("id") + '_ul').show().siblings().hide();
        $(this).removeClass("filter-filter-default").addClass("filter-filter-check").siblings("li").removeClass("filter-filter-check").addClass("filter-filter-default");
    });


    var settings = {
        min: 200,
        inDelay: 600,
        outDelay: 400,
        container: '#toTops',
        containerTop: '#toTops .item3 a',
        scrollSpeed: 200, /*1200*/
        easingType: 'linear'
    };


    var container = settings.container;
    var containerTop = settings.containerTop;
    $(container).show();
    $(containerTop).hide().click(function () {
        $('html, body').animate({ scrollTop: 0 }, 200);
    });

    $(window).scroll(function () {
        var sd = $(window).scrollTop();
        if (typeof document.body.style.maxHeight === "undefined") {
            $(container).css({
                'position': 'absolute',
                'top': $(window).scrollTop() + $(window).height() - 50
            });
        }
        if (sd > settings.min)
            $(containerTop).fadeIn(settings.inDelay);
        else
            $(containerTop).fadeOut(settings.Outdelay);
    });
    $('#toTops .item1 a').click(function () {
        requestcolumns = 3;
        url();
    });
    $('#toTops .item2 a').click(function () {
        requestcolumns = 4;
        url();
    });
    $('#toTops .item3 a').hover(function () {
        $(this).a({ left: -50 }, 150);
    }, function () {
        $(this).a({ left: 0 }, 150);
    });
})