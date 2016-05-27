<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_System/Admin_system.Master" AutoEventWireup="true" CodeBehind="Admin_benchmark.aspx.cs" Inherits="TestAmmy.Admin_System.Admin_benchmark" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head_css" runat="server">
    <link href="../assets/adminLTE/plugins/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_title" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="title_description" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breadcrumb" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="main_content" runat="server">
    <div class="col-md-5 col-sm-offset-4">
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">Benchmarks</h3>
                <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                </div>
            </div>
            <div class="box-body">

                <div class="row">

                    <div class="row">
                        <div class="col-md-2 col-sm-offset-1">
                            <label>Energy</label>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <select id="energy" class="form-control select2" ">
                                    <option value='0'>-SELECT-</option>
                                    <option value='electrical'>electrical</option>
                                    <option value='2'>diesel</option>
                                    <option value='3'>gasoline</option>
                                    <option value='4'>lpg</option>
                                    <option value='5'>water</option>
                                    <option value='6'>occupacy</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-md-8 col-sm-offset-1">

                            <label>Date range:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </div>
                                <input type="text" id="reservation" class="form-control pull-right" />
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                    </div>
                    <div class="row">
                        <div class="col-md-10 col-md-offset-1">
                            <%--    <input type="button"--%>
                            <button type="button" class="btn btn-block btn-primary" onclick='benchmark()'>view</button>
                        </div>
                    </div>
                </div>
            </div>
            </div>
         </div>
            <div id="space"></div>
       
 
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="for_script" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.2/moment.min.js"></script>
    <script src="../assets/adminLTE/plugins/daterangepicker/daterangepicker.js"></script>
    <script src="https://code.highcharts.com/highcharts.js"></script>
    <script src="https://code.highcharts.com/modules/exporting.js"></script>
    <script>
        var i2 = 0;
        var temp;
        $(document).ready(function () {
            $('#reservation').daterangepicker();


        });
        function benchmark() {
            var energy = document.getElementById('energy');
            var reservation = document.getElementById('reservation').value;
            temp = reservation.split(/[- ]+ /);
            var data_pro = [temp[0], temp[1], "month", "electrical"];
            console.log(data_pro);
            $.ajax({
                type: "POST",
                data: JSON.stringify(data_pro),
                url: "http://localhost:1291/Service1/get_graph_benchmark",
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: aa,
                error: bb
            });

        }
        function aa(data) {
            $('#space').append('<div id=appendcol' + i2 + ' class="col-md-12"></div>');
            var long = '<div class="box box-danger " asset=><div class="box-header  with-border"><h3 class="box-title">';
            long += " Benchmark";
            long += '</h3><div class="box-tools pull-right"><button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button><button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button></div></div>';
            long += '<div class="box-body"><div class="row"><div class="col-md-10 col-md-offset-1"> <div class="form-group ">';
            long += '<select id="datetype' + i2 + '" name="datetype" class="form-control select2" onchange="changemode(' + i2 + '); ">';
            long += '<option value="month">MONTH</option>';
            long += '<option value="year">YEAR</option> </select></div>';
            long += '<div id="container' + i2 + '"graph_type="single" "  date=' + temp + '  style="min-width:100%; height: 400px;"></div></div></div></div> </div>';
            $('#appendcol' + i2).html(long);
            //cc(type_,i2, selectedText, data);
            changemode(i2);
            $(".select2").select2();
            i2++;
        }
        function changemode(i3) {
            console.log("i3:", i3);
            var types = document.getElementById("datetype" + i3).value;
            var id = document.getElementById('container' + i3);
            console.log("id:", id);
            var temp = (id.getAttribute('date')).split(',');
            var data_pro = [temp[0], temp[1], types, "electrical"];
            console.log(data_pro);
            $.ajax({
                type: "POST",
                data: JSON.stringify(data_pro),
                url: "http://localhost:1291/Service1/get_graph_benchmark",
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) { cc(data, types, i3); },
                error: bb

            });
        }
        function cc(data, types, i3) {
            var id = document.getElementById('container' + i3);
            //var graph = id.getAttribute('graph_type');
            //console.log("graph", graph);
            var data2 = JSON.parse(data);
            var text = [];
            console.log(data2);
            console.log('#container' + i3, types);
            var text = [];
            if (types == "month") {
                text[3] = "Benchmarking Parameter of Electricity Consumption";
                text[0] = "Show each company usage of electricity per area(m^2) in each month";
                text[1] = "unit/m^2";
                text[2] = 'column';
            } else if (types == "year") {

            }
            var min, max;
            min = -1;
            max = -1;
            for (var i in data2) {
                for (var j in data2[i]["data"]) {
                    data2[i]["data"][j][0] = new Date(data2[i]["data"][j][0]).getTime();
                    if (min == -1) {
                        min = data2[i]["data"][j][0];
                    }
                    else {
                        if (min > data2[i]["data"][j][0]) {
                            min = data2[i]["data"][j][0];
                        }
                    }
                    if (max == -1) {
                        max = data2[i]["data"][j][0];
                    }
                    else {
                        if (max < data2[i]["data"][j][0]) {
                            max = data2[i]["data"][j][0];
                        }
                    }
                }
            }
            console.log("before go to console:", data2);
            $('#container' + i3).highcharts({

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
                    min: min - (max - min) / 4,
                    max: max + (max - min) / 4,
                    crosshair: true,
                    dateTimeLabelFormats: { // don't display the dummy year
                        //day: '%e/%b%Y',
                        //month: '%Y',
                        //year: '%Y'
                        //month: '%e. %b',
                        //year: '%b'
                        millisecond: '%b \'%y',
                        second: '%b \'%y',
                        minute: '%b \'%y',
                        hour: '%b \'%y',
                        day: '%b \'%y',
                        week: '%b \'%y',
                        month: '%b \'%y',
                        year: '%Y'
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
        function bb(result) {
            alert(result.status + ' ' + result.statusText);
        }
    </script>
</asp:Content>
