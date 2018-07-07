function ObtenerComparativoChartPed() {
    $.ajax({
        url: '/Home/ObtenerComparativoChart',
        type: "POST",
        dataType: "json",
        async: false,
        success: function (result) {
            // si la funcion se ejecuta lanzara un alert
            $('#bar-chart-pedido').html('');
            var chartpedido = Morris.Bar({
                element: 'bar-chart-pedido',
                data: result,
                xkey: 'y',
                ykeys: ['PedidoRecibido','PedidoEnviado'],
                labels: ['Ped. Recibidos','Ped. Enviados'],
                hideHover: 'false',
                resize: true,
                smooth: false,
                barColors: ["#5cb85c", "#f0ad4e"],
            });

        },
        error: function (error) {
            // si hay un error lanzara el mensaje de error
            str += '<p class="text-center">Error al cargar grafico comparativo Chart.</p>';
            $('#bar-chart-pedido').html(str);
        }
    });
};

function ObtenerComparativoChartTrans() {
    $.ajax({
        url: '/Home/ObtenerComparativoChart',
        type: "POST",
        dataType: "json",
        async: false,
        success: function (result) {
            // si la funcion se ejecuta lanzara un alert
            $('#bar-chart-transferencia').html('');
            var charttransferencia = Morris.Bar({
                element: 'bar-chart-transferencia',
                data: result,
                xkey: 'y',
                ykeys: ['TransferenciaRecibida', 'TransferenciaEnviada'],
                labels: ['Trans. Enviadas', 'Trans. Recibidas'],
                hideHover: 'false',
                resize: true,
                smooth: false,
                barColors: ["#0b62a4", "#f0ad4e"],
            });
        },
        error: function (error) {
            // si hay un error lanzara el mensaje de error
            str += '<p class="text-center">Error al cargar grafico comparativo Chart.</p>';
            $('#bar-chart-transferencia').html(str);
        }
    });
};

function ObtenerComparativoDonus() {
    $.ajax({
        url: '/Home/ObtenerComparativoDonus',
        type: "POST",
        dataType: "json",
        async: false,
        success: function (result) {
            // si la funcion se ejecuta lanzara un alert
            $('#donut-chart-home').html('');
            Morris.Donut({
                element: 'donut-chart-home',
                data: result,
                resize: true
            });
        },
        error: function (error) {
            // si hay un error lanzara el mensaje de error
            str += '<p class="text-center">Error al cargar grafico comparativo Donus.</p>';
            $('#donut-chart-home').html(str);
        }
    });
};

function ObtenerEstadistica() {
    $.ajax({
        url: '/Home/ObtenerEstadisticas', 
        type: "POST",
        dataType: "json",
        async: false,
        success: function (result) {
            // si la funcion se ejecuta lanzara un alert
            $("#canttransferrec").html(result.TransferenciasRecibidas);
            $("#canttransferenv").html(result.TransferenciasEnviadas);
            $("#cantpedrec").html(result.PedidosRecibidos);
            $("#cantpedenv").html(result.PedidosEnviados);
        },
        error: function (error) {
            // si hay un error lanzara el mensaje de error
            str += '<p class="text-center">Error al cargar.</p>';
            $("#canttransferrec").html(str);
            $("#canttransferenv").html(str);    
            $("#cantpedrec").html(str);
            $("#cantpedenv").html(str);
        }
    });
};


function CrearComparativoArea() {
    Morris.Area({
        element: 'morris-area-chart',
        data: [{
            period: '2010 Q1',
            iphone: 2666,
            ipad: null,
            itouch: 2647
        }, {
            period: '2010 Q2',
            iphone: 2778,
            ipad: 2294,
            itouch: 2441
        }, {
            period: '2010 Q3',
            iphone: 4912,
            ipad: 1969,
            itouch: 2501
        }, {
            period: '2010 Q4',
            iphone: 3767,
            ipad: 3597,
            itouch: 5689
        }, {
            period: '2011 Q1',
            iphone: 6810,
            ipad: 1914,
            itouch: 2293
        }, {
            period: '2011 Q2',
            iphone: 5670,
            ipad: 4293,
            itouch: 1881
        }, {
            period: '2011 Q3',
            iphone: 4820,
            ipad: 3795,
            itouch: 1588
        }, {
            period: '2011 Q4',
            iphone: 15073,
            ipad: 5967,
            itouch: 5175
        }, {
            period: '2012 Q1',
            iphone: 10687,
            ipad: 4460,
            itouch: 2028
        }, {
            period: '2012 Q2',
            iphone: 8432,
            ipad: 5713,
            itouch: 1791
        }],
        xkey: 'period',
        ykeys: ['iphone', 'ipad', 'itouch'],
        labels: ['iPhone', 'iPad', 'iPod Touch'],
        pointSize: 2,
        hideHover: 'auto',
        resize: true
    });
}

function CrearGraficos() {
    if ($('#tabpedido').hasClass('active'))
        ObtenerComparativoChartPed();
    else
        ObtenerComparativoChartTrans();
    ObtenerComparativoDonus();
    ObtenerEstadistica();
}


$(document).ready(function () {
    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        var target = $(e.target).attr("href") // activated tab

        switch (target) {
            case "#tabpedido":
                ObtenerComparativoChartPed();
                break;
            case "#tabtransferencia":
                ObtenerComparativoChartTrans();
                break;
        }
    });

    CrearGraficos();
    var r = setInterval('CrearGraficos()', 50000);
});


