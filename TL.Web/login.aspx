<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeBehind="login.aspx.cs" Inherits="TL.Web.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login - TliangL</title>
    <meta name="keywords" content="tanliang,谭亮,tliangl,谭亮小盆友,个人博客,个人网站,web前端,JavaScript,jquery,css3,html" />
    <meta name="description" content="TliangL分享 >> TliangL博客 @ 谭亮小盆友 >> 谭亮的个人博客，CSS3，HTML5，jQuery" />
    <link rel="stylesheet" type="text/css" href="/j/jquery-easyui-1.3.2/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/j/jquery-easyui-1.3.2/themes/icon.css" />
    <script type="text/javascript" src="/j/jquery-easyui-1.3.2/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/j/jquery-easyui-1.3.2/locale/easyui-lang-zh_CN.js"></script>
    <link href="c/login.css" rel="stylesheet" type="text/css" />
    <script src="j/Mlogin.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/buttonLite.js#uuid=&amp;style=5&amp;fs=4&amp;bgcolor=Green&amp;pophcol=3"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="header">
    </div>
    <div id="content">
        <div class="wrap">
            <div id="box">
                <h3>
                </h3>
                <div class="lefth">
                    您已经是老用户?</div>
                <div class="righth">
                    注册一个新用户</div>
                <div class="clear">
                </div>
                <div class="box" id="login_default">
                    <div class="left-block">
                        <div class="left-slider">
                            <div class="left-item" id="left_default">
                                <form id="form_login" name="login" action="service/action.ashx?action=login" method="post">
                                <fieldset>
                                    <label class="inputLabel" for="login-email-address">
                                        用户名&nbsp;or&nbsp;邮箱地址:</label>
                                    <input type="text" id="login-email-address" class="tf" name="email-address">
                                    <label class="inputLabel" for="login-password">
                                        输入密码:</label>
                                    <input type="password" id="login-password" class="tf" name="password">&nbsp;&nbsp;
                                    <a href="" style="font-size: 15px; font-family: Microsoft yahei; color: gray;">Forgot
                                        your password?</a>
                                    <input type="hidden" name="securityToken" value="1c023c36f4139faecdf580e8ea0c9ac6">
                                </fieldset>
                                <!-- fix for ie7 -->
                                <span style="font-size: 0;">&nbsp;</span>
                                <input type="button" name="Submit" value="登录" class="login btn notext" />
                             <%--   <label class="inputLabel" for="login-qq">
                                    其他方式:</label>
                                <div class="login-icon">
                                    <a href="https://api.weibo.com/oauth2/authorize?client_id=425157704&amp;redirect_uri=http://www.tliangl.com/;response_type=code&amp;state=login"
                                        target="_parent" class="item-btn weibo"></a><a id="qqLoginBtn" href1="https://graph.qq.com/oauth2.0/authorize?which=ConfirmPage&display=pc&client_id=100515616&redirect_uri=http://www.tliangl.com/login.aspx&response_type=code&state=login"
                                            target="_parent" class="item-btn qq"></a><a href="http://www.tliangl.com/connectrenren?from=login"
                                                target="_parent" class="item-btn ren"></a><a href="https://www.tliangl.com/service/auth2/auth?client_id=013dc073f2883c7e03b9415bd798b57a&amp;redirect_uri=http://zhan.renren.com/reg/doubanconfig&amp;response_type=code&amp;state=login"
                                                    target="_parent" class="item-btn db"></a>
                                    <script type="text/javascript" src="http://qzonestyle.gtimg.cn/qzone/openapi/qc_loader.js"
                                        data-appid="100515616" data-redirecturi="http://www.tliangl.com/qc_callback.html"
                                        charset="utf-8"></script>
                                    <script type="text/javascript">
                                        //调用QC.Login方法，指定btnId参数将按钮绑定在容器节点中
                                        QC.Login({
                                            //btnId：插入按钮的节点id，必选
                                            btnId: "qqLoginBtn1",
                                            //用户需要确认的scope授权项，可选，默认all
                                            scope: "all",
                                            //按钮尺寸，可用值[A_XL| A_L| A_M| A_S|  B_M| B_S| C_S]，可选，默认B_S
                                            size: "A_XL"
                                        },
                                function (reqData, opts) {//登录成功
                                    //alert(reqData.figureurl);
                                },
                                 function (opts) {//注销成功
                                     //alert('QQ登录 注销成功');
                                 }
);
                                        QC.Login.signOut();
                                        if (1 == 1) {
                                            setInterval(function () {
                                                if (!animate_login && getCookie('qq_login') != null && getCookie('qq_login').length > 0) {
                                                    animate_login = true;
                                                    QC.Login.getMe(function (openId, accessToken) {
                                                        $('#ff').html('Y:' + accessToken);
                                                    });
                                                    QC.Login({ btnId: "qqLoginBtn1", size: "A_XL" },
                                                     function (oInfo, oOpts) {
                                                         $('.left-slider').a({ top: -300 }, 300);
                                                         setTimeout(function () {
                                                             animate_login = false;
                                                         }, 300);
                                                         $('#email-address-other').val(oInfo.nickname);
                                                         $('#img_other').attr('src', oInfo.figureurl_qq_2);
                                                     });
                                                    //window.location.href = "";
                                                }
                                                else {
                                                    $('#ff').html('n');
                                                }
                                            }, 2000);
                                        }
                                    </script>
                                    <script type="text/javascript" src="http://qzonestyle.gtimg.cn/qzone/openapi/qc_loader.js"
                                        charset="utf-8" data-callback="true"></script>
                                </div>--%>
                                </form>
                                <span id="qqLoginBtn1"></span><span id="ff"></span>
                            </div>
                            <%--<div class="left-item mt20" id="left_other">
                                <form id="form_other" name="login" action="service/action.ashx?action=login" method="post">
                                <fieldset>
                                    <label class="inputLabel" for="email-address-other">
                                        用户名:</label>
                                    <input type="text" id="email-address-other" class="tf" name="email-address-other">
                                    <label class="inputLabel" for="">
                                        头像:</label>
                                    <div class="img_other">
                                        <img id="img_other" width="70" height="70" /></div>
                                </fieldset>
                                <!-- fix for ie7 -->
                                <span style="font-size: 0;">&nbsp;</span>
                                <input type="button" name="Submit" value="确认登录" class="login_other btn notext" />
                                <input type="button" name="Submit" value="返回" class="login_back btn notext" />
                                </form>
                            </div>--%>
                        </div>
                    </div>
                    <div class="right-block">
                        <form id="form_register" name="register" action="service/action.ashx?action=register"
                        method="post">
                        <fieldset>
                            <div class="left">
                                <label class="inputLabel" for="email-address">
                                    用户名&nbsp;or&nbsp;邮箱地址:</label>
                                <input type="text" name="email-address" size="1" maxlength="96" id="email-address"
                                    class="tf">
                            </div>
                            <div class="right">
                                <label class="inputLabel" for="yourname">
                                    您的姓名:</label>
                                <input type="text" name="yourname" size="33" maxlength="32" id="yourname" class="tf">
                            </div>
                            <div class="clear">
                            </div>
                            <div class="left">
                                <label class="inputLabel" for="password-new">
                                    登录密码:</label>
                                <input type="password" name="password" size="1" maxlength="40" id="password-new"
                                    class="tf">
                            </div>
                            <div class="right">
                                <label class="inputLabel" for="password-confirm">
                                    确认密码:</label>
                                <input type="password" name="confirmation" size="1" maxlength="40" id="password-confirm"
                                    class="tf">
                            </div>
                            <div class="clear">
                                <div class="left">
                                    <label class="inputLabel" for="telephone">
                                        联系方式:</label>
                                    <input type="text" name="telephone" size="33" maxlength="32" id="telephone" class="tf">
                                </div>
                                <div class="right">
                                    <label class="inputLabel" for="city">
                                        网址&nbsp;or&nbsp;主页&nbsp;or&nbsp;Blog</label>
                                    <input type="text" name="city" id="city" class="tf" />
                                </div>
                                <div class="clear">
                                </div>
                                <input type="button" name="Submit" value="注册并登录" class="register btn notext" />
                        </fieldset>
                        </form>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
