<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_master.Master" AutoEventWireup="true" CodeBehind="admin_dashboard.aspx.cs" Inherits="TestAmmy.Admin.admin_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_title" runat="server">
    Admin Dashboard
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head_css" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_title" runat="server">
    DASHBOARD
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="title_description" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breadcrumb" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="main_content" runat="server">
    <!--row -->
    <div class="row">
        <!-- col 12 -->
        <div class="col-md-12">
            <%--col 8--%>
            <div class="col-md-8">
                <%--Monthly Recap Report--%>
                
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Energy cost month</h3>
                        <div class="box-tools pull-right">
                            <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            <div class="btn-group">
                                <button class="btn btn-box-tool dropdown-toggle" data-toggle="dropdown"><i class="fa fa-wrench"></i></button>
                                <ul class="dropdown-menu" role="menu">
                                    <li><a href="#">Action</a></li>
                                    <li><a href="#">Another action</a></li>
                                    <li><a href="#">Something else here</a></li>
                                    <li class="divider"></li>
                                    <li><a href="#">Separated link</a></li>
                                </ul>
                            </div>
                            <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-8">
                                <p class="text-center">
                                    <strong>unit: 1 Jan, 2016 - 30 Jul, 2016</strong>
                                </p>
                                <div class="chart">
                                    <!-- Sales Chart Canvas -->
                                    <canvas id="salesChart" style="height: 180px;"></canvas>
                                </div>
                                <!-- /.chart-responsive -->
                            </div>
                            <!-- /.col -->
                            <div class="col-md-4">
                                <p class="text-center">
                                    <strong>Energy</strong>
                                </p>
                                <div class="progress-group">
                                    <span class="progress-text">Electric</span>
                                    <span class="progress-number"><b>160</b>/200</span>
                                    <div class="progress sm">
                                        <div class="progress-bar progress-bar-aqua" style="width: 80%"></div>
                                    </div>
                                </div>
                                <!-- /.progress-group -->
                                <div class="progress-group">
                                    <span class="progress-text">Diesel</span>
                                    <span class="progress-number"><b>310</b>/400</span>
                                    <div class="progress sm">
                                        <div class="progress-bar progress-bar-red" style="width: 80%"></div>
                                    </div>
                                </div>
                                <!-- /.progress-group -->
                                <div class="progress-group">
                                    <span class="progress-text">Gasoline</span>
                                    <span class="progress-number"><b>480</b>/800</span>
                                    <div class="progress sm">
                                        <div class="progress-bar progress-bar-green" style="width: 80%"></div>
                                    </div>
                                </div>
                                <!-- /.progress-group -->
                                <div class="progress-group">
                                    <span class="progress-text">LPG</span>
                                    <span class="progress-number"><b>250</b>/500</span>
                                    <div class="progress sm">
                                        <div class="progress-bar progress-bar-yellow" style="width: 80%"></div>
                                    </div>
                                </div>
                                <!-- /.progress-group -->
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- ./box-body -->
                    <%--<div class="box-footer">
                        <div class="row">
                            <div class="col-sm-3 col-xs-6">
                                <div class="description-block border-right">
                                    <span class="description-percentage text-green"><i class="fa fa-caret-up"></i>17%</span>
                                    <h5 class="description-header">$35,210.43</h5>
                                    <span class="description-text">TOTAL REVENUE</span>
                                </div>
                                <!-- /.description-block -->
                            </div>
                            <!-- /.col -->
                            <div class="col-sm-3 col-xs-6">
                                <div class="description-block border-right">
                                    <span class="description-percentage text-yellow"><i class="fa fa-caret-left"></i>0%</span>
                                    <h5 class="description-header">$10,390.90</h5>
                                    <span class="description-text">TOTAL COST</span>
                                </div>
                                <!-- /.description-block -->
                            </div>
                            <!-- /.col -->
                            <div class="col-sm-3 col-xs-6">
                                <div class="description-block border-right">
                                    <span class="description-percentage text-green"><i class="fa fa-caret-up"></i>20%</span>
                                    <h5 class="description-header">$24,813.53</h5>
                                    <span class="description-text">TOTAL PROFIT</span>
                                </div>
                                <!-- /.description-block -->
                            </div>
                            <!-- /.col -->
                            <div class="col-sm-3 col-xs-6">
                                <div class="description-block">
                                    <span class="description-percentage text-red"><i class="fa fa-caret-down"></i>18%</span>
                                    <h5 class="description-header">1200</h5>
                                    <span class="description-text">GOAL COMPLETIONS</span>
                                </div>
                                <!-- /.description-block -->
                            </div>
                        </div>
                        <!-- /.row -->
                    </div>--%>
                    <!-- /.box-footer -->
                </div>
                <!-- /.box month -->

                <!-- TABLE: LATEST ORDERS -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Log</h3>
                        <div class="box-tools pull-right">
                            <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="table-responsive">
                            <table class="table no-margin">
                                <thead>
                                    <tr>
                                        <th>Order ID</th>
                                        <th>Asset</th>
                                        <th>Status</th>
                                        <th>Popularity</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td><a href="../assets/adminLTE/pages/examples/invoice.html">OR9842</a></td>
                                        <td>อาคารเรียนปฏิบัติการไฟฟ้า</td>
                                        <td><span class="label label-success">Complete</span></td>
                                        <td>
                                            <div class="sparkbar" data-color="#00a65a" data-height="20">90,80,90,-70,61,-83,63</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><a href="../assets/adminLTE/pages/examples/invoice.html">OR1848</a></td>
                                        <td>อาคารบัณฑิตศึกษาวิศวฯ โยธา (ป.โท)</td>
                                        <td><span class="label label-warning">Process</span></td>
                                        <td>
                                            <div class="sparkbar" data-color="#f39c12" data-height="20">90,80,-90,70,61,-83,68</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><a href="../assets/adminLTE/pages/examples/invoice.html">OR7429</a></td>
                                        <td>อาคารเรียนรวม 4 ชั้น</td>
                                        <td><span class="label label-danger">Delivered</span></td>
                                        <td>
                                            <div class="sparkbar" data-color="#f56954" data-height="20">90,-80,90,70,-61,83,63</div>
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td><a href="../assets/adminLTE/pages/examples/invoice.html">OR7429</a></td>
                                        <td>Samsung Smart TV</td>
                                        <td><span class="label label-info">Processing</span></td>
                                        <td>
                                            <div class="sparkbar" data-color="#00c0ef" data-height="20">90,80,-90,70,-61,83,63</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><a href="../assets/adminLTE/pages/examples/invoice.html">OR1848</a></td>
                                        <td>Samsung Smart TV</td>
                                        <td><span class="label label-warning">Process</span></td>
                                        <td>
                                            <div class="sparkbar" data-color="#f39c12" data-height="20">90,80,-90,70,61,-83,68</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><a href="../assets/adminLTE/pages/examples/invoice.html">OR7429</a></td>
                                        <td>iPhone 6 Plus</td>
                                        <td><span class="label label-danger">Delivered</span></td>
                                        <td>
                                            <div class="sparkbar" data-color="#f56954" data-height="20">90,-80,90,70,-61,83,63</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><a href="../assets/adminLTE/pages/examples/invoice.html">OR9842</a></td>
                                        <td>Call of Duty IV</td>
                                        <td><span class="label label-success">Complete</span></td>
                                        <td>
                                            <div class="sparkbar" data-color="#00a65a" data-height="20">90,80,90,-70,61,-83,63</div>
                                        </td>
                                    </tr>--%>
                                </tbody>
                            </table>
                        </div>
                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.box-body -->
                    <div class="box-footer clearfix">
                        <a href="javascript::;" class="btn btn-sm btn-info btn-flat pull-left">Place New Order</a>
                        <a href="javascript::;" class="btn btn-sm btn-default btn-flat pull-right">View All Orders</a>
                    </div>
                    <!-- /.box-footer -->
                </div>
                <!-- /.box -->


                <%--nont--%>

                <%--nont end--%>
            </div>
            <!--/.col8-->

            <div class="col-md-4">

                <%--about organi box--%>
                <div class="box box-success box-solid">
                    <div class="box-header with-border">
                        <h3 class="box-title">ABOUT ORGANIZATION</h3>
                        <div class="box-tools pull-right">

                            <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                        <!-- /.box-tools -->
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <p id="data_user">

                            <strong>Organization :</strong> <%=organization[0] %>
                                    <br />
                            <strong>Code :</strong> <%=organization[1] %>
                                    <br />
                            <strong>Address :</strong> Huai Kaeo Rd, Mueang Chiang Mai District, Chiang Mai 50200<br />
                            <strong>Joined :</strong> <%=organization[2] %>
                                    <br />
                            <strong>Buildings :</strong> <%=organization[3] %> Assets  in responsibility.
                                    <br />

                        </p>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.about organi box -->
               <div class="box box-success box-solid">
                    <div class="box-header with-border">
                        <h3 class="box-title">Company Code:</h3>
                        <div class="box-tools pull-right">
                            <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-10 col-md-offset-1">
                                <h2  >CODE: <font color="green"><%=Session["codecompany"].ToString() %></font></h2>
                            </div>
                            
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- ./box-body -->
                    <%--<div class="box-footer">
                        <div class="row">
                            <div class="col-sm-3 col-xs-6">
                                <div class="description-block border-right">
                                    <span class="description-percentage text-green"><i class="fa fa-caret-up"></i>17%</span>
                                    <h5 class="description-header">$35,210.43</h5>
                                    <span class="description-text">TOTAL REVENUE</span>
                                </div>
                                <!-- /.description-block -->
                            </div>
                            <!-- /.col -->
                            <div class="col-sm-3 col-xs-6">
                                <div class="description-block border-right">
                                    <span class="description-percentage text-yellow"><i class="fa fa-caret-left"></i>0%</span>
                                    <h5 class="description-header">$10,390.90</h5>
                                    <span class="description-text">TOTAL COST</span>
                                </div>
                                <!-- /.description-block -->
                            </div>
                            <!-- /.col -->
                            <div class="col-sm-3 col-xs-6">
                                <div class="description-block border-right">
                                    <span class="description-percentage text-green"><i class="fa fa-caret-up"></i>20%</span>
                                    <h5 class="description-header">$24,813.53</h5>
                                    <span class="description-text">TOTAL PROFIT</span>
                                </div>
                                <!-- /.description-block -->
                            </div>
                            <!-- /.col -->
                            <div class="col-sm-3 col-xs-6">
                                <div class="description-block">
                                    <span class="description-percentage text-red"><i class="fa fa-caret-down"></i>18%</span>
                                    <h5 class="description-header">1200</h5>
                                    <span class="description-text">GOAL COMPLETIONS</span>
                                </div>
                                <!-- /.description-block -->
                            </div>
                        </div>
                        <!-- /.row -->
                    </div>--%>
                    <!-- /.box-footer -->
                </div>
                <%--usage box--%>
                <div class="box box-success">
                    <div class="box-header with-border">
                        <h3 class="box-title">Usage Cost</h3>
                        <div class="box-tools pull-right">
                            <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-8">
                                <div class="chart-responsive">
                                    <canvas id="pieChart" height="150"></canvas>
                                </div>
                                <!-- ./chart-responsive -->
                            </div>
                            <!-- /.col -->
                            <div class="col-md-4">
                                <ul class="chart-legend clearfix">
                                    <li><i class="fa fa-circle-o text-red"></i>Electrical</li>
                                    <li><i class="fa fa-circle-o text-green"></i>Water</li>
                                    <li><i class="fa fa-circle-o text-yellow"></i>Diesel</li>
                                    <li><i class="fa fa-circle-o text-aqua"></i>Gasoline</li>

                                </ul>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.box-body -->
                    <%--    <div class="box-footer no-padding">
                        <ul class="nav nav-pills nav-stacked">
                            <li><a href="#">United States of America <span class="pull-right text-red"><i class="fa fa-angle-down"></i>12%</span></a></li>
                            <li><a href="#">India <span class="pull-right text-green"><i class="fa fa-angle-up"></i>4%</span></a></li>
                            <li><a href="#">China <span class="pull-right text-yellow"><i class="fa fa-angle-left"></i>0%</span></a></li>
                        </ul>
                    </div>--%>
                    <!-- /.footer -->
                </div>
                <!-- /.box usage -->
                <%--about other users box--%>
                <div class="box box-success box-solid">
                    <div class="box-header with-border">
                        <h3 class="box-title">OTHER USERS</h3>
                        <div class="box-tools pull-right">

                            <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                        <!-- /.box-tools -->
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body no-padding">
                        <ul class="users-list clearfix" id="user_create">
                            <li id="create0"></li>



                            <%--                            <li>
                                <img src="../assets/img/person6.png" alt="User Image" />
                                <a class="users-list-name" href="#">Jane</a>
                                <span class="users-list-date">12 Jan</span>
                            </li>
                            <li>
                                <img src="../assets/img/person5.png" alt="User Image" />
                                <a class="users-list-name" href="#">John</a>
                                <span class="users-list-date">12 Jan</span>
                            </li>
                            <li>
                                <img src="../assets/img/person4.png" alt="User Image" />
                                <a class="users-list-name" href="#">Alexander</a>
                                <span class="users-list-date">13 Jan</span>
                            </li>
                            <li>
                                <img src="../assets/img/person3.png" alt="User Image" />
                                <a class="users-list-name" href="#">Sarah</a>
                                <span class="users-list-date">14 Jan</span>
                            </li>
                            <li>
                                <img src="../assets/img/person2.png" alt="User Image" />
                                <a class="users-list-name" href="#">Nora</a>
                                <span class="users-list-date">15 Jan</span>
                            </li>
                            <li>
                                <img src="../assets/img/person1.png" alt="User Image" />
                                <a class="users-list-name" href="#">Nadia</a>
                                <span class="users-list-date">15 Jan</span>
                            </li>--%>
                        </ul>
                        <!-- /.users-list -->
                    </div>
                    <!-- /.box-body -->
                    <div class="box-footer text-center">
                        <a href="javascript::" class="uppercase">View All Users</a>
                    </div>
                    <!-- /.box-footer -->

                </div>
                <!-- /. other users box -->
            </div>
            <!--/.col4-->
        </div>
        <!--/.col12-->
    </div>
    <!--/.row-->

</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="for_script" runat="server">
    <script src="../jstogether/user.js"></script>

    <script>
        $(document).ready(function (){
            var data_pro = <%=Session["codecompany"].ToString()%>;
            getuser(data_pro);
            start(data_pro);
        });
    </script>
    <script src="../assets/adminLTE/plugins/chartjs/Chart.min.js"></script>
    <script src="../assets/adminLTE/dist/js/pages/dashboard2.js"></script>
</asp:Content>

