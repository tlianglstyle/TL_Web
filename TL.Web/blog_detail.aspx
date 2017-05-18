<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="blog_detail.aspx.cs" Inherits="TL.Web.blog_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>
        <%=row["Name"].ToString() %>
        - Blog - TliangL</title>
    <meta name="keywords" content="<%=row["Name"].ToString() %> tanliang,谭亮,tliangl,谭亮小盆友,个人博客,个人网站,web前端,JavaScript,jquery,css3,html" />
    <meta name="description" content="TliangL分享 >> TliangL博客 @ 谭亮小盆友 ,<%=row["Name"].ToString() %> >> 谭亮的个人博客，CSS3，HTML5，jQuery" />
    <script src="/j/jquery-easyui-1.3.2/jquery.easyui.min.js" type="text/javascript"></script>
<%--    <script charset="gbk" src="/j/editor/editor_all.js" type="text/javascript"></script>
    <script charset="gbk" src="/j/editor/editor_config.js" type="text/javascript"></script>
    <link href="/j/editor/themes/default/ueditor.css" rel="stylesheet" type="text/css" />--%>
    <link href="/j/editor/third-party/SyntaxHighlighter/shCoreDefault.css" rel="stylesheet" type="text/css" />
    <link href="/c/blog_detail.css" rel="stylesheet" type="text/css" />
    <link href="/j/prettify/prettify.min.css" rel="stylesheet" type="text/css" />
    <script src="/j/prettify/prettify.min.js" type="text/javascript"></script>
    <script src="j/blog_detail.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.onload = function () {
            $('pre').addClass('prettyprint lang-java');
            prettyPrint();
        }
    </script>
    <script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/buttonLite.js#uuid=&amp;style=5&amp;fs=4&amp;bgcolor=Green&amp;pophcol=3"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="header">
    </div>
    <div id="content">
        <div class="wrap pt20">
            <p id="blog_back">
                <a href="blog.aspx">所有的</a></p>
            <div id="left">
                <div id="info_title">
                    <div class="title">
                        <%=row["Name"].ToString() %></div>
                    <div class="bq">
                        <span class="ico_eyes"></span>
                        <div class="title_info">
                            <%=row["clicks"]%></div>
                    </div>
                    <div class="bq">
                        <span class="ico_date"></span>
                        <div class="title_info">
                            <%=  TL.Common.Utils.DateStringFromNow(row["RecordDate"])%></div>
                    </div>
                    <div class="bq">
                        <span class="ico_tag"></span>
                        <div class="title_info">
                            <asp:Repeater runat="server" ID="rpt_type">
                                <ItemTemplate>
                                    <a href="blog.aspx?f_t=<%# Eval("ID") %>" style="color: #6F9C60;">
                                        <%# Eval("Name")%></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <div id="info_center">
                    <div class="info_content">
                        <%= HttpContext.Current.Server.HtmlDecode(row["content"].ToString())%>
                    </div>
                    <div class="info_tool">
                    <p>上一篇　:<%=lastArticle %></p>
                    <p>下一篇　:<%=nextArticle %></p>
                    <p>本文链接:<a target="_blank" href="http://www.tliangl.com/article<%=row["Id"].ToString() %>.aspx" title="http://www.tliangl.com/article<%=row["Id"].ToString() %>.aspx">http://www.tliangl.com/article<%=row["Id"].ToString() %>.aspx</a>来自<a href="http://www.tliangl.com" title="谭亮小盆友">谭亮小盆友</a></p>  
                    </div>
                </div>
                <div id="info_reply">
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
                                                <a <%# GetULinki(Eval("url"))%>>
                                                <img class="s-scale" src="../p/u/<%# Eval("uimg") %>" />
                                                </a>
                                            </div>
                                            <center class="user_title">
                                                <a <%# GetULink(Eval("url"))%>>
                                                    <%# Eval("uname") %>
                                                </a>
                                            </center>
                                        </div>
                                        <div class="content <%# (Convert.ToInt32(Eval("ID"))%2==1)?"content_y":"content_n" %>">
                                            <div class="ico-left">
                                            </div>
                                            <div class="detail">
                                                <%# Eval("content").ToString().Replace("<", "").Replace(">", "").Replace("[", "<img src=/j/editor/dialogs/emotion/images/").Replace("]", ".gif />")%>
                                            </div>
                                            <div class="toolbar">
                                                <div class="l_1 none">
                                                    <%# Container.ItemIndex + 1%>楼</div>
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
                        <form id="reply_form" name="reply_form" action="service/action.ashx?action=submitBlogReply"
                        method="post">
                        <div class="title">
                            <%--发表回复--%>
                            <% if (TL.Data.UserInfo.GetUserInfo().ID == 1)
                               {%>
                            <label for="rName">
                                您的名字:</label><input name="rName" /><a id="r_More">mores++</a><label style="display: none;"
                                    for="takeCookie"><input type="checkbox" class="takeCookie" name="takeCookie" />记录到COOKIE</label><br />
                            <div class="r_More_info">
                                <label for="rMail">
                                    电子邮件:</label><input name="rMail" /><label>不会公开您的邮箱地址.</label><br />
                                <label for="rAddress">
                                    您的地址:</label><input name="rAddress" value="http://" /><label>您的主页或Blog.</label>
                            </div>
                            <%}
                               else
                               { 
                            %>
                            <input name="rName" type="hidden" />
                            <input name="rMail" type="hidden" />
                            <input name="rAddress" type="hidden" />
                            <br />
                            <%
                                } %>
                        </div>
                        <input type="hidden" id="tid" name="tid" />
                        <div class="content">
                            <div class="u">
                                <img src="p/u/default.png" /></div>
                            <textarea id="replyContent" name="replyContent"></textarea>
                        </div>
                        <div class="toolbar">
                            <div class="fr">
                                <span class="none">还可以输入 <span class="cf30  abc">2000</span> 个字符</span>
                                <input type="button" class="btn_submit" value="评论" />
                            </div>
                            <a href="javascript:void(0)" class="addFace">
                                <img src="http://static.zcool.com.cn/images/face.png"></a> <a class="addFace green">
                                    <span>添加表情</span> </a><span class="ml10 black"></span>
                        </div>
                        </form>
                    </div>
                </div>
            </div>
            <div id="right">
                <div class="times panel none">
                    <div class="topic_tool">
                        <a class="close" title="关闭"></a>
                    </div>
                    <asp:Repeater runat="server" ID="rpt_date">
                        <ItemTemplate>
                            <%# Convert.ToInt32(Eval("tCount")) == -1 ? "<p>" + Eval("y") + "</p>" : "<a href=\"blog.aspx?f_d=" + Eval("y") + "." + Eval("m") + "\">" + Eval("y") + "." + Eval("m") + "(" + Eval("tCount") + ")</a>"%>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="topic panel">
                    <h6>
                        blog</h6>
                    <div class="topic_tool">
                        <a class="close" title="关闭"></a><a class="update"></a>
                    </div>
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
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="toTops">
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
