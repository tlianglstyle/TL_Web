<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeBehind="resources.aspx.cs" Inherits="TL.Web.resources" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ZCOOL - TliangL</title><meta name="keywords" content="zcool,tanliang,谭亮,tliangl,谭亮小盆友,个人博客,个人网站,web前端,JavaScript,jquery,css3,html" />
    <meta name="description" content="TliangL分享 >> TliangL博客 @ 谭亮小盆友 ,ZCOOL>> 谭亮的个人博客，CSS3，HTML5，jQuery" />
    <link href="c/resources.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var role = <%=(TL.Data.UserInfo.GetUserInfo().ID == 2 ? "true" : "false") %>;
    </script>
    <script src="j/Mresources.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/buttonLite.js#uuid=&amp;style=5&amp;fs=4&amp;bgcolor=Green&amp;pophcol=3"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="header">
    </div>
    <div id="content">
        <div class="wrap">
            <div class="clear pt20">
            </div>
            <h3 class="p_title">
                <%--以下这些酷站,<a target="_blank" href="u.aspx" class="e">谭亮小盆友</a>正在努力的膜拜和学习中,--%>如果您有更好的资源,请快快<a target="_blank" href="mailto:style617313168@sohu.com" class="email" title="Email Me:style617313168@sohu.com">eMail</a>给他吧</h3>
            <!--filter-->
            <div id="filter" class="shadow mt20">
                <div id="filter-color">
                    <div class="title">
                        风格</div>
                    <ul>
                        <li class="" title="所有" v="-1"><b style="background-color: #fff; margin-right: 10px;">
                        </b>全部</li>
                        <asp:Repeater runat="server" ID="rpt_color">
                            <ItemTemplate>
                                <li class="<%# Eval("cls") %>" title="<%# Eval("Name") %>" v="<%# Eval("ID") %>"><b
                                    style="background-color: <%# Eval("color") %>"></b>
                                    <%# Eval("stats") %></li>
                            </ItemTemplate>
                        </asp:Repeater>
                        <li class="cl"></li>
                    </ul>
                    <div id="color-more">
                    </div>
                    <div class="cl">
                    </div>
                </div>
                <div id="filter-category">
                    <div class="title">
                        内容</div>
                    <ul>
                        <li v="-1"><a class="checkbox-brand-all green bold">全部</a></li>
                        <asp:Repeater runat="server" ID="rpt_type">
                            <ItemTemplate>
                                <li class="<%# Eval("cls") %>" v="<%# Eval("ID")%>"><a class="checkbox-brand">
                                    <%# Eval("Name")%>(<%# Eval("stats") %>)</a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div id="category-more">
                    </div>
                    <div class="cl">
                    </div>
                </div>
            </div>
            <div id="center">
                <div class="fl item-order">
                    <a v="1" class="cur shadow" title="按最新排序">最新</a> <a v="2" class="shadow" title="按查看数排序">
                        查看</a> <a v="3" class="shadow" title="按推荐人数排序">推荐</a> <a v="4" class="shadow" title="按评论数排序">
                            评论</a>
                </div>
                <div class="fl ml10">
                    <a id="icon-thumb" title="大图展示"></a><a id="icon-list" title="列表展示"></a>
                </div>
                <div class="fl ml20">
                    <a class="result-search" id="btn_add" class="none" href="resource_edit.aspx" target="_blank">
                        新建</a>
                </div>
                <div id="list">
                    <div id="one">
                    </div>
                    <div>
                    </div>
                    <div>
                    </div>
                    <div>
                    </div>
                    <div>
                    </div>
                </div>
                <div id="loading" class="loading">
                    <img src="i/loading.gif" style="border: 1px solid #A8A8A8;" />
                </div>
                <ul id="my_page" class="fr mr10 cl">
                </ul>
            </div>
            <div class="clear">
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
