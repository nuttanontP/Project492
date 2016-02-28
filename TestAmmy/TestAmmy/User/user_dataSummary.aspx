<%@ Page Title="" Language="C#" MasterPageFile="~/User/user_master.Master" AutoEventWireup="true" CodeBehind="user_dataSummary.aspx.cs" Inherits="TestAmmy.User.user_dataSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head_css" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_title" runat="server">
    Data summary
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="title_description" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="main_content" runat="server">
    <div class="row">

        <div class="col-md-12" style="background-color: #ffffff; padding-bottom: 30px; padding-top: 0px">
            <div class="col-sm-4">
                <h4>Data from month:</h4>
                <asp:DropDownList ID="ddl_month" class="form-control dropdown-toggle" runat="server">
                    <asp:ListItem Text="--Select month--" Value="00" />
                    <asp:ListItem Text="January" Value="01" />
                    <asp:ListItem Text="February" Value="02" />
                    <asp:ListItem Text="March" Value="03" />
                    <asp:ListItem Text="April" Value="04" />
                    <asp:ListItem Text="May" Value="05" />
                    <asp:ListItem Text="June" Value="06" />
                    <asp:ListItem Text="July" Value="07" />
                    <asp:ListItem Text="August" Value="08" />
                    <asp:ListItem Text="September" Value="09" />
                    <asp:ListItem Text="October" Value="10" />
                    <asp:ListItem Text="November" Value="11" />
                    <asp:ListItem Text="December" Value="12" />
                </asp:DropDownList>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <div id="chartContainer" style="height: 400px; width: 70%;">
            </div>
            <br />
            <br />
            <br />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="for_script" runat="server">
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>--%>
    <script src="javascripts/datasum.js"></script>
    <script type="text/javascript" src="../assets/script/canvasjs.min.js"></script>

</asp:Content>
