<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="adminDashBoard.aspx.cs" Inherits="TestAmmy.adminDashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
    Admin DashBoard
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="rightmenu" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="content_col9" runat="server">
    <!-- column 2 -->
                        <h3><i class="glyphicon glyphicon-dashboard"></i>&nbsp;Dashboard</h3>

                        <hr />

                        <div class="row">
                            <!-- center left-->
                            <div class="col-md-7">

                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4>Processing Status</h4>
                                    </div>
                                    <div class="panel-body">

                                        <small>Complete</small>
                                        <div class="progress">
                                            <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="72" aria-valuemin="0" aria-valuemax="100" style="width: 72%">
                                                <span class="sr-only">72% Complete</span>
                                            </div>
                                        </div>
                                        <small>In Progress</small>
                                        <div class="progress">
                                            <div class="progress-bar progress-bar-info" role="progressbar" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100" style="width: 20%">
                                                <span class="sr-only">20% Complete</span>
                                            </div>
                                        </div>
                                        <small>At Risk</small>
                                        <div class="progress">
                                            <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100" style="width: 80%">
                                                <span class="sr-only">80% Complete</span>
                                            </div>
                                        </div>

                                    </div>
                                    <!--/panel-body-->
                                </div>
                                <!--/panel-->

                            </div>
                            <!--/col-->

                            <!--center-right-->
                            <div class="col-md-5">
                                <ul class="nav nav-justified">
                                    <li>
                                        <h4><strong>About the organization </strong><a href="#"><i class="glyphicon glyphicon-pencil"></i>edit</a></h4>
                                    </li>

                                </ul>

                                <hr />

                                <p>
                                    <strong>Organization :</strong> <%= companyname %>
                                    <br />
                                    <strong>Code :</strong> <%= code %>
                                    <br />
                                    <strong>Address :</strong> <%= address %><br />
                                    <strong>Joined :</strong>  <%= joined %>
                                    <br />
                                    <strong>Buildings :</strong> 7 buildings in responsibility.
                                    <br />

                                </p>

                                <hr />

                                <%--other users--%>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <div class="panel-title">
                                            <h4>Other Users</h4>
                                        </div>
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-xs-4 text-center">
                                            <img src="assets/img/person6.png" class="img-circle img-responsive" />
                                            Wannipa
                                        </div>
                                        <div class="col-xs-4 text-center">
                                            <img src="assets/img/person1.png" class="img-circle img-responsive" />
                                            Theradech
                                        </div>
                                        <div class="col-xs-4 text-center">
                                            <img src="assets/img/person2.png" class="img-circle img-responsive" />
                                            Buntita
                                        </div>
                                        <div class="col-xs-4 text-center">
                                            <img src="assets/img/person3.png" class="img-circle img-responsive" />
                                            Chuwit
                                        </div>
                                        <div class="col-xs-4 text-center">
                                            <img src="assets/img/person4.png" class="img-circle img-responsive" />
                                            Pisit
                                        </div>
                                    </div>
                                </div>
                                <!--/other users-->
                            </div>
                            <!--/col-span-6-->

                        </div>
                        <!--/row-->
    <%--end col9--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="content_col12" runat="server">
    <hr />
                        <h4><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</h4>
                        <hr />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="contentInRow_outcol12" runat="server">
    <div class="col-md-8">

                        <%--table--%>
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th>Energy Type</th>
                                    <th>Usage</th>
                                    <th>Reduced</th>
                                    <th>Total cost</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Electricity</td>
                                    <td>60.45%</td>
                                    <td>1.2%</td>
                                    <td>23,450 ฿</td>
                                </tr>
                                <tr>
                                    <td>Diesel</td>
                                    <td>5.2%</td>
                                    <td>2%</td>
                                    <td>3,450 ฿</td>
                                </tr>
                                <tr>
                                    <td>LPG</td>
                                    <td>25%</td>
                                    <td>0.45%</td>
                                    <td>4,000 ฿</td>
                                </tr>
                                <tr>
                                    <td>Water supply</td>
                                    <td>8%</td>
                                    <td>1.5%</td>
                                    <td>6,000 ฿</td>
                                </tr>
                                <tr>
                                    <td>Gasoline</td>
                                    <td>14%</td>
                                    <td>1.4%</td>
                                    <td>24,000 ฿</td>
                                </tr>
                            </tbody>
                        </table>
                        <%--/table--%>

                        <hr />

                        <!--tabs-->

                        <%--<div class="container">--%>
                        <div>
                            <h4><i class="glyphicon glyphicon-stats"></i>&nbsp;Data summary</h4>
                            <hr />
                            <ul class="nav nav-tabs" id="myTab">
                                <li class="active"><a href="#profile" data-toggle="tab">This Month</a></li>
                                <li><a href="#messages" data-toggle="tab">Last 3 Months</a></li>
                                <li><a href="#settings" data-toggle="tab">This year</a></li>
                            </ul>

                            <div class="tab-content">
                                <div class="tab-pane active" id="profile">

                                    <p>
                                        <img src="http://www.aucklandcouncil.govt.nz/Plans/LongTermPlan/VolumeOne/images/highresRGB/219834_0_1.jpg" height="300" />
                                    </p>
                                </div>
                                <div class="tab-pane" id="messages">

                                    <p>
                                        <img src="http://www.aucklandcouncil.govt.nz/Plans/LongTermPlan/VolumeOne/images/highresRGB/221546_0_1.jpg" height="300" />

                                    </p>
                                </div>
                                <div class="tab-pane" id="settings">

                                    <p>
                                        <img src="http://www.aucklandcouncil.govt.nz/Plans/LongTermPlan/VolumeOne/images/highresRGB/219834_0_1.jpg" height="300" />

                                    </p>
                                </div>
                            </div>
                        </div>
                        <!--/tabs-->


                        <hr />

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4>New Requests</h4>
                            </div>
                            <div class="panel-body">
                                <div class="list-group">
                                    <a href="#" class="list-group-item active">Hosting virtual mailbox serv..</a>
                                    <a href="#" class="list-group-item">Dedicated server doesn't..</a>
                                    <a href="#" class="list-group-item">RHEL 6 install on new..</a>
                                </div>
                            </div>
                        </div>

                        <hr />

                        <div class="alert alert-info">
                            <button type="button" class="close" data-dismiss="alert">×</button>
                            Please remember to <a href="#">Logout</a> for classified security.
     
                        </div>

                        <hr />
        </div>
    <div class="col-md-4">

                        <ul class="nav nav-pills nav-stacked">
                            <li class="nav-header"></li>
                            
                            <li><a href="#"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;View Specific Reports</a></li>
                            <li class="divider"></li>
                        </ul>

                        <hr />



                    </div>
                    <!--/col-->

</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="content_inRowUpperSection" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="content_container" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="content_footer" runat="server">
         
</asp:Content>
