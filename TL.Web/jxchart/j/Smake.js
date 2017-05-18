var t = "";

var v = "";

var v_c = "";

var c_grid = null;

var data_default = null;

var data_example = null;

var s_temp_flag = false;

var settingType = 1;

var setting_title = {
    family: "宋体",
    fontSize: 15,
    color: ""
};

var setting_legend = {
    family: "宋体",
    fontSize: 15,
    color: ""
};

var setting_x = {
    family: "宋体",
    fontSize: 15,
    color: ""
};

var setting_y = {
    family: "宋体",
    fontSize: 15,
    color: ""
};

var mode_temp = true;

var fixed_temp = true;

var soon_temp = false;

var step_temp = false;

var dataSource = "tt";

$(function () {
    $("#btn_fixed").click(function () {
        if (!fixed_temp) {
            $("#btn_fixed").addClass("c").attr("title", "已经固定我,安心填内容");
            fixed_temp = true;
        } else {
            $("#btn_fixed").removeClass("c").attr("title", "没有固定我");
            fixed_temp = false;
        }
    });
    function fixed(flag) {
        if (flag) {
            if (!fixed_temp) {
                $("#btn_fixed").addClass("c").attr("title", "已经固定我,安心填内容.");
                fixed_temp = true;
            }
        } else {
            if (fixed_temp) {
                $("#btn_fixed").removeClass("c").attr("title", "没有固定我,将自动隐藏.");
                fixed_temp = false;
            }
        }
    }
    function bind() {
        $("#if_chart").attr("src", "chart.aspx?theme=" + v + "&type=" + t + "&v_c=" + v_c);
        $(".step_content").stop().hide().css("overflow", "visible");
        s_temp_flag = false;
    }
    function bindStyle() {
        if (mode_temp) {
            mode_temp = false;
            step_temp = false;
            $("#btn_step_2").hide();
            alert("图表即将生成,生成后您可以继续在左侧定制自己的内容.");
            $("#right,#btn_fixed").show();
            $(".step_content").stop().hide().css("overflow", "visible");
            bind();
            $(".step_item").mouseenter(function () {
                if (!step_temp && !s_temp_flag) {
                    if (!($(this).hasClass("edit") && fixed_temp)) {
                        step_temp = true;
                        $(this).children(".step_content").stop().show().w(1).a({
                            width: 500
                        }, 200).css("overflow", "visible");
                        $(this).children(".step_content").children(".step_content_conetnt").hide();
                        setTimeout(function () {
                            $(".step_content").children(".step_content_conetnt").show();
                            step_temp = false;
                        }, 200);
                    }
                }
            }).mouseleave(function () {
                if (!($(this).hasClass("edit") && fixed_temp)) {
                    $(this).children(".step_content").stop().hide().css("overflow", "visible");
                }
                s_temp_flag = false;
            });
        } else {
            fixed(false);
            bind();
        }
    }
    $(".content-chart-detail > div:eq(0)").show();
    $(".content-chart-type a").mousemove(function () {
        var i = $(".content-chart-type a").index($(this));
        $(".content-chart-detail > div:eq(" + i + ")").show().siblings().hide();
    }).click(function () {
        t = $(this).attr("t");
        $(this).addClass("c").siblings().removeClass("c");
        if (!mode_temp) {
            fixed(false);
            bind();
        } else {
            fixed(false);
            $(".step_item.edit").css("background-position", "-100px 48px ");
            $(".step_content").stop().hide().css("overflow", "visible");
            step_temp = true;
            $(".step_content:eq(1)").stop().show().w(1).a({
                width: 500
            }, 500).css("overflow", "visible");
            $(".step_content:eq(1)").children(".step_content_conetnt").hide();
            setTimeout(function () {
                $(".step_content").children(".step_content_conetnt").show();
                step_temp = !step_temp;
                datagrid();
            }, 1e3);
        }
    });
    $(".content-chart-detail a").click(function () {
        t = $(this).parent().attr("t");
        $(".content-chart-detail a").removeClass("c");
        $(this).addClass("c");
        if (!mode_temp) {
            fixed(false);
            bind();
        }
    });
    if ($.cookie("firstMake") == null || $.cookie("firstMake") == "") {
        $(".op_descDiv").show();
    }
    $(".op_descDiv a").click(function () {
        $.cookie("firstMake", "true");
        $(".op_descDiv").fadeOut(500);
    });
    $(".chart-fullscreen").click(function () {
        window.open("chart.aspx?theme=" + v + "&type=" + t + "&chart_full=full&v_c=" + v_c);
    });
    $("#btn_use").click(function () {
        soon_temp = false;
        $.cookie("soon_temp", "false");
        dataSource = "tt_example";
        $("#form_data").submit();
    });
    $("#p_soon").click(function () {
        if (t == "pie") {
            alert("饼状图表暂不支持快速绘图功能.");
        } else {
            soon_temp = true;
            $.cookie("soon_temp", "true");
            dataSource = "tt";
            $("#form_data").submit();
        }
    }).mouseenter(function () {
        $(".tip_soon").show();
    }).mouseleave(function () {
        $(".tip_soon").hide();
    });
    $(".p_tip .btn_tip_use").click(function () {
        $(this).siblings(".tip_detail").show();
    }).mouseleave(function () { });
    $(".p_tip a.close").click(function () {
        $(".tip_detail").hide();
    });
    $(".step_item > p").click(function () {
        $(this).parent().mouseenter();
    });
    $(".listTop > div[id!=select_color]").click(function () {
        v = $(this).attr("v");
        bindStyle();
    });
    $("#select_color").mouseenter(function () {
        $(".select_color_div").show();
    }).mouseleave(function () {
        $(".select_color_div").hide();
    });
    $(".btn_submit_color").click(function () {
        v_c = $("#color").css("background-color");
        $("#select_color").css("background-color", v_c);
        $(".select_color_div").hide();
        v = "vc";
        bindStyle();
    });
    $("#form_data").form({
        onSubmit: function () {
            if (!$("#chart_title").val()) {
                alert("你没有填写标题!");
                $("#chart_title").focus();
                return false;
            }
            var rows = null;
            if (!soon_temp) {
                if (dataSource == "tt") {
                    rows = data_default.getData();
                } else {
                    rows = data_example.getData();
                }
                if (rows.length < 1) {
                    alert("你没有编辑内容!");
                    return false;
                }
            } else {
                rows = [["X轴", "系列1", ""], ["第一项", 0, ""], ["第二项", 0, ""]["", "", ""]];
            }
            var hd_data = "";
            var content = "";
            var value1 = "", value2 = "", value3 = "", value4 = "", value5 = "", value6 = "", value7 = "", value8 = "", value9 = "", value10 = "";
            if (rows != null) {
                for (var i = 0; i < rows.length - 1; i++) {
                    for (var j = 0; j < rows[i].length - 1; j++) {
                        if (rows[i][j] == null || rows[i][j].toString() == "") {
                            if (i > 0 && j > 0) rows[i][j] = "0"; else {
                                rows[i][j] = " ";
                            }
                        } else if (i > 0 && j > 0 && isNaN(rows[i][j].toString())) {
                            alert("需要输入数字!");
                            c_grid.handsontable("selectCell", i, j);
                            return false;
                            break;
                        }
                        switch (j) {
                            case 1:
                                value1 += rows[i][j].toString() + "_";
                                break;

                            case 2:
                                value2 += rows[i][j].toString() + "_";
                                break;

                            case 3:
                                value3 += rows[i][j].toString() + "_";
                                break;

                            case 4:
                                value4 += rows[i][j].toString() + "_";
                                break;

                            case 5:
                                value5 += rows[i][j].toString() + "_";
                                break;

                            case 6:
                                value6 += rows[i][j].toString() + "_";
                                break;

                            case 7:
                                value7 += rows[i][j].toString() + "_";
                                break;

                            case 8:
                                value8 += rows[i][j].toString() + "_";
                                break;

                            case 9:
                                value9 += rows[i][j].toString() + "_";
                                break;

                            case 10:
                                value10 += rows[i][j].toString() + "_";
                                break;
                        }
                    }
                    content += rows[i][0].toString() + "_";
                }
                content = content.substr(0, content.length - 1);
            }
            hd_data += content + "&";
            value1 = value1 == "" ? "" : value1.substr(0, value1.length - 1) + "&";
            value2 = value2 == "" ? "" : value2.substr(0, value2.length - 1) + "&";
            value3 = value3 == "" ? "" : value3.substr(0, value3.length - 1) + "&";
            value4 = value4 == "" ? "" : value4.substr(0, value4.length - 1) + "&";
            value5 = value5 == "" ? "" : value5.substr(0, value5.length - 1) + "&";
            value6 = value6 == "" ? "" : value6.substr(0, value6.length - 1) + "&";
            value7 = value7 == "" ? "" : value7.substr(0, value7.length - 1) + "&";
            value8 = value8 == "" ? "" : value8.substr(0, value8.length - 1) + "&";
            value9 = value9 == "" ? "" : value9.substr(0, value9.length - 1) + "&";
            value10 = value10 == "" ? "" : value10.substr(0, value10.length - 1) + "&";
            hd_data = hd_data + value1 + value2 + value3 + value4 + value5 + value6 + value7 + value8 + value9 + value10;
            hd_data += $("#chart_title").val();
            $("#hd_data").val(hd_data);
        },
        success: function (data) {
            if (data == "1") {
                if (mode_temp) {
                    if (confirm("保存成功,是否继续?")) {
                        $(".step_content").stop().hide().css("overflow", "visible");
                        step_temp = true;
                        $(".step_content:eq(2)").stop().show().w(1).a({
                            width: 500
                        }, 1e3).css("overflow", "visible");
                        $(".step_content:eq(2)").children(".step_content_conetnt").hide();
                        setTimeout(function () {
                            $(".step_content").children(".step_content_conetnt").show();
                            step_temp = !step_temp;
                        }, 500);
                        $(".step_item.bg").css("background-position", "-100px 48px ");
                    }
                } else {
                    fixed(false);
                    bind();
                }
            } else {
                alert("保存失败");
            }
        }
    });
    $("#btn_data").click(function () {
        soon_temp = false;
        $.cookie("soon_temp", "false");
        c_grid.handsontable("selectCell", 0, 0);
        $("#form_data").submit();
    });
    $("#btn_step_2").hide().click(function () {
        fixed(false);
        $(".step_content").stop().hide().css("overflow", "visible");
        step_temp = true;
        $(".step_content:eq(1)").stop().show().w(1).a({
            width: 500
        }, 1e3).css("overflow", "visible");
        $(".step_content:eq(1)").children(".step_content_conetnt").hide();
        setTimeout(function () {
            $(".step_content").children(".step_content_conetnt").show();
            step_temp = !step_temp;
            datagrid();
        }, 500);
    });
    var load_example = false;
    $("#btn_example").click(function () {
        if ($("#btn_example").html() == "示例") {
            if (!load_example) {
                datagrid_example();
                load_example = true;
            }
            $("#p_tt").hide();
            $("#p_tt_example").show();
            $("#btn_use").show();
            $("#btn_data").hide();
            $(this).html("返回");
            c_grid = $("#data_grid_example");
            dataSource = "tt_example";
            if (!$("#chart_title").val() || $("#chart_title").val() == "") $("#chart_title").after('<input id="chart_title" value="一年的支出情况" />').remove();
        } else {
            $("#p_tt").show();
            $("#p_tt_example").hide();
            $("#btn_use").hide();
            $("#btn_data").show();
            $(this).html("示例");
            dataSource = "tt";
            c_grid = $("#data_grid");
            if ($("#chart_title").val() == "一年的支出情况") $("#chart_title").val("");
        }
    });
    $("#btn_example_2").click(function () {
        if ($("#btn_example").html() == "示例") {
            $("#btn_example").click();
            $(".tip_detail").fadeOut(1e3);
        }
    });
    $("#data_edit .del").afterbind("click", function () {
        $(this).parent().remove();
    });
    $(".data_edit_add").afterbind("click", function () {
        var c = $("<div class='data_item'><input class='data_item_title' placeholder='填写项标题' /><input class='data_item_content' placeholder='填写内容,以\",\"分隔.' /><a class='del op'></a></div>");
        $("#data_edit").append(c);
    });
    function grid_edit() {
        var data = [];
        if (t == "pie") {
            data = [["X轴", "系列"], ["第一项", 0], ["第二项", 0], ["第三项", 0]];
        } else {
            data = [["X轴", "系列1", "系列2", "系列3"], ["第一项", 0, 0, 0], ["第二项", 0, 0, 0], ["第三项", 0, 0, 0]];
        }
        c_grid = $("#data_grid");
        data_default = c_grid.handsontable({
            minSpareRows: 1,
            minSpareCols: 1,
            rowHeaders: false,
            colHeaders: false,
            columnSorting: true,
            data: data,
            removeRowPlugin: true
        }).data("handsontable");
        $(".htCore").addClass("table-striped").addClass("table-hover").addClass("table-bordered");
    }
    function grid_edit_example() {
        var data = [];
        if (t == "pie") {
            data = [["月份", "房屋水电费用"], ["一月", 1010], ["二月", 1030], ["三月", 1040], ["四月", 1020], ["五月", 1100], ["六月", 1020], ["七月", 1120], ["八月", 1050], ["九月", 1080], ["十月", 1120], ["十一月", 1210], ["十二月", 1090]];
        } else {
            data = [["月份", "房屋水电费用", "衣食费用", "交通费用"], ["一月", 1010, 800, 200], ["二月", 1030, 900, 200], ["三月", 1040, 870, 200], ["四月", 1020, 970, 200], ["五月", 1100, 780, 200], ["六月", 1020, 920, 200], ["七月", 1120, 780, 200], ["八月", 1050, 840, 200], ["九月", 1080, 920, 200], ["十月", 1120, 810, 200], ["十一月", 1210, 880, 200], ["十二月", 1090, 920, 200]];
        }
        c_grid = $("#data_grid_example");
        data_example = c_grid.handsontable({
            minSpareRows: 1,
            minSpareCols: 1,
            rowHeaders: false,
            columnSorting: true,
            colHeaders: false,
            data: data,
            removeRowPlugin: true
        }).data("handsontable");
        $(".htCore").addClass("table-striped").addClass("table-hover").addClass("table-bordered");
    }
    function datagrid() {
        grid_edit();
        return false;
        var lastIndex;
        var editIndex = 1;
        $("#tt").datagrid({
            title: "",
            onLoadSuccess: function () {
                $("#tt").datagrid("endEdit", lastIndex);
                $("#tt").datagrid("appendRow", {
                    itemid: editIndex,
                    content: "记录点(x轴)",
                    value: "记录1",
                    value2: "记录2",
                    value3: "记录3"
                });
                editIndex++;
                $("#tt").datagrid("appendRow", {
                    itemid: editIndex,
                    content: "记录点",
                    value: "0",
                    value2: "0",
                    value3: "0"
                });
                editIndex++;
                var lastIndex = $("#tt").datagrid("getRows").length - 1;
                $("#tt").datagrid("beginEdit", lastIndex);
                $(".datagrid-header").hide();
            },
            toolbar: [{
                text: "添加",
                iconCls: "icon-add",
                handler: function () {
                    $("#tt").datagrid("endEdit", lastIndex);
                    $("#tt").datagrid("appendRow", {
                        itemid: editIndex,
                        content: "记录点",
                        value: "0",
                        value2: "0",
                        value3: "0"
                    });
                    editIndex++;
                    var lastIndex = $("#tt").datagrid("getRows").length - 1;
                    $("#tt").datagrid("beginEdit", lastIndex);
                }
            }, "-", {
                text: "移除",
                iconCls: "icon-remove",
                handler: function () {
                    var row = $("#tt").datagrid("getSelected");
                    if (row) {
                        var index = $("#tt").datagrid("getRowIndex", row);
                        $("#tt").datagrid("deleteRow", index);
                        editIndex--;
                    }
                }
            }, "-", {
                text: "清空",
                iconCls: "icon-undo",
                handler: function () {
                    if (confirm("确定要清空内容吗?")) {
                        var item = $("#tt").datagrid("getRows");
                        if (item) {
                            for (var i = item.length - 1; i > 0; i--) {
                                var index = $("#tt").datagrid("getRowIndex", item[i]);
                                $("#tt").datagrid("deleteRow", index);
                            }
                        }
                        editIndex = 1;
                    }
                }
            }],
            onBeforeLoad: function () {
                $(this).datagrid("rejectChanges");
            },
            onClickRow: function (rowIndex) {
                if (lastIndex != rowIndex) {
                    $("#tt").datagrid("endEdit", lastIndex);
                    $("#tt").datagrid("beginEdit", rowIndex);
                }
                lastIndex = rowIndex;
            }
        });
    }
    function datagrid_example() {
        grid_edit_example();
        return false;
        var lastIndex;
        var editIndex = 1;
        $("#tt_example").datagrid({
            title: "",
            onLoadSuccess: function () {
                $("#tt_example").datagrid("endEdit", lastIndex);
                $("#tt_example").datagrid("appendRow", {
                    itemid: editIndex,
                    content: "月份",
                    value: "收入",
                    value2: "支出",
                    value3: "剩余"
                });
                editIndex++;
                $("#tt_example").datagrid("appendRow", {
                    itemid: editIndex,
                    content: "一月",
                    value: "6000",
                    value2: "503",
                    value3: "251"
                });
                editIndex++;
                $("#tt_example").datagrid("appendRow", {
                    itemid: editIndex,
                    content: "二月",
                    value: "6000",
                    value2: "889",
                    value3: "126"
                });
                editIndex++;
                $("#tt_example").datagrid("appendRow", {
                    itemid: editIndex,
                    content: "三月",
                    value: "6000",
                    value2: "433",
                    value3: "666"
                });
                editIndex++;
                $("#tt_example").datagrid("appendRow", {
                    itemid: editIndex,
                    content: "四月",
                    value: "6000",
                    value2: "532",
                    value3: "666"
                });
                editIndex++;
                $("#tt_example").datagrid("appendRow", {
                    itemid: editIndex,
                    content: "五月",
                    value: "6000",
                    value2: "124",
                    value3: "653"
                });
                editIndex++;
                $("#tt_example").datagrid("appendRow", {
                    itemid: editIndex,
                    content: "六月",
                    value: "6000",
                    value2: "777",
                    value3: "666"
                });
                editIndex++;
                $("#tt_example").datagrid("appendRow", {
                    itemid: editIndex,
                    content: "七月",
                    value: "6000",
                    value2: "231",
                    value3: "623"
                });
                editIndex++;
                $("#tt_example").datagrid("appendRow", {
                    itemid: editIndex,
                    content: "八月",
                    value: "6000",
                    value2: "222",
                    value3: "777"
                });
                editIndex++;
                $("#tt_example").datagrid("appendRow", {
                    itemid: editIndex,
                    content: "九月",
                    value: "6000",
                    value2: "211",
                    value3: "251"
                });
                editIndex++;
                $("#tt_example").datagrid("appendRow", {
                    itemid: editIndex,
                    content: "十月",
                    value: "6000",
                    value2: "100",
                    value3: "244"
                });
                editIndex++;
                $("#tt_example").datagrid("appendRow", {
                    itemid: editIndex,
                    content: "十一月",
                    value: "6000",
                    value2: "124",
                    value3: "653"
                });
                editIndex++;
                $("#tt_example").datagrid("appendRow", {
                    itemid: editIndex,
                    content: "十二月",
                    value: "6000",
                    value2: "224",
                    value3: "353"
                });
                var lastIndex = $("#tt_example").datagrid("getRows").length - 1;
                $("#tt_example").datagrid("beginEdit", lastIndex);
                $(".datagrid-header").hide();
            },
            toolbar: [{
                text: "使用这个示例",
                iconCls: "icon-add",
                handler: function () {
                    dataSource = "tt_example";
                    $("#form_data").submit();
                }
            }],
            onBeforeLoad: function () {
                $(this).datagrid("rejectChanges");
            },
            onClickRow: function (rowIndex) {
                if (lastIndex != rowIndex) {
                    $("#tt_example").datagrid("endEdit", lastIndex);
                    $("#tt_example").datagrid("beginEdit", rowIndex);
                }
                lastIndex = rowIndex;
            }
        });
    }
    $(".chart-tool > div").click(function () {
        if (event.target == this) {
            var v = $(this).attr("item");
            if ($(this).hasClass("n")) {
                $.cookie(v, "");
                $(this).removeClass("n");
            } else {
                $.cookie(v, "n");
                $(this).addClass("n");
                $(this).find(".setting_font").hide();
            }
            bind();
        }
    });
    $(".chart-tool > div").mouseenter(function () {
        if (!$(this).hasClass("n")) {
            $(this).find(".setting_font").stop().slideDown(300);
        }
    }).mouseleave(function () {
        $(this).find(".setting_font").stop().slideUp(300);
    });
    $(".setting_font a").click(function () {
        settingType = $(".chart-tool > div").index($(this).parent().parent()) + 1;
        $(".op_setting_font").show();
    });
    $(".op_setting_item > a").click(function () {
        if (!$(this).hasClass("c")) {
            $(this).addClass("c").siblings("a").removeClass("c");
        }
    });
    $(".clearCookie").click(function () {
        $.cookie("setting_title_family", null);
        $.cookie("setting_title_fontSize", null);
        $.cookie("setting_title_color", null);
        $.cookie("setting_x_family", null);
        $.cookie("setting_x_fontSize", null);
        $.cookie("setting_x_color", null);
        $.cookie("setting_y_family", null);
        $.cookie("setting_y_fontSize", null);
        $.cookie("setting_y_color", null);
        bind();
    });
    $(".show_example").hover(function () {
        $(".show_example_div").stop().css("top", "-380px").show().animate({
            top: 0
        }, 300);
    }, function () {
        $(".show_example_div").hide();
    });
    $(".s1,.s2,.s3").click(function () {
        $(".step_item:eq(" + $(".s1,.s2,.s3").index($(this)) + ")").mouseenter();
        s_temp_flag = true;
    });
    $(".op_setting_font .ok").click(function () {
        $(".op_setting_font").hide();
        $(".setting_font").stop().slideUp(300);
        var family = $(".fontFamily a.c").attr("v");
        var fontSize = $(".fontSize a.c").attr("v");
        var color = $(".op_setting_color").css("background-color");
        switch (settingType) {
            case 1:
                setting_title.family = family;
                setting_title.fontSize = fontSize;
                setting_title.color = color;
                $.cookie("setting_title_family", setting_title.family);
                $.cookie("setting_title_fontSize", setting_title.fontSize);
                $.cookie("setting_title_color", setting_title.color);
                break;

            case 3:
                setting_x.family = family;
                setting_x.fontSize = fontSize;
                setting_x.color = color;
                $.cookie("setting_x_family", setting_x.family);
                $.cookie("setting_x_fontSize", setting_x.fontSize);
                $.cookie("setting_x_color", setting_x.color);
                break;

            case 2:
                setting_y.family = family;
                setting_y.fontSize = fontSize;
                setting_y.color = color;
                $.cookie("setting_y_family", setting_y.family);
                $.cookie("setting_y_fontSize", setting_y.fontSize);
                $.cookie("setting_y_color", setting_y.color);
                break;
        }
        bind();
    });
    $(".op_setting_font .close").click(function () {
        $(".op_setting_font").hide();
        $(".setting_font").stop().slideUp(300);
    });
    $("#op_color").mouseenter(function () {
        $("#op_picker").stop().fadeIn(800);
    }).mouseleave(function () {
        $("#op_picker").stop().hide();
    });
});