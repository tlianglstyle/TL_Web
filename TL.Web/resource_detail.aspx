<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="resource_detail.aspx.cs" Inherits="TL.Web.resource_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/j/jquery-easyui-1.3.2/jquery.easyui.min.js" type="text/javascript"></script>
    <script charset="gbk" src="/j/editor/editor_all.js" type="text/javascript"></script>
    <script charset="gbk" src="/j/editor/editor_config.js" type="text/javascript"></script>
    <link href="/j/editor/themes/default/ueditor.css" rel="stylesheet" type="text/css" />
    <link href="c/resource_detail.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="header">
    </div>
    <div id="content">
        <div class="wrap pt20">
            <div id="info_title">
                <div class="info">
                    <div class="title">
                        <%=row["Name"]%></div>
                    <span class="bq">日期：<%= Convert.ToDateTime(row["RecordDate"]).ToShortDateString() %></span>
                    <span class="bq">阅读：<%=row["clicks"]%></span><br />
                    <div class="bq">
                        地址：<a href="<%=row["url"]%>" target="_blank" class="underline gray"><%=row["url"]%></a></div>
                    <div class="bq color">
                        <span>颜色：</span>
                        <%--<b style="background-color: #835729"></b>
                    <b style="background-color: #835729"></b>--%>
                        <asp:Repeater runat="server" ID="rpt_color">
                            <ItemTemplate>
                                <b title="<%# Eval("Name") %>" style="background-color: <%# Eval("color") %>"></b>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <br />
                    <div class="bq">
                        <span>分类：</span>
                        <asp:Repeater runat="server" ID="rpt_type">
                            <ItemTemplate>
                                <a href="resource.aspx?f_t=<%# Eval("ID") %>" class="tag">
                                    <%# Eval("Name")%></a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="uInfo">
                    <div class="img">
                        <img src="/p/u/2.jpg" alt="" /></div>
                    <br />
                    <span class="bq f14 bold">
                        <%=row["uname"] %></span><br />
                    <span class="bq gray">朝阳&nbsp;前端工程师</span><br />
                    <span class="bq gray">
                        <%=TL.Common.Utils.DateStringFromNow(row["RecordDate"])%>发布</span>
                </div>
            </div>
            <div id="info_center">
             <p class="remark"><%=row["Remark"] %></p>
                <div class="info_content">
                    <asp:Repeater ID="rpt_img" runat="server">
                        <ItemTemplate>
                        <img id="_list_img_0" class="m0" src="r/content/<%# Eval("ID") %>.jpg" alt="">
                        </ItemTemplate>
                    </asp:Repeater>
                    <%--<img id="_list_img_0" class="m0" src="r/content/<%=row["content"]%>" alt="">--%>
                </div>
                <div class="info_tool">
                    <div class="info_click">
                    </div>
                    <br />
                    <div class="tool_tool">
                        <div class="tool_info">
                            <span>作品人气</span><br>
                            <b>
                                <%=row["clicks"]%></b>
                            <div class="workNavRightPop">
                                <table>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <span class="c999">浏览：</span><%=row["clicks"]%>人
                                            </td>
                                            <td>
                                                <span class="c999">收藏：</span><%=row["collects"]%>次
                                            </td>
                                            <td>
                                                <span class="c999">评论：</span><%=row["replys"]%>次
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="c999">推荐：</span><%=row["commends"]%>次
                                            </td>
                                        </tr>
                                        <!--
                            <tr>
                            	<td colspan="3"><span class="c999">使用装备：</span>
								
								</td>
                            </tr>
                            -->
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <ul class="tool_ul">
                            <li><a href="javascript:void(0)" onclick="myFavoriteFunc(0,3,617869)">
                                <img src="/i/resource/starW.png">
                                <span class="rightWn"><b>收藏</b><br>
                                    <span>FAVORITE</span> </span></a></li>
                            <li><a href="javascript:void(0)" onclick="popShare()">
                                <img src="/i/resource/shareW.png">
                                <span class="rightWn"><b>分享</b><br>
                                    <span>SHARE IN</span> </span></a></li>
                            <li><a href="javascript:void(0)" onclick="feedBackWindow(617869,3)">
                                <img src="/i/resource/reportW.png">
                                <span class="rightWn"><b>举报</b><br>
                                    <span>REPORT IT</span> </span></a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div id="info_reply">
                <div class="tool_other_title">
                    其他精彩</div>
                <div class="tool_other">
                    <asp:Repeater runat="server" ID="rpt_other">
                        <ItemTemplate>
                            <a href="resource_detail.aspx?id=<%# Eval("ID") %>">
                                <img src="r/img/<%# Eval("ID") %>.jpg" width="240"></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="top">
                    <div class="top_bg">
                        全部评论</div>
                    <div class="top_count">
                        <b>(1)</b></div>
                    <div class="top_reply_bg" id="top_reply_bg" runat="server">
                        <div class="top_sort_date" title="按评论速度">
                            评论速度</div>
                        <div class="top_sort_switch none">
                        </div>
                    </div>
                </div>
                <div class="content" runat="server">
                    <ul class="list">
                        <asp:Repeater ID="rpt_list" runat="server">
                            <ItemTemplate>
                                <li>
                                    <div class="date">
                                        <%# TL.Common.Utils.DateStringFromNow(Eval("RecordDate"))%></div>
                                    <div class="dot">
                                    </div>
                                    <div class="user">
                                        <div class="user-div">
                                            <img src="../p/u/<%# Eval("uimg") %>" />
                                        </div>
                                        <center class="user_title">
                                            <%# Eval("uname") %></center>
                                    </div>
                                    <div class="content <%# (Convert.ToInt32(Eval("ID"))%2==1)?"content_y":"content_n" %>">
                                        <div class="ico-left">
                                        </div>
                                        <div class="detail">
                                            <%# Eval("content").ToString().Replace("[", "<img src=/j/editor/dialogs/emotion/images/").Replace("]", ".gif />")%>
                                        </div>
                                        <div class="toolbar">
                                            <div class="l_1">
                                                1楼</div>
                                            <div class="l_2">
                                                <%# Eval("RecordDate") %></div>
                                            <div class="l_3">
                                                回复</div>
                                        </div>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="reply-add">
                    <form id="reply_form" name="reply_form" action="service/action.ashx?action=submitResourceReply"
                    method="post">
                    <div class="title">
                        发表回复</div>
                    <input type="hidden" id="tid" name="tid" />
                    <div class="content">
                        <div class="u">
                            <img src="p/u/default.png" /></div>
                        <textarea id="replyContent" name="replyContent"></textarea>
                    </div>
                    <div class="toolbar">
                        <div class="fr">
                            <span>还可以输入 <span class="cf30  abc">2000</span> 个字符</span>
                            <input type="button" class="btn_submit" value="评论" />
                        </div>
                        <a href="javascript:void(0)" class="addFace">
                            <img src="http://static.zcool.com.cn/images/face.png"></a> <a class="addFace green">
                                <span>添加表情</span> </a><span class="ml10 black">
                                    <label>
                                        <input type="checkbox" name="commentAndRecommend" value="1" id="commentAndRecommend">
                                        同时推荐此作品</label></span>
                    </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="toTops" title="回到顶部">
        <div class="item3">
            <a></a>
        </div>
    </div>
    <div class="reply-emotion">
        <div class="reply-emotion-div">
            <div class="reply-emotion-close">
            </div>
            <div class="reply-emotion-header">
                <ul>
                    <li><a>精选</a></li>
                    <li><a>BOBO</a></li>
                    <li><a>BABY猫</a></li>
                    <li><a>绿豆蛙</a></li>
                    <li><a>兔斯基</a></li>
                    <li><a>有啊</a></li>
                </ul>
            </div>
            <div class="reply-emotion-content">
                <ul>
                    <li>
                        <ul>
                        </ul>
                    </li>
                    <li>
                        <ul>
                        </ul>
                    </li>
                    <li>
                        <ul>
                        </ul>
                    </li>
                    <li>
                        <ul>
                        </ul>
                    </li>
                    <li>
                        <ul>
                        </ul>
                    </li>
                    <li>
                        <ul>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
