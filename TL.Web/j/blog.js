var list_t = 1; //列表展现方式
var f_d = '-1';
var f_t = -1;
var sumrows = 0;
var pagesize_value = 8, pagesize_value_l = 15;
var pageid = 1;
var pagesize = pagesize_value;
$(function () {

    f_d = parastr('f_d');
    f_t = parastr('f_t');
    pageid = parastr('pageid');
    pagesize = parastr('pagesize');
    if (f_d == null || f_d == ' -1') {
        f_d = '-1';
    } else {
        $('.times a[v="' + f_d + '"]').addClass('c');
    }
    if (f_t == null || f_t == -1) {
        f_t = -1;
    } else {
        $('#left > a[v="' + f_t + '"],.p_tag a[v="' + f_t + '"],#tag_list a[v="' + f_t + '"]').addClass('c');
    }
    if (pageid == null) {
        pageid = 1;
    }
    if (pagesize == null) {
        pagesize = pagesize_value;
    }
    bind(true);
    $('#left > a,.p_tag a,#tag_list a').click(function () {
        $('#left > a,.p_tag a,#tag_list a').removeClass('c');
        $(this).addClass('c');
        f_d = '-1';
        f_t = $(this).attr('v');
        pageid = 1;
        bind(true);
    });
    $('.times a').click(function () {
        $('.times a').removeClass('c');
        $(this).addClass('c');
        f_t = -1;
        f_d = $(this).attr('v');
        pageid = 1;
        bind(true);
    });

    if (!role) { $('#topic-add').hide() }

    var editor;
    var editorOption = {
        //                toolbars: [[
        //                'insertimage',
        //                'link',
        //                'emotion'
        //                ]],
        pasteplain: true,
        //focus时自动清空初始化时的内容
        autoClearinitialContent: true,
        //关闭字数统计
        wordCount: false,
        //关闭elementPath
        elementPathEnabled: false,
        //更多其他参数，请参考editor_config.js中的配置项
        minFrameHeight: 360
    }
    editor = new baidu.editor.ui.Editor(editorOption);
    editor.render("topicContent");
    setTimeout(function () {
        if (parastr('tid') != null) {
            $.ajax({
                type: "get",
                url: "/service/service.ashx?action=GetBlogDetail&tid=" + parastr('tid'),
                success: function (data) {
                    data = eval('(' + data + ')');
                    $("#topicid").val(data.rows[0].id);
                    $("#topicName").val(data.rows[0].name);
                    $("#topicTitle").val(data.rows[0].title);
                    var type = data.rows[0].type.split(',');
                    for (var j = 0; j < type.length; j++) {
                        $('.topic_tag li[v=' + type[j] + ']').addClass('c');
                    }
                    editor.setContent(htmlDecode(data.rows[0].content));
                }
            });
        }
    }, 1000);
    $("#topicName").val("");
    $('#topic_form').form({
        onSubmit: function () {
            editor.sync();
            if (!$("#topicName").val()) {
                alert("标题不能为空！");
                $("#topicName").focus();
                return false;
            }
            $("#topicTitle").val($("#topicTitle").val().toString().replace(new RegExp("<br>", "gm"), ""));
            if (!editor.hasContents()) {
                alert("请填写帖子内容！");
                return false;
            }
            var vote_item = "";
            if ($(".topicType:eq(1)").is(":checked")) {

                var rows = $('#tt').datagrid('getRows');
                if (rows.length == 0) {
                    alert("请编辑投票选项!");
                    return false;
                }
                $('#tt').datagrid('acceptChanges');
                for (var i = 0; i < rows.length; i++) {
                    vote_item += rows[i].itemid + "_" + rows[i].value + "|";
                }
                $("#vote_item").val(vote_item);
            }
        },
        success: function (data) {
            if (data == "1") {
                alert("提交成功");
                window.location.href = "Blog.aspx";
            } else {
                alert("提交失败");
            }
        }
    });
    $("#topic_form .btn-submit").click(function () {
        if ($('.topic_tag li.c').length == 0) { alert('至少选择一个标签'); }
        else {
            $('#topicContentValue').val(htmlEncode(editor.getContent()));
            $('#topic_form').submit();
        }
    });
    $(".topicType").change(function () {
        if ($(".topicType:eq(0)").is(":checked")) {
            $(".vote").slideUp(200);
            $('#tt').datagrid('rejectChanges');
            editIndex = 1;
        } else {
            $(".vote").slideDown(200);
        }
    });

    $(".topicType:eq(0)").attr("checked", "checked");

    var lastIndex;
    var editIndex = 1;
    $('#tt').datagrid({
        title: '',
        toolbar: [{
            text: '添加选项',
            iconCls: 'icon-add',
            handler: function () {
                $('#tt').datagrid('endEdit', lastIndex);
                $('#tt').datagrid('appendRow', {
                    itemid: editIndex,
                    value: ''
                });
                editIndex++;
                var lastIndex = $('#tt').datagrid('getRows').length - 1;
                $('#tt').datagrid('beginEdit', lastIndex);
            }
        }, '-', {
            text: '移除选项',
            iconCls: 'icon-remove',
            handler: function () {
                var row = $('#tt').datagrid('getSelected');
                if (row) {
                    var index = $('#tt').datagrid('getRowIndex', row);
                    $('#tt').datagrid('deleteRow', index);
                    editIndex--;
                }
            }
        }, '-', {
            text: '清空选项',
            iconCls: 'icon-undo',
            handler: function () {
                $('#tt').datagrid('rejectChanges');
                editIndex = 1;
            }
        }],
        onBeforeLoad: function () {
            $(this).datagrid('rejectChanges');
        },
        onClickRow: function (rowIndex) {
            if (lastIndex != rowIndex) {
                $('#tt').datagrid('endEdit', lastIndex);
                $('#tt').datagrid('beginEdit', rowIndex);
            }
            lastIndex = rowIndex;
        }
    });
    $('.topic_tag li').toggle(function () {
        $(this).addClass('c');
        $('#topicData_t').val('');
        $('.topic_tag li.c').each(function () {
            $('#topicData_t').val($('#topicData_t').val() + ',' + $(this).attr('v'));
        });
    }, function () {
        $(this).removeClass('c');
    });
})
function delblog(id) {
    if (confirm('确定删除吗?')) {
        $.ajax({
            type: "get",
            url: "/service/action.ashx?action=DeleteList&tb=blog&list=" + id,
            success: function (data) {
                bind(true);
            }
        });
    }
}
function bind(load) {
    $('html, body').animate({ scrollTop: 0 }, 200);
    $('.post_list').html("");
    $('#my_page').hide();
    $.ajax({
        type: "get",
        url: "/service/service.ashx?action=GetBlog&pid=" + pageid + "&psize=" + pagesize + "&f_d=" + f_d + "&f_t=" + f_t,
        success: function (data) {
            data = eval('(' + data + ')');
            sumrows = data.total;
            if (load) {
                $('#my_page').html("");
                $.tl_page_slider({ pageid: pageid, pagesize: pagesize, sumrows: sumrows, fun: function (index) {
                    pageid = index;
                    //$('#ss').html($('#ss').html() + '。');
                    setTimeout(function () { bind(false); }, 200);
                }, request: true, animate: true
                });
            }
            if (data.rows.length > 0) {
                var content = '';
                for (var i = 0; i < data.rows.length; i++) {
                    if (list_t == 1) {
                        content += '<div class="post_item panel">';
                        content += '<div class="post_body">';
                        content += '<h3><a class="t" href="blog.aspx?f_t=' + data.rows[i].tid + '">[' + data.rows[i].tname + ']</a><a href="article' + data.rows[i].id + '.aspx" target="_blank">' + data.rows[i].name + '</a></h3>';
                        content += '<div class="post_tool">' + data.rows[i].recorddate;
                        content += '<span class="post_comment">评论(' + data.rows[i].replys + ')</span>';
                        content += '<span class="post_view">阅读(' + data.rows[i].clicks + ')</span>';
                        content += '</div>';
                        content += '<p class="post_content">';
                        content += '<a href="http://www.cnblogs.com/rentianlong/" target="_blank"><img width="48" height="48" class="post_img" src="http://pic.cnitblog.com/face/u230080.jpg?id=17142256" alt=""></a>';
                        content += data.rows[i].title + '</p>';
                        content += '</div>';
                        content += '</div>';
                        content += '</div>';
                    } else {
                        content += '<div class="post_row">';
                        content += '<h3><a class="t" href="blog.aspx?f_t=' + data.rows[i].tid + '">[' + data.rows[i].tname + ']</a><a href="article' + data.rows[i].id + '.aspx" target="_blank">' + data.rows[i].name + '</a></h3>';
                        content += '<div class="post_tool">' + data.rows[i].recorddate;
                        content += '<span class="post_comment">评论(' + data.rows[i].replys + ')</span>';
                        content += '<span class="post_view">阅读(' + data.rows[i].clicks + ')</span>';
                        if (role) {
                            content += '<a onclick="delblog(' + data.rows[i].id + ')" v="' + data.rows[i].id + '">删除</a>';
                            content += '<a href="blog.aspx?tid=' + data.rows[i].id + '">编辑</a>';
                        }
                        content += '</div>';
                        content += '</div>';
                        content += '</div>';
                    }
                }
                $('.post_list').html(content).hide().slideDown(300);
                setTimeout(function () { $('#my_page').show(); }, 300);
            }
        },
        error: function () {
            alert("数据读取错误！");
        }
    });
}

$(function () {
    index = 2;
    $('.nav_' + index).bgPosition(nav_bg[index].x, nav_bg[index].y).stop().a({ left: 0 }, 150);


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
    $('#toTops .item1 a').l(-80);
    $('#toTops .item1 a').click(function () {
        pageid = 1;
        pagesize = pagesize_value;
        list_t = 1;
        $('#toTops a').l(0);
        $('#toTops .item1 a').l(-80);
        bind(true);
    });
    $('#toTops .item2 a').click(function () {
        pageid = 1;
        pagesize = pagesize_value_l;
        list_t = 2;
        $('#toTops a').l(0);
        $('#toTops .item2 a').l(-80);
        bind(true);
    });
    $('#toTops .item3 a').hover(function () {
        $(this).a({ left: -80 }, 150);
    }, function () {
        $(this).a({ left: 0 }, 150);
    });
})