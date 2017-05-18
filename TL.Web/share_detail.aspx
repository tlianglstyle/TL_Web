<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeBehind="share_detail.aspx.cs" Inherits="TL.Web.share_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>
        <%=row["Name"]%>
        - Shares - TliangL</title>
    <meta name="keywords" content="<%=row["Name"]%> tanliang,谭亮,tliangl,谭亮小盆友,个人博客,个人网站,web前端,JavaScript,jquery,css3,html" />
    <meta name="description" content="TliangL分享 >> TliangL博客 @ 谭亮小盆友 <%=row["Name"]%> >> 谭亮的个人博客，CSS3，HTML5，jQuery" />
    <link href="c/share_detail.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            var id = parseInt('<%=id %>');
            var imgId = parseInt('<%=imgId %>');
            var imglist_count = parseInt('<%= dv_imgList.Count %>');
            var imgPageCount = parseInt(imglist_count / 9) + (imglist_count % 9 > 0 ? 1 : 0)

            $('#slider a:eq(0)').show().siblings('a').hide();
            check();
            function check() {
                if (imgId <= 1) {
                    $('.btn_prev').hide(); $('.btn_next').show();
                } else if (imgId < imglist_count) {
                    $('.btn_prev').show(); $('.btn_next').show();
                } else {
                    $('.btn_prev').show(); $('.btn_next').hide();
                }
            }
            function take(v) {
                $('html, body').animate({ scrollTop: 0 + 100 }, 200);
                imgPageId = (imgId % 9) == 0 ? (parseInt(imgId / 9)) : (parseInt(imgId / 9) + 1);
                if (imgPageId == 1)
                    $('.panel_tool .prev').removeClass('c').siblings().addClass('c');
                else if (imgPageId == imgPageCount)
                    $('.panel_tool .next').removeClass('c').siblings().addClass('c');
                else
                    $('.panel_tool .prev,.panel_tool .next').removeClass('c').addClass('c');
                $('.scorllList').a({ top: -258 * (imgPageId - 1) }, 400);

                $('.info_content div.' + (!imgTemp ? 'load' : 'next')).stop().fadeOut(800);
                $('.info_content div.' + (!imgTemp ? 'next' : 'load')).stop().hide().children('img').attr('src', '');
                $('.info_content div.' + (!imgTemp ? 'next' : 'load')).fadeIn(800).children('img').attr('src', '/p/s/' + id + '/' + v + '.jpg');

                imgTemp = !imgTemp;
                $('.info_content div.' + (imgTemp ? 'next' : 'load')).children('img').load(function () {
                    $('.info_content').h(parseFloat($('.info_content div.' + (imgTemp ? 'next' : 'load')).children('img').height()));
                });
                setTimeout(function () {
                    imgAnimate = false; check();

                }, 800);
            }
            $('.info_content div.load').children('img').attr('src', '/p/s/<%=row["ID"]%>/<%=imgId%>.jpg').load(function () {
                $('.info_content').h(parseFloat($('.info_content div.load').children('img').height()));
            });

            $('.btn_prev').click(function () {
                if (!imgAnimate) {
                    imgAnimate = true;
                    take(--imgId);
                }
            });
            $('.btn_next').click(function () {
                if (!imgAnimate) {
                    imgAnimate = true;
                    take(++imgId);
                }
            });
            var imgTemp = false;
            var imgAnimate = false;
            $('#imgList .list a').click(function () {
                if (!imgAnimate) {
                    imgAnimate = true;
                    imgId = parseInt($(this).attr('v'));
                    take(imgId);
                }
            });

            var imgPageId = 1;
            $('.panel_tool .next.c').afterbind('click', function () {
                if (imgPageId < imgPageCount) {
                    $('.panel_tool .prev').addClass('c');
                    imgPageId++;
                    if (imgPageId == imgPageCount) $(this).removeClass('c');
                    $('.scorllList').a({ top: -258 * (imgPageId - 1) }, 400);
                }
            });
            $('.panel_tool .prev.c').afterbind('click', function () {
                if (imgPageId > 1) {
                    $('.panel_tool .next').addClass('c');
                    imgPageId--;
                    if (imgPageId == 1) $(this).removeClass('c');
                    $('.scorllList').a({ top: -258 * (imgPageId - 1) }, 400);
                }
            });
            $('.share').mouseenter(function () {
                $('.tl_bshare').stop().w(160).css('margin', '0px').show(200);
            });
            $('.share').mouseleave(function () {
                $('.tl_bshare').stop().w(160).css('margin', '0px').hide(300);
            });
            var temp_share = null;
            $('.info_tool .love').click(function () {
                if (temp_share == null) {
                    temp_share = $(this);
                    var tid = $(this).attr('v');
                    $.ajax({
                        type: "get",
                        url: "/service/action.ashx?action=shareAuto&tid=" + tid + "&col=collects",
                        success: function (data) {
                            if (data == "1") {
                                var c = temp_share.children('.num');
                                c.html((parseInt(c.html()) + 1) + '');
                                temp_share.css('cursor', "default").children('span:eq(0)').html('已喜欢');
                            }
                        }
                    });
                }
            });
        })
      
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="header">
    </div>
    <div id="content">
        <div class="wrap cl pt20">
            <h3 class="p_title">
                <a href="share.aspx">图集目录</a> <a class="p_title_ad" href="share_list.aspx?sid=<%=id %>"
                    style="margin-right: 50px;">发现</a>
            </h3>
            <div id="left" class="shadow">
                <div class="info_title">
                    <h2>
                        <span></span>
                        <%=row["Name"]%></h2>
                    <div class="info_tool">
                        <div class="love" v="<%=row["ID"]%>">
                            <b></b><span>喜欢</span><span class="num"><%=row["collects"]%></span></div>
                        <div class="share">
                            <b></b>分享
                            <div class="tl_bshare">
                                <div id="bShareZXM">
                                    <a title="分享到 人人网" onclick="javascript:bShare.share(event,'renren',0);return false;"
                                        style="cursor: pointer; margin-left: 5px;">
                                        <img src="http://static.bshare.cn/frame/images/logos/zxh/renren.gif" style="height: 48px;
                                            width: 48px;"></a><a title="分享到 新浪微博" onclick="javascript:bShare.share(event,'sinaminiblog',0);return false;"
                                                style="cursor: pointer; margin-left: 5px;"><img src="http://static.bshare.cn/frame/images/logos/zxh/sinaminiblog.gif"
                                                    style="height: 48px; width: 48px;"></a><a title="分享到 腾讯微博" onclick="javascript:bShare.share(event,'qqmb',0);return false;"
                                                        style="cursor: pointer; margin-left: 5px;"><img src="http://static.bshare.cn/frame/images/logos/zxh/qqmb.gif"
                                                            style="height: 48px; width: 48px;"></a><a title="分享到 搜狐微博" onclick="javascript:bShare.share(event,'sohuminiblog',0);return false;"
                                                                style="cursor: pointer; margin-left: 5px;"><img src="http://static.bshare.cn/frame/images/logos/zxh/sohuminiblog.gif"
                                                                    style="height: 48px; width: 48px;"></a><a title="分享到 网易微博" onclick="javascript:bShare.share(event,'neteasemb',0);return false;"
                                                                        style="cursor: pointer; margin-left: 5px;"><img src="http://static.bshare.cn/frame/images/logos/zxh/neteasemb.gif"
                                                                            style="height: 48px; width: 48px;"></a><a title="分享到 QQ空间" onclick="javascript:bShare.share(event,'qzone',0);return false;"
                                                                                style="cursor: pointer; margin-left: 5px;"><img src="http://static.bshare.cn/frame/images/logos/zxh/qzone.gif"
                                                                                    style="height: 48px; width: 48px;"></a><a title="分享到 开心网" onclick="javascript:bShare.share(event,'kaixin001',0);return false;"
                                                                                        style="cursor: pointer; margin-left: 5px;"><img src="http://static.bshare.cn/frame/images/logos/zxh/kaixin001.gif"
                                                                                            style="height: 48px; width: 48px;"></a><a title="分享到 豆瓣网" onclick="javascript:bShare.share(event,'douban',0);return false;"
                                                                                                style="cursor: pointer; margin-left: 5px;"><img src="http://static.bshare.cn/frame/images/logos/zxh/douban.gif"
                                                                                                    style="height: 48px; width: 48px;"></a><a title="更多平台..." onclick="javascript:bShare.more(event);return false;"
                                                                                                        style="cursor: pointer; margin-left: 5px;"><img src="http://static.bshare.cn/frame/images/logos/zxh/more.gif"
                                                                                                            style="height: 48px; width: 48px;"></a></div>
                                <script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/buttonLite.js#uuid=f8a4a53f-438a-4ffa-939f-7f313a7e2b05&amp;style=-1"></script>
                                <script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/addons/bshareZxh.js"></script>
                                <script type="text/javascript" charset="utf-8">
                                    bShare.addEntry({
                                        title: '<%=row["Name"]%>',
                                        summary: '<%=row["Name"]%> tliangl分享',
                                        vUid: '', vEmail: '', vTag: 'BSHARE', pic: "" + "http://www.tliangl.com/" + 'p/s/<%=row["ID"]%>/<%=imgId%>.jpg'
                                    });
                                </script>
                            </div>
                        </div>
                    </div>
                    <h3>
                        <%=row["content"]%>
                    </h3>
                    <div class="info_content">
                        <a id="btn_prev" class="btn_prev"></a><a class="btn_next"></a>
                        <%--<div class="temp none">
                            <img src="/p/s/3/5.jpg" alt="">
                        </div>--%>
                        <div class="load">
                            <img src="" alt="" />
                        </div>
                        <div class="next">
                            <img src="" alt="" />
                        </div>
                    </div>
                    <script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/addons/bshareAp.js"></script>
                </div>
            </div>
            <div id="right">
                <div id="imgList" class="shadow">
                    <h2>
                        <span></span>
                        <%= TL.Common.Utils.DateStringFromNow(row["RecordDate"])%>
                    </h2>
                    <div class="panel_tool">
                        <a class="next c"></a><a class="prev"></a>
                    </div>
                    <div class="list">
                        <div class="scorllList">
                            <asp:Repeater ID="rpt_img" runat="server">
                                <ItemTemplate>
                                    <a v="<%# Eval("SID") %>"><span style="background-image: url(/p/s/<%# Eval("shareid") %>/<%# Eval("SID") %>_min.jpg);">
                                    </span></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="cl">
                    </div>
                </div>
                <div id="imgOther" class="shadow">
                    <h2>
                        <span></span>其他收集</h2>
                    <div class="list">
                        <asp:Repeater ID="rpt_other" runat="server">
                            <ItemTemplate>
                                <a title="<%# Eval("Name") %>" href="sharec<%# Eval("ID") %>.aspx"><span style="background-image: url(/p/s/<%# Eval("shareid") %>/<%# Eval("SID") %>_min.jpg);">
                                </span></a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="cl">
                    </div>
                </div>
                <div id="topicOther" class="shadow">
                    <h2>
                        <span></span>更多精彩</h2>
                    <asp:Repeater runat="server" ID="rpt_topic">
                        <ItemTemplate>
                            <div class="item">
                                <div class="topic_num">
                                </div>
                                <div class="topic_content">
                                    <a href="article<%# Eval("ID") %>.aspx">
                                        <%# Eval("Name") %></a></div>
                                <div class="cl">
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="cl h100px">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
