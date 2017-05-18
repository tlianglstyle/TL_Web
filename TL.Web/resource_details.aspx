<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeBehind="resource_details.aspx.cs" Inherits="TL.Web.resource_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=row["Name"]%> -ZCOOL - TliangL</title>
    <meta name="keywords" content="<%=row["Name"]%> tanliang,谭亮,tliangl,T小鱼,个人博客,个人网站,web前端,JavaScript,jquery,css3,html" />
    <meta name="description" content="TliangL分享 >> TliangL博客 @ T小鱼 <%=row["Name"]%> >> 谭亮的个人博客，CSS3，HTML5，jQuery" />
    <script src="/j/jquery-easyui-1.3.2/jquery.easyui.min.js" type="text/javascript"></script>
    <script charset="gbk" src="/j/editor/editor_all.js" type="text/javascript"></script>
    <script charset="gbk" src="/j/editor/editor_config.js" type="text/javascript"></script>
    <link href="/j/editor/themes/default/ueditor.css" rel="stylesheet" type="text/css" />
    <link href="c/resource_details.css" rel="stylesheet" type="text/css" />
    <script src="j/Mresource_details.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/buttonLite.js#uuid=&amp;style=5&amp;fs=4&amp;bgcolor=Green&amp;pophcol=3"></script>
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
                                <a href="resources.aspx?f_t=<%# Eval("ID") %>" class="tag shadow">
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
                            <a href="resource_details.aspx?id=<%# Eval("ID") %>">
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
                <div id="Div1" class="content" runat="server">
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
                    <div class="title none">
                        发表回复</div>
                    <input type="hidden" id="tid" name="tid" />
                    <div class="content">
                        <div class="u">
                            <img src="p/u/default.png" /></div>
                        <textarea id="replyContent" name="replyContent"></textarea>
                    </div>
                    <div class="toolbar">
                        <div class="fr">
                            <%--<span>还可以输入 <span class="cf30  abc">2000</span> 个字符</span>--%>
                            <input type="button" class="btn_submit" value="评论" />
                        </div>
                        <a href="javascript:void(0)" class="addFace">
                            <img src="http://static.zcool.com.cn/images/face.png"></a> <a class="addFace white">
                                <span>添加表情</span> </a><span class="ml10 gray">
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
