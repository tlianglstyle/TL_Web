$(function () {
    $('.listTop > div').click(function () {
        if (!$(this).hasClass('more')) {
            var v = $(this).attr('v');
            window.location.href = "main.aspx?theme=" + v;
        }
    });
    $('.listTop > div.more').click(function () {
        if (!config_temp) {
            if (!config_status) {
                config_temp = true;
                $('html, body').animate({ scrollTop: 600 }, 200);
                $('.p-config').stop().css({ 'margin': '0px', 'padding': '0px' }).slideDown(400);
                setTimeout(function () { config_status = !config_status; config_temp = false; }, 400);
                $('#btn_config_close').show();
            }
        }
    });
    setTimeout(function () {
        $('.highcharts-container > svg > g:eq(0)').click().remove();
        $('.highcharts-container').css('overflow', 'visible');

        $('.highcharts-container > div').css({ 'right': '-160px', 'top': '110px' }).show();

    }, 2000);
    setInterval(function () {
        $('.highcharts-container > div').show();
        $('.highcharts-container > div > div').css({ 'border': '0px' });
        $('.highcharts-container > div > div > div').css({ 'padding': '7px 20px' });
        $('.highcharts-container > div > div > hr').remove();
    }, 10);
    var config_status = false;
    var config_temp = false;
    $('#btn_config').click(function () {
        if (!config_temp) {
            if (!config_status) {
                config_temp = true;
                $('html, body').animate({ scrollTop: 600 }, 200);
                $('.p-config').stop().css({ 'margin': '0px', 'padding': '0px' }).slideDown(400);
                setTimeout(function () { config_status = !config_status; config_temp = false; }, 400);
                $('#btn_config_close').show();
            } else {
                config_temp = true;
                $('.p-config').stop().css({ 'margin': '0px', 'padding': '0px' }).slideUp(200);
                setTimeout(function () { config_status = !config_status; config_temp = false; }, 200);
                $('#btn_config_close').hide();
            }
        }
    });
    $('#btn_config_close').click(function () {
        if (config_status && !config_temp) {
            config_temp = true;
            $('.p-config').stop().css({ 'margin': '0px', 'padding': '0px' }).slideUp(200);
            setTimeout(function () { config_status = !config_status; config_temp = false; }, 400);
            $('#btn_config_close').hide();
        }
    });
    $('#bt-view-live').toggle(function () {
        $(this).a({ left: 150 }, 200);
        $('#box-live-test').a({ left: 0 }, 200);
    }, function () {
        $(this).a({ left: 0 }, 200);
        $('#box-live-test').a({ left: -150 }, 200);
    });
    $('.nav-config a').click(function () {
        alert('功能维护中!');
    });
    $('.content-chart-detail > div:eq(0)').show();
//    $('.content-chart-type a').mousemove(function () {
//        var i = $('.content-chart-type a').index($(this));
//        $(this).removeClass('n').siblings().addClass('n');
//        $('.content-chart-detail > div:eq(' + i + ')').show().siblings().hide();
//    });
    $('#chart').highcharts({
        plotBackgroundImage: 'i/default/chart-type-pie.png',
        title: {
            text: 'Monthly Average Temperature',
            x: -20 //center
        },
        subtitle: {
            text: 'Source: WorldClimate.com',
            x: -20
        },
        xAxis: {
            categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
        },
        yAxis: {
            title: {
                text: 'Temperature (°C)'
            },
            plotLines: [{
                value: 0,
                width: 1,
                color: '#808080'
            }]
        },
        tooltip: {
            valueSuffix: '°C'
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle',
            borderWidth: 0
        },
        series: [{
            name: 'Tokyo',
            data: [7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6]
        }, {
            name: 'New York',
            data: [-0.2, 0.8, 5.7, 11.3, 17.0, 22.0, 24.8, 24.1, 20.1, 14.1, 8.6, 2.5]
        }, {
            name: 'Berlin',
            data: [-0.9, 0.6, 3.5, 8.4, 13.5, 17.0, 18.6, 17.9, 14.3, 9.0, 3.9, 1.0]
        }, {
            name: 'London',
            data: [3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8]
        }]
    });
});