<%@ Page Title="" Language="C#" MasterPageFile="~/jxchart/Main.Master" AutoEventWireup="true" CodeBehind="use.aspx.cs" Inherits="TL.Web.jxchart.use" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="c/use.css" rel="stylesheet" type="text/css" />
    <link href="j/handsontable.css" rel="stylesheet" type="text/css" />
    <script src="j/handsontable.js" type="text/javascript"></script>
    <link rel="stylesheet" href="j/color/farbtastic.css" type="text/css" />
    <script type="text/javascript" src="j/color/farbtastic.js"></script>
    <script src="j/highcharts/js/highcharts.js" type="text/javascript"></script>
    <%--<script src="http://code.highcharts.com/highcharts.js" type="text/javascript"></script>--%>
    <script src="j/highcharts/js/highcharts-3d.js" type="text/javascript"></script>
    <script src="j/highcharts/js/highcharts-more.js" type="text/javascript"></script>
    <script type="text/javascript" src="j/highcharts/js/modules/exporting.src.js"></script>
    <script type="text/javascript">
    </script>
    <script src="j/use.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<input type="hidden" id="v_c" value="<%=v_c %>" />
<input type="hidden" id="type" value="<%=type %>" />
<input type="hidden" id="hd_data" value="<%=hd_data %>" />
<input type="hidden" id="setting_title" value="<%=setting_title %>" />
<input type="hidden" id="setting_legend" value="<%=setting_legend %>" />
<input type="hidden" id="setting_x" value="<%=setting_x %>" />
<input type="hidden" id="setting_y" value="<%=setting_y %>" />
<input type="hidden" id="setting_pointValue" value="<%=setting_pointValue %>" />
<input type="hidden" id="setting_y_gridLineWidth" value="<%=setting_y_gridLineWidth %>" />
<input type="hidden" id="setting_title_family" value="<%=setting_title_family %>" />
<input type="hidden" id="setting_title_fontSize" value="<%=setting_title_fontSize %>" />
<input type="hidden" id="setting_title_color" value="<%=setting_title_color %>" />
<input type="hidden" id="setting_x_family" value="<%=setting_x_family %>" />
<input type="hidden" id="setting_x_fontSize" value="<%=setting_x_fontSize %>" />
<input type="hidden" id="setting_x_color" value="<%=setting_x_color %>" />
<input type="hidden" id="setting_y_family" value="<%=setting_y_family %>" />
<input type="hidden" id="setting_y_fontSize" value="<%=setting_y_fontSize %>" />
<input type="hidden" id="setting_y_color" value="<%=setting_y_color %>" />
    <div class="chart_type">
        <a t="pie" class="scale-m pie"></a><a t="line" class="scale-m line"></a>
        <a t="column" class="scale-m bar"></a>
            <a t="area" class="scale-m area"></a>
            <a t="other" class="chart_all"></a>
    </div>
    <div class="example-list example-list-load">
<h3 class="title">选择一个示例<a class="close"></a></h3>
<div class="data">
<a style="margin-left:50px" class="scaleb" t="pie"><img src="i/example/chart-type-pie.png"><p>饼图</p></a>
<a class="scaleb" t="line"><img src="i/example/chart-type-line.png"><p>折线图</p></a>
<a class="scaleb" t="column"><img src="i/example/chart-type-bar.png"><p>柱状图</p></a>
<a style="margin-right:50px" class="scaleb" t="area"><img src="i/example/chart-type-area.png"><p>区域图</p></a>
<a class="scaleb" v="stat_speed"><img src="i/example/1.jpg"><p>仪表盘-速度计</p></a>
<a class="scaleb" v="stat_clock"><img src="i/example/2.jpg"><p>仪表盘-时钟</p></a>
<a class="scaleb" v="stat_multi_pie"><img src="i/example/3.jpg"><p>双层饼图</p></a>
<a class="scaleb" v="stat_half_pie"><img src="i/example/4.jpg"><p>半饼图</p></a>

<a class="scaleb" t="bubble"><img src="i/example/9.jpg" style="max-height: 200px;"><p>3D气泡图</p></a>

<a class="scaleb"><img src="i/example/6.jpg" style="max-height: 200px;"><p>瀑布图</p></a>
<a class="scaleb"><img src="i/example/7.jpg" style="
    max-height: 200px;
