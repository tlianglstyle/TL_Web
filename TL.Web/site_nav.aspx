<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeBehind="site_nav.aspx.cs" Inherits="TL.Web.site_nav" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>LINKS - TliangL</title>
    <meta name="keywords" content="LINKS tanliang,谭亮,tliangl,谭亮小盆友,个人博客,个人网站,web前端,JavaScript,jquery,css3,html" />
    <meta name="description" content="TliangL分享 >> TliangL博客 @ 谭亮小盆友 LINKS >> 谭亮的个人博客，CSS3，HTML5，jQuery" />
    <link href="c/site_nav.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/buttonLite.js#uuid=&amp;style=5&amp;fs=4&amp;bgcolor=Green&amp;pophcol=3"></script>
 
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--  <div id="header">
    </div>--%>
    <div class="box">
        <form id="form_login" name="login" action="service/action.ashx?action=login" method="post">
        <fieldset>
            <label class="inputLabel" for="login-email-address">
                网站名称:</label>
            <input type="text" class="text" id="site_url" name="site_url">
            <label class="inputLabel" for="login-password">
                网站地址:</label>
            <input type="text" class="text" id="site_desc" name="site_desc">&nbsp;&nbsp; <a href=""
                style="font-size: 15px; font-family: Microsoft yahei; color: gray;">Forgot your
                password?</a>
            <label class="inputLabel" for="login-email-address">
                站长邮箱:</label>
            <input type="text" class="text" id="Text1" name="site_url">
            <label class="inputLabel" for="login-email-address">
                网站简介:</label>
            <textarea id="" name="" class="text"></textarea>
        </fieldset>
        <!-- fix for ie7 -->
        <span style="font-size: 0;">&nbsp;</span>
        <input type="button" name="Submit" value="登录" class="submit" />
        </form>
    </div>
    <div id="content">
        <div class="wrapper">
            <h2 class="content_t">
                LINKS</h2>
            <a class="content_b" href="http://www.tliangl.com">back</a>
            <div id="catalog">
                <a class="content_request none">申请</a>
        <div class="area_section"  data-catalog="download" class="active">
            <div class="acticle_header">
              <h2 class="icon-site"><a>作品汇总</a></h2>
            </div>
            <ul class="website-list">
                <li> <a href="http://mobile.lenovo-idea.com/2015/list/index.html" class="website active" target="_blank">佳意堂-H5</a>
                    <p class="description">请使用微信打开页面</p>
              </li>
              <li><a href="http://tliangl.com/mobile/lenovo.html" class="website active" target="_blank">联想-H5</a>
                    <p class="description">请使用微信打开页面</p>
              </li>
              <li class="hot-item"> <a href="http://www.thinkworldshop.com.cn" class="website" target="_blank">ThinkPad</a>
                <p class="description">联想ThinkPad官方商城</p>
              </li> 
              <li class="hot-item"> <a href="http://mobile.thinkworldshop.com.cn" class="website" target="_blank">ThinkPad Mobile</a>
                <p class="description">联想ThinkPad官方商城手机版</p>
              </li> 
              <li class="new-item"> <a href="http://www.xiange.me/" class="website" target="_blank">鲜歌</a>
                <p class="description">互联网水果电商</p>
              </li>
              <li class="hot-item"> <a href="http://www.chinatravelsolution.com" class="website" target="_blank">chinatravelsolution</a>
                <p class="description">chinatravelsolution@10km Marathon</p>
              </li>
              <li class="new-item"> <a href="http://www.ekang.cc/" class="website" target="_blank">亿康体检</a>
                <p class="description">O2O体检服务平台</p>
              </li>
              <li> <a href="http://www.lookhere.cc/" class="website" target="_blank">LookHere</a>
                <p class="description">LookHere婚纱摄影</p>
              </li>  
              <li> <a href="/jxchart" class="website" target="_blank">极限报表</a>
                <p class="description">在线图表、报表生成</p>
              </li>
              <li> <a href="http://fbrushes.com/" class="website" target="_blank">Fbrushes</a>
                <p class="description">笔刷+纹理，高质量的免费PS笔刷、图案及纹理</p>
              </li>
              <li class="hot-item"> <a href="http://www.creattor.com/" class="website" target="_blank">Creattor</a>
                <p class="description">网站模版，强烈推荐这枚华丽丽的网页设计必备神站</p>
              </li>
              <li> <a href="http://www.dafont.com/theme.php?cat=504&amp;fpp=20" class="website" target="_blank">Dafont</a>
                <p class="description">字体，高质量免费字体下载，设计师必备资源站</p>
              </li>
            </ul>
            <a href="/" class="more-item1" target="_blank"></a> 
        </div>
        <div class="h5-list">
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_1.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; top: 224.90455010070798px; left: 220px;">
						<a href="http://mobile.lenovo-idea.com/2014/mas/">
							<p>乐檬K3圣诞节</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_2.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; left: 220px; top: 110.41726543273924px;">
                        <a href="http://mobile.lenovo-idea.com/2014/formulate/">
                            <p>策反王撕葱</p>
                        </a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_19.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; left: 220px; top: -10px;">
						<a href="http://mobile.lenovo-idea.com/2015/amazon/">
							<p>亚马逊</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div><div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_21.jpg">
					</div>
					<div class="info" style="display: block; left: -10px; opacity: 1; top: 318.9864501953125px;">
						<a href="http://tliangl.com/mobile/tc/index.html">
							<p>众人添财</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_4.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; top: 319px; left: -230px;">
						<a href="http://mobile.lenovo-idea.com/2014/gjh/">
							<p>广交会</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_5.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; top: -318.9864501953125px; left: 220px;">
						<a href="http://mobile.lenovo-idea.com/2014/h5game/">
							<p>乐檬K3绕口令</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_6.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; left: -10px; top: -318.9864807128906px;">
						<p></p>
						<a href="http://mobile.lenovo-idea.com/2014/wmn/">
							<p>武媚娘 乐檬K3病毒</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_7.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; left: -230px; top: -10px;">
						<a href="http://mobile.lenovo-idea.com/2014/h5p/">
							<p>乐檬k3产品</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_8.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; left: -230px; top: -10px;">
						<a href="http://mobile.lenovo-idea.com/2014/treasure/">
							<p>厕所挖宝总动员</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_9.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; top: -318.9864501953125px; left: 220px;">
						<a href="http://mobile.lenovo-idea.com/2014/crowdfunding/">
							<p>黄金斗士Note8 众筹</p>
						</a>
						
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_10.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; top: 318.986478805542px; left: -10px;">
						<a href="http://mobile.lenovo-idea.com/w/2015/offline/MobLove/">
							<p>联想手机2015爱你有我 </p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_11.jpg">
					</div>
					<div class="info">
						<a href="http://mobile.lenovo-idea.com/2014/pinpai2/">
							<p>联想手机品牌 </p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_3.jpg">
					</div>
					<div class="info" style="display: block; left: 220px; opacity: 1; top: 318.9864807128906px;">
						<a href="http://mobile.lenovo-idea.com/2014/dh/">
							<p>大寒</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div><div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_12.jpg">
					</div>
					<div class="info">
						<a href="http://mobile.lenovo-idea.com/2014/wajueji/">
							<p>挖笋尖</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_13.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; top: -10px; left: 220px;">
						<a href="http://s90.lenovo-idea.com/vibex2/">
							<p>联想手机vibe X2</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_14.jpg">
					</div>
					<div class="info" style="display: block; top: 318.98651123046875px; opacity: 1; left: -10px;">
						<a href="http://mobile.lenovo-idea.com/2014/wumai/">
							<p>雾里看笋</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_15.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; left: -10px; top: -10px;">
						<a href="http://happy.lenovo-idea.com/act/2014_A805E/">
							<p>一块皮子华丽蜕变之旅</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_16.jpg">
					</div>
					<div class="info">
						<a href="http://mobile.lenovo-idea.com/2015/offline/doraemon/">
							<p>联想智能电视携手哆啦A梦发红包赠玩偶送电视啦！</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_17.jpg">
					</div>
					<div class="info">
						<a href="http://mobile.lenovo-idea.com/2015/offline/lanternfestival/">
							<p>叮当加速度，元宵送祝福！</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_18.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; top: 318.9864692687988px; left: -10px;">
						<a href="http://mobile.lenovo-idea.com/w/2015/joysaloon/women/">
							<p>让爱传递,她的达芬奇密码</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_20.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; left: 220px; top: 182.53109531555177px;">
						<a href="http://mobile.lenovo-idea.com/2015/offline/cooking/">
							<p>厨房巅峰挑战赛</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_22.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; top: -318.9864501953125px; left: -230px;">
						<a href="http://mobile.lenovo-idea.com/2015/offline/notebook/">
							<p>联想小新笔记本</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_test1.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; top: 318.9864501953125px; left: -10px;">
						<a href="http://mobile.lenovo-idea.com/2015/test/360outer/">
							<p>360全景图</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_23.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; left: -10px; top: 318.9864730834961px;">
						<a href="http://mobile.lenovo-idea.com/2015/telecomday/">
							<p>联想大客户 电信日</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_24.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; left: -230px; top: -193.2061px;">
						<a href="http://mobile.lenovo-idea.com/2015/bless/">
							<p>联想高考祈福H5</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_25.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; left: -10px; top: -10px;">
						<a href="http://mobile.lenovo-idea.com/2015/dbfestival/">
							<p>联想大客户 端午节送红包</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_26.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; left: -230px; top: -271.5376px;">
						<a href="http://mobile.lenovo-idea.com/2015/weixin/">
							<p>乐檬K3乐懵了 微信</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_27.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; left: -10px; top: -319px;">
						<a href="http://mobile.lenovo-idea.com/2015/sale/">
							<p>乐檬k3 线下助销</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_28.jpg">
					</div>
					<div class="info" style="display: block; top: -10px; opacity: 1; left: -230px;">
						<a href="http://mobile.lenovo-idea.com/2015/k80/">
							<p>联想k80 线下助销</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_29.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; top: -10px; left: -230px;">
						<a href="http://mobile.lenovo-idea.com/2015/festival/">
							<p>惠普七夕奇葩求爱</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_30.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; top: -318.9864959716797px; left: -10px;">
						<a href="http://mobile.lenovo-idea.com/2015/holiday/">
							<p>联想秋季新品发布</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_31.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; left: -230px; top: 318.9864807128906px;">
						<a href="http://mobile.lenovo-idea.com/2015/moto360/">
							<p>新一代moto 360</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_32.jpg">
					</div>
					<div class="info" style="display: block; left: 220px;">
						<a href="http://mobile.lenovo-idea.com/2015/p1/">
							<p>联想员工享福啦！</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_34.jpg">
					</div>
					<div class="info" style="display: block; opacity: 1; top: -318.98651123046875px; left: -10px;">
						<a href="http://mobile.lenovo-idea.com/2015/hp/">
							<p>HP华丽蜕变计时赛</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
			<div class="list">
				<div class="h5_box">
					<div class="image">
						<img class="d-img" src="/p/h5/img_33.jpg">
					</div>
					<div class="info" style="display: block; left: -10px; top: -318.9864807128906px; opacity: 1;">
						<a href="http://mobile.lenovo-idea.com/2015/motoxstyle/">
							<p>Moto X Style选择无可复制 (第三方公司制作)</p>
						</a>
					</div>
				</div>
			<div class="h5_pos"></div></div>
		</div>
        <br /><br /><br /><br />
        <div class="area_section"  data-catalog="download" class="active">
            <div class="acticle_header">
              <h2 class="icon-download"><a>资源下载</a></h2>
            </div>
            <ul class="website-list">
              <li class="hot-item"> <a href="http://ui-cloud.com/" class="website" target="_blank">UI-Cloud</a>
                <p class="description">UI搜索引擎，设计师必备，提供用户界面PSD下载</p>
              </li> 
              <li class="new-item"> <a href="http://findicons.com/" class="website" target="_blank">FindIcons</a>
                <p class="description">Icon，著名图标搜索引擎，超过410185个免费图标</p>
              </li>
              <li class="hot-item"> <a href="http://subtlepatterns.com/" class="website" target="_blank">SubtlePatterns</a>
                <p class="description">背景纹理，最上档次的无缝背景纹理下载站，木有之一</p>
              </li>
              <li class="new-item"> <a href="http://www.agiledesigners.com/" class="website" target="_blank">Agile Designers</a>
                <p class="description">资源列表，想找国外最棒的设计类网站吗？看这里</p>
              </li>
              <li> <a href="http://cn.freepik.com/" class="website" target="_blank">Freepik</a>
                <p class="description">干货搜索引擎，超过一百万个PSD、矢量、照片下载</p>
              </li>          
              <li class="new-item"> <a href="http://www.templatemonster.com/" class="website" target="_blank">网页模版巨人</a>
                <p class="description">国际顶尖的网页模版库，借鉴和学习网页趋势的宝地</p>
              </li>
              <li> <a href="http://freebiesbooth.com/" class="website" target="_blank">FreebiesBooth</a>
                <p class="description">PSD，免费web设计资源及分层PSD下载的干货铺子</p>
              </li>
              <li> <a href="http://www.brusheezy.com/" class="website" target="_blank">Brusheezy</a>
                <p class="description">笔刷，著名的免费笔刷、图案纹理资源站</p>
              </li>
              <li> <a href="http://fbrushes.com/" class="website" target="_blank">Fbrushes</a>
                <p class="description">笔刷+纹理，高质量的免费PS笔刷、图案及纹理</p>
              </li>
              <li class="hot-item"> <a href="http://www.creattor.com/" class="website" target="_blank">Creattor</a>
                <p class="description">网站模版，强烈推荐这枚华丽丽的网页设计必备神站</p>
              </li>
              <li> <a href="http://www.dafont.com/theme.php?cat=504&amp;fpp=20" class="website" target="_blank">Dafont</a>
                <p class="description">字体，高质量免费字体下载，设计师必备资源站</p>
              </li>
              <li> <a href="http://logopond.com/" class="website" target="_blank">LogoPond</a>
                <p class="description">Logo，高端LOGO集萃，设计前必须来池子里泡一泡</p>
              </li>
            </ul>
            <a href="/" class="more-item1" target="_blank"></a> 
        </div>
                <div class="area_section"  data-catalog="tutorials">
            <div class="acticle_header">
          <h2 class="icon-tutorials">设计教程</h2>
        </div>
        <ul class="website-list">
          <li class="hot-item"> <a href="http://www.psdvault.com/" class="website" target="_blank">PSDVault</a>
            <p class="description">PSD宝库，提供了顶尖大师们的PS教程及技巧 </p>
          </li>
          <li> <a href="http://psd.tutsplus.com/" class="website" target="_blank">PSDTuts+</a>
            <p class="description">Photoshop教程，从初学者到高级进阶，应有尽有</p>
          </li>
          <li> <a href="http://www.smashingmagazine.com/" class="website" target="_blank">Smashing Magazine</a>
            <p class="description">专注于用户体验设计和前端开发的著名设计博客</p>
          </li>
          <li class="new-item"> <a href="http://naldzgraphics.net/" class="website" target="_blank">Naldz Graphics</a>
            <p class="description">推荐！24岁少年创办的知名人气设计资源教程博客</p>
          </li>
          <li class="new-item"> <a href="http://www.digitalartsonline.co.uk/tutorials/" class="website" target="_blank">数字艺术在线</a>
            <p class="description">教程都很棒！你更会爱上网站展现教程的回廊方式</p>
          </li>
          <li> <a href="http://www.photoshoplady.com/" class="website" target="_blank">Photoshop Lady</a>
            <p class="description">提供各种详细的photoshop教程，优设联盟站点</p>
          </li>
          <li> <a href="http://www.uisdc.com/" class="website" target="_blank">SDC优秀网页设计</a>
            <p class="description">与大师零距离接触，一线设计师、总监的干货分享地</p>
          </li>
          <li> <a href="http://psd.fanextra.com/" class="website" target="_blank">PSD爱好者</a>
            <p class="description">提供Photoshop教程、设计文章和资源下载</p>
          </li>
          <li> <a href="http://www.zcool.com.cn/" class="website" target="_blank">站酷</a>
            <p class="description">综合性设计分享网站，原创设计交流平台</p>
          </li>
          <li> <a href="http://abduzeedo.com/" class="website" target="_blank">Abduzeedo</a>
            <p class="description">汇集大量视觉灵感和酷炫PS教程的设计博客</p>
          </li>
          <li> <a href="http://creattica.com/" class="website" target="_blank">Creattica</a>
            <p class="description">综合，免费的PSD、纹理、背景图、icon</p>
          </li>
          <li class="hot-item"> <a href="http://www.webdesignerdepot.com/" class="website" target="_blank">Webdesigner Depot</a>
            <p class="description">网页设计师必备，涵盖大量教程、工具、素材</p>
          </li>
        </ul>
        <a href="/" class="more-item" title="即将绽放更多，尽请期待">更多</a> </div>
                <div class="area_section"  data-catalog="picture">
            <div class="acticle_header">
          <h2 class="icon-picture">高清图库</h2>
        </div>
        <ul class="website-list">
          <li class="hot-item"> <a href="http://wallbase.cc/toplist" class="website" target="_blank">WallBase</a>
            <p class="description">最强悍的高清无码宽屏壁纸站。天地良心，图库首选</p>
          </li>
          <li> <a href="http://500px.com/" class="website" target="_blank">500px</a>
            <p class="description">有着世界上最好的照片分享，你值得拥有</p>
          </li>
          <li> <a href="http://www.stockvault.net/" class="website" target="_blank">Stockvault</a>
            <p class="description">免费可商用的高清图库，分类非常详细</p>
          </li>
          <li> <a href="http://www.twitrcovers.com/" class="website" target="_blank">Twitter Covers</a>
            <p class="description">超酷！装扮微博的必备图库站点</p>
          </li>
          <li> <a href="http://coolvibe.com/" class="website" target="_blank">CoolVibe</a>
            <p class="description">一个展示高清插画壁纸以及动漫、梦幻图片的地方</p>
          </li>
          <li> <a href="http://www.wallsoc.com/" class="website" target="_blank">Wallsoc</a>
            <p class="description">高清壁纸站，挑选图片很方便，搜索功能也不错</p>
          </li>
          <li class="hot-item"> <a href="http://www.deviantart.com/" class="website" target="_blank">deviantART</a>
            <p class="description">每天发表约14万个新作品！一个国际化的在线艺术社区</p>
          </li>
          <li> <a href="http://www.desktopnexus.com/" class="website" target="_blank">Desktop Nexus</a>
            <p class="description">新鲜及时的高品质图片壁纸社区</p>
          </li>
          <li> <a href="http://www.desktopwallpapers.co.uk/" class="website" target="_blank">DesktopWallpapers</a>
            <p class="description">比较有搜图氛围的高清图库，适合夜晚浏览</p>
          </li>
          <li class="new-item"> <a href="http://photo.naver.com/" class="website" target="_blank">Photo / Naver</a>
            <p class="description">韩国著名门户Naver推出的画廊，Banner素材必备！</p>
          </li>
          <li class="new-item"> <a href="http://fotologue.jp/" class="website" target="_blank">FotoLogue</a>
            <p class="description">日本一家高端的照片交流社区，网站的视觉体验非常棒</p>
          </li>
          <li class="hot-item"> <a href="http://www.flickr.com/explore" class="website" target="_blank">Flickr</a>
            <p class="description">提供世界上一流的图片服务，雅虎旗下图片分享网站</p>
          </li>         
        </ul>
        <a href="/" class="more-item">更多</a> </div>
                <div class="area_section"  data-catalog="color">
            <div class="acticle_header">
          <h2 class="icon-color">配色方案</h2>
        </div>
        <ul class="website-list">
          <li class="hot-item"> <a href="https://kuler.adobe.com/" class="website" target="_blank">Kuler</a>
            <p class="description">网页设计师配色的最佳之选</p>
          </li>
          <li> <a href="http://www.colourlovers.com/" class="website" target="_blank">COLOURlovers</a>
            <p class="description">交流颜色、色彩趋势和配色方案的超人气社区</p>
          </li>
          <li> <a href="http://www.colorhunter.com/" class="website" target="_blank">Color Hunter</a>
            <p class="description">实用！上传图片创建配色方案</p>
          </li>
          <li> <a href="http://colorschemedesigner.com/" class="website" target="_blank">Color Scheme Designer 3</a>
            <p class="description">专业调色板，可在线实时预览网页设计配色的工具</p>
          </li>
          <li> <a href="http://www.csswinner.com/colorsearch/blue" class="website" target="_blank">CssWinner网页色彩分类</a>
            <p class="description">CSS画廊，可根据右侧颜色块展现最流行的网页</p>
          </li>
          <li> <a href="http://colrd.com/" class="website" target="_blank">ColRD</a>
            <p class="description">可创建及共享配色方案的灵感网站</p>
          </li>
          <li class="hot-item"> <a href="http://color.uisdc.com/" class="website" target="_blank">中国色彩大辞典</a>
            <p class="description">中国/日本传统色彩命名，点击色彩可直接吸取色值</p>
          </li>
          <li> <a href="http://www.nicopon.com/" class="website" target="_blank">日本颜色大辞典</a>
            <p class="description">日本web颜色样品网站，颜色样品大辞典</p>
          </li>
          <li> <a href="http://www.visibone.com/" class="website" target="_blank">VisiBone</a>
            <p class="description">网页设计参考指南，提供免费在线的配色方案实验室</p>
          </li>
          <li> <a href="http://www.colorschemer.com/" class="website" target="_blank">即时配色方案</a>
            <p class="description">ColorSchemer，有很多网页设计师专业配色软件</p>
          </li>
          <li> <a href="http://www.fashiontrendsetter.com/" class="website" target="_blank">Fashion Trendsetter</a>
            <p class="description">帮你关注每年最流行的颜色搭配</p>
          </li>
          <li class="new-item"> <a href="http://colorblender.com/" class="website" target="_blank">ColorBlender</a>
            <p class="description">是一款非常有趣的免费在线网页配色工具</p>
          </li>          
        </ul>
        <a href="/" class="more-item">更多</a> </div>
                <div class="area_section"  data-catalog="ui">
            <div class="acticle_header">
          <h2 class="icon-ui">界面设计</h2>
        </div>
        <ul class="website-list">
          <li class="hot-item"> <a href="http://dribbble.com/" class="website" target="_blank">Dribbble</a>
            <p class="description">设计师必备站点，刘碧到不需要注释</p>
          </li>
          <li class="hot-item"> <a href="http://www.behance.net/" class="website" target="_blank">Behance</a>
            <p class="description">全球领先的创意设计类聚合平台</p>
          </li>
          <li class="hot-item"> <a href="http://www.iconfans.com/" class="website" target="_blank">ICONFANS</a>
            <p class="description">图标粉丝网，国内专业图形界面交互设计平台</p>
          </li>
          <li> <a href="http://www.uiparade.com/" class="website" target="_blank">UI 阅兵场</a>
            <p class="description">展示世界最有才华设计师的用户界面设计作品</p>
          </li>
          <li> <a href="http://365psd.com/" class="website" target="_blank">365psd</a>
            <p class="description">兢兢业业每天更新着用户界面相关的PSD</p>
          </li>
          <li> <a href="http://designmoo.com/" class="website" target="_blank">Designmoo</a>
            <p class="description">一个分享UI的资源社区，可以去定期收货</p>
          </li>
          <li> <a href="http://www.pixeden.com/" class="website" target="_blank">Pixeden</a>
            <p class="description">赞！免费优质界面设计源文件及有网站模板</p>
          </li>
          <li> <a href="http://freeuikits.com/" class="website" target="_blank">免费的UI组件包</a>
            <p class="description">推荐！致力于分享免费的UI和GUI PSD文件</p>
          </li>
          <li> <a href="http://www.icondeposit.com/" class="website" target="_blank">Icon Deposit</a>
            <p class="description">UI竞技场！为设计师提供作品展示的平台</p>
          </li>
          <li> <a href="http://www.blazrobar.com/" class="website" target="_blank">BlazRobar</a>
            <p class="description">有很多免费精华宝贵的界面资源，注册后即可下载</p>
          </li>
          <li> <a href="http://designmodo.com/" class="website" target="_blank">Designmodo</a>
            <p class="description">所有高质量UI工具包都在这里可以找到，部分免费下载</p>
          </li>
          <li> <a href="http://www.mobile-patterns.com/" class="website" target="_blank">Mobile Patterns</a>
            <p class="description">一个集合iOS界面截图给设计者灵感的酷站</p>
          </li>
        </ul>
        <a href="/" class="more-item">更多</a> </div>
                <div class="area_section"  data-catalog="template">
            <div class="acticle_header">
          <h2 class="icon-template">网站模版</h2>
        </div>
        <ul class="website-list">
          <li class="hot-item"> <a href="http://www.templatemonster.com/" class="website" target="_blank">网页模版巨人</a>
            <p class="description">著名的网页模版库，借鉴和学习网页趋势的宝地</p>
          </li>
          <li class="new-item"> <a href="http://templates.entheosweb.com/" class="website" target="_blank">Entheos Templates</a>
            <p class="description">强大的模板库，包括最流行的响应式网页、HTML5酷站</p>
          </li>
          <li> <a href="http://www.dreamtemplate.com/" class="website" target="_blank">梦幻模板</a>
            <p class="description">超过7000个梦幻般的网站模板及Flash模板下载</p>
          </li>
          <li> <a href="http://www.templateworld.com/" class="website" target="_blank">网页模版世界</a>
            <p class="description">提供各种专业的网页开发模板，记得利用好左侧的分类</p>
          </li>
          <li> <a href="http://www.4templates.com/website-templates/" class="website" target="_blank">4Templates</a>
            <p class="description">网页模版市集，挑那些贵的看，然后预览，然后...</p>
          </li>
          <li> <a href="http://www.freewebsitetemplates.com/" class="website" target="_blank">免费网站模板</a>
            <p class="description">有几百个免费网站模板下载，可以挑着看看</p>
          </li>
          <li class="hot-item"> <a href="http://www.wix.com/" class="website" target="_blank">享誉全球的 WIX</a>
            <p class="description">超赞！该站全球排名378！可以帮你免费定制网站</p>
          </li>
          <li> <a href="http://www.freewebtemplates.com/" class="website" target="_blank">免费模版库</a>
            <p class="description">历史悠久的老站点，1999年就致力于分享免费网站模版</p>
          </li>
          <li> <a href="http://www.templatesbox.com/" class="website" target="_blank">模版盒子</a>
            <p class="description">提供免费的模版和Flash下载，分类详细</p>
          </li>          
          <li> <a href="http://www.buytemplates.net/products/search" class="website" target="_blank">Buy Templates</a>
            <p class="description">一个卖网页模版的站点，大家可预览手工下载</p>
          </li>
          <li> <a href="http://themeforest.net/category/site-templates" class="website" target="_blank">ThemeForest</a>
            <p class="description">TF下的频道，业内最大的网站模板和CMS主题商城之一</p>
          </li>
          <li class="new-item"> <a href="http://www.gavick.com/" class="website" target="_blank">GavickPro</a>
            <p class="description">惊人且美丽的Joomla模板和WordPress主题</p>
          </li>                     
        </ul>
        <a href="/" class="more-item">更多</a> </div>
                <div class="area_section"  data-catalog="site">
            <div class="acticle_header">
          <h2 class="icon-site">酷站推荐</h2>
        </div>
        <ul class="website-list">
          <li class="hot-item"><a href="http://www.awwwards.com/" class="website" target="_blank">Awwwards</a>
            <p class="description">精挑细选世界各地的最佳网站！并对其打分颁奖</p>
          </li>
          <li><a href="http://www.csswinner.com/" class="website" target="_blank">CSS Winner</a>
            <p class="description">全球网页设计画廊，并对提交的佳作颁奖</p>
          </li>
          <li><a href="http://cssdesignawards.com/" class="website" target="_blank">CSS Design Awards</a>
            <p class="description">展示世界上最好的网站，激励全球网页设计师</p>
          </li>
          <li><a href="http://www.cssmania.com/" class="website" target="_blank">CSS狂热者</a>
            <p class="description">是全球最早采用CSS画廊展示网站的鼻祖</p>
          </li>
          <li><a href="http://www.besthtml5gallery.com/" class="website" target="_blank">HTML5 网站画廊</a>
            <p class="description">最好的html5网站画廊，含免费网站模板下载</p>
          </li>
          <li><a href="http://www.dzinemart.com/" class="website" target="_blank">Dzine灵感集市</a>
            <p class="description">CSS网页设计灵感画廊</p>
          </li>
          <li class="new-item"><a href="http://hao.uisdc.com/designer/" class="website" target="_blank">全球顶尖设计师名站</a>
            <p class="description">200个全球顶级WEB设计师名站欣赏，持续更新中</p>
          </li>
          <li class="new-item"><a href="http://reeoo.com/?s=app" class="website" target="_blank">App for Reeoo</a>
            <p class="description">国内人气最高的酷站画廊，设计App灵感必备</p>
          </li>
          <li class="new-item"><a href="http://freszki.nowymarketing.pl/" class="website" target="_blank">freszki</a>
            <p class="description">波兰网站！收集一些振奋人心的电子商务网站</p>
          </li>
          <li><a href="http://www.designbombs.com/" class="website" target="_blank">设计炸弹</a>
            <p class="description">收集、分享和发现世界各地有趣的CSS网站设计</p>
          </li>
          <li><a href="http://www.thebestdesigns.com/" class="website" target="_blank">The Best Designs</a>
            <p class="description">会定期对全球优秀网页设计师颁发最佳设计大奖</p>
          </li>
          <li class="new-item"><a href="http://bm.straightline.jp/" class="website" target="_blank">日本酷站索引</a>
            <p class="description">近6000个！av大合集也没这么全，必备酷站</p>
          </li>
        </ul>
        <a href="/" class="more-item">更多</a> </div>
                <div class="area_section"  data-catalog="inspiration">
            <div class="acticle_header">
          <h2 class="icon-inspiration">灵感创意</h2>
        </div>
        <ul class="website-list">
          <li class="hot-item"><a href="http://pinterest.com/all/?category=design" class="website" target="_blank">Pinterest</a>
            <p class="description">一个受世界瞩目的，全球最大的创意灵感图片分享网站</p>
          </li>
          <li><a href="http://www.baubauhaus.com/" class="website" target="_blank">Baubauhaus</a>
            <p class="description">提供设计灵感、插画摄影、时尚以及艺术相关的一切</p>
          </li>
          <li class="hot-item"><a href="http://huaban.com/?md=uisdc.com" class="website" target="_blank">花瓣</a>
            <p class="description">采集你喜欢的美好事物，发现新知，启发设计灵感</p>
          </li>          
          <li><a href="http://vi.sualize.us/" class="website" target="_blank">VisualizeUs</a>
            <p class="description">一个强悍的社会化创意图片收藏夹</p>
          </li>
          <li><a href="http://illusion.scene360.com/" class="website" target="_blank">幻觉</a>
            <p class="description">展示最惊人的创作，涵盖艺术、设计、摄影和视频</p>
          </li>
          <li><a href="http://www.booooooom.com/" class="website" target="_blank">BOOOOOOOM</a>
            <p class="description">发人深省的创意图片，博客设计简约但内容丰富</p>
          </li>
          <li class="new-item"><a href="http://www.thefwa.com/" class="website" target="_blank">FWA winner</a>
            <p class="description">怒赞！别和FWA谈创意，说再多都是矫情</p>
          </li>         
          <li class="hot-item"><a href="http://9gag.com/" class="website" target="_blank">9GAG</a>
            <p class="description">可能是全球最搞笑的趣图网站，笑可以带来更多灵感</p>
          </li>
          <li><a href="http://www.notcot.org/" class="website" target="_blank">NOTCOT</a>
            <p class="description">过滤掉不美的事物，每日灵感来源，让创意无所不在</p>
          </li>
          <li class="new-item"><a href="http://designtaxi.com/" class="website" target="_blank">Design TAXI</a>
            <p class="description">被福布斯誉为最具创意和设计感的五大网站之一</p>
          </li>         
          <li><a href="http://weheartit.com/" class="website" target="_blank">We Heart It</a>
            <p class="description">让鼓舞人心的图像唤醒生活情趣，激发设计灵感</p>
          </li>
          <li class="hot-item"><a href="http://butdoesitfloat.com/" class="website" target="_blank">butdoesitfloat</a>
            <p class="description">网站的图片很吸引眼球，优设哥向你保证</p>
          </li>
        </ul>
        <a href="/" class="more-item">更多</a> </div>
                <div class="area_section"  data-catalog="font">
            <div class="acticle_header">
          <h2 class="icon-font">字体设计</h2>
        </div>
        <ul class="website-list">
          <li class="new-item"><a href="http://ziti.admin5.com/" class="website" target="_blank">A5字体下载</a>
            <p class="description">国内较全的字体库，提供中英文字体预览、打包下载</p>
          </li>
          <li><a href="http://www.addictivefonts.com/" class="website" target="_blank">上瘾的字体</a>
            <p class="description">最好的英文字体，下载免费可用于商业用途</p>
          </li>
          <li class="new-item"><a href="http://www.abstractfonts.com/" class="website" target="_blank">Abstract Fonts</a>
            <p class="description">超过十三万免费字体下载，包括大热的web字体</p>
          </li>
          <li><a href="http://www.typographyserved.com/" class="website" target="_blank">TypographyServed</a>
            <p class="description">推荐！字体专题频道，汇聚字体设计、印字、排版</p>
          </li>
          <li><a href="http://fontfabric.com/" class="website" target="_blank">Font Fabric</a>
            <p class="description">免费高品质字体打包下载</p>
          </li>
          <li><a href="https://www.fontfont.com/fonts" class="website" target="_blank">FontFont</a>
            <p class="description">字体巨擘！强大的字体检索引擎，收编无数优质字体</p>
          </li>
          <li><a href="http://www.linotype.com/catalog" class="website" target="_blank">LinoType</a>
            <p class="description">超过10500个高质量的字体下载，从古典到时尚</p>
          </li>
          <li><a href="http://www.fonts2u.com/index.html" class="website" target="_blank">Fonts2u</a>
            <p class="description">Fonts2u首屏的字体检索超强大，找字体很方便</p>
          </li>
          <li><a href="http://typophile.com/" class="website" target="_blank">印刷达人</a>
            <p class="description">一个比较高端的有关字体设计、印刷排版的交流圈子</p>
          </li>
          <li class="new-item"><a href="http://www.losttype.com/browse/" class="website" target="_blank">Lost Type</a>
            <p class="description">推荐：字体都非常漂亮，展示方式悦目清新</p>
          </li>
          <li><a href="http://icomoon.io/app/" class="website" target="_blank">IcoMoon</a>
            <p class="description">强悍的WEB字体制造器，提供图片版和字体版下载</p>
          </li>
          <li class="new-item"><a href="http://www.fontsquirrel.com/" class="website" target="_blank">字体松鼠</a>
            <p class="description">赞！100%免费下载可商用！专为设计师精心挑选</p>
          </li>
        </ul>
        <a href="/" class="more-item">更多</a> </div>
                <div class="area_section"  data-catalog="blog">
            <div class="acticle_header">
          <h2 class="icon-blog">行业名博</h2>
        </div>
        <ul class="website-list">
          <li><a href="http://cdc.tencent.com/" class="website" target="_blank">腾讯CDC</a>
            <p class="description">腾讯用户研究与体验设计中心，腾讯的核心部门之一</p>
          </li>
          <li><a href="http://ueo.baidu.com/" class="website" target="_blank">百度联盟用户体验中心</a>
            <p class="description">百度联盟事业部用户体验团队官方博客</p>
          </li>
          <li><a href="http://ued.taobao.com/blog/" class="website" target="_blank">淘宝UED</a>
            <p class="description">淘宝UED团队官方博客</p>
          </li>
          <li><a href="http://tgideas.qq.com/" class="website" target="_blank">腾讯TGideas</a>
            <p class="description">腾讯游戏官方设计团队</p>
          </li>
          <li><a href="http://udc.weibo.com/" class="website" target="_blank">新浪微博UDC</a>
            <p class="description">微博用户研究与体验设计中心博客</p>
          </li>
          <li><a href="http://ued.baidu.com/" class="website" target="_blank">百度商业UED团队</a>
            <p class="description">百度商业产品用户体验团队，以体验驱动商业价值</p>
          </li>
          <li><a href="http://mux.baidu.com/" class="website" target="_blank">百度MUX</a>
            <p class="description">百度无线用户体验部官方博客</p>
          </li>
          <li><a href="http://uxc.360.cn/" class="website" target="_blank">360UXC</a>
            <p class="description">奇虎360 UXC用户体验设计中心</p>
          </li>
          <li><a href="http://ecd.tencent.com/" class="website" target="_blank">腾讯ecd</a>
            <p class="description">腾讯电商用户体验设计部</p>
          </li>
          <li><a href="http://vc.changyou.com/" class="website" target="_blank">搜狐畅游视觉设计中心</a>
            <p class="description">搜狐畅游视觉设计中心团队博客</p>
          </li>
          <li><a href="http://www.lpued.com/?category_name=all" class="website" target="_blank">良无限-UED</a>
            <p class="description">无名良品用户体验团队博客</p>
          </li>
          <li><a href=" http://ux.etao.com/" class="website" target="_blank">一淘UX团队</a>
            <p class="description">阿里巴巴一淘用户体验部门官方博客</p>
          </li>
        </ul>
        <a href="/" class="more-item">更多</a> </div>
                <div class="area_section"  data-catalog="infographic">
            <div class="acticle_header">
          <h2 class="icon-infographic">信息图</h2>
        </div>
        <ul class="website-list">
          <li class="hot-item"><a href="http://visual.ly/" class="website" target="_blank">Visual</a>
            <p class="description">各种各样的漂亮信息图！学信息图设计的同学必备</p>
          </li>
          <li class="hot-item"><a href="http://www.good.is/infographics" class="website" target="_blank">GOOD</a>
            <p class="description">GOOD信息图，前沿时尚、用色考究的信息图设计</p>
          </li>
          <li><a href="http://www.best-infographics.com/" class="website" target="_blank">Best Infographics</a>
            <p class="description">省事！帮你搜寻互联网上每天最热门的信息图</p>
          </li>
          <li class="new-item"><a href="http://news.qq.com/newspedia/all.htm" class="website" target="_blank">图表腾讯</a>
            <p class="description">推荐！腾讯的新闻百科，中文信息图设计得很不错</p>
          </li>
          <li><a href="http://www.tuyansuo.com/" class="website" target="_blank">图研所</a>
            <p class="description">一睹世界各地出色信息图案例，信息视觉化专业网站</p>
          </li>
          <li><a href="http://picsays.com/" class="website" target="_blank">图说</a>
            <p class="description">专注信息图表达，每天定量更新优质信息图</p>
          </li>
          <li class="new-item"><a href="http://roll.news.sina.com.cn/chart/index.shtml" class="website" target="_blank">新浪图解天下</a>
            <p class="description">新闻视觉化，以图达意，轻松直观的阅读体验</p>
          </li>
          <li><a href="http://news.sohu.com/s2011/matrix-huizong/" class="website" target="_blank">搜狐 数字之道</a>
            <p class="description">数字剖析新闻，图表读懂社会。民生数据，简明图表</p>
          </li>
          <li><a href="http://www.coolinfographics.com/" class="website" target="_blank">超酷信息图</a>
            <p class="description">顶级的数据可视化和信息图博客</p>
          </li>
          <li><a href="http://infosthetics.com/" class="website" target="_blank">信息美学可视化</a>
            <p class="description">一场信息化设计的美学盛宴</p>
          </li>
          <li class="new-item"><a href="http://data.163.com/special/datablog/" class="website" target="_blank">网易数读</a>
            <p class="description">网易数据新闻，有大量信息图、图表、及数据分析</p>
          </li>
          <li><a href="http://www.informationisbeautiful.net/" class="website" target="_blank">美丽信息图</a>
            <p class="description">一位信息图设计师的网站，爱馅饼讨厌饼图</p>
          </li>
        </ul>
        <a href="/" class="more-item">更多</a> </div>
                <div class="area_section"  data-catalog="interactive">
            <div class="acticle_header">
          <h2 class="icon-interactive">交互设计</h2>
        </div>
        <ul class="website-list">
          <li><a href="http://ui-patterns.com/" class="website" target="_blank">UI-Patterns</a>
            <p class="description">为资深用户界面设计师寻提供灵感和参考的宝库</p>
          </li>
          <li class="hot-item"><a href="http://codepen.io/" class="website" target="_blank">代码笔</a>
            <p class="description">codepen！寻找交互灵感的圣地</p>
          </li>
          <li><a href="http://uxmag.com/" class="website" target="_blank">UX Magazine</a>
            <p class="description">提供稳定、丰富、可靠的一站式用户体验资源</p>
          </li>
          <li><a href="http://www.axure.org/" class="website" target="_blank">WebPPD</a>
            <p class="description">产品原型设计，夯实你做产品经理的基本功</p>
          </li>
          <li><a href="http://ux.stackexchange.com/" class="website" target="_blank">User Experience</a>
            <p class="description">人气问答站，设计师和用户体验专家常在那里鬼混</p>
          </li>
          <li><a href="http://www.uxbooth.com/articles/" class="website" target="_blank">UX Booth</a>
            <p class="description">资深用户体验、交互设计师的交流社区</p>
          </li>
          <li><a href="http://www.uxpond.com/" class="website" target="_blank">UX Pond</a>
            <p class="description">一个专注用户体验资讯、技术、工具的搜索引擎</p>
          </li>
          <li><a href="http://johnnyholland.org/" class="website" target="_blank">Johnny Holland</a>
            <p class="description">这里只聊交互设计</p>
          </li>
          <li class="new-item"><a href="http://fff.cmiscm.com/" class="website" target="_blank">交互神站：FFF</a>
            <p class="description">前所未有的网页交互体验！震惊你的各种交互特效</p>
          </li>
          <li class="new-item"><a href="http://jumpui.com/" class="website" target="_blank">交互案例分享</a>
            <p class="description">每周分享各种Web和App上各种有意思的交互案例</p>
          </li>
          <li><a href="http://tympanus.net/codrops/" class="website" target="_blank">Codrops</a>
            <p class="description">提供有用的、启发灵感的网络资源和交互案例</p>
          </li>
          <li><a href="http://www.uie.com/articles/" class="website" target="_blank">UIE</a>
            <p class="description">世界上最大的可用性研究组织。</p>
          </li>
        </ul>
        <a href="/" class="more-item">更多</a> </div>
                <div class="area_section"  data-catalog="illustrated">
            <div class="acticle_header">
          <h2 class="icon-illustrated">漫画插图</h2>
        </div>
        <ul class="website-list">
          <li class="hot-item"><a href="http://www.pixiv.net/" class="website" target="_blank">P站！</a>
            <p class="description">大名鼎鼎的日本高清同人画、插画作品分享站</p>
          </li>
          <li class="hot-item"><a href="http://sakiroo.com/" class="website" target="_blank">SAKIROO</a>
            <p class="description">韩国插画设计网，人设为主</p>
          </li>
           <li><a href="http://www.illustrationserved.com/" class="website" target="_blank">插画驿站</a>
            <p class="description">Behance旗下的插画网</p>
          </li>         
          <li><a href="http://coolvibe.com/" class="website" target="_blank">Cool Vibe</a>
            <p class="description">超酷！展示高清插画壁纸以及动漫、梦幻图片的地方</p>
          </li>
          <li><a href="http://www.pidjin.net/" class="website" target="_blank">Fredo and Pidjin</a>
            <p class="description">世界上最有趣的网络漫画</p>
          </li>
          <li><a href="http://www.howtoons.com/" class="website" target="_blank">Howtoons</a>
            <p class="description">一个原创卡通动漫站点，也有不错的教程和图库资源</p>
          </li>
          <li class="hot-item"><a href="http://www.creativeuncut.com/" class="website" target="_blank">Creative Uncut</a>
            <p class="description">推荐！游戏角色原型设计网</p>
          </li>
          <li class="new-item"><a href="http://drawr.net/" class="website" target="_blank">drawr</a>
            <p class="description">漫画菜鸟必备！可以观看别人的绘画过程</p>
          </li>         
          <li><a href="http://www.illustrationmundo.com/" class="website" target="_blank">插画世界</a>
            <p class="description">一个聚集世界各地优秀插画家及作品的网站</p>
          </li>
          <li><a href="http://diterlizzi.com/home/" class="website" target="_blank">Tony DiTerlizzi</a>
            <p class="description">强力推荐：著名插画家托尼的个人网站</p>
          </li>
          <li class="hot-item"><a href="http://www.illustrationweb.com/styles" class="website" target="_blank">插画家经纪人</a>
            <p class="description">一个历史悠久的提供可靠插画家及插画资源的平台</p>
          </li>
           <li><a href="http://www.cartoonstock.com/" class="website" target="_blank">CartoonStock</a>
            <p class="description">漫画搜索引擎，超过30万幅幽默、政治、卡通漫画</p>
          </li>
        </ul>
        <a href="/" class="more-item">更多</a> </div>
                <div class="area_section"  data-catalog="infomation">
            <div class="acticle_header">
          <h2 class="icon-infomation">互联网讯</h2>
        </div>
        <ul class="website-list">
          <li class="hot-item"><a href="http://www.w3.org/" class="website" target="_blank">W3C官网</a>
            <p class="description">这是互联网的基础，推荐及时了解前端最新资讯</p>
          </li>
          <li><a href="http://www.ifanr.com/" class="website" target="_blank">爱范儿</a>
            <p class="description">发现创新价值的科技媒体，全景关注移动互联网</p>
          </li>
          <li class="hot-item"><a href="http://www.alibuybuy.com/" class="website" target="_blank">互联网的那点事</a>
            <p class="description">聚焦互联网前沿资讯，网络精华内容，交流产品心得！</p>
          </li>
          <li class="hot-item"><a href="http://www.w3school.com.cn/" class="website" target="_blank">w3school在线教程</a>
            <p class="description">全球最大的中文Web技术教程</p>
          </li>
          <li class="new-item"><a href="http://www.geekpark.net/" class="website" target="_blank">极客公园</a>
            <p class="description">报道互联网热门趋势、热点产品的深度分析。</p>
          </li>
          <li><a href="http://www.cnbeta.com/" class="website" target="_blank">cnBeta中文IT资讯站</a>
            <p class="description">提供最新最快的IT业界资讯</p>
          </li>
          <li><a href="http://www.leiphone.com/" class="website" target="_blank">雷锋网</a>
            <p class="description">专注于移动互联网创业及创新的人气科技博客</p>
          </li>
          <li><a href="http://www.donews.com/" class="website" target="_blank">DoNews</a>
            <p class="description">中国互联网从业人士交流最权威的平台</p>
          </li>
          <li><a href="http://tech.163.com/" class="website" target="_blank">网易科技</a>
            <p class="description">有态度！以独特视角呈现科技圈内大事小事</p>
          </li>
          <li class="new-item"><a href="http://www.newhua.com/" class="website" target="_blank">牛华网</a>
            <p class="description">华军软件园旗下网站，第一时间提供最具价值IT资讯</p>
          </li>
          <li><a href="http://www.chinabyte.com/" class="website" target="_blank">ChinaByte比特网</a>
            <p class="description">中国最具影响力和商业价值的IT门户</p>
          </li>
          <li class="hot-item"><a href="http://www.reddit.com/" class="website" target="_blank">Reddit</a>
            <p class="description">互联网第一大社交新闻站点。别看长相，看内涵</p>
          </li>
        </ul>
        <a href="/" class="more-item">更多</a> </div>
                <div class="area_section"  data-catalog="company">
            <div class="acticle_header">
          <h2 class="icon-company">设计公司</h2>
        </div>
        <ul class="website-list">
          <li class="hot-item"><a href="http://www.f-i.com/work/all" class="website" target="_blank">Fi</a>
            <p class="description">享誉全球的著名互动设计公司</p>
          </li>
          <li><a href="http://landor.com/" class="website" target="_blank">Landor 朗涛</a>
            <p class="description">全球最大的品牌策略顾问与设计公司</p>
          </li>
          <li><a href="http://www.pentagram.com/" class="website" target="_blank">五角设计</a>
            <p class="description">世界最富盛名的设计公司之一，1972年在英国成立</p>
          </li>
          <li><a href="http://www.ogilvy.com.cn/" class="website" target="_blank">奥美</a>
            <p class="description">世界上最大的市场传播机构之一</p>
          </li>
          <li><a href="http://www.eicodesign.com/index" class="website" target="_blank">eico design</a>
            <p class="description">成立于2004年，国内最早的专业界面设计团队</p>
          </li>
          <li><a href="http://ala.ch/" class="website" target="_blank">ala</a>
            <p class="description">创于1999，你可以在他们这看到流行设计趋势</p>
          </li>
          <li class="new-item"><a href="http://45royale.com/" class="website" target="_blank">45royale</a>
            <p class="description">创建于2006年，极具人气的设计团队，作品干净、优雅</p>
          </li>
          <li class="new-item"><a href="http://www.tg-vision.com/" class="website" target="_blank">TG-vision 双晖传媒</a>
            <p class="description">成立于2006年，专业用户体验设计团队。</p>
          </li>
          <li class="new-item"><a href="http://www.uelike.com/" class="website" target="_blank">优艺客</a>
            <p class="description">一家北京设计创意公司，首页被很多工作室模仿</p>
          </li>
          <li><a href="http://www.akqa.com/" class="website" target="_blank">雅酷 AKQA</a>
            <p class="description">全球拿奖最多的知名互动创意公司</p>
          </li>
          <li class="hot-item"><a href="http://www.2advanced.com/" class="website" target="_blank">2advanced Studios</a>
            <p class="description">美国最具专业技术和创意团队之一，打造顶尖交互网站</p>
          </li>
          <li><a href="http://www.tbwa.com/" class="website" target="_blank">李岱艾广告公司</a>
            <p class="description">TBWA是全球增长最快的跨国广告公司</p>
          </li>
        </ul>
        <a href="/" class="more-item">更多</a> </div>
                <div class="area_section"  data-catalog="tool">
            <div class="acticle_header">
          <h2 class="icon-tool">神器推荐</h2>
        </div>
        <ul class="website-list">
          <li class="hot-item"><a href="http://www.bootcss.com/" class="website" target="_blank">Bootstrap</a>
            <p class="description">Twitter推出的简洁、直观、强悍的前端开发框架</p>
          </li>
          <li><a href="http://www.uisdc.com/ps-coolorus1-0" class="website" target="_blank">配色神器Coolorus</a>
            <p class="description">高端色轮插件，秒杀市面上大部分网页配色工具</p>
          </li>
          <li><a href="http://www.uisdc.com/froont" class="website" target="_blank">响应式网页设计工具</a>
            <p class="description">Froont！一个允许设计师在线设计响应式网页的工具</p>
          </li>
          <li class="hot-item"><a href="http://e.weibo.com/1773655610/yjK1C9DpH" class="website" target="_blank">全能取色神器Pixeur</a>
            <p class="description">有和PS一样的全能取色窗，更有贴心配色方案</p>
          </li>
          <li class="new-item"><a href="http://www.uisdc.com/top-10-codefree-website-builders" class="website" target="_blank">全球10大建站神器</a>
            <p class="description">全球备受赞誉的智能建站工具大揭密，不用编码</p>
          </li>         
          <li class="new-item"><a href="http://www.uisdc.com/indispensable-tool" class="website" target="_blank">设计师必备工具推荐</a>
            <p class="description">40个国外同行总结的超人气设计工具</p>
          </li>
          <li class="new-item"><a href="http://www.sitestar.cn/" class="website" target="_blank">SiteStar！建站之星</a>
            <p class="description">国内著名免费建站神器，无拘无束创建属于您的网站</p>
          </li>
            <li><a href="http://webcolourdata.com/" class="website" target="_blank">Web Colour Data</a>
            <p class="description">从今天起，你可以快速获取地球上想要的网站配色方案</p>
          </li>        
          <li class="hot-item"><a href="http://www.uisdc.com/ps-play" class="website" target="_blank">Ps Play</a>
            <p class="description">手机同步实时预览电脑PS画面，移动设计零阻力</p>
          </li>
          <li><a href="http://www.uisdc.com/clippingmagic" class="website" target="_blank">ClippingMagic</a>
            <p class="description">抠图神器！超赞的在线智能抠图工具</p>
          </li>
          <li><a href="http://www.svgeneration.com/" class="website" target="_blank">在线背景纹理生成器</a>
            <p class="description">SVGeneration！大家可以自由定制，换颜色换细节</p>
          </li>     
          <li class="hot-item"><a href="http://pixlr.com/editor/" class="website" target="_blank">pixlr</a>
            <p class="description">备受好评的在线版PS，到哪都能PS了</p>
          </li>
        </ul>
        <a href="/" class="more-item">更多</a> </div>
                <div class="area_section"  data-catalog="learn">
            <div class="acticle_header">
          <h2 class="icon-learn">设计培训</h2>
        </div>
        <ul class="website-list">
          <li class="hot-item"><a href="http://www.uidesign.cc/prospect/" class="website" target="_blank">莱茵教育</a>
            <p class="description">UI设计教育领导者，国内首家UI设计连锁教育机构</p>
          </li>
          <li><a href="http://www.cgsociety.org/" class="website" target="_blank">CG Society</a>
            <p class="description">权威的CG创意设计基地，有专业的技能培训</p>
          </li>  
          <li class="new-item"> <a href="http://www.si27.com/" class="website" target="_blank">星狮创想</a>
            <p class="description">国内首家UI及UED设计培训机构，良心育人，品质保障</p>
          </li>           
          <li><a href="http://www.duobei.com/search/course?word=%E8%AE%BE%E8%AE%A1" class="website" target="_blank">多贝网络教室</a>
            <p class="description">在线的实时互动教学平台，有一些设计培训讲座</p>
          </li> 
          <li><a href="http://99ut.blueidea.com/" class="website" target="_blank">Unify Tutorial</a>
            <p class="description">在线设计教学网，以PS及其基础知识作为起点教学</p>
          </li> 
          <li><a href="https://tutsplus.com/course/photoshop-techniques-for-web-designers/" class="website" target="_blank">TutsPlus 网页教学视频</a>
            <p class="description">视频教学，TutsPlus二级频道下的网页教学视频</p>
          </li>
          <li><a href="https://www.udemy.com/photoshop-cs6-crash-course/" class="website" target="_blank">Udemy</a>
            <p class="description">Udemy！国外一家在线教学网络培训平台</p>
          </li>            
          <li><a href="http://www.video2brain.com/en/web-mobile-design" class="website" target="_blank">Video2Brain</a>
            <p class="description">在线视频课程培训平台，高达2000个教学视频</p>
          </li>
          <li><a href="http://study.163.com/plan/planIntroduction.htm?id=425569#/planIntroduction" class="website" target="_blank">网易云课堂</a>
            <p class="description">设计师的自我修炼，网易全新概念互联网教育课堂</p>
          </li>
          <li><a href="http://www.vectordiary.com/illustrator/illustrator-training-course/" class="website" target="_blank">vectordiary</a>
            <p class="description">Illustrator 30天入门，全球热传的人气课程</p>
          </li> 
           <li><a href="http://www.illustratorsaustralia.com/" class="website" target="_blank">澳大利亚插画部落</a>
            <p class="description">一个提供插画设计及教程培训的爱好者联盟组织</p>
          </li>
          <li><a href="http://www.howcast.com/guides/952-How-to-Photoshop" class="website" target="_blank">Howcast</a>
            <p class="description">Howcast教学视频栏目的PS基础课程</p>
          </li>  
        </ul>
        <a href="/" class="more-item">更多</a> </div>
          <div class="area_section"  data-catalog="weibo">
            <div class="acticle_header">
          <h2 class="icon-weibo">热门微博</h2>
        </div>
        <ul class="website-list">
          <li class="hot-item"><a href="http://weibo.com/mobiweb" class="website" target="_blank">移动WEB前端设计</a>
            <p class="description">前端牛人的微博，分享超炫的HTML5和CSS3干货</p>
          </li>
          <li class="hot-item"><a href="http://weibo.com/alibuybuy" class="website" target="_blank">互联网的那点事</a>
            <p class="description">互联网人气最高的微博之一，各种内幕、小道消息、行业段子</p>
          </li>
          <li><a href="http://e.weibo.com/zhihu" class="website" target="_blank">知乎</a>
            <p class="description">一个真实的网络问答社区，帮你寻找答案，分享知识</p>
          </li>
          <li><a href="http://weibo.com/208235676" class="website" target="_blank">我爱ppt</a>
            <p class="description">100%活人账号 一个热爱生活，喜欢分享各类PPT的人</p>
          </li>
          <li><a href="http://weibo.com/u/1863948211" class="website" target="_blank">手机iphone频道</a>
            <p class="description">这是iphone迷的聚集地，新浪iphone类人气微博</p>
          </li>
          <li><a href="http://weibo.com/fenng" class="website" target="_blank">Fenng</a>
            <p class="description">手艺人，特别推荐他的微信：小道消息，很火的哟</p>
          </li>
          <li><a href="http://e.weibo.com/uidesign" class="website" target="_blank">优秀网页设计</a>
            <p class="description">网页设计干货微博！每日更新及时，推荐关注</p>
          </li>
          <li><a href="http://e.weibo.com/manziwenzhai" class="website" target="_blank">蛮子文摘</a>
            <p class="description">设计师除了设计，更应该关注家事国事天下事</p>
          </li>
          <li><a href="http://e.weibo.com/wepan" class="website" target="_blank">微盘</a>
            <p class="description">优设哥分享设计资源和干货就靠微盘了，强烈推荐</p>
          </li>
          <li><a href="http://weibo.com/baiduuxc" class="website" target="_blank">百度用户体验部</a>
            <p class="description">百度最大的设计团队，由215名设计师组成</p>
          </li>
          <li><a href="http://weibo.com/qiushid" class="website" target="_blank">求是设计会</a>
            <p class="description">超人气的设计类微博，传承信仰，继续热情</p>
          </li>
          <li><a href="http://weibo.com/honghaier555" class="website" target="_blank">你丫才美工</a>
            <p class="description">严格意义来讲，打水印和打码一样，都是下流的凑性</p>
          </li>          
        </ul>
        <a href="/" class="more-item">更多</a> </div>
            </div>
            <%--  <div class="tips">
        <div class="guide">
            <span class="mark"> 
                <i class="mark-hot">最热</i> <i class="mark-new">最新</i> 
            </span> 
            <a class="uisdc" href="http://www.uisdc.com/" target="_blank">优设首页</a>
        </div>
        <em class="slogan"><a style="color:#fa5f5f" ;="" target="_blank" href="http://www.uisdc.com/">学网页，到优设</a></em> 
        <span class="hot-words"><b style="opacity: 1; ">大家在关注：</b><a href="http://www.uisdc.com/category/hot-download/tools-download" class="website" target="_blank" style="opacity: 1; "><strong>神器下载</strong></a><a href="http://www.uisdc.com/category/hot-download/texture-and-background" class="website" target="_blank" style="opacity: 1; "><strong>纹理打包下载</strong></a><a href="http://www.uisdc.com/34-designers-book" class="website" target="_blank" style="opacity: 1; "><strong>设计师图书推荐</strong></a><a href="http://www.uisdc.com/24-kinds-of-new-way-of-interaction" class="website" target="_blank" style="opacity: 1; "><strong>新兴交互设计</strong></a></span>
    </div>--%>
        </div>
    </div>
    <script>
        
        //$('.h5-list .list').append($('<div class="h5_pos"></div>'));
        $('.h5-list .h5_box').afterbind('mouseenter', function (e) {
            if (!$(this).children('.block_op').is(":animated")) {
                var m = getMousePos(e);
                var i = $(this).parent();
                var w = 200;
                var lt = $(this).offset();
                var lb = i.find('.h5_pos').offset();
                var h = lb.top - lt.top;
                var temp = 50;
                if (m.x < lt.left + temp && m.y > lt.top + temp && m.y < lt.top + h - temp) {
                    $(this).find('.info').stop().show().op(1).t(-10).l(-w-20).a({ left: -10 }, 200);
                } else if (m.x > lt.left + w - 20 && m.y > lt.top + temp && m.y < lt.top + h - temp) {
                    $(this).find('.info').stop().show().op(1).op(1).t(-10).l(w+20).a({ left: -10 }, 200);
                } else if (m.y < lt.top + temp) {
                    $(this).find('.info').stop().show().op(1).l(-10).t(-h-20).a({ top: -10 }, 200);
                } else if (m.y > lt.top + h - temp) {
                    $(this).find('.info').stop().show().op(1).l(-10).t(h+20).a({ top: -10 }, 200);
                }
            }
        });
        $('.h5-list .h5_box').afterbind('mouseleave', function (e) {
            var m = getMousePos(e);
            var i = $(this).parent();
            var w = 200;
            var lt = $(this).offset();
            var lb = i.find('.h5_pos').offset();
            var h = lb.top - lt.top;
            var temp = 0;
            if (m.x > lt.left + w) {
                $(this).find('.info').stop().show().a({ left: w + 20 }, 200);
            } else if (m.x < lt.left) {
                $(this).find('.info').stop().show().a({ left: -w - 30 }, 200);
            } else if (m.y > lb.top - 20) {
                $(this).find('.info').show().a({ top: h+20 }, 200);
            } else if (m.y < lt.top) {
                $(this).find('.info').stop().show().a({ top: -h-20 }, 200);
            } else {

            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
