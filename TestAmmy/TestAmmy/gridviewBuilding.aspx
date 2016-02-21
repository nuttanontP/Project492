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
    <asp:Button ID="addbuild" runat="server" class="btn btn-info pull-left" Text="Add buildingnont" OnClick="addbuild_Click" />
    <%--button addbuilding--%>
    <button type="button" class="btn btn-primary pull-left" data-toggle="modal" data-target="#exampleModal">Add Building</button>
    <%--modal window--%>
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <br />
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4>Add Building</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="building-name" class="control-label">Building Name:</label>
                        <%--   <input type="text" class="form-control" id="recipient-name"/>--%>
                        <asp:TextBox class="form-control" ID="txtbuildingname" runat="server"></asp:TextBox>

                    </div>
                    <div class="form-group">
                        <label for="details" class="control-label">Details:</label>
                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                        <textarea class="form-control" runat="server" rows="5" id="txtdetails"></textarea>

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                    <asp:Button ID="btn_ok" runat="server" Text="Add" class="btn btn-primary" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
    </div>

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
    <script src="assets/js/bootstrap.min.js"></script>

    <script>
        $(document).ready(function () {
            $(".info").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
            //$(".display").DataTable();
        });
    </script>
</asp:Content>


