<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="blog.aspx.cs" Inherits="TL.Web.blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Blog - TliangL</title>
    <meta name="keywords" content="tanliang,谭亮,tliangl,谭亮小盆友,个人博客,个人网站,web前端,JavaScript,jquery,css3,html" />
    <meta name="description" content="TliangL分享 >> TliangL博客 @ 谭亮小盆友 >> 谭亮的个人博客，CSS3，HTML5，jQuery" />
    <link href="c/blog.css" rel="stylesheet" type="text/css" charset="utf-8" />
    <script charset="gbk" src="/j/editor/editor_all.js" type="text/javascript"></script>
    <script charset="gbk" src="/j/editor/editor_config.js" type="text/javascript"></script>
    <link href="/j/editor/themes/default/ueditor.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/j/jquery-easyui-1.3.2/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/j/jquery-easyui-1.3.2/themes/icon.css" />
    <script type="text/javascript" src="/j/jquery-easyui-1.3.2/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/j/jquery-easyui-1.3.2/locale/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript">
        var role = <%=(TL.Data.UserInfo.GetUserInfo().ID == 2 ? "true" : "false") %>;
    </script>
    <script src="j/blog.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/buttonLite.js#uuid=&amp;style=5&amp;fs=4&amp;bgcolor=Green&amp;pophcol=3"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="header">
    </div>
    <div id="content">
        <div class="wrap cl pt10">
            <div id="tag_list">
                <asp:Repeater runat="server" ID="rpt_tag">
                    <ItemTemplate>
                        <a v="<%# Eval("ID") %>">
                            <%# Eval("Name") %></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div id="left">
                <a v="-1">category</a>
                <div class="times panel">
                    <asp:Repeater runat="server" ID="rpt_date">
                        <ItemTemplate>
                            <%# Convert.ToInt32(Eval("tCount")) == -1 ? "<p>" + Eval("y") + "</p>" : "<a v=\"" + Eval("y") + "." + Eval("m") + "\">" + Eval("y") + "." + Eval("m") + "(" + Eval("tCount") + ")</a>"%>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%-- <p>
                        2013</p>
                    <a href="blog.aspx?f_d=2013.8">2013.8(1)</a> <a href="blog.aspx?f_d=2013.7">2013.7(3)</a>
                    <a href="blog.aspx?f_d=2013.3">2013.3(3)</a> <a href="blog.aspx?f_d=2013.2">2013.2(1)</a>
                    <p>
                        2012</p>
                    <a href="blog.aspx?f_d=2012.11">2012.11(2)</a> <a href="blog.aspx?f_d=2012.9">2012.9(1)</a>--%>
                </div>
                <div class="topic panel">
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
            <div id="center">
                <div class="p_tag">
                    <a v="1">CSS</a><a v="2">HTML5</a><a v="3" class="r">JavaScript</a>
                    <div class="cl">
                    </div>
                </div>
                <div class="post_list">
                </div>
                <ul id="my_page" class="fr mr10">
                </ul>
            </div>
            <div id="right">
                <div class="history panel">
                    <h6>
                        最近访客</h6>
                    <ul class="u_history">
                        <li>
                            <img src="p/u/1.jpg" /><p>
                                <b>胡秀玲</b>&nbsp北京&nbsp;朝阳<br />
                                <span>今天&nbsp;09:48</span></p>
                        </li>
                        <li>
                            <img src="p/u/2.jpg" /><p>
                                <b>蓝泡</b>&nbsp北京&nbsp;朝阳<br />
                                <span>今天&nbsp;09:48</span></p>
                        </li>
                        <li>
                            <img src="p/u/1.jpg" /><p>
                                <b>宋郡琼</b>&nbsp北京&nbsp;朝阳<br />
                                <span>今天&nbsp;09:48</span></p>
                        </li>
                        <li>
                            <img src="p/u/2.jpg" /><p>
                                <b>胡秀玲</b>&nbsp北京&nbsp;朝阳<br />
                                <span>今天&nbsp;09:48</span></p>
                        </li>
                        <li>
                            <img src="p/u/1.jpg" /><p>
                                <b>胡秀玲</b>&nbsp北京&nbsp;朝阳<br />
                                <span>今天&nbsp;09:48</span></p>
                        </li>
                    </ul>
                </div>
                <div class="webStat panel">
                    <h6>
                        网站统计</h6>
                    <p>
                        文章:215</p>
                    <p>
                        评论:1124</p>
                    <p>
                        今日浏览量:5</p>
                    <p>
                        今日浏览量:5</p>
                </div>
            </div>
            <div class="cl">
                <div class="topic-add" id="topic-add">
                    <form id="topic_form" name="topic_form" action="service/action.ashx?action=submitBlog"
                    method="post">
                    <div class="title">
                        新文章</div>
                    <input id="topicid" name="topicid" type="hidden" value="0" />
                    <span class="f13">标题:</span><input id="topicName" name="topicName" class=" w50 mt5 ml5 mb5 h25px f15" />
                    <br />
                    <span class="f13">摘要:</span><textarea id="topicTitle" name="topicTitle" class="w100"></textarea>
                    <span class="f13">标签:</span>
                    <div class="pt5 pb5 topic_tag">
                        <ul>
                            <asp:Repeater runat="server" ID="rpt_type">
                                <ItemTemplate>
                                    <li class="" title="<%# Eval("Name") %>" v="<%# Eval("ID")%>"><a class="checkbox-brand">
                                        <%# Eval("Name")%>(<%# Eval("stats") %>)</a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div class="pt5 pb5 pl20">
                        <input type="radio" name="topicType" value="1" class="ml20 topicType" checked="checked" /><span
                            class="f13 ml5">主题</span>
                        <input type="radio" name="topicType" value="2" class="ml20 topicType" /><span class="f13 ml5">投票</span>
                    </div>
                    <div class="vote mt5 mb5 none">
                        <div class="pt5 pb5 pl20">
                            <input type="hidden" id="topicData_t" type="hidden" name="topicData_t" />
                            投票类型:<input type="radio" name="voteType" value="1" class="ml20 voteType" checked="checked" /><span
                                class="f13 ml5">单选</span>
                            <input type="radio" name="voteType" value="2" class="ml20 voteType" /><span class="f13 ml5">多选</span>
                        </div>
                        <input id="vote_item" name="vote_item" type="hidden" />
                        <table id="tt" style="width: 650px; height: auto;" title="Editable DataGrid" iconcls="icon-edit"
                            singleselect="true" idfield="itemid" method="get">
                            <thead>
                                <tr>
                                    <th field="itemid" width="40" editor="text">
                                        编号
                                    </th>
                                    <th field="value" width="500" editor="text">
                                        内容
                                    </th>
                                    <th field="attr1" width="50">
                                    </th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                    <div>
                        <input id="topicContentValue" name="topicContentValue" type="hidden" />
                        <textarea class="content" id="topicContent" name="topicContent"></textarea>
                    </div>
                    <div class="toolbar">
                        <input type="button" class="btn-submit mt10 ml10" value="发表" style="width: 200px;
                            height: 100px;" />
                    </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="toTops">
        <div class="item1">
            <a></a>
        </div>
        <div class="item2">
            <a></a>
        </div>
        <div class="item3">
            <a></a>
        </div>
    </div>
</asp:Content>
