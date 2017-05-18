<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeBehind="share.aspx.cs" Inherits="TL.Web.share" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Shares - TliangL</title>
    <meta name="keywords" content="收集 tanliang,谭亮,tliangl,谭亮小盆友,个人博客,个人网站,web前端,JavaScript,jquery,css3,html" />
    <meta name="description" content="TliangL分享 >> TliangL博客 @ 谭亮小盆友 Shares >> 谭亮的个人博客，CSS3，HTML5，jQuery" />
    <link href="c/share.css" rel="stylesheet" type="text/css" />
    <script src="j/Mshare.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/buttonLite.js#uuid=&amp;style=5&amp;fs=4&amp;bgcolor=Green&amp;pophcol=3"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="header">
    </div>
    <div id="content">
        <div class="wrap cl pt20">
        <h3 class="p_title">来自于<a target="_blank" href="u.aspx" class="e">谭亮小盆友</a>
          
                <a class="p_title_ad" href="share_list.aspx">发现</a>
        </h3>
            <asp:Repeater ID="rpt_list" runat="server">
                <ItemTemplate>
                    <div class="find_album_list fix shadow">
                        <a class="find_album_title" href="sharep<%# Eval("ID") %>.aspx" target="_blank"><span></span>
                            <%# Eval("Name") %></a>
                        <h3>
                            <%# Eval("Remark") %></h3>
                        <%# GetChildren(Convert.ToInt32(Eval("ID")))%>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="toTops">
        <div class="item3">
            <a></a>
        </div>
    </div>
</asp:Content>
