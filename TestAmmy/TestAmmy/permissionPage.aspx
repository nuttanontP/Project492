<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="PermissionPage.aspx.cs" Inherits="TestAmmy.PermissionPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" runat="server">
    <link href="assets/DataTables-1.10.11/media/css/dataTables.bootstrap.css" rel="stylesheet" />
    <link href="assets/DataTables-1.10.11/media/css/dataTables.jqueryui.css" rel="stylesheet" />
    <%--<link href="assets/DataTables-1.10.11/media/css/jquery.dataTables.min.css" rel="stylesheet" />--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="rightmenu" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="content_col9" runat="server">
    <h3>Change Permission</h3>
    <hr />

    <asp:GridView ID="permissionview" class="table table-hover table-bordered info" DataKeyNames="id,energy_id,building_buidlingid" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="name" HeaderText="full name" />
            <asp:BoundField DataField="building_name" HeaderText="Building Name" />
            <asp:BoundField DataField="energy_name" HeaderText="Energy type" />
        </Columns>
    </asp:GridView>

    <button type="button" class="btn btn-primary pull-left" data-toggle="modal" data-target="#exampleModal">Add permission</button>


    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <br />
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4>Add permission</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="user-name" class="control-label">Responsible Person:</label>
                        <%--   <input type="text" class="form-control" id="recipient-name"/>--%>
                        <asp:DropDownList ID="ddl_name" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="building-name" class="control-label">Building Name:</label>
                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                        <asp:DropDownList ID="ddl_building" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="energy-type" class="control-label">Energy Type:</label>
                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                        <asp:DropDownList ID="ddl_energy" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="energy-type" class="control-label">Energy Type DDL:</label>
                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                        <asp:CheckBoxList ID="YrChkBox" runat="server"
                            OnSelectedIndexChanged="YrChkBox_SelectedIndexChanged" DataValueField="energy_id" DataTextField="energy_name" RepeatLayout="table">
                        </asp:CheckBoxList>
                        
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <asp:Button ID="btn_ok" runat="server" Text="Add" class="btn btn-primary" OnClick="Button1_Click" />
                    <%--<button type="button" class="btn btn-primary">Save</button>--%>
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
    <script src="assets/DataTables-1.10.11/media/js/jquery.js"></script>
    <script src="assets/DataTables-1.10.11/media/js/dataTables.bootstrap.min.js"></script>
    <script src="assets/DataTables-1.10.11/media/js/jquery.dataTables.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {

            $(".info").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();

            $('#exampleModal').on('show.bs.modal', function (event) {
                var button = $(event.relatedTarget) // Button that triggered the modal
                var recipient = button.data('whatever') // Extract info from data-* attributes
                // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
                // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
                var modal = $(this)
                modal.find('.modal-title').text('New message to ' + recipient)
                modal.find('.modal-body input').val(recipient)
            })
        });


    </script>
</asp:Content>
