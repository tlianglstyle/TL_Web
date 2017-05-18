<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="TL.Web._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TLiangL</title>
    <meta name="keywords" content="tanliang,谭亮,tliangl,谭亮小盆友,个人博客,个人网站,web前端,JavaScript,jquery,css3,html5" />
    <meta http-equiv="description" content="TliangL分享 >> TliangL博客 @ 谭亮小盆友" />
    <link href="/c/Mdefault_default.css" rel="stylesheet" type="text/css" />
    <script src="/j/Mdefault.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/buttonLite.js#uuid=&amp;style=5&amp;fs=4&amp;bgcolor=Green&amp;pophcol=3"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="header">
    </div>
    <div id="content">
        <div class="wrap cl pt20" id="slider_p">
            <h3 class="p_title">
                欢迎来到<a target="_blank" href="Mu.html" class="e">谭亮小盆友</a>的空间,如有不适,请关闭浏览器,即可痊愈.<a
                    class="p_title_ii" href="blog.aspx"></a>
                <div class="p_title_article">
                    <div class="panel_tool">
                        <a class="next c"></a><a class="prev"></a>
                    </div>
                    <ul>
                        <asp:Repeater ID="rpt_article" runat="server">
                            <ItemTemplate>
                                <li><a class="p_title_ad" href="article<%#Eval("ID") %>.aspx" title="<%#Eval("Name") %>"><%#Eval("Name")%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </h3>
            <div id="slider">
            	<div class="box_tlslider box_tlslider_large">
					<ul>
						<li><a target="_blank" href="/jxchart"><img src="p/i/9.jpg" class="cubeRandom" /></a><div class="label_text"><p></p></div></li>
						<li><a target="_blank" href="http://www.ekang.cc"><img src="p/i/5.jpg" class="cubeShow" /></a><div class="label_text"><p></p></div></li>
						<li><a href="sharep6.aspx"><img src="p/i/2.jpg" class="upBars" /></a><div class="label_text"><p></p></div></li>
						<li><a href="sharep22.aspx"><img src="p/i/4.jpg" class="swapBarsBack" /></a><div class="label_text"><p></p></div></li>
						<li><a href="sharep7.aspx"><img src="p/i/7.jpg" class="circlesRotate" /></a><div class="label_text"><p></p></div></li>
					</ul>
				</div>
               <%-- <a class="slider_prev"></a><a class="slider_next"></a>
                <ul class="rslides_tabs">
                    <li class="c"><a></a></li>
                    <li class=""><a></a></li>
                    <li class=""><a></a></li>
                </ul>
                <div class="slides" style="position: relative; width: 1024px; height: 413px;">
                    <a href="sharep7.aspx">
                        <img src="p/i/7.jpg" /></a> <a href="sharep6.aspx">
                            <img src="p/i/2.jpg" /></a> <a href="sharep5.aspx">
                                <img src="p/i/1.jpg" /></a>
                </div>
                <div id="ribon">
                </div>--%>
            </div>
            <div id="slider_bg">
            </div>
        </div>
        <div class="wrap">
            <div id="tabs">
                <div>
                    <a class="tabs_1 tabs" href="photos.aspx" target="_blank"></a>
                    <div>
                        <h1>
                            MrLiu About</h1>
                        <a href="photos.aspx" title="browse mores" target="_blank">browse mores</a>
                    </div>
                </div>
                <div>
                    <a class="tabs_2 tabs" href="blog.aspx" target="_blank"></a>
                    <div>
                        <h1>
                            Grow Learning</h1>
                        <a href="blog.aspx" title="browse mores" target="_blank">browse mores</a>
                    </div>
                </div>
                <div>
                    <a class="tabs_3 tabs" href="share_list.aspx" target="_blank"></a>
                    <div>
                        <h1>
                            Artistic</h1>
                        <a href="share_list.aspx" title="browse mores" target="_blank">browse mores</a>
                    </div>
                </div>
            </div>
            <div id="cate" class="shadow">
                <a class="cate_more" href="share.aspx" title="browse mores"></a>
                <div class="left">
                </div>
                <div class="right">
                </div>
                <asp:Repeater ID="rpt_list" runat="server">
                    <ItemTemplate>
                        <div class="find_album_list fix">
                            <a v="1" class="find_album_title" href="sharep<%# Eval("ID") %>.aspx" target="_blank">
                                <span></span>
                                <%# Eval("Name") %></a>
                            <h3>
                                <%# Eval("Remark") %></h3>
                            <%# GetChildren(Convert.ToInt32(Eval("ID")))%>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

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
