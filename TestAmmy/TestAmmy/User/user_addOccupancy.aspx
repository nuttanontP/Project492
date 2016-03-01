﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User/user_master.Master" AutoEventWireup="true" CodeBehind="user_addOccupancy.aspx.cs" Inherits="TestAmmy.User.user_addOccupancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head_css" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_title" runat="server">
    Occupancy
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="title_description" runat="server">
    Details of Occupancy
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
            <li class="active"><a href="#profile" data-toggle="tab"><strong>Occupancy Details</strong></a></li>

        </ul>

        <div class="tab-content">
            <div class="tab-pane active" id="profile">


                <table class="table table-bordered table-hover" id="tab_logics">
                    <thead>
                        <tr>
                            <th class="text-center col-xs-2" rowspan="2">Date   
                            </th>
                            <th class="text-center" colspan="2">Room
                            </th>
                            <th class="text-center" rowspan="2">Number of Guests(Number)
                            </th>
                            <th class="text-center col-xs-3" rowspan="2">Tools</th>

                        </tr>
                        <tr>

                            <th class="text-center">Available</th>
                            <th class="text-center">Occupied</th>

                        </tr>
                    </thead>

                    <tbody>
                        <tr id='addrs0'>
                            <td>
                                <input type="text" name='date' placeholder='select date' class="form-control datepicker" />
                            </td>
                            <td>
                                <input type="text" name='av_room' placeholder='eg. 123' class="form-control" />
                            </td>
                            <td>
                                <input type="text" name='oc_room' placeholder='eg. 123' class="form-control" />
                            </td>
                            <td>
                                <input type="text" name='number' placeholder='eg. 123' class="form-control" />
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
                               <a id="add_rows" class=" btn btn-success  pull-right glyphicon glyphicon-plus"></a>

                <asp:Button ID="Button1" runat="server" Text="Button" class="btn btn-info center-block" OnClick="Button1_Click" />

            </div>
            <%--end tab1--%>
        </div>

    </div>
</div></div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="for_script" runat="server">
     <script src="javascripts/add_occupancy.js"></script>

</asp:Content>
