<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_System/Admin_system.Master" AutoEventWireup="true" CodeBehind="Admin_CompanyList.aspx.cs" Inherits="TestAmmy.Admin_System.Admin_CompanyList" %>

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
    <div class="row">
        <div class="col-md-12">
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">CompanyList</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <div class="box-body">

                    <div class="row">
                        <div class="col-sm-10 col-sm-offset-0">
                            <asp:GridView ID="companygrid" AutoGenerateColumns="False" class=" company table table-bordered table-striped" HeaderStyle-HorizontalAlign="Center" DataKeyNames="companycode" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="companycode" HeaderText="Company Code" />
                                    <asp:BoundField DataField="company_name" HeaderText="Name" />
                                    <asp:BoundField DataField="company_area" HeaderText="Area (sq. m.)" />
                                    <asp:BoundField DataField="company_type" HeaderText="Type" />
                                    <asp:BoundField DataField="company_join" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Join" />
                                  
                                </Columns>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="for_script" runat="server">
    <script>
        $(document).ready(function () {
            $(".company").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
            //$(".Diesel").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
            //$('.company').dataTable({ "scrollX": true });
        });
    </script>
</asp:Content>
