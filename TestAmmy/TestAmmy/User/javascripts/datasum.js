
var result;
function recall(result) {
    console.log(result);
    tempx1 = [];
    tempx2 = [];
    tempx3 = [];
    if (result != 'no') {
        for (var i in result) {
            tempx1.push({ x: new Date(result[i]["date"]), y: result[i]["DGSet"] });
            tempx2.push({ x: new Date(result[i]["date"]), y: result[i]["Vehicle"] });
            tempx3.push({ x: new Date(result[i]["date"]), y: result[i]["OtherPurpose"] });
        }
    }

    var chart = new CanvasJS.Chart("chartContainer",
    {

        title: {
            text: "Diesel Consumption Details",
            padding: 15,
            fontFamily: "Source Sans Pro,Helvetica Neue,Helvetica,Arial,sans-serif",
            fontSize: 30
        },
        animationEnabled: true,
        axisX: {

            gridColor: "Silver",
            tickColor: "silver",
            valueFormatString: "DD/MMM",
            title: "Date"



        },
        toolTip: {
            shared: true
        },
        theme: "theme2",
        axisY: {
            gridColor: "Silver",
            tickColor: "silver",
            title: "Diesel consumed",
            suffix: " Liter"

        },
        legend: {
            verticalAlign: "center",
            horizontalAlign: "right"
        },
        data: [
        {
            type: "line",
            showInLegend: true,
            lineThickness: 2,
            name: "for DG set",
            markerType: "square",
            color: "#F08080",
            dataPoints: tempx1
        },
        {
            type: "line",
            showInLegend: true,
            name: "for vehicle ",
            color: "#20B2AA",
            lineThickness: 2,

            dataPoints: tempx2
        },
        {
            type: "line",
            showInLegend: true,
            name: "for other purpose ",
            color: "#000",
            lineThickness: 2,

            dataPoints: tempx3

        }


        ],
        legend: {
            cursor: "pointer",
            itemclick: function (e) {
                if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                    e.dataSeries.visible = false;
                }
                else {
                    e.dataSeries.visible = true;
                }
                chart.render();
            }
        }
    });

    chart.render();
}


$('#main_content_ddl_month').change(function () {
    //alert($('#content_col9_ddl_month').val());
    var nont = [$('#main_content_ddl_month').val()];
    $.ajax({
        type: "POST",
        data: JSON.stringify(nont),
        url: "http://localhost:1291/Service1/selectdiesel2",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            if (data == 'no') {
                recall('no');
            }
            else {
                result = JSON.parse(data);
                recall(result);
            };

        }
    });

});

window.onload = function () {
    // var date = [new Date('2010-01-02'), new Date('2010-01-27'), new Date('2010-02-27')];
    var nont = [$('#content_col9_ddl_month').val()];
    $.ajax({
        type: "POST",
        data: JSON.stringify(nont),
        url: "http://localhost:1291/Service1/selectdiesel2",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            if (data == 'no') {
                recall('no');
            } else {
                result = JSON.parse(data);
                recall(result);
            }

        }
    });
}

