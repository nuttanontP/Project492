var code;
var i2 = 0;
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
                document.getElementById("buidling2").innerHTML = options;
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
    console.log("i3:", i3)
    var type = document.getElementById("datetype" + i3).value;
    var kind = document.getElementById("kind" + i3).value;
    var id = document.getElementById('container' + i3 + select);
    console.log("id:",id);
    var temp = (id.getAttribute('date')).split(',');
    var data_pro = [id.getAttribute('asset'), code, id.getAttribute('energy'), temp[0], temp[1], type, kind]
    console.log(data_pro);
    $.ajax({
        type: "POST",
        data: JSON.stringify(data_pro),
        url: "http://localhost:1291/Service1/getdatagrap2h",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) { cc(type, kind, i3, select, data); },
        error: bb

    });
}
function changemode2(i3, energy3) {
    console.log("i3:", i3)
    var type = document.getElementById("datetype" + i3).value;
    var kind = document.getElementById("kind" + i3).value;
    var id = document.getElementById('container' + i3 + energy3);
    var temp2 = (id.getAttribute('building')).split(',');
    var temp = (id.getAttribute('date')).split(',');
    var data_pro = [code, energy3, type,kind, temp[0], temp[1], temp2.length];
    data_pro = data_pro.concat(temp2);
    console.log(data_pro);
    $.ajax({
        type: "POST",
        data: JSON.stringify(data_pro),
        url: "http://localhost:1291/Service1/getdatagraph3",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) { cc(type, kind, i3, energy3, data); },
        error: bb

    });

}
function cc(type, kind, i3, select, data) {
    //var kind = kind;
    //var type = document.getElementById('datetype' + i3).value;
    var id = document.getElementById('container' + i3 + select);
    var graph = id.getAttribute('graph_type');
    console.log("graph", graph);
    var data2 = JSON.parse(data);
    var text = [];
    console.log(data2);
    console.log('#container' + i3 + select, kind,type);
    if (select == "Water" || select == "Electrical" || select == "Diesel" || select == "Gasoline") {
        if (type == "day" || type == "month" || type == "year") {
            if (type == "day" && select == "Water") {
                //day
                text[3] = 'Water Consumption';
                if (kind == "current") {
                    text[0] = "graph shows the relation of current Meter and date";
                    text[1] = "";
                    text[2] = 'line';
                }
                else if (kind == "different") {
                    text[0] = "graph shows the relation of usage of water in unit and date";
                    text[1] = "unit(s)";
                    text[2] = 'spline';

                }
                else if (kind == "money") {
                    text[0] = "graph shows the relation of usage cost of water in baht and date";
                    text[1] = "Baht";
                    text[2] = 'spline';
                }
            }
            else if(type == "month" && select == "Water") {
                //month
                text[3] = 'Water Consumption';
                if (kind == "current") {
                    text[0] = "graph shows the relation of current Meter and month";
                    text[1] = "";
                    text[2] = 'column';
                }
                else if (kind == "different") {
                    text[0] = "graph shows the relation of usage of water in unit and month";
                    text[1] = "unit(s)";
                    text[2] = 'column';

                }
                else if (kind == "money") {
                    text[0] = "graph shows the relation of usage cost of water in baht and month";
                    text[1] = "Baht";
                    text[2] = 'column';

                }
            }
            else if (type == "year" && select == "Water") {
                //month
                text[3] = 'Water Consumption';
                if (kind == "current") {
                    text[0] = "graph shows the relation of current Meter and year";
                    text[1] = "";
                    text[2] = 'column';
                }
                else if (kind == "different") {
                    text[0] = "graph shows the relation of usage of water in unit and year";
                    text[1] = "unit(s)";
                    text[2] = 'column';

                }
                else if (kind == "money") {
                    text[0] = "graph shows the relation of usage cost of water in baht and year";
                    text[1] = "Baht";
                    text[2] = 'column';

                }
            }
            else if (type == "day" && select == "Electrical") {
                text[3] = 'Electrical Consumption';
                if (kind == "current") {
                    text[0] = "graph shows the relation of current Meter and date";
                    text[1] = "";
                    text[2] = 'line';
                }
                else if (kind == "different") {
                    text[0] = "graph shows the relation of usage of Electrical in unit and date";
                    text[1] = "unit(s)";
                    text[2] = 'spline';

                }
                else if (kind == "money") {
                    text[0] = "graph shows the relation of usage cost of Electrical in baht and date";
                    text[1] = "Baht";
                    text[2] = 'spline';

                }
            }
            else if (type == "month" && select == "Electrical"){
                text[3] = 'Electrical Consumption';
                if (kind == "current") {
                    text[0] = "graph shows the relation of current Meter and month";
                    text[1] = "";
                    text[2] = 'column';
                }
                else if (kind == "different") {
                    text[0] = "graph shows the relation of usage of Electrical in unit and month";
                    text[1] = "unit(s)";
                    text[2] = 'column';

                }
                else if (kind == "money") {
                    text[0] = "graph shows the relation of usage cost of Electrical in baht and month";
                    text[1] = "Baht";
                    text[2] = 'column';

                }
            }
            else if (type == "year" && select == "Electrical") {
                text[3] = 'Electrical Consumption';
                if (kind == "current") {
                    text[0] = "graph shows the relation of current Meter and year";
                    text[1] = "";
                    text[2] = 'column';
                }
                else if (kind == "different") {
                    text[0] = "graph shows the relation of usage of Electrical in unit and year";
                    text[1] = "unit(s)";
                    text[2] = 'column';

                }
                else if (kind == "money") {
                    text[0] = "graph shows the relation of usage cost of Electrical in baht and year";
                    text[1] = "Baht";
                    text[2] = 'column';

                }
            }
            else if (type == "day" && select == "Diesel") {
                text[3] = 'Diesel Consumption';
                if (kind == "current") {
                    text[0] = "graph shows the relation of current Meter and day";
                    text[1] = "";
                    text[2] = 'line';
                }
                else if (kind == "different") {
                    text[0] = "graph shows the relation of usage of Diesel in unit and day";
                    text[1] = "unit(s)";
                    text[2] = 'spline';

                }
                else if (kind == "money") {
                    text[0] = "graph shows the relation of usage cost of Diesel in baht and day";
                    text[1] = "Baht";
                    text[2] = 'spline';

                }
            }
            else if (type == "month" && select == "Diesel") {
                text[3] = 'Diesel Consumption';
                if (kind == "current") {
                    text[0] = "graph shows the relation of current Meter and month";
                    text[1] = "";
                    text[2] = 'column';
                }
                else if (kind == "different") {
                    text[0] = "graph shows the relation of usage of Diesel in unit and month";
                    text[1] = "unit(s)";
                    text[2] = 'column';

                }
                else if (kind == "money") {
                    text[0] = "graph shows the relation of usage cost of Diesel in baht and month";
                    text[1] = "Baht";
                    text[2] = 'column';

                }
            }
            else if (type == "year" && select == "Diesel") {
                text[3] = 'Diesel Consumption';
                if (kind == "current") {
                    text[0] = "graph shows the relation of current Meter and year";
                    text[1] = "";
                    text[2] = 'column';
                }
                else if (kind == "different") {
                    text[0] = "graph shows the relation of usage of Diesel in unit and year";
                    text[1] = "unit(s)";
                    text[2] = 'column';

                }
                else if (kind == "money") {
                    text[0] = "graph shows the relation of usage cost of Diesel in baht and year";
                    text[1] = "Baht";
                    text[2] = 'column';

                }
            }


            else if (type == "day" && select == "Gasoline") {
                text[3] = 'Gasoline Consumption';
                if (kind == "current") {
                    text[0] = "graph shows the relation of current Meter and day";
                    text[1] = "";
                    text[2] = 'line';
                }
                else if (kind == "different") {
                    text[0] = "graph shows the relation of usage of Gasoline in unit and day";
                    text[1] = "unit(s)";
                    text[2] = 'spline';

                }
                else if (kind == "money") {
                    text[0] = "graph shows the relation of usage cost of Gasoline in baht and day";
                    text[1] = "Baht";
                    text[2] = 'spline';

                }
            }
            else if (type == "month" && select == "Gasoline") {
                text[3] = 'Gasoline Consumption';
                if (kind == "current") {
                    text[0] = "graph shows the relation of current Meter and month";
                    text[1] = "";
                    text[2] = 'column';
                }
                else if (kind == "different") {
                    text[0] = "graph shows the relation of usage of Gasoline in unit and month";
                    text[1] = "unit(s)";
                    text[2] = 'column';

                }
                else if (kind == "money") {
                    text[0] = "graph shows the relation of usage cost of Gasoline in baht and month";
                    text[1] = "Baht";
                    text[2] = 'column';

                }
            }
            else if (type == "year" && select == "Gasoline") {
                text[3] = 'Gasoline Consumption';
                if (kind == "current") {
                    text[0] = "graph shows the relation of current Meter and year";
                    text[1] = "";
                    text[2] = 'column';
                }
                else if (kind == "different") {
                    text[0] = "graph shows the relation of usage of Gasoline in unit and year";
                    text[1] = "unit(s)";
                    text[2] = 'column';

                }
                else if (kind == "money") {
                    text[0] = "graph shows the relation of usage cost of Gasoline in baht and year";
                    text[1] = "Baht";
                    text[2] = 'column';

                }
            }
        }
        for (var i in data2) {
            for (var j in data2[i]["data"]) {
                data2[i]["data"][j][0] = new Date(data2[i]["data"][j][0]).getTime();
            }
        }
        $('#container' + i3 + select).highcharts({
               
            chart: {
                type: text[2]
            },
            title: {
                text: text[3]
            },
            subtitle: {
                text: text[0]
            },
            xAxis: {
                type: 'datetime',

                crosshair: true,
                dateTimeLabelFormats: { // don't display the dummy year
                    day: '%e/%b/%Y',
                    //month: '%Y',
                    year: '%Y'
                    //month: '%e. %b',
                    //year: '%b'
                },

            },
            yAxis: {
                   
                title: {
                    text: text[1]
                }
            },
            tooltip: {
                headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                    '<td style="padding:0"><b>{point.y} ' + text[1] + '</b></td></tr>',
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
        Highcharts.setOptions({
            global: {
                useUTC: false,
            },
            lang: {
                thousandsSep: ','
            }
        });

    }


}
function getState2(val) {
    //console.log(val);
}
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
        long += " " + buidling_2;
        long += '</h3><div class="box-tools pull-right"><button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button><button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button></div></div>';
        long += '<div class="box-body"><div class="row"><div class="col-md-10 col-md-offset-1"> <div class="form-group ">';
        long += '<select id="datetype' + i2 + '" name="datetype" class="form-control select2" onchange="changemode(' + i2 + ',\'' + selectedText + '\'); ">';
        long += '<option value="day">DAY</option>';
        long += '<option value="month">MONTH</option>';
        long += '<option value="year">YEAR</option> </select></div>';
        long += '<select id="kind' + i2 + '" name="kind" class="form-control select2" onchange="changemode(' + i2 + ',\'' + selectedText + '\');" >';
        long += '<option value="current">Current Meter or purchased</option>';
        long += '<option value="different">Usage in Unit / consumed</option>';
        long += '<option value="money">Cost of Usage</option> </select>';
        long += '<div id="container' + i2 + selectedText  +'"  graph_type="single" " asset=' + buidling + ' energy=' + selectedText + ' date=' + temp + '  style="min-width:100%; height: 400px;"></div></div></div></div> </div>';
        $('#appendcol' + i2).html(long);
        //cc(type_,i2, selectedText, data);
        changemode(i2, selectedText);
        $(".select2").select2();
        i2++;

        //console.log(i2);
    }

};
function bb(result) {
    alert(result.status + ' ' + result.statusText);
}
function submit_tab2() {
    
    var temp2 = $('#buidling2').val();
    var energy2 = document.getElementById("energy2");
    var energy3 = energy2.options[energy2.selectedIndex].text;
    var temp3 = temp2.join(" or ");
    var reservation = document.getElementById('reservation2').value;
    var temp = reservation.split(/[- ]+ /);
    var data_pro = [code, energy3, 'day','current', temp[0], temp[1], temp2.length];
    data_pro = data_pro.concat(temp2);
    console.log(data_pro);
    $.ajax({
        type: "POST",
        data: JSON.stringify(data_pro),
        url: "http://localhost:1291/Service1/getdatagraph3",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: dd,
        error: bb

    });
    function dd(data) {
        $('#space').append('<div id=appendcol' + i2 + ' class="col-md-12"></div>');
        var long = '<div class="box box-danger " asset=><div class="box-header  with-border"><h3 class="box-title">';
        //long += "Asset: " + buidling_2 + "  energy:  " + selectedText + " date: " + reservation;
        long += " Multiple graph of " + energy3;
        long += '</h3><div class="box-tools pull-right"><button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button><button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button></div></div>';
        long += '<div class="box-body"><div class="row"><div class="col-md-10 col-md-offset-1"> <div class="form-group ">';
        long += '<select id="datetype' + i2 + '" name="datetype" class="form-control select2" onchange="changemode2(' + i2 + ',\'' + energy3 + '\'); ">';
        long += '<option value="day">DAY</option>';
        long += '<option value="month">MONTH</option>';
        long += '<option value="year">YEAR</option> </select></div>';
        long += '<select id="kind' + i2 + '" name="kind" class="form-control select2" onchange="changemode2(' + i2 + ',\'' + energy3 + '\');" >';
        long += '<option value="current">Current Meter</option>';
        long += '<option value="different">Usage in Unit</option>';
        long += '<option value="money">Cost of Usage</option> </select>';
        long += '<div id="container' + i2 + '' + energy3 + '" graph_type="multiple" energy=' + energy3 + ' date=' + temp + ' building=' + temp2 + '  style="min-width:100%; height: 400px;"></div></div></div></div> </div>';
        $('#appendcol' + i2).html(long);
        //cc(type_,i2, selectedText, data);
        changemode2(i2, energy3);
        $(".select2").select2();
        i2++;

        //console.log(i2);
    }

}
