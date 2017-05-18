<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TL.Web.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="c/index.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        index = 1;
        $('.nav_' + index).bgPosition(nav_bg[index].x, nav_bg[index].y).stop().a({ left: 0 }, 150);

        $('.timeLine li').afterbind('mousemove', function () { $('.timeLine li .tip').hide(); $(this).find('.tip').show(); $(this).addClass('current').siblings('li').removeClass('current'); }).afterbind('mouseout', function () { $('.timeLine li .tip').hide(); $(this).removeClass('current'); }); ;
        var arr_tag = ['HTML5', 'jQuery', 'JavaScript', '简约', '书房', '田园', '餐厅', '现代', '阳台', '飘窗', '玄关', 'Html/Css'];
        //var arr_tag_color = ['a6edad', 'ecaaf4', 'acfdf8', 'addff3', 'ddf8c5', 'eef19c', 'fcd6c4', 'f8aff5', 'dbdade', 'efe0cc', 'ffd3ec'];
        var arr_tag_color = ['fa2e2e', 'c706ce', '18056c', '475472', '0b806e', '108d42', '38f533', '9eb80c', '9e7a0e', 'dc29cd', 'ac8118', 'ac8118'];
        for (var i = 0; i < arr_tag.length; i++) {
            var j = Math.ceil(Math.random() * 11);
            $('.p_tag ul').append('<li><a href="blog.aspx?id=1" style="background-color:#' + arr_tag_color[j] + '">' + arr_tag[i] + '</a></li>');
        }
        var settings = {
            min: 200,
            inDelay: 600,
            outDelay: 400,
            containerID: 'toTops',
            containerHoverID: '#toTopHover',
            scrollSpeed: 200, /*1200*/
            easingType: 'linear'
        };

        var containerIDhash = settings.containerID;
        var containerHoverIdHash = settings.containerHoverID;
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
        $('#toTops  a').hover(function () {
            $(this).a({ left: -66 }, 150);
        }, function () {
            $(this).a({ left: 0 }, 150);
        });
    })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="header">
            <div class="wrap cl back">
                <div class="hd">
                </div>
            </div>
            <div class="header_nav">
                <div class="wrap cl">
                    <div class="hWord">
                        晚上好, 世界的模样, 取决于你凝视她的目光
                    </div>
                </div>
            </div>
        </div>
        <div id="content">
            <div class="wrap cl pt20">
                <div id="left">
                    <div class="p">
                        <div class="tag">
                        </div>
                        <div class="p_c">
                            <div class="p_t">
                                骷↘沽鱼的标签</div>
                            <div class="p_tag">
                                <ul>
                                    <!--<li><a>Html/Css</a></li>
                                    <li><a>HTML5</a></li>
                                    <li><a>jQuery</a></li>
                                    <li><a>JavaScript</a></li>
                                    <li><a>简约</a></li>
                                    <li><a>书房</a></li>
                                    <li><a>田园</a></li>
                                    <li><a>餐厅</a></li>
                                    <li><a>现代</a></li>
                                    <li><a>阳台</a></li>
                                    <li><a>飘窗</a></li>
                                    <li><a>玄关</a></li>-->
                                </ul>
                                <div class="cl">
                                </div>
                            </div>
                            <div class="topic">
                            
                                <asp:Repeater runat="server" ID="rpt_topic">
                                    <ItemTemplate>
                                        <li>
                                            <div class="topic_num">
                                                <%# Container.ItemIndex + 1 %>.</div>
                                            <div class="topic_content">
                                                <a href="blog_detail.aspx?id=<%# Eval("ID") %>"><%# Eval("Name") %></a></div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="p_photo">
                                <div class="item">
                                    <img src="p/p/1.jpg" />
                                </div>
                                <div class="item">
                                    <img src="p/p/4.jpg" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="p_t">
                    </div>
                </div>
                <div id="center">
                    <ul class="timeLine">
                        <li><span class="undis"></span><strong>数码</strong>
                            <div class="tip">
                                <img src="http://img1.gtimg.com/ent/pics/hv1/50/193/1307/85036940.jpg" alt="2006年一吻定情">
                                <p>
                                    数码数码数码数码数码数码数码数码数码数码</p>
                            </div>
                        </li>
                        <li class=""><span class="dis"></span><strong>数码</strong>
                            <div class="tip">
                                <img src="http://img1.gtimg.com/ent/pics/hv1/123/193/1307/85037013.jpg" alt="熊黛林首次“攻城”">
                                <p>
                                    数码数码数码数码数码数码数码数码数码数码</p>
                            </div>
                        </li>
                        <li class=""><span class="undis"></span><strong>数码</strong>
                            <div class="tip">
                                <img src="http://img1.gtimg.com/ent/pics/hv1/160/193/1307/85037050.jpg" alt="泰国相聚72小时">
                                <p>
                                    数码数码数码数码数码数码数码数码数码数码</p>
                            </div>
                        </li>
                        <li class=""><span class="dis"></span><strong>数码</strong>
                            <div class="tip">
                                <img src="http://img1.gtimg.com/ent/pics/hv1/207/193/1307/85037097.jpg" alt="郭富城痛悼熊父">
                                <p>
                                    数码数码数码数码数码数码数码数码数码数码</p>
                            </div>
                        </li>
                        <li class=""><span class="undis"></span><strong>数码</strong>
                            <div class="tip">
                                <img src="http://img1.gtimg.com/ent/pics/hv1/239/193/1307/85037129.jpg" alt="上演“世纪握手”">
                                <p>
                                    数码数码数码数码数码数码数码数码数码数码</p>
                            </div>
                        </li>
                    </ul>
                    <div class="post_tab">
                        <div class="c">
                            动态</div>
                        <div>
                            留言</div>
                        <div>
                            足迹</div>
                    </div>
                    <div class="post_list">
                        <div class="post_item">
                            <div class="digg">
                                12</div>
                            <div class="post_body">
                                <h3>
                                    <a href="" target="_blank">项目预估激发的矛盾</a></h3>
                                <p class="post_content">
                                    <a href="http://www.cnblogs.com/rentianlong/" target="_blank">
                                        <img width="48" height="48" class="post_img" src="http://pic.cnitblog.com/face/u230080.jpg?id=17142256"
                                            alt=""></a> 俺是某互联网公司程序猿一枚，由于要开发新的产品，所以人手不够，招了一个程序猿B，再加上美工mm C，就构成了我们的开发小组。由于公司产品人数不够，公司又招了一个月的产品没有招到，所以该产品一直拖着，俺和程序猿B就维护着之前的产品，解决些BUG啥的。过了一阵子，还没招来，部门经理最后决定不等新来的产品...
                                </p>
                                <div class="post_footer">
                                    2013-7-6 12:24 <span class="post_comment">评论(5)</span> <span class="post_view">阅读(24)</span>
                                </div>
                            </div>
                        </div>
                        <div class="post_item">
                            <div class="digg">
                                12</div>
                            <div class="post_body">
                                <h3>
                                    <a href="" target="_blank">项目预估激发的矛盾</a></h3>
                                <p class="post_content">
                                    <a href="http://www.cnblogs.com/rentianlong/" target="_blank">
                                        <img width="48" height="48" class="post_img" src="p/u/1.jpg" alt=""></a> 俺是某互联网公司程序猿一枚，由于要开发新的产品，所以人手不够，招了一个程序猿B，再加上美工mm
                                    C，就构成了我们的开发小组。由于公司产品人数不够，公司又招了一个月的产品没有招到，所以该产品一直拖着，俺和程序猿B就维护着之前的产品，解决些BUG啥的。过了一阵子，还没招来，部门经理最后决定不等新来的产品...
                                </p>
                                <div class="post_footer">
                                    2013-7-6 12:24 <span class="post_comment">评论(5)</span> <span class="post_view">阅读(24)</span>
                                </div>
                            </div>
                        </div>
                        <div class="post_item">
                            <div class="digg">
                                12</div>
                            <div class="post_body">
                                <h3>
                                    <a href="" target="_blank">项目预估激发的矛盾</a></h3>
                                <p class="post_content">
                                    <a href="http://www.cnblogs.com/rentianlong/" target="_blank">
                                        <img width="48" height="48" class="post_img" src="p/u/2.jpg" alt=""></a> 俺是某互联网公司程序猿一枚，由于要开发新的产品，所以人手不够，招了一个程序猿B，再加上美工mm
                                    C，就构成了我们的开发小组。由于公司产品人数不够，公司又招了一个月的产品没有招到，所以该产品一直拖着，俺和程序猿B就维护着之前的产品，解决些BUG啥的。过了一阵子，还没招来，部门经理最后决定不等新来的产品...
                                </p>
                                <div class="post_footer">
                                    2013-7-6 12:24 <span class="post_comment">评论(5)</span> <span class="post_view">阅读(24)</span>
                                </div>
                            </div>
                        </div>
                        <div class="post_item">
                            <div class="digg">
                                12</div>
                            <div class="post_body">
                                <h3>
                                    <a href="" target="_blank">项目预估激发的矛盾</a></h3>
                                <p class="post_content">
                                    <a href="http://www.cnblogs.com/rentianlong/" target="_blank">
                                        <img width="48" height="48" class="post_img" src="http://pic.cnitblog.com/face/u230080.jpg?id=17142256"
                                            alt=""></a> 俺是某互联网公司程序猿一枚，由于要开发新的产品，所以人手不够，招了一个程序猿B，再加上美工mm C，就构成了我们的开发小组。由于公司产品人数不够，公司又招了一个月的产品没有招到，所以该产品一直拖着，俺和程序猿B就维护着之前的产品，解决些BUG啥的。过了一阵子，还没招来，部门经理最后决定不等新来的产品...
                                </p>
                                <div class="post_footer">
                                    2013-7-6 12:24 <span class="post_comment">评论(5)</span> <span class="post_view">阅读(24)</span>
                                </div>
                            </div>
                        </div>
                        <div class="post_item">
                            <div class="digg">
                                12</div>
                            <div class="post_body">
                                <h3>
                                    <a href="" target="_blank">项目预估激发的矛盾</a></h3>
                                <p class="post_content">
                                    <a href="http://www.cnblogs.com/rentianlong/" target="_blank">
                                        <img width="48" height="48" class="post_img" src="http://pic.cnitblog.com/face/u230080.jpg?id=17142256"
                                            alt=""></a> 俺是某互联网公司程序猿一枚，由于要开发新的产品，所以人手不够，招了一个程序猿B，再加上美工mm C，就构成了我们的开发小组。由于公司产品人数不够，公司又招了一个月的产品没有招到，所以该产品一直拖着，俺和程序猿B就维护着之前的产品，解决些BUG啥的。过了一阵子，还没招来，部门经理最后决定不等新来的产品...
                                </p>
                                <div class="post_footer">
                                    2013-7-6 12:24 <span class="post_comment">评论(5)</span> <span class="post_view">阅读(24)</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="right">
                    <div class="u">
                        <div class="uPhoto">
                            <img src="p/u/2.jpg" /></div>
                        <center class="uName">
                            ／骷↘沽鱼﹏</center>
                        <center class="uInfo">
                            男&nbsp;双鱼座&nbsp;北京朝阳</center>
                        <ul class="hData">
                            <li class="d1"><a>13</a></li>
                            <li class="d2"><a>456</a></li>
                            <li class="d3"><a>186</a></li>
                        </ul>
                    </div>
                    <div class="p_reply">
                    <h6>
                        最新评论</h6>
                    <div class="topic_tool">
                        <a class="close" title="关闭"></a>
                    </div>
                    <ul class="ul_reply">
                        <asp:Repeater runat="server" ID="rpt_reply">
                            <ItemTemplate>
                                <li>
                                    <p class="title">
                                        <a target="_blank" href="<%# Convert.ToInt32(Eval("t"))==1?"blog":"resource" %>_detail.aspx?id=<%# Eval("pid") %>">
                                            <%# Eval("pname")%></a>
                                    </p>
                                    <img src="p/u/<%# Eval("UserID") %>.jpg" /><p>
                                        <b>
                                            <%# Eval("UserName") %></b><span><%#TL.Common.Utils.DateStringFromNow(Eval("RecordDate")) %></span>
                                    </p>
                                    <p class="info">
                                        <%# Eval("content").ToString().Replace("[", "<img src=/j/editor/dialogs/emotion/images/").Replace("]", ".gif />")%></p>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                 <div class="history">
                    <div class="topic_tool">
                        <a class="close" title="关闭"></a>
                    </div>
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
                    <div class="webStat">
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
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div id="toTops" title="回到顶部">
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
    