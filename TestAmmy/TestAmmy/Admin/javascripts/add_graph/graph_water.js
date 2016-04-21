var code;
function start(company_code) {
    code = company_code;
    $.ajax({
        type: "POST",
        data: JSON.stringify(company_code),
        url: "http://localhost:1291/Service1/getbuilding",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            //$("#state-list").html(data);
            // console.log(JSON.parse(data));
            var data2 = JSON.parse(data);
            var options = "<option value=0>-select-</option>";
            if (data2 != 'no') {
                for (var i in data2) {
                    options += "<option value=" + data2[i]["buidlingid"] + ">" + data2[i]["building_name"] + "</option>";
                    //options+= "<asp:ListItem Text="+data2[i]["building_name"]+" Value="+data2[i]["buidlingid"]+" />"
                }
                document.getElementById("buidling").innerHTML = options;
            }
        }
    });
}
function getState(val) {
    $.ajax({
        type: "POST",
        data: JSON.stringify(val),
        url: "http://localhost:1291/Service1/getenergy",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            //$("#state-list").html(data);
            //console.log(data);
            var data2 = JSON.parse(data);
            //console.log(data2);
            document.getElementById("energy").innerHTML = "";
            var options = "<option value=0>-select-</option>";
            for (var i in data2) {
                options += "<option value=" + data2[i]["energy_id"] + ">" + data2[i]["energy_name"] + "</option>";
                //options+= "<asp:ListItem Text="+data2[i]["building_name"]+" Value="+data2[i]["buidlingid"]+" />"
            }
            if (data2 != 'no') {
                document.getElementById("energy").innerHTML = options;
            }
        }
    });
    $("#energy").select2('val', "");
    $("#energy").select2({
        placeholder: 'Select energy type'
    });
}
function changemode(i3, select) {
    console.log("i3:",i3)
    var type = document.getElementById("datetype"+i3).value;
    var kind = document.getElementById("kind"+i3).value;
    var id = document.getElementById('container' + i3 + select);
    var temp = (id.getAttribute('date')).split(',');
    var data_pro = [id.getAttribute('asset'), code, id.getAttribute('energy'), temp[0], temp[1], type,kind]
    console.log(data_pro);
    $.ajax({
        type: "POST",
        data: JSON.stringify(data_pro),
        url: "http://localhost:1291/Service1/getdatagrap2h",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) { cc(type, i3, select, data); },
        error: bb

    });
}
function cc(type,i3, select, data) {
    var type = document.getElementById('datetype' + i3).value;
    var data2 = JSON.parse(data);
    console.log(data2);
    console.log('#container' + i3 + select);
    if (type == "month") {
        $('#container' + i3 + select).highcharts({
            chart: {
                type: 'column'
            },
            title: {
                text: 'Water'
            },
            subtitle: {

                text: 'graph shows the relation of current Meter water and month  '
            },
            xAxis: {
                categories: data2[0]["categories"],

            },
            yAxis: {

                title: {
                    text: 'unit'
                }
            },
            tooltip: {
                headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}:</td>' +
                    '<td style="padding:0"><b>{point.y} unit</b></td></tr>',
                footerFormat: '</table>',
                shared: true,
                useHTML: true
            },
            plotOptions: {
                column: {
                    pointPadding: 0.2,
                    borderWidth: 0
                }
            },
            series: data2[1]
        });
    }
    else if (type == "day") {
        for (var i in data2) {
            for (var j in data2[i]["data"]) {
                data2[i]["data"][j][0] = new Date(data2[i]["data"][j][0]).getTime();
            }
        }
        $('#container' + i3 + select).highcharts({
            chart: {
                type: 'line'
            },
            title: {
                text: 'Water'
            },
            subtitle: {
                text: 'graph shows the relation of current Meter water and date  '
            },
            xAxis: {
                type: 'datetime',

                crosshair: true,
                dateTimeLabelFormats: { // don't display the dummy year
                    day: '%e/%b/%Y'
                    //month: '%Y',
                    //year: '%Y'
                    //month: '%e. %b',
                    //year: '%b'
                },

            },
            yAxis: {
                min: 0,
                title: {
                    text: 'unit'
                }
            },
            tooltip: {
                headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                    '<td style="padding:0"><b>{point.y} person</b></td></tr>',
                footerFormat: '</table>',
                shared: true,
                useHTML: true
            },
            plotOptions: {
                column: {
                    pointPadding: 0.2,
                    borderWidth: 0
                }
            },
            series: data2
        });
    }

}
function getState2(val) {
    //console.log(val);
}
var i2 = 0;
function dosomething(value) {
    var type_ = value;
    var buidling_1 = document.getElementById('buidling');
    var buidling_2 = buidling_1.options[buidling_1.selectedIndex].text;
    var buidling = document.getElementById('buidling').value;
    var energy = document.getElementById('energy');
    var selectedText = energy.options[energy.selectedIndex].text;
    var reservation = document.getElementById('reservation').value;
    var temp = reservation.split(/[- ]+ /);
    var data_pro = [buidling, code, selectedText];
    data_pro = data_pro.concat(temp);
    data_pro = data_pro.concat(type_);
    data_pro = data_pro.concat("current");
    console.log(data_pro);
    $.ajax({
        type: "POST",
        data: JSON.stringify(data_pro),
        url: "http://localhost:1291/Service1/getdatagrap2h",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: aa,
        error: bb
    });
    function aa(data) {
        $('#space').append('<div id=appendcol' + i2 + ' class="col-md-12"></div>');
        var long = '<div class="box box-danger " asset=><div class="box-header  with-border"><h3 class="box-title">';
        //long += "Asset: " + buidling_2 + "  energy:  " + selectedText + " date: " + reservation;
        long += " "+buidling_2;
        long += '</h3><div class="box-tools pull-right"><button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button><button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button></div></div>';
        long += '<div class="box-body"><div class="row"><div class="col-md-10 col-md-offset-1"> <div class="form-group ">';
        long += '<select id="datetype' + i2 + '" name="datetype" class="form-control select2" onchange="changemode(' + i2 + ',\'' + selectedText + '\'); ">';
        long += '<option value="day">DAY</option>';
        long += '<option value="month">MONTH</option>';
        long += '<option value="year">YEAR</option> </select></div>';
        long += '<select id="kind' + i2 + '" name="kind" class="form-control select2" onchange="changemode(' + i2 + ',\'' + selectedText + '\');" >';
        long += '<option value="current">current meter</option>';
        long += '<option value="different">different unit</option>';
        long += '<option value="money">money cost</option> </select>';
        long += '<div id="container' + i2 + '' + selectedText + '" asset=' + buidling + ' energy=' + selectedText + ' date=' + temp + '  style="min-width:100%; height: 400px;"></div></div></div></div> </div>';
        $('#appendcol' + i2).html(long);
        cc(type_,i2, selectedText, data);
        $(".select2").select2();
        i2++;
        //console.log(i2);
    }
};

function bb(result) {
    alert(result.status + ' ' + result.statusText);
}