"><p>漏斗图</p></a>
<a class="scaleb"><img src="i/example/8.jpg" style="max-height: 200px;"><p>混合图</p></a>
<a class="scaleb"><img src="i/example/5.jpg" style="max-height: 190px;"><p>错误条形图</p></a>
<a class="scaleb"><img src="i/example/10.jpg" style="max-height: 190px;"><p>散列图</p></a>
<a class="scaleb"><img src="i/example/11.jpg" style="max-height: 190px;"><p>条形图</p></a>
<a class="scaleb"><img src="i/example/12.jpg" style="max-height: 190px;"><p>箱线图</p></a>
<a class="scaleb"><img src="i/example/13.jpg" style="max-height: 189px;"><p>仪表图-伏-压图</p></a>
</div></div>
    <div class="chart_data">
    
    <%--<span>在下面的表格里编辑图表内容.</span>--%>
    <div class="p_tip">
    <span class="label_title">标题:</span>
    <input id="chart_title" value="房屋水电费用" style="width:260px;height:21px;" />
    <div class="btn_step ani btn_tip_use">如何填写
    <div class="tip_detail" style="display: none; ">
                    <a class="close"></a>
                        1.请选中单元格后进行编辑, 单元格操作可使用<span style="color:#32E232;margin:0px 5px;">右键菜单</span>.<br>
                        2.支持的操作:ctrl + c , ctrl + v , ctrl+a , ↑ , ← , ↓ , → , 回格 , delete.</span><br>
                        3.您可以从 <span style="color:orange">Excel</span> 表直接复制表格.<br>
                        4.图示:
                        </div></div>
    <div id="p_soon" class="btn_step ani" style="display:none;">鼠标绘图
                    <div class="tip_soon" style="display: none; ">
                    无需填写图表内容,在图表上依次单击任意位置,自动绘制图表:
                    </div></div>
                    

                    
                        </div>

        <div id="data_grid" style="width: 100%;height1:390px;">
        </div>
        <a class="btn_step btn-handsontable " title="清空内容" id="handsontableClear"></a>
        <a class="btn_step btn-handsontable ani" title="在末尾添加一行" id="handsontableAddRows"><i></i>行</a>
        <a class="btn_step btn-handsontable ani" title="在末尾移除一行" id="handsontableRemoveRows" style="background-color:#E26767;"><i style="background-position:-1412px -98px;"></i>行</a>
        <a class="btn_step btn-handsontable ani" title="在末尾移除一列" id="handsontableRemoveColumns" style="float:right;background-color:#E26767;"><i style="background-position:-1412px -98px"></i>列</a>
        <a class="btn_step btn-handsontable ani" title="在末尾添加一列" id="handsontableAddColumns" style="float:right;"><i></i>列</a>
    </div>
    <div class="chart_tool">
    </div>
    <div class="chart_content">
        <div id="chart">
        </div>
        <a class="chart-refresh op" title="重新加载"></a>
        <a class="chart-fullscreen" title="全屏查看"></a>
        <a class="chart-3d k" title="开启3D">3D</a>
         <div class="show_example_div"></div>
         <div class="chart-tool"><%--<span style="float:left;line-height: 26px;">配置:</span>--%>
             <i class="btn_step s1 ani">背景设置
             <div class="select_bg">
                        <div c="" v="" class="p_indexPanel_item_top default ani">
                            <span style="color:orange;">无背景</span>
                            <c></c>
                        </div>
                        <div c="" v="grid" class="p_indexPanel_item_top grid ani">
                            <span>网&nbsp;格</span>
                            <c></c>
                        </div>
                        <div c="#fff" v="white" class="p_indexPanel_item_top white ani">
                            <span style="color:#838383;">白&nbsp;底</span>
                            <c></c>
                        </div>
                        <div c="dimGray" v="gray" class="p_indexPanel_item_top gray ani">
                            <span>灰&nbsp;色</span>
                            <c></c>
                        </div>
                        <div id="select_color" v="" class="p_indexPanel_item_top ani more" style="background-image: url(i/make/bg-color.png);background-size: 84%;background-position: 10px 15px;background-color:Orange;background-repeat: no-repeat;height: 114px;float: right;width: 114px;">
                        <div class="select_color_div">
                        <div class="form-item ani btn_step" id="color" name="color" value="#123456"></div>
                        <div class="btn_submit_color ani btn_step">OK</div>
                         <div id="picker" style="margin: 0px auto;"></div>
                            <span style="font- size: 69px; line-height: 85px; margin: 0px;"></span>
                            <c></c>
                        </div>
                        </div>
                        <div c="#2966B3" v="dark-blue" class="p_indexPanel_item_top dark-blue ani">
                            <span>深&nbsp;蓝</span>
                            <c></c>
                        </div>
                        
                        <div c="#3EB122" v="dark-green" class="p_indexPanel_item_top c dark-green ani">
                            <span>深&nbsp;绿</span>
                            <c></c>
                        </div>
                        <div c="#928165" v="dark-kaqi" class="p_indexPanel_item_top c dark-kaqi ani">
                            <span>卡&nbsp;其</span>
                            <c></c>
                        </div>
                        <div c="#b0109f" v="dark-zise" class="p_indexPanel_item_top c dark-zise ani">
                            <span>暗&nbsp;紫</span>
                            <c></c>
                        </div>
                       
                    </div>
             </i>
            <i class="clearCookie btn_step">清除我的配置</i>
             <i class="btn_step s2 ani" style="display:none;">3D设置
             <div class="select_3d">
             <span style="color:#868686">x:&nbsp;</span><input style="width:300px;" id="input_change_3d_y" type="range" /><br /><br />
             <span style="color:#868686">y:&nbsp;</span><input style="width:300px;" id="input_change_3d_x" type="range" />
                    </div>
             </i>
             <i class="show_example btn_step" style="margin-left:50px;">图示</i>
            <div item="setting_title" class='ani <%=setting_title%>'>标题<a class="setting_1"></a><a class="setting_2"></a>
            <div class="setting_font">
            <a class="setting_1" title="显示/隐藏"></a>
            <a class="setting_2" title="样式设置"></a>
            </div>
            </div> 
            <div item="setting_y" class='ani <%=setting_y%>'>Y轴
            <div class="setting_font">
            <a class="setting_1" title="显示/隐藏"></a>
            <a class="setting_2" title="样式设置"></a>
            </div></div>
            <div item="setting_x" class='ani <%=setting_x%>'>X轴
            <div class="setting_font">
            <a class="setting_1" title="显示/隐藏"></a>
            <a class="setting_2" title="样式设置"></a>
            </div></div>
            <div item="setting_legend" class='ani <%=setting_legend%>'>图例
            <div class="setting_font">
            <a class="setting_1" title="显示/隐藏"></a>
            </div>
            </div>
            
            
        </div>
    </div>
    <div id="right">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div class="op_setting_font">
