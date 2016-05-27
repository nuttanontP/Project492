<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_master.Master" AutoEventWireup="true" CodeBehind="admin_graph.aspx.cs" Inherits="TestAmmy.Admin.admin_graph" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head_css" runat="server">
    <!-- daterange picker -->
    <%--<link rel="stylesheet" href="../../plugins/daterangepicker/daterangepicker-bs3.css">--%>
    <link href="../assets/adminLTE/plugins/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_title" runat="server">
    Visualization
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="title_description" runat="server">
   Visualize history data
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breadcrumb" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="main_content" runat="server">
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <div class="box box-success">
                <div class="box-header with-border">
                    <h3 class="box-title">Asset selection</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <div class="box-body">
                    <div class="nav-tabs-custom ">
                        <ul class="nav nav-tabs " id="myTab">
                            <li class="active"><a href="#profile" data-toggle="tab"><strong>Single Asset</strong></a></li>
                            <li><a href="#tab2" data-toggle="tab"><strong>Multi Assets</strong></a></li>
                        </ul>
                        <div class="tab-content">
                            <%--start tab1--%>
                            <div class="tab-pane active" id="profile">
                                <div class="row">
                                    <div class="col-md-2">
                                        <label>Asset</label>
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
                                        <label>Energy</label>
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

                                        <label>Date range (recently 2 months):</label>
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
                                        <button type="button" class="btn btn-block btn-success" onclick='dosomething("day")'>Add Graph</button>
                                    </div>
                                </div>
                            </div>
                            <%--end tab1--%>
                            <%--start tab2--%>
                            <div class="tab-pane" id="tab2">
                                <div class="row">
                                    <div class="col-md-2">
                                        <label>Assets</label>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group ">
                                            <select id="buidling2" name="buidling2" class="form-control select2" multiple="" data-placeholder=" Select assets" onchange="getState(this.value);" style="width: 100%;">
                                                <option value='0'>-SELECT-</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <label>Energy</label>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group ">
                                            <select id="energy2" class="form-control select2" style="width: 100%;">
                                                <option value='1'>Electricity</option>
                                                <option value='2'>Diesel</option>
                                                <option value='3'>Gasoline</option>
                                                <option value='4'>LPG</option>
                                                <option value='5'>Water</option>
                                                <option value='6'>Occupancy</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-md-8">

                                        <label>Date range (recently 2 months):</label>
                                        <div class="input-group">
                                            <div class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </div>
                                            <input type="text" id="reservation2" class="form-control pull-right" />
                                        </div>
                                        <!-- /.input group -->
                                    </div>
                                    <!-- /.form group -->
                                </div>
                                <div class="row">
                                    <div class="col-md-10 col-md-offset-1">
                                        <%--    <input type="button"--%>
                                        <button type="button" class="btn btn-block btn-success" onclick='submit_tab2()'>Add Graph</button>
                                    </div>
                                </div>

                            </div>
                            <%--end tab2--%>
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
            $('#reservation2').daterangepicker();
            var companycode = <%=Session["codecompany"].ToString()%>;
            $("#buidling").select2('val',"");
            $("#buidling").select2({
                placeholder: 'Select asset '
            });

            $("#energy2").select2('val',"");
            $("#energy2").select2({
                placeholder: 'Select energy type'
            });
            start(companycode);
        });
    </script>
    <script src="javascripts/add_graph/graph_water.js"></script>
</asp:Content>
