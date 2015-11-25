<%@ Page Title="" Language="C#" MasterPageFile="~/masterp.Master" AutoEventWireup="true" CodeBehind="addData.aspx.cs" Inherits="TestAmmy.addData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
Data Management 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content1" runat="server">
<%--start row1--%>
       <div class="row" style="border: 1px solid rgb(243, 243, 243); padding-bottom: 20px;">
        <div class="col-md-12">
            <h4>Import Excel File </h4>
           <%--start form import--%>
             <form>
  
  <div class="form-group">
    <label for="exampleInputFile">File input</label>
    <input type="file" id="exampleInputFile">
    <p class="help-block">support only HEEI form (excel file).</p>
  </div>
  
  <button type="submit" class="btn btn-default">Submit</button>
</form>
<%--end import--%>
        </div>
        <%--./end col-md-12--%>            
    </div>
<%--./end row1--%>

<%--start row2--%>
    <div class="row" style="border: 1px solid rgb(243, 243, 243); padding-bottom: 20px;">
        <div class="col-md-12">
   
            <h4>Add Data</h4>
        </div>
        <%--./end col-md-12--%>
    </div>
<%--./end row2--%>

</asp:Content>
