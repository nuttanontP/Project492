<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="gridviewBuilding.aspx.cs" Inherits="TestAmmy.gridviewBuilding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" runat="server">
    <link href="assets/DataTables-1.10.11/media/css/dataTables.bootstrap.css" rel="stylesheet" />
    <link href="assets/DataTables-1.10.11/media/css/dataTables.jqueryui.css" rel="stylesheet" />
    <%--<link href="assets/DataTables-1.10.11/media/css/jquery.dataTables.min.css" rel="stylesheet" />--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="rightmenu" runat="server"></asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="content_col9" runat="server">
    <h3>Manage the building data</h3>
    <hr />

    <asp:GridView ID="buildgrid" class="table table-hover table-bordered info" runat="server" AutoGenerateColumns="False" DataKeyNames="buidlingid" OnRowCommand="buildgrid_RowCommand" HeaderStyle-HorizontalAlign="Center" OnRowDeleting="buildgrid_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="No">
                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="building_name" HeaderText="name" />
            <asp:BoundField DataField="building_detail" HeaderText="detail" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="Delete" runat="server" CausesValidation="False" CommandName="delete" Text="ลบ" class="btn btn-danger btn-xs" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClientClick="JavaScript:return confirm('ยืนยันการลบข้อมูล ?');"><span class="glyphicon glyphicon-trash" aria-hidden="true"></span></asp:LinkButton>
                </ItemTemplate>
                
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
    <br />
    <asp:Button ID="addbuild" runat="server"  class="btn btn-info pull-left" Text="Add building" OnClick="addbuild_Click" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="content_col12" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="contentInRow_outcol12" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="content_inRowUpperSection" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="content_container" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="content_footer" runat="server">
</asp:Content>

<asp:Content ID="Content10" ContentPlaceHolderID="forScripts" runat="server">

    <%--  <script src="jsnont/jquery.js"></script>
    <script src="assets/js/bootstrap_dash.min.js"></script>
    <script src="jsnont/jquery.dataTables.min.js"></script>--%>
    <script src="assets/DataTables-1.10.11/media/js/jquery.js"></script>
    <script src="assets/DataTables-1.10.11/media/js/dataTables.bootstrap.min.js"></script>
    <script src="assets/DataTables-1.10.11/media/js/jquery.dataTables.min.js"></script>
    <script>
        $(document).ready(function () {
            $(".info").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
            //$(".display").DataTable();
        });
    </script>
</asp:Content>


