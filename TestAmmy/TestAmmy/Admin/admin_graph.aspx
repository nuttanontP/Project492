<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_master.Master" AutoEventWireup="true" CodeBehind="admin_graph.aspx.cs" Inherits="TestAmmy.Admin.admin_graph" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head_css" runat="server">
    <!-- daterange picker -->
    <%--<link rel="stylesheet" href="../../plugins/daterangepicker/daterangepicker-bs3.css">--%>
    <link href="../assets/adminLTE/plugins/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_title" runat="server">
    Graph
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="title_description" runat="server">
    graph you want to see
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breadcrumb" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="main_content" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="box box-success">
                <div class="box-header with-border">
                    <h3 class="box-title">setting.</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <div class="box-body">
                    <div class="row">
                        <div class="col-md-2">
                            <label>building</label>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <select id="buidling" name="buidling" class="form-control select2" onchange="getState(this.value);">
                                    <option value='0'>-SELECT-</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <label>energy</label>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <select id="energy" class="form-control select2" onchange="getState2(this.value);">
                                    <option value='0'>-SELECT-</option>
                                </select>

                            </div>

                        </div>

                    </div>
                    <div class="row">
                        <div class="form-group col-md-8">

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
                            <button type="button" class="btn btn-block btn-success" onclick='dosomething()'>Success</button>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div id="space"></div>

    </div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="for_script" runat="server">
    <!-- date-range-picker -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.2/moment.min.js"></script>
    <%-- <script src="../../plugins/daterangepicker/daterangepicker.js"></script>--%>
    <script src="../assets/adminLTE/plugins/daterangepicker/daterangepicker.js"></script>
    <script src="https://code.highcharts.com/highcharts.js"></script>
    <script src="https://code.highcharts.com/modules/exporting.js"></script>
    <script>
        $(document).ready(function () {
            $('#reservation').daterangepicker();
            var companycode = <%=Session["codecompany"].ToString()%>;
            $.ajax({
                type: "POST",
                data: JSON.stringify(companycode),
                url: "http://localhost:1291/Service1/getbuilding",
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function(data){
                    //$("#state-list").html(data);
                    // console.log(JSON.parse(data));
                    var data2 = JSON.parse(data);
                    var options = "<option value='0'>-SELECT-</option>";
                    if(data2 !='no'){
                        for(var i in data2){
                            options += "<option value="+data2[i]["buidlingid"]+">"+ data2[i]["building_name"] +"</option>";
                            //options+= "<asp:ListItem Text="+data2[i]["building_name"]+" Value="+data2[i]["buidlingid"]+" />"
                        }
                        document.getElementById("buidling").innerHTML = options;
                    }
                  
                    
                }
            });
           
        });
        function getState(val)
        {   
           
            $.ajax({
                type: "POST",
                data: JSON.stringify(val),
                url: "http://localhost:1291/Service1/getenergy",
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function(data){
                    //$("#state-list").html(data);
                    //console.log(data);
                    var data2 = JSON.parse(data);
                    //console.log(data2);
                    document.getElementById("energy").innerHTML = "";
                    var options = "<option value='0'>-SELECT-</option>";
                    for(var i in data2){
                        options += "<option value="+data2[i]["energy_id"]+">"+ data2[i]["energy_name"] +"</option>";
                        //options+= "<asp:ListItem Text="+data2[i]["building_name"]+" Value="+data2[i]["buidlingid"]+" />"
                    }
                    if(data2 != 'no'){
                        document.getElementById("energy").innerHTML = options;
                    }
                    
                }
              
            });
            $("#energy").select2('val',"");
            $("#energy").select2({
                placeholder: 'Select energy type'
            });
        }
        function getState2(val){
            //console.log(val);
        }

       
    </script>
    <script>
        var i2 = 0;
        function dosomething(){
            var buidling = document.getElementById('buidling').value;
            var energy = document.getElementById('energy');
            var selectedText = energy.options[energy.selectedIndex].text;
            var reservation = document.getElementById('reservation').value;
            var temp = reservation.split(/[- ]+ /);
            var data_pro = [buidling,selectedText];
            data_pro =  data_pro.concat(temp);
            console.log(data_pro);
            $.ajax({
                type: "POST",
                data: JSON.stringify(data_pro),
                url: "http://localhost:1291/Service1/getdatagraph",
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: aa,
                error: bb
              
            });
            function aa(data){
                var data2 = JSON.parse(data);
                console.log(data2);
                console.log(Date.UTC(2012, 2, 6, 10));
                for(var i in data2){
                    //console.log(data2[i]["data"]);
                    for(var j in data2[i]["data"] ){
                        //console.log(data2[i]["data"][j][0]);
                        data2[i]["data"][j][0] = new Date(data2[i]["data"][j][0]).getTime();
                        //console.log(data2[i]["data"][j][0]);
                    }
                }
                $('#space').append('<div id=appendcol'+i2+' class="col-md-12"></div>');
                $('#appendcol'+i2).html(' <div class="box box-danger"><div class="box-header  with-border"><h3 class="box-title">box1.</h3><div class="box-tools pull-right"><button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button><button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button></div></div><div class="box-body"><div class="row"><div class="col-md-10 col-md-offset-1"><div id="container'+i2+'" style="min-width:100%; height: 400px;"></div></div></div></div> </div>');
                $('#container'+i2).highcharts({
                    chart: {
                        type: 'column'
                    },
                    title: {
                        text: 'Monthly Average Rainfall'
                    },
                    subtitle: {
                        text: 'Source: WorldClimate.com'
                    },
                    xAxis: {
                        type:'datetime',
                            
                        crosshair: true,
                        dateTimeLabelFormats: { // don't display the dummy year
                            month: '%e. %b',
                            year: '%b'
                        },
                            
                    },
                    yAxis: {
                        min: 0,
                        title: {
                            text: 'Rainfall (mm)'
                        }
                    },
                    tooltip: {
                        headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                        pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                            '<td style="padding:0"><b>{point.y:.1f} mm</b></td></tr>',
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
                    series:data2
                });
                i2++;
                console.log(i2);
                    
            }
            function bb(result){
                alert(result.status + ' ' + result.statusText);
            }
           
        };
    </script>
</asp:Content>
