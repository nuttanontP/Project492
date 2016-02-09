<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="managebuilding.aspx.cs" Inherits="TestAmmy.managebuilding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="rightmenu" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="content_col9" runat="server">
    <div class="row">
        <div class="col-md-3">
             <div class="col-md-6">
                 <h3>Grid veiw Building </h3>
                 <asp:GridView ID="GridView1" runat="server" class="table table-hover table-bordered success"    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                 </asp:GridView>
             </div>
        </div>
    </div>
</asp:Content>