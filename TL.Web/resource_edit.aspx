<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="resource_edit.aspx.cs" Inherits="TL.Web.resource_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script charset="gbk" src="/j/editor/editor_all.js" type="text/javascript"></script>
    <script charset="gbk" src="/j/editor/editor_config.js" type="text/javascript"></script>
    <link href="/j/editor/themes/default/ueditor.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/j/jquery-easyui-1.3.2/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/j/jquery-easyui-1.3.2/themes/icon.css" />
    <script type="text/javascript" src="/j/jquery-easyui-1.3.2/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/j/jquery-easyui-1.3.2/locale/easyui-lang-zh_CN.js"></script>
    <link href="/j/uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/j/uploadify/swfobject.js"></script>
    <script type="text/javascript" src="/j/uploadify/jquery.uploadify.min.js"></script>
    <style type="text/css">
        .info-add
        {
            position: relative;
            margin-left: 10px;
            min-height: 100px;
            clear: both;
            padding-bottom: 20px;
            border-radius: 4px;
        }
        .info-add .title
        {
            color: #333333;
            font-size: 14px;
            font-weight: bold;
            line-height: 30px;
            width: 60px;
        }
        .info-add .content
        {
            min-height: 400px;
            width: 1024px;
            background-color: #FAFAFA;
            border: 1px solid #F4F4F4;
        }
        .info_color ul
        {
            width1: 100%;
            border: 1px solid #eee;
            overflow: hidden;
            min-height: 40px;
            max-height: 70px;
            background-color: white;
            padding: 5px 10px;
        }
        .info_color ul li
        {
            width1: 145px;
            height: 20px;
            float: left;
            font-size: 15px;
            cursor: pointer;
            padding: 2px 5px;
        }
        .info_color ul li a:hover
        {
            background-color: #E3FDDA;
            border-radius: 3px;
            text-decoration: none;
        }
        .info_color ul li.c a
        {
            background-color: #419413;
            border-radius: 3px;
            color: white;
        }
        .info_color a
        {
            color: #7C7C7C;
            padding: 3px 8px;
            white-space: nowrap;
        }
        
        .info_type ul
        {
            width1: 100%;
            border: 1px solid #eee;
            overflow: hidden;
            min-height: 40px;
            max-height: 70px;
            background-color: white;
            padding: 5px 10px;
        }
        .info_type ul li
        {
            width1: 145px;
            height: 20px;
            float: left;
            font-size: 15px;
            cursor: pointer;
            padding: 2px 5px;
        }
        .info_type ul li a:hover
        {
            background-color: #E3FDDA;
            border-radius: 3px;
            text-decoration: none;
        }
        .info_type ul li.c a
        {
            background-color: #419413;
            border-radius: 3px;
            color: white;
        }
        .info_type a
        {
            color: #7C7C7C;
            padding: 3px 8px;
            white-space: nowrap;
        }
        
        .uploadify-button
        {
            background-color: transparent;
            border: none;
            padding: 0;
        }
        .uploadify:hover .uploadify-button
        {
            background-color: transparent;
        }
    </style>
    <script type="text/javascript">
        var id = 0;
        $(function () {
            id = parastr("id");
            if (parastr("id") != null)
                $('#infoid').val(id);
            else
                $('#infoid').val("0");
            var editor;
            var editorOption = {
                //                toolbars: [[
                //                'insertimage',
                //                'link',
                //                'emotion'
                //                ]],
                pasteplain: true,
                //focus时自动清空初始化时的内容
                autoClearinitialContent: true,
                //关闭字数统计
                wordCount: false,
                //关闭elementPath
                elementPathEnabled: false,
                //更多其他参数，请参考editor_config.js中的配置项
                minFrameHeight: 360
            }
            editor = new baidu.editor.ui.Editor(editorOption);
            editor.render("infoContent");

            $("#infoName").val("");
            $('#info_form').form({
                onSubmit: function () {
                    editor.sync();
                    if (!$("#infoName").val()) {
                        alert("标题不能为空！");
                        $("#infoName").focus();
                        return false;
                    }
                    $("#infoRemark").val($("#infoRemark").val().toString().replace(new RegExp("<br>", "gm"), ""));
                },
                success: function (data) {
                    if (data != "0") {
                        id = data;
                        if ($('#cbx_img').is(':checked')) {
                            if ($("#queue > div").length > 0) {
                                $("#file_upload").uploadify("settings", "formData", { "id": id, "AddTime": "true" }); //设置表单数据
                                $("#file_upload").uploadify("upload");
                            }
                        }
                        if ($('#cbx_img_content').is(':checked')) {
                            uploadlenth = $("#queue_content > div").length;
                            if ($("#queue_content > div").length > 0) {
                                $("#file_upload_content").uploadify("settings", "formData", { "id": id, "AddTime": "true" }); //设置表单数据
                                $("#file_upload_content").uploadify("upload", "*");
                            }
                        }
                        if ($('#cbx_img_content').is(':checked')) {
                            var ii = setInterval(function () {
                                if ($("#queue_content > div").length == 0) {
                                    clearInterval(ii);
                                    //alert('操作成功');

                                    $('#infoName').val('');
                                    $('#infoUrl').val('');
                                }
                            }, 200);
                        } else {
                            //alert('操作成功'); 
                            $('#infoName').val('');
                            $('#infoUrl').val('');
                        }

                    } else {
                        alert("提交失败");
                    }
                }
            });
            $("#info_form .btn-submit").click(function () {
                if ($('.info_color li.c').length == 0) { alert('至少选择一个标签'); }
                else if ($('.info_type li.c').length == 0) { alert('至少选择一个标签'); }
                else {
                    $('#infoContentValue').val(htmlEncode(editor.getContent()));
                    $('#info_form').submit();
                }
            });
            $("#info_form .btn-reset").click(function () {
                $('#infoName').val('');
                $('#infoUrl').val('');
            });

            $('.info_color li').toggle(function () {
                $(this).addClass('c');
                $('#colorData_t').val('');
                $('.info_color li.c').each(function () {
                    $('#colorData_t').val($('#colorData_t').val() + ',' + $(this).attr('v'));
                });
            }, function () {
                $(this).removeClass('c');
            });
            $('.info_type li').toggle(function () {
                $(this).addClass('c');
                $('#typeData_t').val('');
                $('.info_type li.c').each(function () {
                    $('#typeData_t').val($('#typeData_t').val() + ',' + $(this).attr('v'));
                });
            }, function () {
                $(this).removeClass('c');
            });
            setTimeout(function () {
                if (parastr('id') != null) {
                    $.ajax({
                        type: "get",
                        url: "/service/service.ashx?action=GetResourceDetail&tid=" + parastr('id'),
                        success: function (data) {
                            data = eval('(' + data + ')');
                            $("#infoid").val(data.rows[0].id);
                            $("#infoName").val(data.rows[0].name);
                            $("#infoUrl").val(data.rows[0].url);
                            $("#infoRemark").val(data.rows[0].remark);
                            var color = data.rows[0].color.split(',');
                            for (var i = 0; i < color.length; i++) {
                                $('.info_color li[v=' + color[i] + ']').click();
                            }
                            var type = data.rows[0].type.split(',');
                            for (var j = 0; j < type.length; j++) {
                                $('.info_type li[v=' + color[j] + ']').click();
                            }

                            editor.setContent(htmlDecode(data.rows[0].content));
                        }
                    });
                }
            }, 1000);
            uploadFile();
            uploadFile_content();
        })
        function uploadFile() {
            $("#file_upload").uploadify({
                //开启调试       
                'debug': false,
                //是否自动上传     
                'auto': false,
                //是否允许同时上传多个文件
                'multi': false,
                //超时时间         
                'successTimeout': 99999,
                //设置按钮上文字
                //'buttonText': '浏览',
                //浏览按钮的高度 
                height: 24,
                //浏览按钮的宽度 
                width: 80,
                //提交方式[html] view plaincopyprint?
                'method': 'get',
                //附带值      
                //        'formData': {
                //            'userid': '用户id',
                //            'username': '用户名',
                //            'rnd': '加密密文'
                //        },
                //不执行默认的onSelect事件    
                'overrideEvents': ['onDialogClose'],
                //文件选择后的容器ID     
                'queueID': 'queue',
                //服务器端脚本使用的文件对象的名称 $_FILES个['upload']    
                'fileObjName': 'Filedata',
                //flash       
                'swf': "/j/uploadify/uploadify.swf",
                //上传处理程序    
                'uploader': '/service/action.ashx?action=uploadResourceImg&code=' + Math.random(),
                //浏览按钮的背景图片路径    
                'buttonImage': "/j/uploadify/uploadify-ok.gif",
                //expressInstall.swf文件的路径。   
                'expressInstall': '/j/uploadify/expressInstall.swf',
                //在浏览窗口底部的文件类型下拉菜单中显示的文本       
                'fileTypeDesc': '支持的格式：',
                //允许上传的文件后缀    
                'fileTypeExts': '*.*',
                //上传文件的大小限制     
                'fileSizeLimit': '50MB',
                //上传数量     
                'queueSizeLimit': 1,
                //每次更新上载的文件的进展    
                'onUploadProgress': function (file, bytesUploaded, bytesTotal, totalBytesUploaded, totalBytesTotal) {
                    //有时候上传进度什么想自己个性化控制，可以利用这个方法            
                    //使用方法见官方说明  
                },
                //选择上传文件后调用     
                'onSelect': function (file) {
                    $("#ImageName").val(file.name);
                },
                //返回一个错误，选择文件的时候触发      
                'onSelectError': function (file, errorCode, errorMsg) {
                    switch (errorCode) {
                        case -100:
                            alert("上传的文件数量已经超出系统限制的" + $('#file_upload').uploadify('settings', 'queueSizeLimit') + "个文件！");
                            break;
                        case -110:
                            alert("文件 [" + file.name + "] 大小超出系统限制的" + $('#file_upload').uploadify('settings', 'fileSizeLimit') + "大小！");
                            break;
                        case -120:
                            alert("文件 [" + file.name + "] 大小异常！");
                            break;
                        case -130:
                            alert("文件 [" + file.name + "] 类型不正确！");
                            break;
                    }
                },
                //检测FLASH失败调用     
                'onFallback': function () {
                    alert("您未安装FLASH控件，无法上传图片！请安装FLASH控件后再试。");
                },
                //取消上传后弹出消息框   
                'onCancel': function (file) {
                    $("#ImageName").val("");
                },
                //上传到服务器，服务器返回相应信息到data里   
                'onUploadSuccess': function (file, data, response) {
                    if (data == 1) {
                    }
                    else {
                        alert("文档上传失败！");
                    }
                }
            });
        }
        var uploadlenth = 0;
        var uploadindex = 0;
        function uploadFile_content() {
            $("#file_upload_content").uploadify({
                //开启调试       
                'debug': false,
                //是否自动上传     
                'auto': false,
                //是否允许同时上传多个文件
                'multi': true,
                //超时时间         
                'successTimeout': 99999,
                //设置按钮上文字
                //'buttonText': '浏览',
                //浏览按钮的高度 
                height: 24,
                //浏览按钮的宽度 
                width: 80,
                //提交方式[html] view plaincopyprint?
                'method': 'get',
                //附带值      
                //        'formData': {
                //            'userid': '用户id',
                //            'username': '用户名',
                //            'rnd': '加密密文'
                //        },
                //不执行默认的onSelect事件    
                'overrideEvents': ['onDialogClose'],
                //文件选择后的容器ID     
                'queueID': 'queue_content',
                //服务器端脚本使用的文件对象的名称 $_FILES个['upload']    
                'fileObjName': 'Filedata',
                //flash       
                'swf': "/j/uploadify/uploadify.swf",
                //上传处理程序    
                'uploader': '/service/action.ashx?action=uploadResourceImgContent&code=' + Math.random(),
                //浏览按钮的背景图片路径    
                'buttonImage': "/j/uploadify/uploadify-ok.gif",
                //expressInstall.swf文件的路径。   
                'expressInstall': '/j/uploadify/expressInstall.swf',
                //在浏览窗口底部的文件类型下拉菜单中显示的文本       
                'fileTypeDesc': '支持的格式：',
                //允许上传的文件后缀    
                'fileTypeExts': '*.*',
                //上传文件的大小限制     
                'fileSizeLimit': '50MB',
                //上传数量     
                'queueSizeLimit': 20,
                //每次更新上载的文件的进展    
                'onUploadProgress': function (file, bytesUploaded, bytesTotal, totalBytesUploaded, totalBytesTotal) {
                    //有时候上传进度什么想自己个性化控制，可以利用这个方法            
                    //使用方法见官方说明  
                },
                //选择上传文件后调用     
                'onSelect': function (file) {
                    $("#ImageName").val(file.name);
                },
                //返回一个错误，选择文件的时候触发      
                'onSelectError': function (file, errorCode, errorMsg) {
                    switch (errorCode) {
                        case -100:
                            alert("上传的文件数量已经超出系统限制的" + $('#file_upload').uploadify('settings', 'queueSizeLimit') + "个文件！");
                            break;
                        case -110:
                            alert("文件 [" + file.name + "] 大小超出系统限制的" + $('#file_upload').uploadify('settings', 'fileSizeLimit') + "大小！");
                            break;
                        case -120:
                            alert("文件 [" + file.name + "] 大小异常！");
                            break;
                        case -130:
                            alert("文件 [" + file.name + "] 类型不正确！");
                            break;
                    }
                },
                //检测FLASH失败调用     
                'onFallback': function () {
                    alert("您未安装FLASH控件，无法上传图片！请安装FLASH控件后再试。");
                },
                //取消上传后弹出消息框   
                'onCancel': function (file) {
                    $("#ImageName").val("");
                },
                //上传到服务器，服务器返回相应信息到data里   
                'onUploadSuccess': function (file, data, response) {
                    uploadindex++;
                    if (uploadlenth == uploadindex) {
                        // alert("文档上传成功！");
                    }
                    if (data == 1) {
                        //alert("文档上传成功！");
                    }
                    else {
                        alert("文档上传失败！");
                    }
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="info-add" id="info-add">
        <form id="info_form" name="info_form" action="service/action.ashx?action=submitResource"
        method="post">
        <div class="toolbar">
            <input type="button" class="btn-submit mt10 ml10" value="submit" style="width: 200px;
                height: 100px;" />
            <input type="button" class="btn-reset mt10 ml10" value="reset" style="width: 200px;
                height: 100px;" />
        </div>
        <div class="title">
            作品编辑</div>
        <input id="infoid" name="infoid" type="hidden" value="0" />
        <span class="f13">标题:</span><input id="infoName" name="infoName" class=" w50 mt5 ml5 mb5 h25px f15" />
        <br />
        <span class="f13">地址:</span><input id="infoUrl" name="infoUrl" class=" w50 mt5 ml5 mb5 h25px f15" />
        <br />
        <span class="f13">封面:<input type="checkbox" id="cbx_img" class="none" checked="checked" />
        </span>
        <input type="file" name="file_upload" id="file_upload" />
        <div id="queue">
        </div>
        <br />
        <span class="f13">内容图片:<input type="checkbox" id="cbx_img_content" class="none" checked="checked" />
        </span>
        <input type="file" name="file_upload_content" id="file_upload_content" />
        <div id="queue_content">
        </div>
        <br />
        <span class="f13">描述:</span><textarea id="infoRemark" name="infoRemark" class="w100"></textarea>
        <span class="f13">风格:</span>
        <div class="pt5 pb5 info_color">
            <input type="hidden" id="colorData_t" name="colorData_t" />
            <ul>
                <asp:Repeater runat="server" ID="rpt_color">
                    <ItemTemplate>
                        <li class="" title="<%# Eval("Name") %>" v="<%# Eval("ID")%>"><a class="checkbox-brand">
                            <%# Eval("Name")%>(<%# Eval("stats") %>)</a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <span class="f13">类别:</span>
        <div class="pt5 pb5 info_type">
            <input type="hidden" id="typeData_t" name="typeData_t" />
            <ul>
                <asp:Repeater runat="server" ID="rpt_type">
                    <ItemTemplate>
                        <li class="" title="<%# Eval("Name") %>" v="<%# Eval("ID")%>"><a class="checkbox-brand">
                            <%# Eval("Name")%>(<%# Eval("stats") %>)</a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div>
            <input id="infoContentValue" name="infoContentValue" type="hidden" />
            <textarea class="content" id="infoContent" name="infoContent"></textarea>
        </div>
        </form>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
