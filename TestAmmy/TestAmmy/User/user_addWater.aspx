<%@ Page Title="" Language="C#" MasterPageFile="~/User/user_master.Master" AutoEventWireup="true" CodeBehind="user_addWater.aspx.cs" Inherits="TestAmmy.User.user_addWater" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head_css" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_title" runat="server">
    Water Consumption
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="title_description" runat="server">
    Daily Water Consumption Detail
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="main_content" runat="server">
    <div class="row">
        <div class="col-md-12" style="background-color: #ffffff; padding-bottom: 30px; padding-top: 0px">
            <%------------%>
            <div id="datePopup"></div>
            <div>

                <div class="col-sm-4">
                    <h4>Building Name:</h4>
                    <asp:DropDownList ID="ddl_building" class="form-control dropdown-toggle" runat="server">
                        <asp:ListItem Text="No Building" Value="" />
                    </asp:DropDownList>

                </div>
                <br />
                <br />
                <br />
                <br />
                <hr />
                <ul class="nav nav-tabs" id="myTab">
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
                                    <th class="text-center col-xs-3">Tools</th>

                                </tr>
                            </thead>
                            <tbody>
                                <tr id='addrs0'>
                                    <td>
                                        <input type="text" name='date' placeholder='select date' class="form-control datepicker" />
                                    </td>
                                    <td>
                                        <input type="text" name='meter' placeholder='eg. 1024' class="form-control" />
                                    </td>
                                    <td class="text-center">
                                        <button type="button" class="btn btn-success glyphicon glyphicon-floppy-disk"></button>
                                        <button type="button" class="btn btn-warning glyphicon glyphicon-pencil"></button>
                                        <button type="button" class="btn btn-danger glyphicon glyphicon-trash" onclick='dels(0)'></button>
                                    </td>
                                </tr>
                                <tr id='addrs1'></tr>
                            </tbody>
                        </table>
                        <a id="add_rows" class="btn btn-success  pull-right glyphicon glyphicon-plus"></a>

                        <asp:Button ID="Button1" runat="server" Text="Button" class="btn btn-info center-block" OnClick="Button1_Click" />

                    </div>
                    <%--end tab1--%>
                    <%--tab2--%>
                    <div class="tab-pane" id="tab2">
                        <table class="table table-bordered table-hover" id="tab_logic">
                            <thead>
                                <tr>
                                    <th class="text-center col-xs-2">Date   
                                    </th>
                                    <th class="text-center">Peak (kwh)
                                    </th>
                                    <th class="text-center">Off Peak (kwh)
                                    </th>
                                    <th class="text-center">Holiday (kwh)
                                    </th>
                                    <th class="text-center col-xs-3">Tools</th>

                                </tr>
                            </thead>
                            <tbody>
                                <tr id='addr0'>
                                    <td>
                                        <input type="text" name='date' placeholder='select date' class="form-control datepicker" />

                                    </td>
                                    <td>
                                        <input type="text" name='name' placeholder='eg. 200' class="form-control" />
                                    </td>
                                    <td>
                                        <input type="text" name='mail' placeholder='eg. 250' class="form-control" />
                                    </td>
                                    <td>
                                        <input type="text" name='mobile0' placeholder='eg. 350' class="form-control" />
                                    </td>
                                    <td class="text-center">
                                        <button type="button" class="btn btn-success glyphicon glyphicon-floppy-disk"></button>
                                        <button type="button" class="btn btn-warning glyphicon glyphicon-pencil"></button>
                                        <button type="button" class="btn btn-danger glyphicon glyphicon-trash" onclick='del(0)'></button>
                                    </td>
                                </tr>
                                <tr id='addr1'></tr>
                            </tbody>
                        </table>
                        <a id="add_row" class=" btn btn-success  pull-right glyphicon glyphicon-plus"></a>
                    </div>

                    <%--end tab2--%>

                    <%--tab3--%>
                    <div class="tab-pane" id="tab3">
                        <table class="table table-bordered table-hover" id="tab_logic3">
                            <thead>
                                <tr>
                                    <th class="text-center col-xs-2">Date   
                                    </th>
                                    <th class="text-center">Peak (kwh)
                                    </th>
                                    <th class="text-center">Off Peak (kwh)
                                    </th>
                                    <th class="text-center col-xs-3">Tools</th>

                                </tr>
                            </thead>
                            <tbody>
                                <tr id='addrss0'>
                                    <td>
                                        <input type="text" name='date' placeholder='select date' class="form-control datepicker" />

                                    </td>
                                    <td>
                                        <input type="text" name='name' placeholder='eg. 200' class="form-control" />
                                    </td>
                                    <td>
                                        <input type="text" name='mail' placeholder='eg. 250' class="form-control" />
                                    </td>
                                    <td class="text-center">
                                        <button type="button" class="btn btn-success glyphicon glyphicon-floppy-disk"></button>
                                        <button type="button" class="btn btn-warning glyphicon glyphicon-pencil"></button>
                                        <button type="button" class="btn btn-danger glyphicon glyphicon-trash" onclick='delss(0)'></button>
                                    </td>
                                </tr>
                                <tr id='addrss1'></tr>
                            </tbody>
                        </table>
                        <a id="add_row3" class=" btn btn-success  pull-right glyphicon glyphicon-plus"></a>


                    </div>
                    <%--end tab3--%>
                </div>

            </div>
        </div>

    </div>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="for_script" runat="server">
    <script src="javascripts/add_water.js"></script>

</asp:Content>
