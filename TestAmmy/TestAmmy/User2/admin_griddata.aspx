<%@ Page Title="" Language="C#" MasterPageFile="~/User2/admin_master.Master" AutoEventWireup="true" CodeBehind="admin_griddata.aspx.cs" Inherits="TestAmmy.User2.admin_griddata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head_css" runat="server">
    <link href="../assets/adminLTE/plugins/datepicker/datepicker3.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_title" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="title_description" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breadcrumb" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="main_content" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="box box-success">
                <div class="box-header with-border">
                    <h3 class="box-title">grid</h3>
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
                                <select id="energy" class="form-control select2">
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
                                <input type="text" name='date' placeholder='select date' class="form-control datepicker" id="datep"/>

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
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <table id="example" class="table table-bordered table-striped" >
                    <thead>
                        <tr>
                            <th>date</th>
                            <th>current</th>

                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <th>date</th>
                            <th>current</th>
                        </tr>
                    </tfoot>
                </table>
            </div>

        </div>


    </div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="for_script" runat="server">

    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.2/moment.min.js"></script>
    <script src="../assets/adminLTE/plugins/datepicker/bootstrap-datepicker.js"></script>



    <%--new--%>
    <script src="http://eternicode.github.io/bootstrap-datepicker/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script src="http://eternicode.github.io/bootstrap-datepicker/bootstrap-datepicker/css/datepicker3.css"></script>
    <script>
        $(".datepicker").datepicker({
            format: "mm-yyyy",
            viewMode: "months", 
            minViewMode: "months"
        });
        var companycode = <%=Session["codecompany"].ToString()%>;
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                data: JSON.stringify(companycode),
                url: "http://localhost:1291/Service1/getbuilding",
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function(data){
                    var data2 = JSON.parse(data);
                    var options = "<option value='0'>-SELECT-</option>";
                    if(data2 !='no'){
                        for(var i in data2){
                            options += "<option value="+data2[i]["buidlingid"]+">"+ data2[i]["building_name"] +"</option>";
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

                    var data2 = JSON.parse(data);

                    document.getElementById("energy").innerHTML = "";
                    var options = "<option value='0'>-SELECT-</option>";
                    for(var i in data2){
                        options += "<option value="+data2[i]["energy_id"]+">"+ data2[i]["energy_name"] +"</option>";
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
        function dosomething() {
            var buidling = document.getElementById('buidling').value;
            var energy = document.getElementById('energy');
            var selectedText = energy.options[energy.selectedIndex].text;
            var reservation = document.getElementById("datep").value;
            var temp = reservation.split('-');
            var data_pro = [buidling,selectedText,temp[0],temp[1]];
            console.log(data_pro);
            $.ajax({
                type: "POST",
                data: JSON.stringify(data_pro),
                url: "http://localhost:1291/Service1/Grid_electric",
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: AjaxGetFieldDataSucceeded,
                error: AjaxGetFieldDataFailed
            });
        }
        function AjaxGetFieldDataSucceeded(result) {
            if (result != "[]") {

                dataTab = $.parseJSON(result);
                console.log("dataTab",dataTab);
                console.log("dataTab[non_design]",dataTab["non_design"]);
                //instance of datatable
                oTable = $('#example').dataTable({
                    "bProcessing": true,
                    "aaData": dataTab["non_design"],
                    //important  -- headers of the json
                    "aoColumns": [{ "mDataProp": "date" }, { "mDataProp": "current" }],
                    "sPaginationType": "full_numbers",
                    "aaSorting": [[0, "asc"]],
                    "bJQueryUI": true,
                });
            }
        }
        function AjaxGetFieldDataFailed(result) {
            alert(result.status + ' ' + result.statusText);
        }
    </script>
</asp:Content>
