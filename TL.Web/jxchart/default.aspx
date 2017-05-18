<%@ Page Title="" Language="C#" MasterPageFile="~/jxchart/Main.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TL.Web.jxchart._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="c/main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="menu_main">
<ul>
<li class="first"><a class="logo" href="main.aspx"></a></li>
<li><a href="use.aspx">使用</a></li>
<li><a href="intro.aspx">介绍</a></li>
<li><a href="example.aspx">示例</a></li>
<li class="last"><a href="stat.aspx">统计</a></li>
</ul>

</div>
<div class="menubtn">
<a class="startUse" href="use.aspx"></a>
<a class="showDemo" href="intro.aspx"></a>
</div>
<div class="others">
<a href="use.aspx" style="margin-right: 40px;"><img src="i/main/main_other_1.jpg" /></a>
<a href="use.aspx"><img src="i/main/main_other_2.jpg" /></a>
</div>
    <a href="#" id="bt-view-live" style="left: 0px;"></a>
    <div id="box-live-test">
        <ul class="live-animation">
            <li><a href="" rel="cube">商务</a></li>
            <li><a href="" rel="cubeRandom">教育</a></li>
            <li><a href="" rel="block">科技</a></li>
            <li><a href="" rel="cubeStop">报告</a></li>
            <li><a href="" rel="cubeHide">自然</a></li>
            <li><a href="" rel="cubeSize">人物</a></li>
            <li><a href="" rel="horizontal">环保</a></li>
            <li><a href="" rel="showBars">节日</a></li>
            <li><a href="" rel="showBars">培训</a></li>
            <li><a href="" rel="showBars">休闲</a></li>
            <li><a href="" rel="showBars">医疗</a></li>
            <li><a href="" rel="showBars">其他</a></li>
        </ul>
    </div>
    <div id="bg-test-animations">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
