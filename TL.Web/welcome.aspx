<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="welcome.aspx.cs" Inherits="TL.Web.welcome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Blog - TLiangL</title>
    <meta name="keywords" content="Blog tanliang,谭亮,tliangl,谭亮小盆友,个人博客,个人网站,web前端,JavaScript,jquery,css3,html" />
    <meta name="description" content="TliangL分享 >> TliangL博客 @ 谭亮小盆友 Blog >> 谭亮的个人博客，CSS3，HTML5，jQuery" />
    <link href="c/welcome.css" rel="stylesheet" type="text/css" />
    <script src="j/Mwelcome.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/buttonLite.js#uuid=&amp;style=5&amp;fs=4&amp;bgcolor=Green&amp;pophcol=3"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="header">
        <div class="wrap cl back">
            <div class="hd">
                <div id="tag_list">
                    <asp:Repeater runat="server" ID="rpt_tag">
                        <ItemTemplate>
                            <a href="blog.aspx?f_t=<%# Eval("ID") %>">
                                <%# Eval("Name") %></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div class="header_nav">
            <div class="wrap cl">
                <div class="hWord">
                    <%=timeSent()%>, 世界的模样, 取决于你凝视她的目光
                </div>
            </div>
        </div>
    </div>
    <div id="content">
        <div class="wrap cl pt20">
            <div id="left">
                <div class="post_list">
                    <div class="post_item">
                        <div class="post_body">
                            <h3>
                                再牛逼的伟人，也有苦逼的青春</h3>
                            <div class="post_content">
                                <p>
                                    1874年，某个十六岁的德国青年中学毕业，成绩在全班23人中也只排在第八，老师们对他的印象是该生除过人品好之外，实在看不出其他任何的才华和天赋，聊以自慰的是他有一手保命的技能&mdash;&mdash;弹钢琴。<br>
                                    &#12288;&#12288;<br>
                                    &#12288;&#12288;但是，青年却抛弃了键盘系这个很有前途的专业，毅然决然的选择了物理这个苦逼专业，就连大学的物理学教授都劝他：这个学科的一切都已经被研究完了，后面来的人连个酱油都没得打了。<br>
                                    &#12288;&#12288;<br>
                                    &#12288;&#12288;的确，当时的物理学家确实有资格这个么说，19世纪末，经典物理学大厦宣告建立，它是这样的接近完美而自洽，以至于大神开尔文爵士形容它时说俺们物理学现在是晴空万里，除过偶尔飘出的几朵小乌云。<br>
                                    &#12288;&#12288;<br>
                                    &#12288;&#12288;当然选个物理专业也就算了，有个牛逼导师带着也算有点前途的，然而青年的老师们却是当时科研上牛X闪闪但是讲课却其烂无比的亥姆霍兹和基尔霍夫之流，这类老师的统一特点就是经常在课堂上要停下来提醒前面大声说话的同学不要吵醒后面睡觉的同学们...
                                    <br />
                                    <a class="f12" href="article44.aspx">[阅读全文]</a></p>
                            </div>
                            <div class="post_tool">
                                14/142
                            </div>
                            <a href="article44.aspx" class="post_btn">[阅读全文]</a>
                        </div>
                    </div>
                    <div class="list_hr">
                    </div>
                    <div class="post_item">
                        <div class="post_body">
                            <h3>
                                【原创绘本】琥珀岛-壹</h3>
                            <div class="post_content">
                                <p>
                                    熔岩大陆绵长的海岸线</p>
                                <p>
                                    散落着一些渔民村落</p>
                                <p>
                                    藻贝海湾却人烟稀少</p>
                                <p>
                                    这里</p>
                                <p>
                                    有一棵风树</p>
                                <p>
                                    它还是一粒种子的时候</p>
                                <p>
                                    我就住在这儿</p>
                                <p>
                                    沿着海岸旅行的时候我到过很多地方</p>
                                <p>
                                    繁华的都市</p>
                                <p>
                                    无际的草原</p>
                                <p>
                                    却没有另一棵风树</p>
                                <p>
                                    也没人愿意靠近我的风树屋</p>
                                <p>
                                    这使它和我愈加显得与这大陆格格不入</p>
                                <p>
                                    待续……
                                    <br />
                                    <a class="f12" href="article1.aspx">[阅读全文]</a></p>
                            </div>
                            <div class="post_tool">
                                0/41
                            </div>
                            <a href="article1.aspx" class="post_btn">[阅读全文]</a>
                        </div>
                    </div>
                    <div class="list_hr">
                    </div>
                    <div class="post_item">
                        <div class="post_body">
                            <h3>
                                水手</h3>
                            <div class="post_content">
                                <p>
                                    &nbsp; &nbsp; &nbsp; &nbsp;体内充斥着排泄物，我需要马桶。<br>
                                    &nbsp; &nbsp; &nbsp; &nbsp;于是，我发了疯似的找打火机。<br>
                                    &nbsp; &nbsp; &nbsp; &nbsp;我有三个打火机，但总是找不到他们，因为我本身就不希望别人看到它。<br>
                                    &nbsp; &nbsp; &nbsp; &nbsp;煤气灶的电池也被我拔下来，因为那是相机上的电池，需要充电，这下彻底没希望了，我的脑子又装进了一些浆糊，我不想去找隔壁的隔壁的男人借，因为他屋里烟味太重，我不喜欢烟，在隔壁姐姐眼里我也是内敛的乖宝宝，她是我从公司到家里唯一的女性。<br>
                                    &nbsp; &nbsp; &nbsp; &nbsp;当你抛弃一切的时候，就会得到想要的。<br>
                                    &nbsp; &nbsp; &nbsp; &nbsp;十分钟后，我不愿再为任何事费心费力，我发了疯似的强行结束了所有的编程软件，那么显示器的背后就是打火机。<br>
                                    &nbsp; &nbsp; &nbsp; &nbsp;里面的气体足够，一块钱的气体足够你用到衣锦还乡。<br>
                                    &nbsp; &nbsp; &nbsp; &nbsp;是的，一个声音时常问着笑口常开的我们：你希望在这里得到什么，荒废什么，还是要告诉别人或自己你曾经来过？<br>
                                    &nbsp; &nbsp; &nbsp; &nbsp;都市的泊油路太硬，踩不出足迹。<br>
                                    &nbsp; &nbsp; &nbsp; &nbsp;卫生间的灯修好了，坐便器很舒服，我总是坐很久，因为只有这时我才有心情抽烟，烟弥漫进了我的鼻孔，眼睛，好舒坦。<br>
                                    &nbsp; &nbsp; &nbsp; &nbsp;我喜欢把烟头放进纸篓后用手纸将它盖好，因为在隔壁姐姐眼里我是个内敛的乖宝宝。我更不喜欢跟同事一起出去抽烟，我不喜欢抽他人飘过来的烟味，不纯净还带着北方气味...
                                    <br />
                                    <a class="f12" href="article46.aspx">[阅读全文]</a></p>
                            </div>
                            <div class="post_tool">
                                4/7
                            </div>
                            <a href="article46.aspx" class="post_btn">[阅读全文]</a>
                        </div>
                    </div>
                </div>
            </div>
            <div id="right">
                <div class="u">
                    <div class="uPhoto">
                        <img src="p/u/2.jpg" /></div>
                    <center class="uName">
                        谭亮小盆友</center>
                    <center class="uInfo">
                        男&nbsp;双鱼座&nbsp;北京朝阳</center>
                    <ul class="hData">
                        <li class="d1"><a href="blog.aspx">13</a></li>
                        <li class="d2"><a href="blog.aspx">456</a></li>
                        <li class="d3"><a href="photos.aspx">186</a></li>
                    </ul>
                </div>
                <div class="topic">
                    <h6>
                        最新文章</h6>
                    <div class="topic_tool">
                        <a class="close" title="关闭"></a><a class="update" title="换一批"></a>
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
                                    <img src="p/u/<%# Eval("uimg") %>" /><p>
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
