<%@ Page Title="" Language="C#" MasterPageFile="~/masterp.Master" AutoEventWireup="true" CodeBehind="homePage.aspx.cs" Inherits="TestAmmy.homePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
    MIS for Energy Management
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content1" runat="server">

    <div class="row">
        <div class="col-md-12" style="border: 1px solid rgb(243, 243, 243); padding-bottom: 20px;">

            <img style="width: inherit" src="assets/img/header2.png" alt="">

            <br />
            <div style="text-align: center ; padding-top:20px;">
                <asp:Button ID="Button_user" class="btn btn-info btn-lg" runat="server" Text="User Management" OnClick="userManage" />
                <asp:Button ID="Button_energy" class="btn btn-info btn-lg" runat="server" Text="Energy Management" OnClick="addData" />

            </div>

        </div>
    </div>

</asp:Content>
