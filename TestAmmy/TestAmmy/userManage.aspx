<%@ Page Title="" Language="C#" MasterPageFile="~/masterp.Master" AutoEventWireup="true" CodeBehind="userManage.aspx.cs" Inherits="TestAmmy.userManage" %>


<asp:Content ID="header1" ContentPlaceHolderID="head1" runat="server">
    User Management
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content1" runat="server">

    <div class="row" style="border: 1px solid rgb(243, 243, 243); padding-bottom: 20px;">

        <div class="col-md-5">
            <h4>USER PROFILE</h4>
            <br />

            <div class="row">
                <div class="col-xs-8 col-sm-6">
                    <%--              Level 2: .col-xs-8 .col-sm-6--%>
                    <img src="https://pbs.twimg.com/media/B8okPMTCUAAArOV.png" width="150" class="img-thumbnail" />

                </div>
                <div class="col-xs-4 col-sm-6">
                    <%--              Level 2: .col-xs-4 .col-sm-6--%>
                    <div class="center-block">
                        <p>NAME : _______________</p>
                        <br />
                        <p>SURNAME : ____________</p>
                        <br />
                        <p>E-MAIL : _____________</p>
                        <br />
                        <p>COMPANY : ____________</p>
                        <br />
                        <p>POSITION : ___________</p>
                        <br />
                        <button type="button" class="btn btn-info">edit</button>


                    </div>

                </div>
            </div>
        </div>
        <div class="col-md-7">
            <h4>TEAM WORK</h4>
            <table class="table table-hover">
                <tr class="active">

                    <th scope="row">#</th>
                    <td>PROFILE</td>
                    <td>ACCOUNT</td>
                    <td>PRIVACY</td>

                </tr>
                <tr>
                    <th scope="row">1</th>
                    <td>
                        <img src="https://pbs.twimg.com/media/B8okPMTCUAAArOV.png" width="80" class="img-thumbnail" />
                    </td>
                    <td>wiriyapa@hotel.com</td>
                    <td>can edit, Electrical</td>
                </tr>
                <tr>
                    <th scope="row">2</th>
                    <td>
                        <img src="https://pbs.twimg.com/media/B8okPMTCUAAArOV.png" width="80" class="img-thumbnail" />
                    </td>
                    <td>Suchat_somyot@hotel.com</td>
                    <td>can edit, Water</td>

                </tr>
                <tr>
                    <th scope="row">3</th>
                    <td>
                        <img src="https://pbs.twimg.com/media/B8okPMTCUAAArOV.png" width="80" class="img-thumbnail" />
                    </td>
                    <td>ajaraya_theparak@hotel.com</td>
                    <td>can view, All</td>

                </tr>

            </table>
            <div style="text-align: right">
                <button type="button" class="btn btn-info">edit</button>
            </div>

        </div>
    </div>

    <div class="row" <%--style="border: 1px solid rgb(243, 243, 243);"--%>>

        <div class="col-md-12" style="margin-top: 20px;">

            <div class="row">
                <div class="col-xs-2">
                    <%--                 Level 2: .col-xs-8 .col-sm-6--%>
                </div>
                <div class="col-xs-8">
                    <div style="text-align: center">
                        <asp:Button ID="Button1" class="btn btn-info btn-lg" runat="server" Text="Add energy data" OnClick="addData" />
                        <asp:Button ID="Button2" class="btn btn-info btn-lg" runat="server" Text="Show data graphs" OnClick="showGraph" />
                        <asp:Button ID="Button3" class="btn btn-info btn-lg" runat="server" Text="Show files" OnClick="showFiles" />

                    </div>
                </div>
                <div class="col-xs-2">
                    <%--                Level 2: .col-xs-4 .col-sm-6--%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
