<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="photos.aspx.cs" Inherits="TL.Web.photos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Mrliu - TliangL</title>
    <meta name="keywords" content="相册,刘洪军,tanliang,谭亮,tliangl,谭亮小盆友,个人博客,个人网站,web前端,JavaScript,jquery,css3,html" />
    <meta name="description" content="TliangL分享 >> TliangL博客 @ 谭亮小盆友 >> 谭亮的个人博客，CSS3，HTML5，jQuery" />
    <link href="/c/photos.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var paratemeters = '<%=paratemeters %>';
    </script>
    <script src="/j/Mphotos.js" type="text/javascript"></script>
    <%--<script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/buttonLite.js#uuid=&amp;style=5&amp;fs=4&amp;bgcolor=Green&amp;pophcol=3"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="header">
    </div>
    <div id="content">
        <div id="photo_content" class="wrap cl">
            <div id="photo_control">
                <div id="left">
                    <div id="photo_show" class="wrap cl">
                        <p>
                            刘洪军</p>
                        <ul>
                            <li v="2" c="36" d="刘洪军-2011.10.5" s="刘洪军-2011.10.5" h="160" class="itme_2_2"><a>
                                <img src="/p/p/t2.jpg" />
                            </a>
                                <div class="photo_b">
                                    <p>
                                        2011.10.5</p>
                                </div>
                            </li>
                            <li v="1" c="23" d="刘洪军-2010.2" s="刘洪军-2010.2" h="130" class="itme_2_2"><a>
                                <img src="/p/p/t1.jpg" />
                            </a>
                                <div class="photo_b">
                                    <p>
                                        2010.2</p>
                                </div>
                            </li>
                             <li v="5" c="22" d="漳河-2013.10.4" s="漳河-2013.10.4" h="150" class="itme_2_2"><a>
                                <img src="/p/p/t4.jpg" />
                            </a>
                                <div class="photo_b">
                                    <p>
                                        2013.10.4</p>
                                </div>
                            </li>
                         <%--   <li v="3" c="26" h="150" class="itme_2_2"><a>
                                <img src="/p/p/t3.jpg" />
                            </a>
                                <div class="photo_b">
                                    <p>
                                        知足</p>
                                </div>
                            </li>--%>
                        </ul>
                    </div>
                    <div id="photos" class="wrap cl">
                        <p>
                            所有的</p>
                        <ul>
                            <li c="0" class="itme_2_2"><a target="_blank" href="http://www.tliangl.com/sharec288.aspx">
                                <img src="/p/p/1.jpg" /><img src="/p/p/1_2.jpg" /><div>
                                    萝莉</div>
                            </a></li>
                            <li v="4" c="58" d="动物" s="动物"><a>
                                <img src="/p/p/2.jpg" /><img src="/p/p/2_2.jpg" /><div>
                                    动物</div>
                            </a></li>
                            <li c="0"><a>
                                <img src="/p/p/3.jpg" /><img src="/p/p/3_2.jpg" /><div style="color:Red;">
                                    您无权访问</div>
                            </a></li>
                            <li c="0"><a>
                                <img src="/p/p/4.jpg" /><img src="/p/p/4.jpg" /><div style="color:Red;">
                                    您无权访问</div>
                            </a></li>
                            <li c="0" class="itme_2_1"><a>
                                <img src="/p/p/6.jpg" /><img src="/p/p/6_2.jpg" /><div style="color:Red;">
                                    您无权访问</div>
                            </a></li>
                            <li c="0"><a>
                                <img src="/p/p/5.jpg" /><img src="/p/p/5.jpg" /><div style="color:Red;">
                                    您无权访问</div>
                            </a></li>
                        </ul>
                    </div>
                </div>
                <div id="right">
                    <p>
                        <a id="photo_back">返回相册</a>
                        <a class="share weibo"></a>
                        <a class="share tx"></a>
                        <a class="share qq"></a>
                        <a class="share dou"></a>
                        </p>
                    <div id="photo_page">
                    </div>
                    <div id="photo_tool">
                        <a class="close"></a><a class="next"></a><a class="prev"></a><a class="comment">
                        </a>
                    </div>
                    <div id="photo_list">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
