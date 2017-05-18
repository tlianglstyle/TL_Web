<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeBehind="leave.aspx.cs" Inherits="TL.Web.leave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Talk - TliangL</title>
    <meta name="keywords" content="Contact tanliang,谭亮,tliangl,谭亮小盆友,个人博客,个人网站,web前端,JavaScript,jquery,css3,html" />
    <meta name="description" content="TliangL分享 >> TliangL博客 @ 谭亮小盆友 Talk >> 谭亮的个人博客，CSS3，HTML5，jQuery" />
    <link href="c/Mtalk.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/buttonLite.js#uuid=&amp;style=5&amp;fs=4&amp;bgcolor=Green&amp;pophcol=3"></script>
    <script src="/j/jquery-easyui-1.3.2/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="/j/talk.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="wrap pt20">
            <h2 class="u_content_t">
                Talk</h2>
            <div class="list_bar">
                <a class="bar_homes" href="http://tliangl.com/"></a>
                <a class="bar_talk" href="http://tliangl.com/welcome.aspx" target="_blank"></a>
                <a class="bar_QQ" href="http://tliangl.com/leave.aspx"></a>
                <a class="bar_sina" href="http://tliangl.com/site_nav.aspx" target="_blank"></a>
            </div>
            <div class="reply_add">
                <form id="reply_form" name="reply_form" action="service/action.ashx?action=submitTalk"
                method="post">
                <div class="title">
                    <label for="rName" style="float:left;">
                        您的昵称:</label>
                    
                    <div class="real" style="display:<%= TL.Data.UserInfo.GetUserInfo().ID == 1?"none":"block" %>">
                    <span id="realName"><%= TL.Data.UserInfo.GetUserInfo().uname %></span><a id="realClear">clear</a>
                    </div>
                    <div class="Unreal" style="display:<%= TL.Data.UserInfo.GetUserInfo().ID == 1?"block":"none" %>">
                    <input id="rName" name="rName" value="" />
                    <a id="r_Back" style="display:<%= TL.Data.UserInfo.GetUserInfo().ID == 1?"none":"inline-block" %>">back</a>
                    <a id="r_More">更多信息</a>
                    </div>
                    <div class="r_More_info">
                        <label for="rMail">
                            电子邮件:</label><input name="rMail" /><label>不会公开您的邮箱地址.</label><br />
                        <label for="rAddress">
                            您的地址:</label><input name="rAddress" value="http://" /><label>您的主页或Blog.</label>
                    </div>
                </div>
                <input type="hidden" id="tid" name="tid" value="0" />
                <div class="content">
                    <textarea id="replyContent" name="replyContent"></textarea>
                </div>
                <div class="toolbar">
                    <div class="fr">
                        <a class="btn_submit" value="" >提交</a>
                    </div>
                </div>
                </form>
            </div>
            <div class="right">
                <ul class="talk_list">
                    <%--<li>
                    <div class="replylist_black ta">
                     <div class="replylist_l"></div>
                        <div class="replylist_r">
                            <div class="replylist_r_h"> 97楼 | 2013-08-09 09:25:16</div>
                            <div class="replylist_r_t"></div>
                            <div class="replylist_r_c">
                                <span><a target="_blank" href="http:// ">zzpmingyi</a>:</span>自己很少创意，看到一些比较完美的页面都想着模仿一遍，想从中找到一些高手当时设计页面时的思路，这样做有效果吗
                                                                                <div class="reply">
                                            <div class="reply_t"></div>
                                            <div class="reply_c"><span><a target="_blank" href="http://weibo.com/bluevisual">Blue</a>:</span>一定有是效果！临摹好的作品，能培养更成熟的设计思路，慢慢形成自己的设计感觉，最终一定会有很大进步。
                                            <br>2013-08-09 15:29:50</div>
                                    </div>
                                                                            </div>
                            <div class="replylist_r_b"></div>
                        </div>
                </div>
                    <div class="clear"></div>
                    </li>--%>
                </ul>
                <ul id="my_page" class="fr mr10 mt20"></ul>
            </div>
            <%--<ul class="list none">
                <li><a href="#">
                    <h2>
                        Floor #1</h2>
                    <p>
                        阿飞问问啊分</p>
                </a></li>
                <li><a href="#">
                    <h2>
                        Floor #2</h2>
                    <p>
                        Text Content #2</p>
                </a></li>
                <li><a href="#">
                    <h2>
                        title #3</h2>
                    <p>
                        Text Content #3</p>
                </a></li>
                <li><a href="#">
                    <h2>
                        title #4</h2>
                    <p>
                        Text Content #4</p>
                </a></li>
                <li><a href="#">
                    <h2>
                        title #5</h2>
                    <p>
                        Text Content #5</p>
                </a></li>
                <li><a href="#">
                    <h2>
                        title #6</h2>
                    <p>
                        Text Content #6</p>
                </a></li>
                <li><a href="#">
                    <h2>
                        title #2</h2>
                    <p>
                        Text Content #2</p>
                </a></li>
                <li><a href="#">
                    <h2>
                        title #7</h2>
                    <p>
                        Text Content #7</p>
                </a></li>
                <li><a href="#">
                    <h2>
                        title #8</h2>
                    <p>
                        Text Content #8</p>
                </a></li>
            </ul>--%>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
