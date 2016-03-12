<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_master.Master" AutoEventWireup="true" CodeBehind="admin_building.aspx.cs" Inherits="TestAmmy.Admin.admin_building" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_title" runat="server">
    Add building

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head_css" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_title" runat="server">
    Building Data
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="title_description" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breadcrumb" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="main_content" runat="server">
    <div class="row">

        <div class="col-md-12">
            <!-- general form elements -->
            <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        <%-- <button class="btn btn-block btn-default" data-toggle="modal" data-target="#exampleModal"><i class="fa fa-plus"></i>Add permission</button>--%>
                        <button type="button" class="btn btn-block btn-default" data-toggle="modal" data-target="#exampleModal"><i class="fa fa-plus"></i>&nbsp;Add Building</button>


                    </h3>
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
                                        <label for="ex3">Building Name</label>
                                        <%--<input class="form-control" id="ex3" type="text" />--%>
                                        <asp:TextBox class="form-control" ID="txtbuildingname" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="comment">Details:</label>
                                        <textarea class="form-control" runat="server" rows="5" id="txtdetails"></textarea>
                                    </div>

                                 
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                    <asp:Button type="button" ID="btn_ok" runat="server" Text="Add" class="btn btn-primary" OnClick="Button1_Click" />
                                    <%--<button type="button" class="btn btn-primary">Save</button>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <asp:GridView ID="buildgrid" class="table table-bordered table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="buidlingid" OnRowCommand="buildgrid_RowCommand" HeaderStyle-HorizontalAlign="Center" OnRowDeleting="buildgrid_RowDeleting" OnRowEditing="buildgrid_RowEditing" >
        <Columns>
            <asp:TemplateField HeaderText="No">
                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="building_name" HeaderText="name" />
            <asp:BoundField DataField="building_detail" HeaderText="detail" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="Edit" runat="server" CausesValidation="False" CommandName="edit" Text="แก้ไข" class="btn btn-warning btn-xs" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClientClick="JavaScript:return confirm('ยืนยันการแก้ไขข้อมูล ?');$('#myModal').modal('show'); "><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>

                    <asp:LinkButton ID="Delete" runat="server" CausesValidation="False" CommandName="delete" Text="ลบ" class="btn btn-danger btn-xs" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClientClick="JavaScript:return confirm('ยืนยันการลบข้อมูล ?');"><span class="glyphicon glyphicon-trash" aria-hidden="true"></span></asp:LinkButton>
                </ItemTemplate>

            </asp:TemplateField>
        </Columns>

    </asp:GridView>

                </div>
            </div>
            <!-- /.box -->
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="for_script" runat="server">
    <script>
        $(function () {
            $(".table-striped").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
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
