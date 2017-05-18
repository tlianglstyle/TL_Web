<%@ Page Title="" Language="C#" MasterPageFile="~/jxchart/Main.Master" AutoEventWireup="true" CodeBehind="intro.aspx.cs" Inherits="TL.Web.jxchart.intro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="c/intro.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="content">
<a class="pageStart" href="use.aspx">开始</a>
<a class="pageBack" onclick="javascript:history.go(-1);">返回</a>
<div style="position: absolute;top:0px;left:0px;width:100%;background: #1FB1E2;height: 735px;"></div><div style="width:100%;position:absolute;">
<div style="height: 3680px;width:1024px;background: url(i/intro/bg_intro.jpg) 0px -218px;margin:0px auto;z-index: 10000;">
<div style="height: 257px;width: 600px;background: url(i/intro/logo_intro.png) 0px 0px;margin:0px auto;margin-top: 60px;z-index: 10001;"></div>
</div>
 </div></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
