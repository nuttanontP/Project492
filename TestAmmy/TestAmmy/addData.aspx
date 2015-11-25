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
            <div>
                <div class="form-group">
                    <label for="exampleInputFile">File input</label>
                    <input type="file" id="exampleInputFile">
                    <p class="help-block">support only HEEI form (excel file).</p>
                </div>

                <button type="submit" class="btn btn-default">Submit</button>
            </div>
            <%--end import--%>
        </div>
        <%--./end col-md-12--%>
    </div>
    <%--./end row1--%>

    <%--start row2--%>
    <div class="row" style="border: 1px solid rgb(243, 243, 243); padding-bottom: 20px;">
        <div class="col-md-12">

            <h4>Add Data</h4>
            <div style="text-align: center; padding-bottom: 10px;">
                <button type="button" class="btn btn-info">Electrical</button>
                <button type="button" class="btn btn-info">Diesel</button>
                <button type="button" class="btn btn-info">Gasoline</button>
                <button type="button" class="btn btn-info">LPG</button>
                <button type="button" class="btn btn-info">Water Consumption</button>
            </div>
            <div style="text-align: center ; padding-bottom: 10px;">
                <div class="table-responsive">
                    <table class="table table-bordered">
                        <tr class="active">
                            <td>Date</td>
                            <td>Current Meter Reading</td>
                        </tr>
                        <tr>
                            <td class="active">01-JAN-15</td>
                            <td>
                                <%--<input class="form-control" type="text" placeholder="Current Meter Number">--%>
                                <asp:TextBox ID="txtmeter1" runat="server" class="form-control" placeholder="Current Meter Number"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="active">02-JAN-15</td>
                            <td>
                                <%--<input class="form-control" type="text" placeholder="Current Meter Number">--%>
                                <asp:TextBox ID="txtmeter2" runat="server" class="form-control" placeholder="Current Meter Number"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="active">03-JAN-15</td>
                            <td>
                                <%--<input class="form-control" type="text" placeholder="Current Meter Number">--%>
                                <asp:TextBox ID="txtmeter3" runat="server" class="form-control" placeholder="Current Meter Number"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="active">04-JAN-15</td>
                            <td>
                                <%--<input class="form-control" type="text" placeholder="Current Meter Number">--%>
                                <asp:TextBox ID="txtmeter4" runat="server" class="form-control" placeholder="Current Meter Number"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="active">05-JAN-15</td>
                            <td>
                                <%--<input class="form-control" type="text" placeholder="Current Meter Number">--%>
                                <asp:TextBox ID="txtmeter5" runat="server" class="form-control" placeholder="Current Meter Number"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="active">06-JAN-15</td>
                            <td>
                                <%--<input class="form-control" type="text" placeholder="Current Meter Number">--%>
                                <asp:TextBox ID="txtmeter6" runat="server" class="form-control" placeholder="Current Meter Number"> </asp:TextBox>
                            </td>
                        </tr>
                        
                    </table>
                   <div style="text-align: right ; padding-bottom: 10px;">
                        <%--<button type="button" class="btn btn-info">Save</button>--%>
                       <asp:Button ID="Button1" runat="server"   class="btn btn-info" Text="Save" OnClick="Button1_Click" />
                   </div>

                </div>
            </div>

        </div>
        <%--./end col-md-12--%>
    </div>
    <%--./end row2--%>
</asp:Content>
