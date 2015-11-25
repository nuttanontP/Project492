<%@ Page Title="" Language="C#" MasterPageFile="~/masterp.Master" AutoEventWireup="true" CodeBehind="viewGraphs.aspx.cs" Inherits="TestAmmy.viewGraphs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
    Energy consumption Graph
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content1" runat="server">
    <div class="row" style="border: 1px solid rgb(243, 243, 243); padding-bottom: 20px;">
        <div class="col-md-12">
             <h4>DATA</h4><br/>
             <div style="text-align: center ; padding-bottom: 10px;">
                <div class="table-responsive">
                    <table class="table table-bordered">
                        <tr class="active">
                            <td>Date</td>
                            <td>Current Meter Reading</td>
                        </tr>
                        <tr>
                            <td class="active">01-JAN-15</td>
                            <td><input class="form-control" type="text" placeholder=" Meter Number" readonly></td>
                        </tr>
                        <tr>
                            <td class="active">02-JAN-15</td>
                            <td><input class="form-control" type="text" placeholder=" Meter Number" readonly></td>
                        </tr>
                        <tr>
                            <td class="active">03-JAN-15</td>
                            <td><input class="form-control" type="text" placeholder=" Meter Number" readonly></td>
                        </tr>
                        <tr>
                            <td class="active">04-JAN-15</td>
                            <td><input class="form-control" type="text" placeholder=" Meter Number" readonly></td>
                        </tr>
                        <tr>
                            <td class="active">05-JAN-15</td>
                            <td><input class="form-control" type="text" placeholder=" Meter Number" readonly></td>
                        </tr>
                        <tr>
                            <td class="active">06-JAN-15</td>
                            <td><input class="form-control" type="text" placeholder=" Meter Number" readonly></td>
                        </tr>
                        <tr>
                            <td class="active">07-JAN-15</td>
                            <td><input class="form-control" type="text" placeholder=" Meter Number" readonly></td>
                        </tr>
                        <tr>
                            <td class="active">08-JAN-15</td>
                            <td><input class="form-control" type="text" placeholder=" Meter Number" readonly></td>
                        </tr>
                        <tr>
                            <td class="active">09-JAN-15</td>
                            <td><input class="form-control" type="text" placeholder=" Meter Number" readonly></td>
                        </tr>
                        <tr>
                            <td class="active">10-JAN-15</td>
                            <td><input class="form-control" type="text" placeholder=" Meter Number" readonly></td>
                        </tr>
                    </table>
                   <div style="text-align: right ; padding-bottom: 10px;">
                        <button type="button" class="btn btn-info">back</button>
                   </div>

                </div>
            </div>
        </div>
    </div> 

</asp:Content>
