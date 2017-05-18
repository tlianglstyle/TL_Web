var sumrows = 0;
var pageid = 1;
var pagesize = 8;
$(function () {

    $('#reply_form').form({
        onSubmit: function () {
            if (!$("#replyContent").val()) {
                alert("请填写留言！");
                return false;
            }
        },
        success: function (data) {
            if (data == "0") {
                alert("评论失败!");
            } else if (data == "3") {
                alert("该名字已存在!");
            } else {
                $("#replyContent").val("");
                //alert('评论成功!');
                $('#realName').html(data);
                $('#r_Back').css('display', 'inline-block');
                setUser(true);
                bind(true);
            }
        }
    });
    $("#reply_form .btn_submit").click(function () {
        $('#reply_form').submit();
    });
    $('#r_More').toggle(function () { $('.r_More_info').stop().show(); }, function () { $('.r_More_info').stop().hide(); });
    $('#realClear').click(function () {
        setUser(false);
    });
    $('#r_Back').click(function () {
        setUser(true);

    });
    bind(true);
})
function setUser(flag) {
    if (flag) {
        $('.real').show();
        $('.Unreal').hide();
        $('#rName').val('');
        $('.r_More_info').stop().hide();
    } else {
        $('.real').hide();
        $('.Unreal').fadeIn(500);
    }
}
function bind(load) {
    $('html, body').animate({ scrollTop: 0 }, 200);
    $('.post_list').html("");
    $('#my_page').hide();
    $.ajax({
        type: "get",
        url: "/service/service.ashx?action=GetTalk&pid=" + pageid + "&psize=" + pagesize,
        success: function (data) {
            data = eval('(' + data + ')');
            sumrows = data.total;
            if (load) {
                $('#my_page').html("");
                $.tl_page_slider({ hover_borderColor: '#383838', color: '#919191', borderColor: '#6B6B6B', pageid: pageid, pagesize: pagesize, sumrows: sumrows, fun: function (index) {
                    pageid = index;
                    //$('#ss').html($('#ss').html() + '。');
                    setTimeout(function () { bind(false); }, 200);
                }, request: true, animate: true
                });
            }
            if (data.rows.length > 0) {
                var content = '';
                for (var i = 0; i < data.rows.length; i++) {
                    //总页数
                    var sub_pages = 0;
                    if (sumrows % pagesize == 0) {
                        sub_pages = sumrows / pagesize;
                    } else {
                        sub_pages = sumrows / pagesize + 1;
                    }
                    content += '<li><div class="replylist_black">';
                    content += '<a class="' + (data.rows[i].url.length > 10 ? 'replylist_lLink" href="' + data.rows[i].url + '" target="_blank" title="' + data.rows[i].url + '" ' : 'replylist_l') + '"></a>';
                    content += '<div class="replylist_r">';
                    content += '<div class="replylist_r_h"> ' + ((pagesize - i) + pagesize * (sub_pages - pageid)) + '楼 | ' + data.rows[i].recorddate + '</div>';
                    content += '<div class="replylist_r_t"></div>';
                    content += '<div class="replylist_r_c">';
                    content += '<span><a target="_blank" title="' + data.rows[i].url + '" ' + (data.rows[i].url.length > 10 ? 'href="' + data.rows[i].url + '"' : ' class="uLabel" ') + '>' + data.rows[i].uname + '</a>:</span>' + data.rows[i].content + '';
                    if (data.rows[i].reply_uname != null && data.rows[i].reply_uname.toString().length > 0) {
                        content += '<div class="reply">';
                        content += '<div class="reply_t"></div>';
                        content += '<div class="reply_c">';
                        content += '<span><a target="_blank" href="' + data.rows[i].reply_url + '">' + data.rows[i].reply_uname + '</a>:</span>' + data.rows[i].reply_content + '<br>' + data.rows[i].reply_recorddate + '';
                        content += '</div>';
                        content += '</div>';
                    }
                    content += '</div>';
                    content += '<div class="replylist_r_b"></div>';
                    content += '</div>';
                    content += '<div class="clear"></div>';
                    content += '</li>';
                }
                $('.talk_list').html(content).hide().fadeIn(600);
                $('html, body').animate({ scrollTop: 0 }, 200);
                setTimeout(function () { $('#my_page').show(); }, 300);
            }
        },
        error: function () {
            alert("数据读取错误！");
        }
    });
}
