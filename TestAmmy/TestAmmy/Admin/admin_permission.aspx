<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_master.Master" AutoEventWireup="true" CodeBehind="admin_permission.aspx.cs" Inherits="TestAmmy.Admin.admin_permission"  EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head_css" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_title" runat="server">
     Permission Management
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="title_description" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breadcrumb" runat="server">
     <li class="active">Permission</li>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="main_content" runat="server">
    <div class="row">

        <div class="col-md-12">
            <!-- general form elements -->
            <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        <%-- <button class="btn btn-block btn-default" data-toggle="modal" data-target="#exampleModal"><i class="fa fa-plus"></i>Add permission</button>--%>
                        <button type="button" class="btn btn-block btn-default" data-toggle="modal" data-target="#exampleModal"><i class="fa fa-plus"></i>&nbsp;Add permission</button>


                    </h3>
                    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <br />
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <h4>Add Permission</h4>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group">
                                        <label for="user-name" class="control-label">Responsible User:</label>
                                        <%--   <input type="text" class="form-control" id="recipient-name"/>--%>
                                        <asp:DropDownList ID="ddl_name" class="form-control select2" Style="width: 100%;" runat="server">
                                            <asp:ListItem Text="no name" Value="" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="building-name" class="control-label">Asset Name:</label>
                                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                                        <asp:DropDownList ID="ddl_building" class="form-control select2" Style="width: 100%;" runat="server">
                                            <asp:ListItem Text="no building" Value="" />
                                        </asp:DropDownList>
                                    </div>

                                    <div class="form-group">
                                        <label for="energy-type" class="control-label">Energy Type (allowed to manage) :</label>
                                        <br />
                                        <br />
                                        <%--<textarea class="form-control" id="message-text"></textarea>--%>

                                        <asp:CheckBoxList ID="YrChkBox" class="minimal" runat="server"
                                            OnSelectedIndexChanged="YrChkBox_SelectedIndexChanged" DataValueField="energy_id" DataTextField="energy_name" RepeatLayout="Flow">
                                        </asp:CheckBoxList>

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
                    <asp:GridView ID="permissionview" class="table table-bordered table-striped" DataKeyNames="id,building_buidlingid,building_company_companycode,energy_id" runat="server" AutoGenerateColumns="False" OnRowCommand="permissionview_RowCommand" OnRowDeleting="permissionview_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="name" HeaderText="Full Name" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="building_name" HeaderText="Asset Name" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="energy_name" HeaderText="Energy Type" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete" runat="server" CausesValidation="False" CommandName="delete" Text="ลบ" class="btn btn-danger btn-xs" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClientClick="JavaScript:return confirm('Are you sure you want to delete this item ? \n Your data will be gone.');"><span class="glyphicon glyphicon-trash" aria-hidden="true"></span></asp:LinkButton>
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
