<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="addBuilding.aspx.cs" Inherits="TestAmmy.addBuilding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
    Add building
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="rightmenu" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="content_col9" runat="server">
    <h3>Add New Building</h3>
    <hr />
    <div class="col-sm-2">
    </div>
    <div class="col-sm-8">
        <div>
            <label for="ex3">Building Name</label>
            <%--<input class="form-control" id="ex3" type="text" />--%>
            <asp:TextBox class="form-control" ID="txtbuildingname"  runat="server"></asp:TextBox>
        </div>
      
        <br />
        <div>
            <label for="comment">Details:</label>
            <textarea class="form-control"  runat="server" rows="5" id="txtdetails" ></textarea>
        </div>
        <br />


    <%--<button type="submit" class="btn btn-info">Add</button>--%>
        <asp:Button ID="Button1" runat="server" class="btn btn-info" Text="  --ADD--  " OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" class="btn btn-danger" Text="--CANCEL--" OnClick="Button2_Click" />
    </div>

    <div class="col-sm-2">
    </div>
        <div class="col-sm-12">
            <hr />
</div>
   
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="content_col12" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="contentInRow_outcol12" runat="server">
</asp:Content>