<a class="close btn_step ani" style="background-color:#C53737;">关闭</a>
<a class="ok  btn_step ani">确认</a>
<div class="op_setting_item fontFamily">
<i>字体</i>
<a class="ani c" v="Sim Sun">宋体</a>
<a class="ani" v="SimHei">黑体</a>
<a class="ani" v="KaiTi">楷体</a>
<a class="ani" v="Microsoft YaHei">微软雅黑</a>
</div>
<div class="op_setting_item fontSize">
<i>字号</i>
<a class="ani c" v="13">13</a>
<a class="ani" v="14">14</a>
<a class="ani" v="15">15</a>
<a class="ani" v="16">16</a>
<a class="ani" v="17">17</a>
<a class="ani" v="18">18</a>
<a class="ani" v="19">19</a>
<a class="ani" v="20">20</a>
<a class="ani" v="21">21</a>
<a class="ani" v="22">22</a>
<a class="ani" v="23">23</a>
<a class="ani" v="24">24</a>
<a class="ani" v="25">25</a>
</div>
<div class="op_setting_item fontColor">
<i>颜色</i>
        <div class="op_setting_color" id="op_color" name="op_color" value="#123456">
        <div id="op_picker" style="margin: 0px auto;"></div>
        </div>
</div>
</div>
<div class="chart-fullscreen-div">
<h3 class="title"><a class="close"></a></h3>
<div id="chart_fullscreen"></div>
</div>
</asp:Content>
