﻿var t = "", v = "", v_c = "", c_grid = null, data_default = null, data_example = null, s_temp_flag = !1, settingType = 1, setting_title = { family: "宋体", fontSize: 15, color: "" }, setting_legend = { family: "宋体", fontSize: 15, color: "" }, setting_x = { family: "宋体", fontSize: 15, color: "" }, setting_y = { family: "宋体", fontSize: 15, color: "" }, mode_temp = !0, fixed_temp = !0, soon_temp = !1, step_temp = !1, dataSource = "tt"; $(function () { function a(a) { a ? fixed_temp || ($("#btn_fixed").addClass("c").attr("title", "已经固定我,安心填内容."), fixed_temp = !0) : fixed_temp && ($("#btn_fixed").removeClass("c").attr("title", "没有固定我,将自动隐藏."), fixed_temp = !1) } function b() { $("#if_chart").attr("src", "chart.aspx?theme=" + v + "&type=" + t + "&v_c=" + v_c), $(".step_content").stop().hide().css("overflow", "visible"), s_temp_flag = !1 } function c() { mode_temp ? (mode_temp = !1, step_temp = !1, $("#btn_step_2").hide(), alert("图表即将生成,生成后您可以继续在左侧定制自己的内容."), $("#right,#btn_fixed").show(), $(".step_content").stop().hide().css("overflow", "visible"), b(), $(".step_item").mouseenter(function () { step_temp || s_temp_flag || $(this).hasClass("edit") && fixed_temp || (step_temp = !0, $(this).children(".step_content").stop().show().w(1).a({ width: 500 }, 200).css("overflow", "visible"), $(this).children(".step_content").children(".step_content_conetnt").hide(), setTimeout(function () { $(".step_content").children(".step_content_conetnt").show(), step_temp = !1 }, 200)) }).mouseleave(function () { $(this).hasClass("edit") && fixed_temp || $(this).children(".step_content").stop().hide().css("overflow", "visible"), s_temp_flag = !1 })) : (a(!1), b()) } function e() { var a = []; a = "pie" == t ? [["X轴", "系列"], ["第一项", 0], ["第二项", 0], ["第三项", 0]] : [["X轴", "系列1", "系列2", "系列3"], ["第一项", 0, 0, 0], ["第二项", 0, 0, 0], ["第三项", 0, 0, 0]], c_grid = $("#data_grid"), data_default = c_grid.handsontable({ minSpareRows: 1, minSpareCols: 1, rowHeaders: !1, colHeaders: !1, columnSorting: !0, data: a, removeRowPlugin: !0 }).data("handsontable"), $(".htCore").addClass("table-striped").addClass("table-hover").addClass("table-bordered") } function f() { var a = []; a = "pie" == t ? [["月份", "房屋水电费用"], ["一月", 1010], ["二月", 1030], ["三月", 1040], ["四月", 1020], ["五月", 1100], ["六月", 1020], ["七月", 1120], ["八月", 1050], ["九月", 1080], ["十月", 1120], ["十一月", 1210], ["十二月", 1090]] : [["月份", "房屋水电费用", "衣食费用", "交通费用"], ["一月", 1010, 800, 200], ["二月", 1030, 900, 200], ["三月", 1040, 870, 200], ["四月", 1020, 970, 200], ["五月", 1100, 780, 200], ["六月", 1020, 920, 200], ["七月", 1120, 780, 200], ["八月", 1050, 840, 200], ["九月", 1080, 920, 200], ["十月", 1120, 810, 200], ["十一月", 1210, 880, 200], ["十二月", 1090, 920, 200]], c_grid = $("#data_grid_example"), data_example = c_grid.handsontable({ minSpareRows: 1, minSpareCols: 1, rowHeaders: !1, columnSorting: !0, colHeaders: !1, data: a, removeRowPlugin: !0 }).data("handsontable"), $(".htCore").addClass("table-striped").addClass("table-hover").addClass("table-bordered") } function g() { return e(), !1 } function h() { return f(), !1 } $("#btn_fixed").click(function () { fixed_temp ? ($("#btn_fixed").removeClass("c").attr("title", "没有固定我"), fixed_temp = !1) : ($("#btn_fixed").addClass("c").attr("title", "已经固定我,安心填内容"), fixed_temp = !0) }), $(".content-chart-detail > div:eq(0)").show(), $(".content-chart-type a").mousemove(function () { var a = $(".content-chart-type a").index($(this)); $(this).removeClass("n").siblings().addClass("n"), $(".content-chart-detail > div:eq(" + a + ")").show().siblings().hide() }).click(function () { t = $(this).attr("t"), $(this).addClass("c").siblings().removeClass("c"), mode_temp ? (a(!1), $(".step_item.edit").css("background-position", "-100px 48px "), $(".step_content").stop().hide().css("overflow", "visible"), step_temp = !0, $(".step_content:eq(1)").stop().show().w(1).a({ width: 500 }, 500).css("overflow", "visible"), $(".step_content:eq(1)").children(".step_content_conetnt").hide(), setTimeout(function () { $(".step_content").children(".step_content_conetnt").show(), step_temp = !step_temp, g() }, 1e3)) : (a(!1), b()) }), $(".content-chart-detail a").click(function () { t = $(this).parent().attr("t"), $(".content-chart-detail a").removeClass("c"), $(this).addClass("c"), mode_temp || (a(!1), b()) }), (null == $.cookie("firstMake") || "" == $.cookie("firstMake")) && $(".op_descDiv").show(), $(".op_descDiv a").click(function () { $.cookie("firstMake", "true"), $(".op_descDiv").fadeOut(500) }), $(".chart-fullscreen").click(function () { window.open("chart.aspx?theme=" + v + "&type=" + t + "&chart_full=full&v_c=" + v_c) }), $("#btn_use").click(function () { soon_temp = !1, $.cookie("soon_temp", "false"), dataSource = "tt_example", $("#form_data").submit() }), $("#p_soon").click(function () { "pie" == t ? alert("饼状图表暂不支持快速绘图功能.") : (soon_temp = !0, $.cookie("soon_temp", "true"), dataSource = "tt", $("#form_data").submit()) }).mouseenter(function () { $(".tip_soon").show() }).mouseleave(function () { $(".tip_soon").hide() }), $(".p_tip .btn_tip_use").click(function () { $(this).siblings(".tip_detail").show() }).mouseleave(function () { }), $(".p_tip a.close").click(function () { $(".tip_detail").hide() }), $(".step_item > p").click(function () { $(this).parent().mouseenter() }), $(".listTop > div[id!=select_color]").click(function () { v = $(this).attr("v"), c() }), $("#select_color").mouseenter(function () { $(".select_color_div").show() }).mouseleave(function () { $(".select_color_div").hide() }), $(".btn_submit_color").click(function () { v_c = $("#color").css("background-color"), $("#select_color").css("background-color", v_c), $(".select_color_div").hide(), v = "vc", c() }), $("#form_data").form({ onSubmit: function () { var a, b, c, d, e, f, g, h, i, j, k, l, m, n, o; if (!$("#chart_title").val()) return alert("你没有填写标题!"), $("#chart_title").focus(), !1; if (a = null, soon_temp) a = [["X轴", "系列1", ""], ["第一项", 0, ""], ["第二项", 0, ""][""]]; else if (a = "tt" == dataSource ? data_default.getData() : data_example.getData(), a.length < 1) return alert("你没有编辑内容!"), !1; if (b = "", c = "", d = "", e = "", f = "", g = "", h = "", i = "", j = "", k = "", l = "", m = "", null != a) { for (n = 0; n < a.length - 1; n++) { for (o = 0; o < a[n].length - 1; o++) { if (null == a[n][o] || "" == a[n][o].toString()) a[n][o] = n > 0 && o > 0 ? "0" : " "; else if (n > 0 && o > 0 && isNaN(a[n][o].toString())) return alert("需要输入数字!"), c_grid.handsontable("selectCell", n, o), !1; switch (o) { case 1: d += a[n][o].toString() + "_"; break; case 2: e += a[n][o].toString() + "_"; break; case 3: f += a[n][o].toString() + "_"; break; case 4: g += a[n][o].toString() + "_"; break; case 5: h += a[n][o].toString() + "_"; break; case 6: i += a[n][o].toString() + "_"; break; case 7: j += a[n][o].toString() + "_"; break; case 8: k += a[n][o].toString() + "_"; break; case 9: l += a[n][o].toString() + "_"; break; case 10: m += a[n][o].toString() + "_" } } c += a[n][0].toString() + "_" } c = c.substr(0, c.length - 1) } b += c + "&", d = "" == d ? "" : d.substr(0, d.length - 1) + "&", e = "" == e ? "" : e.substr(0, e.length - 1) + "&", f = "" == f ? "" : f.substr(0, f.length - 1) + "&", g = "" == g ? "" : g.substr(0, g.length - 1) + "&", h = "" == h ? "" : h.substr(0, h.length - 1) + "&", i = "" == i ? "" : i.substr(0, i.length - 1) + "&", j = "" == j ? "" : j.substr(0, j.length - 1) + "&", k = "" == k ? "" : k.substr(0, k.length - 1) + "&", l = "" == l ? "" : l.substr(0, l.length - 1) + "&", m = "" == m ? "" : m.substr(0, m.length - 1) + "&", b = b + d + e + f + g + h + i + j + k + l + m, b += $("#chart_title").val(), $("#hd_data").val(b) }, success: function (c) { "1" == c ? mode_temp ? confirm("保存成功,是否继续?") && ($(".step_content").stop().hide().css("overflow", "visible"), step_temp = !0, $(".step_content:eq(2)").stop().show().w(1).a({ width: 500 }, 1e3).css("overflow", "visible"), $(".step_content:eq(2)").children(".step_content_conetnt").hide(), setTimeout(function () { $(".step_content").children(".step_content_conetnt").show(), step_temp = !step_temp }, 500), $(".step_item.bg").css("background-position", "-100px 48px ")) : (a(!1), b()) : alert("保存失败") } }), $("#btn_data").click(function () { soon_temp = !1, $.cookie("soon_temp", "false"), c_grid.handsontable("selectCell", 0, 0), $("#form_data").submit() }), $("#btn_step_2").hide().click(function () { a(!1), $(".step_content").stop().hide().css("overflow", "visible"), step_temp = !0, $(".step_content:eq(1)").stop().show().w(1).a({ width: 500 }, 1e3).css("overflow", "visible"), $(".step_content:eq(1)").children(".step_content_conetnt").hide(), setTimeout(function () { $(".step_content").children(".step_content_conetnt").show(), step_temp = !step_temp, g() }, 500) }); var d = !1; $("#btn_example").click(function () { "示例" == $("#btn_example").html() ? (d || (h(), d = !0), $("#p_tt").hide(), $("#p_tt_example").show(), $("#btn_use").show(), $("#btn_data").hide(), $(this).html("返回"), c_grid = $("#data_grid_example"), dataSource = "tt_example", $("#chart_title").val() && "" != $("#chart_title").val() || $("#chart_title").after('<input id="chart_title" value="一年的支出情况" />').remove()) : ($("#p_tt").show(), $("#p_tt_example").hide(), $("#btn_use").hide(), $("#btn_data").show(), $(this).html("示例"), dataSource = "tt", c_grid = $("#data_grid"), "一年的支出情况" == $("#chart_title").val() && $("#chart_title").val("")) }), $("#btn_example_2").click(function () { "示例" == $("#btn_example").html() && ($("#btn_example").click(), $(".tip_detail").fadeOut(1e3)) }), $("#data_edit .del").afterbind("click", function () { $(this).parent().remove() }), $(".data_edit_add").afterbind("click", function () { var a = $("<div class='data_item'><input class='data_item_title' placeholder='填写项标题' /><input class='data_item_content' placeholder='填写内容,以\",\"分隔.' /><a class='del op'></a></div>"); $("#data_edit").append(a) }), $(".chart-tool > div").click(function () { if (event.target == this) { var a = $(this).attr("item"); $(this).hasClass("n") ? ($.cookie(a, ""), $(this).removeClass("n")) : ($.cookie(a, "n"), $(this).addClass("n"), $(this).find(".setting_font").hide()), b() } }), $(".chart-tool > div").mouseenter(function () { $(this).hasClass("n") || $(this).find(".setting_font").stop().slideDown(300) }).mouseleave(function () { $(this).find(".setting_font").stop().slideUp(300) }), $(".setting_font a").click(function () { settingType = $(".chart-tool > div").index($(this).parent().parent()) + 1, $(".op_setting_font").show() }), $(".op_setting_item > a").click(function () { $(this).hasClass("c") || $(this).addClass("c").siblings("a").removeClass("c") }), $(".clearCookie").click(function () { $.cookie("setting_title_family", null), $.cookie("setting_title_fontSize", null), $.cookie("setting_title_color", null), $.cookie("setting_x_family", null), $.cookie("setting_x_fontSize", null), $.cookie("setting_x_color", null), $.cookie("setting_y_family", null), $.cookie("setting_y_fontSize", null), $.cookie("setting_y_color", null), b() }), $(".show_example").hover(function () { $(".show_example_div").stop().css("top", "-380px").show().animate({ top: 0 }, 300) }, function () { $(".show_example_div").hide() }), $(".s1,.s2,.s3").click(function () { $(".step_item:eq(" + $(".s1,.s2,.s3").index($(this)) + ")").mouseenter(), s_temp_flag = !0 }), $(".op_setting_font .ok").click(function () { var a, c, d; switch ($(".op_setting_font").hide(), $(".setting_font").stop().slideUp(300), a = $(".fontFamily a.c").attr("v"), c = $(".fontSize a.c").attr("v"), d = $(".op_setting_color").css("background-color"), settingType) { case 1: setting_title.family = a, setting_title.fontSize = c, setting_title.color = d, $.cookie("setting_title_family", setting_title.family), $.cookie("setting_title_fontSize", setting_title.fontSize), $.cookie("setting_title_color", setting_title.color); break; case 3: setting_x.family = a, setting_x.fontSize = c, setting_x.color = d, $.cookie("setting_x_family", setting_x.family), $.cookie("setting_x_fontSize", setting_x.fontSize), $.cookie("setting_x_color", setting_x.color); break; case 2: setting_y.family = a, setting_y.fontSize = c, setting_y.color = d, $.cookie("setting_y_family", setting_y.family), $.cookie("setting_y_fontSize", setting_y.fontSize), $.cookie("setting_y_color", setting_y.color) } b() }), $(".op_setting_font .close").click(function () { $(".op_setting_font").hide(), $(".setting_font").stop().slideUp(300) }), $("#op_color").mouseenter(function () { $("#op_picker").stop().fadeIn(800) }).mouseleave(function () { $("#op_picker").stop().hide() }) });