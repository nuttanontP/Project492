<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_master.Master" AutoEventWireup="true" CodeBehind="admin_addWater.aspx.cs" Inherits="TestAmmy.Admin.admin_addWater" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_title" runat="server">
    Add Water Consumption
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head_css" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_title" runat="server">
    Water Consumption
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="title_description" runat="server">
    Daily Water Consumption Detail
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breadcrumb" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="main_content" runat="server">
    <div class="row">
        <div id="datePopup"></div>
        <div class="col-md-12">
            <div class="box box-success">
                <div class="box-header with-border">
                    <h3 class="box-title"></h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>
                </div>
                <div class="box-body">
                    <div class="row">

                        <!-- /.input group -->
                        <div class="col-sm-4">
                            <!-- /.form-group -->
                            <div class="form-group">
                                <label>Asset Name:</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-building"></i>
                                    </div>
                                    <asp:DropDownList ID="ddl_building" class="form-control select2" runat="server">
                                        <asp:ListItem Text="No Building" Value="" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-5"></div>
                        <div class="col-sm-3">
                            <!-- /.form-group -->
                            <div class="form-group">
                                <label>FACTOR(UNIT/BAHT)</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa  fa-usd"></i>
                                    </div>
                                    <input type="number" runat="server" class="form-control" id='factor' min="0" placeholder='eg. 3' />
                                    <span class="input-group-addon">.00</span>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-10 col-sm-offset-1">
                                <div class="nav-tabs-custom ">
                                    <ul class="nav nav-tabs " id="myTab">

                                        <li class="active"><a href="#profile" data-toggle="tab"><strong>Supply Water system</strong></a></li>
                                        <li><a href="#tab2" data-toggle="tab"><strong>Ground Water system</strong></a></li>
                                        <li><a href="#tab3" data-toggle="tab"><strong>Ground/Supply Water system</strong></a></li>
                                    </ul>

                                    <div class="tab-content">
                                        <div class="tab-pane active" id="profile">


                                            <table class="table table-bordered table-hover" id="tab_logics">
                                                <thead>
                                                    <tr>
                                                        <th class="text-center col-xs-2">Date   
                                                        </th>
                                                        <th class="text-center">Current Meter Reading
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr id='addrs0'>
                                                        <td>
                                                            <input type="text" name='date0' placeholder='select date' class="form-control datepicker" />
                                                        </td>
                                                        <td>
                                                            <input type="text" name='meter0' placeholder='eg. 1024' class="form-control" />
                                                        </td>
                                                        <td class="text-center">
                                                            <button type="button" class="btn btn-success btn-xs glyphicon glyphicon-floppy-disk"></button>
                                                            <button type="button" class="btn btn-warning btn-xs glyphicon glyphicon-pencil"></button>
                                                            <button type="button" class="btn btn-danger btn-xs glyphicon glyphicon-trash" onclick='dels(0)'></button>
                                                        </td>
                                                    </tr>
                                                    <tr id='addrs1'></tr>
                                                </tbody>
                                            </table>
                                            <a id="add_rows" class="btn btn-success  pull-right glyphicon glyphicon-plus"></a>

                                            <asp:Button ID="Button1" runat="server" Text="Add Data" class="btn btn-success center-block" OnClick="Button1_Click" />

                                        </div>
                                        <%--end tab1--%>
                                        <%--tab2--%>
                                        <div class="tab-pane" id="tab2">
                                            <table class="table table-bordered table-hover" id="tab_logic">
                                                <thead>
                                                    <tr>
                                                        <th class="text-center col-xs-2">Date   
                                                        </th>
                                                        <th class="text-center">Current Meter Reading
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr id='addr0'>
                                                        <td>
                                                            <input type="text" name='date1' placeholder='select date' class="form-control datepicker" />
                                                        </td>
                                                        <td>
                                                            <input type="text" name='meter1' placeholder='eg. 1024' class="form-control" />
                                                        </td>
                                                        <td class="text-center">
                                                            <button type="button" class="btn btn-success  btn-xs glyphicon glyphicon-floppy-disk"></button>
                                                            <button type="button" class="btn btn-warning  btn-xs glyphicon glyphicon-pencil"></button>
                                                            <button type="button" class="btn btn-danger  btn-xs glyphicon glyphicon-trash" onclick='del(0)'></button>
                                                        </td>
                                                    </tr>
                                                    <tr id='addr1'></tr>
                                                </tbody>
                                            </table>
                                            <a id="add_row" class=" btn btn-success  pull-right glyphicon glyphicon-plus"></a>
                                            <asp:Button ID="Button2" runat="server" Text="Add Data" class="btn btn-success center-block" OnClick="Button2_Click" />
                                        </div>

                                        <%--end tab2--%>

                                        <%--tab3--%>
                                        <div class="tab-pane" id="tab3">
                                            <table class="table table-bordered table-hover" id="tab_logic3">
                                                <thead>
                                                    <tr>
                                                        <th class="text-center col-xs-2">Date   
                                                        </th>
                                                        <th class="text-center">Current Meter Reading
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr id='addrss0'>
                                                        <td>
                                                            <input type="text" name='date2' placeholder='select date' class="form-control datepicker" />
                                                        </td>
                                                        <td>
                                                            <input type="text" name='meter2' placeholder='eg. 1024' class="form-control" />
                                                        </td>
                                                        <td class="text-center">
                                                            <button type="button" class="btn btn-success  btn-xs glyphicon glyphicon-floppy-disk"></button>
                                                            <button type="button" class="btn btn-warning  btn-xs glyphicon glyphicon-pencil"></button>
                                                            <button type="button" class="btn btn-danger  btn-xs glyphicon glyphicon-trash" onclick='delss(0)'></button>
                                                        </td>
                                                    </tr>
                                                    <tr id='addrss1'></tr>
                                                </tbody>
                                            </table>
                                            <a id="add_row3" class=" btn btn-success  pull-right glyphicon glyphicon-plus"></a>
                                            <asp:Button ID="Button3" runat="server" Text="Add Data" class="btn btn-success center-block" OnClick="Button3_Click" />

                                        </div>
                                        <%--end tab3--%>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="for_script" runat="server">
    <script src="javascripts/add_water.js"></script>

</asp:Content>
