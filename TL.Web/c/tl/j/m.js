var index = 1;
var nav_bg = [{ x: 1, y: 1 }, { x: 0, y: 0 }, { x: 1, y: -184 }, { x: 1, y: -248 }, { x: 1, y: -313 }, { x: 1, y: -737}];
$(function () {
    // $('#nav #nav_menubar div a').stop().a({ left: -57 }, 150);
    $('#nav #nav_menubar div').hover(function () {
        if (index == $('#nav #nav_menubar div').index(this) + 1) {
            $(this).children('a').stop().a({ left: -57 }, 150);
        } else {
            $(this).children('a').stop().a({ left: 0 }, 150);
        }
    }, function () {
        if (index == $('#nav #nav_menubar div').index(this) + 1) {
            $(this).children('a').stop().a({ left: 0 }, 150);
        } else {
            $(this).children('a').stop().a({ left: -57 }, 150);
        }
    });
    var searchvalue = "搜索你喜欢的";
    $('#nav #nav_search input').focus(function () { if ($(this).val() == searchvalue) $(this).val(''); $('#nav #nav_search').addClass('focus'); }).blur(function () { if ($(this).val() == "") $(this).val(searchvalue); $('#nav #nav_search').removeClass('focus'); });
})