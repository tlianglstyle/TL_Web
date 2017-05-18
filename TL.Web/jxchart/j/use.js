$(function () {
    $(".example-list .data").h(getBrowserSize().h - 100);
    setTimeout(function () {
        $("#picker").farbtastic("#color");
        $("#op_picker").farbtastic("#op_color");
    }, 2e3);
    var chart = null;
    var c_grid = $("#data_grid");
    var objChart = "chart";
    var data_default = null;
    var option = {};
    var funback = function () { };
    var ii_funback = null;
    var hd_data_default = "月份_一月_二月_三月_四月_五月_六月_七月_八月_九月_十月_十一月_十二月&房屋水电费用_1010_1030_1040_1020_1100_1020_1120_1050_1080_1120_1210_1090&衣食费用_800_900_870_970_780_920_780_840_920_810_880_920&交通费用_200_200_200_200_200_200_200_200_200_200_200_200&我的报表";
    var data = [];
    var t = "";
    var t_example = "";
    var event_temp = false;
    var v_c = "#fff";
    var settingType = "";
    var option3d_temp = true;
    var color_bubble = [[[0, "rgba(255,255,255,0.5)"], [1, "rgba(69,114,167,0.5)"]], [[0, "rgba(255,255,255,0.5)"], [1, "rgba(170,70,67,0.5)"]], [[0, "rgba(255,255,255,0.5)"], [1, "rgba(142, 250, 122, 0.75)"]]];
    var chart_rows = ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"];
    var chart_columns = [];
    var chart_data = [{
        name: "Tokyo",
        data: [7, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6]
    }, {
        name: "New York",
        data: [-.2, .8, 5.7, 11.3, 17, 22, 24.8, 24.1, 20.1, 14.1, 8.6, 2.5]
    }, {
        name: "Berlin",
        data: [-.9, .6, 3.5, 8.4, 13.5, 17, 18.6, 17.9, 14.3, 9, 3.9, 1]
    }, {
        name: "London",
        data: [3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17, 16.6, 14.2, 10.3, 6.6, 4.8]
    }];
    var title_content = "月份";
    var title_chart = "极限报表-演示示例";
    var title_X = "";
    var title_Y = "";
    data = [["月份", "房屋水电费用", "衣食费用", "交通费用"], ["一月", 1010, 800, 200], ["二月", 1030, 900, 200], ["三月", 1040, 870, 200], ["四月", 1020, 970, 200], ["五月", 1100, 780, 200], ["六月", 1020, 920, 200], ["七月", 1120, 780, 200], ["八月", 1050, 840, 200], ["九月", 1080, 920, 200], ["十月", 1120, 810, 200], ["十一月", 1210, 880, 200], ["十二月", 1090, 920, 200]];
    data_default = c_grid.handsontable({
        minSpareRows: 1,
        minSpareCols: 1,
        rowHeaders: false,
        colHeaders: false,
        columnSorting: true,
        data: data,
        contextMenu: true,
        removeRowPlugin: true
    }).data("handsontable");
    $("#handsontableAddRows").click(function () {
        var rows = $("#data_grid table tbody tr").length;
        c_grid.handsontable("alter", "insert_row", rows);
    }).next().click(function () {
        var rows = $("#data_grid table tbody tr").length;
        c_grid.handsontable("alter", "remove_row", rows - 1);
    }).next().click(function () {
        var cols = $("#data_grid table tbody tr:eq(0) td").length;
        c_grid.handsontable("alter", "remove_col", cols - 1);
    }).next().click(function () {
        var cols = $("#data_grid table tbody tr:eq(0) td").length;
        c_grid.handsontable("alter", "insert_col", cols);
    });
    $("#handsontableClear").click(function () {
        if (confirm("确定要清空吗(刷新当前页面可还原到示例数据)?")) {
            data = [["x轴", "系列"], ["数值", 10], ["数值", 20], ["数值", 30]];
            data_default = c_grid.handsontable({
                minSpareRows: 1,
                minSpareCols: 1,
                rowHeaders: false,
                colHeaders: false,
                columnSorting: true,
                data: data,
                contextMenu: true,
                removeRowPlugin: true
            }).data("handsontable");
        }
    });
    $(".htCore").addClass("table-striped").addClass("table-hover").addClass("table-bordered");
    var ii_data = null;
    if (parastr("v") != null && parastr("v") != "") {
        t_example = parastr("v");
        $(".example-list").hide();
        bindChartControl();
        ii_data = setInterval(bindData, 1500);
    } else {
        ii_data = setInterval(bindData, 1500);
    }
    function bindData() {
        if (t_example == "") {
            var rows = data_default.getData();
            var hd_data = "";
            var content = "";
            var value1 = "", value2 = "", value3 = "", value4 = "", value5 = "", value6 = "", value7 = "", value8 = "", value9 = "", value10 = "";
            if (rows != null) {
                for (var i = 0; i < rows.length; i++) {
                    for (var j = 0; j < rows[i].length; j++) {
                        if (rows[i][j] == null || rows[i][j].toString() == "") {
                            if (i > 0 && j > 0) rows[i][j] = "0"; else {
                                rows[i][j] = " ";
                            }
                        } else if (i > 0 && j > 0 && isNaN(rows[i][j].toString())) { }
                        switch (j) {
                            case 1:
                                value1 += rows[i][j].toString().replace(",", "") + "_";
                                break;

                            case 2:
                                value2 += rows[i][j].toString().replace(",", "") + "_";
                                break;

                            case 3:
                                value3 += rows[i][j].toString().replace(",", "") + "_";
                                break;

                            case 4:
                                value4 += rows[i][j].toString().replace(",", "") + "_";
                                break;

                            case 5:
                                value5 += rows[i][j].toString().replace(",", "") + "_";
                                break;

                            case 6:
                                value6 += rows[i][j].toString().replace(",", "") + "_";
                                break;

                            case 7:
                                value7 += rows[i][j].toString().replace(",", "") + "_";
                                break;

                            case 8:
                                value8 += rows[i][j].toString().replace(",", "") + "_";
                                break;

                            case 9:
                                value9 += rows[i][j].toString().replace(",", "") + "_";
                                break;

                            case 10:
                                value10 += rows[i][j].toString().replace(",", "") + "_";
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
            if (hd_data_default != hd_data) {
                hd_data_default = hd_data;
                getData();
                bindOption();
                bindChart();
            } else { }
        } else {
            if ($("#setting_title").val() != "n") {
                if (option.title.text != $("#chart_title").val()) {
                    option.title.text = $("#chart_title").val();
                    bindChart();
                }
            } else {
                if (option.title.text != "") {
                    option.title.text = "";
                    bindChart();
                }
            }
        }
    }
    setInterval(function () {
        $(".highcharts-container:eq(0) > div").css({
            left: "660px",
            top: "444px",
            width: "110px",
            height: "40px",
            overflow: "hidden",
            padding: "5px",
            "z-index": "10000"
        }).show();
        $(".highcharts-container:eq(1) > div").css({
            position: "fixed",
            left: "10px",
            top: "2px",
            width: "725px",
            height: "35px",
            overflow: "hidden",
            padding: "2px"
        }).show();
        $(".highcharts-container:eq(0) > div > div").css({
            border: "0px",
            height: "30px",
            padding: "5px",
            "box-shadow": "0px 0px 0px 0px white"
        });
        $(".highcharts-container:eq(1) > div > div").css({
            border: "0px",
            height: "30px",
            padding: "5px",
            "box-shadow": "0px 0px 0px 0px white",
            background: "none"
        });
        $(".highcharts-container:eq(0) > div > div > div").css({
            "background-color": "#57B915",
            "border-radius": "2px",
            color: "white",
            padding: "5px 10px",
            "float": "left",
            "border-radius": "3px"
        });
        $(".highcharts-container:eq(1) > div > div > div").css({
            padding: "7px 20px",
            "float": "left",
            "border-radius": "3px",
            background: "#C5C5C5",
            "margin-left": "5px"
        });
        $(".highcharts-container > div > div > hr").remove();
    }, 10);
    function getData() {
        var hd_data = hd_data_default;
        if (hd_data != "") {
            var arr = hd_data.split("&");
            chart_rows = [];
            chart_columns = [];
            var arr_content = arr[0].split("_");
            title_content = arr_content[0];
            for (var i = 1; i < arr_content.length; i++) {
                chart_rows.push(arr_content[i]);
            }
            chart_data = [];
            for (var i = 1; i < arr.length - 1; i++) {
                if ($("#type").val() == "pie" && i > 1) {
                    continue;
                } else {
                    chart_columns.push(arr[i].split("_")[0].toString());
                    var arr_data = arr[i].split("_");
                    var chart_data_children = [];
                    for (var j = 1; j < arr_data.length; j++) {
                        chart_data_children.push({
                            y: parseFloat(arr_data[j]),
                            sliced: false,
                            name: chart_rows[j - 1],
                            color: getRandomColor(j)
                        });
                    }
                    var c_curr = null;
                    if ($("#type").val() == "bubble") {
                        c_curr = {
                            name: chart_columns[i - 1],
                            data: chart_data_children,
                            marker: {
                                fillColor: {
                                    radialGradient: {},
                                    stops: color_bubble[i % 3]
                                }
                            }
                        };
                    } else {
                        c_curr = {
                            name: chart_columns[i - 1],
                            data: chart_data_children
                        };
                    }
                    chart_data.push(c_curr);
                }
                if ($("#setting_title").val() == "" ? true : false) {
                    title_chart = arr[arr.length - 1].toString();
                } else {
                    title_chart = "";
                }
            }
        }
    }
    function bindOption() {
        funback = function () {
            return false;
        };
        v_c = ($("#v_c").val().length > 0 ? $("#v_c").val() : false) || Highcharts.theme && Highcharts.theme.chart.backgroundColor || "";
        var setting_title_color = $("#setting_title_color").val().length > 0 ? unescape($("#setting_title_color").val()) : Highcharts.theme && Highcharts.theme.title.style.color || "Gray";
        var setting_title_fontSize = parseInt($("#setting_title_fontSize").val().length > 0 ? $("#setting_title_fontSize").val() : 13);
        var setting_title_family = $("#setting_title_family").val().length > 0 ? unescape($("#setting_title_family").val()) : "SimSun";
        setting_title_family = setting_title_family.replace("%20", " ");
        setting_title_font = $("#setting_title_color").val().length > 0 ? setting_title_fontSize + "px " + setting_title_family : Highcharts.theme && Highcharts.theme.title.style.font || "13 SimHei";
        var setting_x_color = $("#setting_x_color").val().length > 0 ? unescape($("#setting_x_color").val()) : Highcharts.theme && Highcharts.theme.xAxis.labels.style.color || "Gray";
        var setting_x_fontSize = parseInt($("#setting_x_fontSize").val().length > 0 ? $("#setting_x_fontSize").val() : 13);
        var setting_x_family = $("#setting_x_family").val().length > 0 ? unescape($("#setting_x_family").val()) : "SimSun";
        setting_x_family = setting_x_family.replace("%20", " ");
        setting_x_font = $("#setting_x_color").val().length > 0 ? setting_x_fontSize + "px " + setting_x_family : Highcharts.theme && Highcharts.theme.xAxis.labels.style.font || "13 SimHei";
        var setting_y_color = $("#setting_y_color").val().length > 0 ? unescape($("#setting_y_color").val()) : Highcharts.theme && Highcharts.theme.yAxis.labels.style.color || "Gray";
        var setting_y_fontSize = parseInt($("#setting_y_fontSize").val().length > 0 ? $("#setting_y_fontSize").val() : 13);
        var setting_y_family = $("#setting_y_family").val().length > 0 ? unescape($("#setting_y_family").val()) : "SimSun";
        setting_y_family = setting_y_family.replace("%20", " ");
        setting_y_font = $("#setting_y_color").val().length > 0 ? setting_y_fontSize + "px " + setting_y_family : Highcharts.theme && Highcharts.theme.yAxis.labels.style.font || "13 SimHei";
        option = {
            chart: {
                renderTo: objChart,
                plotBorderWidth1: 1,
                backgroundColor: v_c,
                type: $("#type").val(),
                shadow: true,
                options3d: {
                    enabled: true,
                    alpha: 0,
                    beta: 0
                }
            },
            plotBackgroundImage1: "i/default/chart-type-pie.png",
            title: {
                text: title_chart,
                x: -20,
                style: {
                    color: setting_title_color,
                    font: setting_title_font
                }
            },
            subtitle: {
                text: " ",
                x: -20
            },
            xAxis: {
                gridLineWidth: 0,
                tickWidth: $("#setting_x").val() == "n" ? 0 : 1,
                lineColor: $("#setting_x").val() == "n" ? "#fff" : "gray",
                labels: {
                    enabled: $("#setting_x").val() == "n" ? false : true,
                    style: {
                        color: setting_x_color,
                        font: setting_x_font
                    }
                },
                categories: chart_rows,
                title: {
                    text: title_X
                }
            },
            yAxis: {
                tickWidth: $("#setting_y").val() == "n" ? 0 : 1,
                lineColor: $("#setting_y").val() == "n" ? "#fff" : "gray",
                labels: {
                    enabled: $("#setting_y").val() == "n" ? false : true,
                    style: {
                        color: setting_y_color,
                        font: setting_y_font
                    }
                },
                title: {
                    text: title_Y
                },
                gridLineWidth: $("#setting_y_gridLineWidth").val(),
                plotLines: [{
                    value: 0,
                    width: 1,
                    color: "#808080"
                }]
            },
            tooltip: {
                valueSuffix: "",
                formatter: function () {
                    if ((this.y + "").indexOf(".") != -1) return this.y.toFixed(2);
                    return this.y;
                }
            },
            legend: {
                enabled: $("#setting_legend").val() == "n" ? false : true,
                layout: "vertical",
                align: "right",
                verticalAlign: "middle",
                borderWidth: 0
            },
            plotOptions: {
                column: {
                    dataLabels: {
                        enabled: true,
                        color: Highcharts.theme && Highcharts.theme.dataLabelsColor || "gray",
                        style: {
                            textShadow1: "0 0 3px #4E4E4E, 0 0 3px #fcfcfc",
                            fontSize: "13px"
                        },
                        formatter: function () {
                            if ($("#setting_pointValue").val() == "n") {
                                return "";
                            } else {
                                if ((this.y + "").indexOf(".") != -1) return this.y.toFixed(2);
                                return this.y;
                            }
                        }
                    }
                },
                line: {
                    dataLabels: {
                        enabled: true,
                        color: Highcharts.theme && Highcharts.theme.dataLabelsColor || "gray",
                        style: {
                            textShadow1: "0 0 3px #4E4E4E, 0 0 3px #fcfcfc",
                            fontSize: "13px"
                        },
                        formatter: function () {
                            if ($("#setting_pointValue").val() == "n") {
                                return "";
                            } else {
                                if ((this.y + "").indexOf(".") != -1) return this.y.toFixed(2);
                                return this.y;
                            }
                        }
                    }
                },
                pie: {
                    innerSize: 100,
                    depth: 45,
                    cursor: "pointer",
                    allowPointSelect: true,
                    showInLegend: true,
                    dataLabels: {
                        enabled: true,
                        color: Highcharts.theme && Highcharts.theme.dataLabelsColor || "gray",
                        formatter: function () {
                            var p = this.percentage + "";
                            var pos = p.indexOf(".");
                            if (pos != -1) {
                                p = p.substr(0, pos + 2);
                            }
                            return "<b>" + this.point.name + "</b>: " + p + " %";
                        }
                    }
                },
                area: {
                    dataLabels: {
                        enabled: true,
                        color: Highcharts.theme && Highcharts.theme.dataLabelsColor || "gray",
                        style: {
                            textShadow1: "0 0 3px #4E4E4E, 0 0 3px #fcfcfc",
                            fontSize: "13px"
                        },
                        formatter: function () {
                            if ($("#setting_pointValue").val() == "n") {
                                return "";
                            } else {
                                if ((this.y + "").indexOf(".") != -1) return this.y.toFixed(2);
                                return this.y;
                            }
                        }
                    }
                },
                series: {
                    lineWidth: $("#type").val() == "bubble" ? 0 : 3,
                    point: {
                        events: {}
                    }
                }
            },
            series: chart_data
        };
    }
    var bindChart_temp = false;
    function bindChart() {
        option.chart.renderTo = objChart;
        event_temp = false;
        if (!bindChart_temp) {
            bindChart_temp = true;
            if (option3d_temp) {
                option.chart.options3d.enabled = true;
            } else {
                option.chart.options3d.enabled = false;
            }
            chart = new Highcharts.Chart(option, funback);
            chart.redraw(false);
            setTimeout(function () {
                if (objChart == "chart") {
                    $(".highcharts-container:eq(0) > svg > g:eq(0)").click().remove();
                    $(".highcharts-container:eq(0) > div").css({
                        left: "48px",
                        top: "440px",
                        width: "745px",
                        height: "40px",
                        overflow: "hidden"
                    }).show();
                } else {
                    $(".highcharts-container:eq(1) > svg > g:eq(0)").click().remove();
                    $(".highcharts-container:eq(1) > div").css({
                        position: "fixed",
                        left: "10px",
                        top: "2px",
                        width: "745px",
                        height: "35px",
                        overflow: "hidden"
                    }).show();
                }
                $(".highcharts-container").css("overflow", "visible");
                event_temp = true;
                bindChart_temp = false;
            }, 1500);
        }
    }
    $(".chart_type a").click(function () {
        if ($(this).attr("t") == "other") {
            $(".example-list").stop().t(-550).show().a({
                top: 0
            }, 300);
        } else {
            t_example = "";
            t = $(this).attr("t");
            $("#type").val(t);
            $.cookie("type", t);
            option.chart.type = t;
            getData();
            bindOption();
            chart3DControl();
            bindChart();
        }
    });
    function chart3DControl() {
        switch (t) {
            case "pie":
                option.chart.options3d = {
                    enabled: true,
                    alpha: 45,
                    beta: 0
                };
                break;

            case "column":
                option.chart.options3d = {
                    enabled: true,
                    alpha: 10,
                    beta: 15,
                    viewDistance: 25,
                    depth: 70
                };
                break;

            default:
                option.chart.options3d = {
                    enabled: false,
                    alpha: 0,
                    beta: 0
                };
                break;
        }
    }
    $(".scaleb").click(function () {
        if ($(this).hasAttr("t")) {
            t_example = "";
            t = $(this).attr("t");
            $("#type").val(t);
            $.cookie("type", t);
            option.chart.type = t;
            getData();
            bindOption();
            chart3DControl();
        } else {
            t_example = $(this).attr("v");
        }
        bindChartControl();
        $(".example-list").fadeOut(500);
    });
    $(".example-list .close").click(function () {
        $(".example-list").fadeOut(500);
    });
    $("#p_soon").click(function () { }).mouseenter(function () {
        $(".tip_soon").show();
    }).mouseleave(function () {
        $(".tip_soon").hide();
    });
    $(".p_tip .btn_tip_use").mouseenter(function () {
        $(".tip_detail").show();
    }).mouseleave(function () {
        $(".tip_detail").hide();
    });
    $(".p_tip a.close").click(function () {
        $(".tip_detail").hide();
    });
    $(".show_example").hover(function () {
        $(".show_example_div").stop().css("top", "-380px").show().animate({
            top: 0
        }, 300);
    }, function () {
        $(".show_example_div").hide();
    });
    $(".setting_font a").click(function () {
        if ($(this).hasClass("setting_1")) {
            var c = $(this).parent().parent();
            var v = c.attr("item");
            var temp_flag = c.hasClass("n") ? true : false;
            if (temp_flag) {
                $.cookie(v, "");
                $("#" + v).val("");
                c.removeClass("n");
            } else {
                $.cookie(v, "n");
                $("#" + v).val("n");
                c.addClass("n");
            }
            switch (v) {
                case "setting_title":
                    if (temp_flag) {
                        option.title.text = $("#chart_title").val();
                    } else option.title.text = "";
                    break;

                case "setting_x":
                    if (temp_flag) {
                        option.xAxis.tickWidth = 1;
                        option.xAxis.lineColor = "gray";
                        option.xAxis.labels.enabled = true;
                    } else {
                        option.xAxis.tickWidth = 0;
                        option.xAxis.lineColor = "#fff";
                        option.xAxis.labels.enabled = false;
                    }
                    break;

                case "setting_y":
                    if (temp_flag) {
                        option.yAxis.tickWidth = 1;
                        option.yAxis.lineColor = "gray";
                        option.yAxis.labels.enabled = true;
                    } else {
                        option.yAxis.tickWidth = 0;
                        option.yAxis.lineColor = "#fff";
                        option.yAxis.labels.enabled = false;
                    }
                    break;

                case "setting_legend":
                    if (temp_flag) {
                        option.legend.enabled = true;
                    } else {
                        option.legend.enabled = false;
                    }
                    break;
            }
            bindChart();
        } else {
            settingType = $(".chart-tool > div").index($(this).parent().parent()) + 1;
            $(".op_setting_font").show();
        }
    });
    $(".chart-tool > div").mouseenter(function () { }).mouseleave(function () { });
    $(".op_setting_font .ok").click(function () {
        $(".op_setting_font").hide();
        var family = $(".fontFamily a.c").attr("v");
        var fontSize = $(".fontSize a.c").attr("v");
        var color = $(".op_setting_color").css("background-color");
        switch (settingType) {
            case 1:
                $.cookie("setting_title_family", family);
                $.cookie("setting_title_fontSize", fontSize);
                $.cookie("setting_title_color", color);
                $("#setting_title_family").val(family);
                $("#setting_title_fontSize").val(fontSize);
                $("#setting_title_color").val(color);
                option.title.style.color = color;
                option.title.style.font = fontSize + "px " + family;
                break;

            case 3:
                $.cookie("setting_x_family", family);
                $.cookie("setting_x_fontSize", fontSize);
                $.cookie("setting_x_color", color);
                $("#setting_x_family").val(family);
                $("#setting_x_fontSize").val(fontSize);
                $("#setting_x_color").val(color);
                option.xAxis.labels.style.color = color;
                option.xAxis.labels.style.font = fontSize + "px " + family;
                break;

            case 2:
                $.cookie("setting_y_family", family);
                $.cookie("setting_y_fontSize", fontSize);
                $.cookie("setting_y_color", color);
                $("#setting_y_family").val(family);
                $("#setting_y_fontSize").val(fontSize);
                $("#setting_y_color").val(color);
                option.yAxis.labels.style.color = color;
                option.yAxis.labels.style.font = fontSize + "px " + family;
                break;
        }
        bindChartControl();
    });
    $(".op_setting_font .close").click(function () {
        $(".op_setting_font").hide();
    });
    $("#op_color").mouseenter(function () {
        $("#op_picker").stop().fadeIn(800);
    }).mouseleave(function () {
        $("#op_picker").stop().hide();
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
        $.cookie("v_c", null);
        $.cookie("type", null);
        $.cookie("setting_title", null);
        $.cookie("setting_legend", null);
        $.cookie("setting_x", null);
        $.cookie("setting_y", null);
        $("#setting_title_family").val("");
        $("#setting_title_fontSize").val("");
        $("#setting_title_color").val("");
        $("#setting_x_family").val("");
        $("#setting_x_fontSize").val("");
        $("#setting_x_color").val("");
        $("#setting_y_family").val("");
        $("#setting_y_fontSize").val("");
        $("#setting_y_color").val("");
        $("#v_c").val("");
        $("#type").val("");
        $("#setting_title").val("");
        $("#setting_legend").val("");
        $("#setting_x").val("");
        $("#setting_y").val("");
        bindOption();
        bindChart();
    });
    $(".s2").mouseenter(function () {
        $(this).find(".select_3d").show();
    }).mouseleave(function () {
        $(this).find(".select_3d").hide();
    });
    $("#input_change_3d_x").on("change", function () {
        option.chart.renderTo = objChart;
        chart.options.chart.options3d.alpha = this.value;
        showValues();
        chart.redraw(false);
    });
    $("#input_change_3d_y").on("change", function () {
        option.chart.renderTo = objChart;
        chart.options.chart.options3d.beta = this.value;
        showValues();
        chart.redraw(false);
    });
    function showValues() { }
    $(".s1").mouseenter(function () {
        $(this).find(".select_bg").show();
    }).mouseleave(function () {
        $(this).find(".select_bg").hide();
    });
    $(".select_bg > div[id!=select_color]").click(function () {
        v_c = $(this).attr("c");
        $("#v_c").val(v_c);
        $.cookie("v_c", v_c);
        option.chart.backgroundColor = v_c;
        bindChartControl();
    });
    $("#select_color").mouseenter(function () {
        $(".select_color_div").show();
    }).mouseleave(function () {
        $(".select_color_div").hide();
    });
    $(".btn_submit_color").click(function () {
        v_c = $("#color").css("background-color");
        $("#v_c").val(v_c);
        $.cookie("v_c", v_c);
        $("#select_color").css("background-color", v_c);
        $(".select_color_div").hide();
        option.chart.backgroundColor = v_c;
        bindChartControl();
    });
    $(".chart-fullscreen").click(function () {
        $(".chart-fullscreen-div").show();
        objChart = "chart_fullscreen";
        option.chart.renderTo = objChart;
        bindChart();
    });
    $(".chart-fullscreen-div .close").click(function () {
        $(".chart-fullscreen-div").fadeOut(500);
        objChart = "chart";
    });
    $(".chart-refresh").click(function () {
        bindChart();
    });
    $(".chart-3d").click(function () {
        if (option3d_temp) $(this).removeClass("k"); else $(this).addClass("k");
        option3d_temp = !option3d_temp;
        bindChart();
    });
    function bindChartControl() {
        funback = function () {
            return false;
        };
        clearInterval(ii_funback);
        switch (t_example) {
            case "stat_speed":
                stat_speed();
                break;

            case "stat_multi_pie":
                stat_multi_pie();
                break;

            case "stat_clock":
                stat_clock();
                break;

            default:
                bindChart();
                break;
        }
    }
    function stat_multi_pie() {
        var colors = Highcharts.getOptions().colors, categories = ["MSIE", "Firefox", "Chrome", "Safari", "Opera"], name = "Browser brands", data = [{
            y: 55.11,
            color: colors[0],
            drilldown: {
                name: "MSIE versions",
                categories: ["MSIE 6.0", "MSIE 7.0", "MSIE 8.0", "MSIE 9.0"],
                data: [10.85, 7.35, 33.06, 2.81],
                color: colors[0]
            }
        }, {
            y: 21.63,
            color: colors[1],
            drilldown: {
                name: "Firefox versions",
                categories: ["Firefox 2.0", "Firefox 3.0", "Firefox 3.5", "Firefox 3.6", "Firefox 4.0"],
                data: [.2, .83, 1.58, 13.12, 5.43],
                color: colors[1]
            }
        }, {
            y: 11.94,
            color: colors[2],
            drilldown: {
                name: "Chrome versions",
                categories: ["Chrome 5.0", "Chrome 6.0", "Chrome 7.0", "Chrome 8.0", "Chrome 9.0", "Chrome 10.0", "Chrome 11.0", "Chrome 12.0"],
                data: [.12, .19, .12, .36, .32, 9.91, .5, .22],
                color: colors[2]
            }
        }, {
            y: 7.15,
            color: colors[3],
            drilldown: {
                name: "Safari versions",
                categories: ["Safari 5.0", "Safari 4.0", "Safari Win 5.0", "Safari 4.1", "Safari/Maxthon", "Safari 3.1", "Safari 4.1"],
                data: [4.55, 1.42, .23, .21, .2, .19, .14],
                color: colors[3]
            }
        }, {
            y: 2.14,
            color: colors[4],
            drilldown: {
                name: "Opera versions",
                categories: ["Opera 9.x", "Opera 10.x", "Opera 11.x"],
                data: [.12, .37, 1.65],
                color: colors[4]
            }
        }];
        var browserData = [];
        var versionsData = [];
        for (var i = 0; i < data.length; i++) {
            browserData.push({
                name: categories[i],
                y: data[i].y,
                color: data[i].color
            });
            for (var j = 0; j < data[i].drilldown.data.length; j++) {
                var brightness = .2 - j / data[i].drilldown.data.length / 5;
                versionsData.push({
                    name: data[i].drilldown.categories[j],
                    y: data[i].drilldown.data[j],
                    color: getRandomColor(i)
                });
            }
        }
        var setting_title_color = $("#setting_title_color").val().length > 0 ? unescape($("#setting_title_color").val()) : Highcharts.theme && Highcharts.theme.title.style.color || "Gray";
        var setting_title_fontSize = parseInt($("#setting_title_fontSize").val().length > 0 ? $("#setting_title_fontSize").val() : 13);
        var setting_title_family = $("#setting_title_family").val().length > 0 ? unescape($("#setting_title_family").val()) : "SimSun";
        setting_title_family = setting_title_family.replace("%20", " ");
        setting_title_font = $("#setting_title_color").val().length > 0 ? setting_title_fontSize + "px " + setting_title_family : Highcharts.theme && Highcharts.theme.title.style.font || "13 SimHei";
        option = {
            chart: {
                renderTo: objChart,
                backgroundColor: v_c,
                type: "pie",
                options3d: {
                    enabled: false,
                    alpha: 45,
                    beta: 0
                }
            },
            title: {
                text: $("#setting_title").val() == "n" ? "两层饼图" : "",
                style: {
                    color: setting_title_color,
                    font: setting_title_font
                }
            },
            yAxis: {
                title: {
                    text: "Total percent market share"
                }
            },
            plotOptions: {
                pie: {
                    shadow: false,
                    center: ["50%", "50%"],
                    innerSize: 100,
                    depth: 45
                }
            },
            tooltip: {
                valueSuffix: "%"
            },
            series: [{
                name: "Browsers",
                data: browserData,
                size: "60%",
                dataLabels: {
                    formatter: function () {
                        return this.y > 5 ? this.point.name : null;
                    },
                    color: "white",
                    distance: -30
                }
            }, {
                name: "Versions",
                data: versionsData,
                size: "90%",
                innerSize: "70%",
                dataLabels: {
                    formatter: function () {
                        return this.y > 1 ? "<b>" + this.point.name + ":</b> " + this.y + "%" : null;
                    }
                }
            }]
        };
    }
    function stat_clock() {
        var now = stat_clock_getNow();
        var setting_title_color = $("#setting_title_color").val().length > 0 ? unescape($("#setting_title_color").val()) : Highcharts.theme && Highcharts.theme.title.style.color || "Gray";
        var setting_title_fontSize = parseInt($("#setting_title_fontSize").val().length > 0 ? $("#setting_title_fontSize").val() : 13);
        var setting_title_family = $("#setting_title_family").val().length > 0 ? unescape($("#setting_title_family").val()) : "SimSun";
        setting_title_family = setting_title_family.replace("%20", " ");
        setting_title_font = $("#setting_title_color").val().length > 0 ? setting_title_fontSize + "px " + setting_title_family : Highcharts.theme && Highcharts.theme.title.style.font || "13 SimHei";
        option = {
            chart: {
                renderTo: objChart,
                type: "gauge",
                plotBackgroundColor: null,
                plotBackgroundImage: null,
                plotBorderWidth: 0,
                plotShadow: false,
                backgroundColor: v_c
            },
            credits: {
                enabled: false
            },
            title: {
                text: $("#setting_title").val() == "n" ? "时钟" : $("#chart_title").val(),
                style: {
                    color: setting_title_color,
                    font: setting_title_font
                }
            },
            pane: {
                background: [{}, {
                    backgroundColor: Highcharts.svg ? {
                        radialGradient: {
                            cx: .5,
                            cy: -.4,
                            r: 1.9
                        },
                        stops: [[.5, "rgba(255, 255, 255, 0.2)"], [.5, "rgba(200, 200, 200, 0.2)"]]
                    } : null
                }]
            },
            yAxis: {
                labels: {
                    distance: -20
                },
                min: 0,
                max: 12,
                lineWidth: 0,
                showFirstLabel: false,
                minorTickInterval: "auto",
                minorTickWidth: 1,
                minorTickLength: 5,
                minorTickPosition: "inside",
                minorGridLineWidth: 0,
                minorTickColor: "#666",
                tickInterval: 1,
                tickWidth: 2,
                tickPosition: "inside",
                tickLength: 10,
                tickColor: "#666",
                title: {
                    text: "Powered by<br/>Highcharts",
                    style: {
                        color: "#BBB",
                        fontWeight: "normal",
                        fontSize: "8px",
                        lineHeight: "10px"
                    },
                    y: 10
                }
            },
            tooltip: {
                formatter: function () {
                    return this.series.chart.tooltipText;
                }
            },
            series: [{
                data: [{
                    id: "hour",
                    y: now.hours,
                    dial: {
                        radius: "60%",
                        baseWidth: 4,
                        baseLength: "95%",
                        rearLength: 0
                    }
                }, {
                    id: "minute",
                    y: now.minutes,
                    dial: {
                        baseLength: "95%",
                        rearLength: 0
                    }
                }, {
                    id: "second",
                    y: now.seconds,
                    dial: {
                        radius: "100%",
                        baseWidth: 1,
                        rearLength: "20%"
                    }
                }],
                animation: false,
                dataLabels: {
                    enabled: false
                }
            }]
        };
        funback = function (chart) {
            ii_funback = setInterval(function () {
                var hour = chart.get("hour"), minute = chart.get("minute"), second = chart.get("second"), now = stat_clock_getNow(), animation = now.seconds == 0 ? false : {
                    easing: "easeOutElastic"
                };
                chart.tooltipText = stat_clock_pad(Math.floor(now.hours), 2) + ":" + stat_clock_pad(Math.floor(now.minutes * 5), 2) + ":" + stat_clock_pad(now.seconds * 5, 2);
                hour.update(now.hours, true, animation);
                minute.update(now.minutes, true, animation);
                second.update(now.seconds, true, animation);
            }, 1e3);
        };
        bindChart();
    }
    function stat_clock_getNow() {
        var now = new Date();
        return {
            hours: now.getHours() + now.getMinutes() / 60,
            minutes: now.getMinutes() * 12 / 60 + now.getSeconds() * 12 / 3600,
            seconds: now.getSeconds() * 12 / 60
        };
    }
    function stat_clock_pad(number, length) {
        return new Array((length || 2) + 1 - String(number).length).join(0) + number;
    }
    function stat_half_pie() {
        t_example = "";
        t = "pie";
        $("#type").val(t);
        $.cookie("type", t);
        getData();
        bindOption();
        option.plotOptions.pie.startAngle = 90;
        option.plotOptions.pie.endAngle = -180;
        bindChart();
    }
    function stat_speed() {
        var setting_title_color = $("#setting_title_color").val().length > 0 ? unescape($("#setting_title_color").val()) : Highcharts.theme && Highcharts.theme.title.style.color || "Gray";
        var setting_title_fontSize = parseInt($("#setting_title_fontSize").val().length > 0 ? $("#setting_title_fontSize").val() : 13);
        var setting_title_family = $("#setting_title_family").val().length > 0 ? unescape($("#setting_title_family").val()) : "SimSun";
        setting_title_family = setting_title_family.replace("%20", " ");
        setting_title_font = $("#setting_title_color").val().length > 0 ? setting_title_fontSize + "px " + setting_title_family : Highcharts.theme && Highcharts.theme.title.style.font || "13 SimHei";
        option = {
            chart: {
                renderTo: objChart,
                backgroundColor: v_c,
                type: "gauge",
                plotBackgroundColor: null,
                plotBackgroundImage: null,
                plotBorderWidth: 0,
                plotShadow: false
            },
            title: {
                text: $("#setting_title").val() == "n" ? "速度计" : $("#chart_title").val(),
                style: {
                    color: setting_title_color,
                    font: setting_title_font
                }
            },
            pane: {
                startAngle: -150,
                endAngle: 150,
                background: [{
                    backgroundColor: {
                        linearGradient: {
                            x1: 0,
                            y1: 0,
                            x2: 0,
                            y2: 1
                        },
                        stops: [[0, "#FFF"], [1, "#333"]]
                    },
                    borderWidth: 0,
                    outerRadius: "109%"
                }, {
                    backgroundColor: {
                        linearGradient: {
                            x1: 0,
                            y1: 0,
                            x2: 0,
                            y2: 1
                        },
                        stops: [[0, "#333"], [1, "#FFF"]]
                    },
                    borderWidth: 1,
                    outerRadius: "107%"
                }, {}, {
                    backgroundColor: "#DDD",
                    borderWidth: 0,
                    outerRadius: "105%",
                    innerRadius: "103%"
                }]
            },
            yAxis: {
                min: 0,
                max: 200,
                minorTickInterval: "auto",
                minorTickWidth: 1,
                minorTickLength: 10,
                minorTickPosition: "inside",
                minorTickColor: "#666",
                tickPixelInterval: 30,
                tickWidth: 2,
                tickPosition: "inside",
                tickLength: 10,
                tickColor: "#666",
                labels: {
                    step: 2,
                    rotation: "auto"
                },
                title: {
                    text: "km/h"
                },
                plotBands: [{
                    from: 0,
                    to: 120,
                    color: "#55BF3B"
                }, {
                    from: 120,
                    to: 160,
                    color: "#DDDF0D"
                }, {
                    from: 160,
                    to: 200,
                    color: "#DF5353"
                }]
            },
            series: [{
                name: "Speed",
                data: [80],
                tooltip: {
                    valueSuffix: " km/h"
                }
            }]
        };
        funback = function (chart) {
            if (!chart.renderer.forExport) {
                setInterval(function () {
                    var point = chart.series[0].points[0], newVal, inc = Math.round((Math.random() - .5) * 20);
                    newVal = point.y + inc;
                    if (newVal < 0 || newVal > 200) {
                        newVal = point.y - inc;
                    }
                    point.update(newVal);
                }, 3e3);
            }
        };
        bindChart();
    }
});

function getRandomColor(i) {
    if (i == 0) {
        return "#FFCA04";
    } else if (i == 1) {
        return "#61C5F4";
    } else if (i == 2) {
        return "#E547F1";
    } else if (i == 3) {
        return "#B3FF00";
    } else if (i == 4) {
        return "red";
    } else {
        return "#" + ("00000" + (Math.random() * 16777216 << 0).toString(16)).slice(-6);
    }
}