<%@ Page Title="" Language="C#" MasterPageFile="~/masterp.Master" AutoEventWireup="true" CodeBehind="permissionPage.aspx.cs" Inherits="TestAmmy.testPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content1" runat="server">
     <div class="row">
       
         <div class="col-md-3">
        </div>
       

        <div class="col-md-6">
            <h3>Permission to manage data</h3>
         
                &nbsp;
    <fieldset class="form-group">
        <label for="exampleSelect1">Building</label>
     <%--   <select class="form-control" id="exampleSelect1">
            <option>01-30 Years Building</option>
            <option>02-IE Building</option>
            <option>03-Mechanical Building</option>
            <option>04-Civil Engineer Building</option>
        </select>--%>
        <asp:DropDownList ID="ddlbuilding" runat="server" AppendDataBoundItems="true">
            <asp:ListItem Text="<Select Building>" Value="0" />
        </asp:DropDownList>
    </fieldset>
                &nbsp;
      <fieldset class="form-group">
          <label for="exampleSelect1">Type of Energy</label>
      <%--    <select class="form-control" id="exampleSelect2">
              <option>Electricity</option>
              <option>Water system</option>
              <option>Gasoline</option>
              <option>Diesel</option>
              <option>LPG</option>
              <option>Occupancy</option>

          </select>--%>
          <asp:DropDownList ID="ddlEnergytype" runat="server">
               <asp:ListItem Text="Electricity" Value="1" />
              <asp:ListItem Text="Water" Value="2" />
              <asp:ListItem Text="Gasoline" Value="3" />
              <asp:ListItem Text="Diesel" Value="4" />
              <asp:ListItem Text="LPG" Value="5" />
              <asp:ListItem Text="Occupancy" Value="6" />
          </asp:DropDownList>
      </fieldset>
                <br />

      <%--<button type="submit" class="btn btn-primary">Submit</button>--%>
                <asp:Button ID="button_sumbit" runat="server"  class="btn btn-primary" Text="Sumbit" OnClick="button_sumbit_Click" OnDataBinding="button_sumbit_DataBinding" />
        
        </div>
       
        
         <div class="col-md-3"></div>
    </div>
   

</asp:Content>
