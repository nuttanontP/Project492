<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_master.Master" AutoEventWireup="true" CodeBehind="admin_company.aspx.cs" Inherits="TestAmmy.Admin.admin_company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head_css" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_title" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="title_description" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breadcrumb" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="main_content" runat="server">
    <div class="box">
        <div class="box-header with-border">
            <h3 class="box-title">Organization detail</h3>

        </div>
        <div class="box-body">
            <div class="row">


                <div class="col-md-8">
                    <div class="form-horizontal">
                        <div class="box-body">
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-2 control-label">Type of Organization</label>
                                <div class="col-sm-9">
                                    <div class="input-group">
                                        <asp:DropDownList ID="ddl_type" class="form-control select2" runat="server">
                                            <asp:ListItem Text="null" Value="0" />
                                            <asp:ListItem Text="Hotel" Value="1" />
                                            <asp:ListItem Text="Home" Value="2" />
                                            <asp:ListItem Text="Company" Value="3" />
                                            <asp:ListItem Text="Education" Value="4" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-2 control-label">Area</label>
                                <div class="col-sm-9">
                                    <div class="input-group">

                                        <input type="number" runat="server" class="form-control" id='area2' min="0" placeholder='eg. 7.00' />
                                        <div class="input-group-addon">
                                            m^2
                                        </div>
                                    </div>

                                </div>
                            </div>

                            <div class="form-group">
                                <label for="firstName" class="col-sm-2 control-label">Address</label>
                                <div class="col-sm-9">
                                    <textarea id="address2" name="Text1" style="width: 510px; height: 80px;" runat="server"></textarea>

                                </div>
                            </div>


                        </div>

                    </div>
                </div>
                <!--/.col8-->
            </div>
            <!--/.row-->
        </div>
        <!-- /.box-body -->
        <div class="box-footer">
            <asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-primary pull-right" OnClick="Button1_Click" />
        </div>
        <!-- /.box-footer-->
    </div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="for_script" runat="server">
    
</asp:Content>
