<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="gridviewBuilding.aspx.cs" Inherits="TestAmmy.gridviewBuilding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" runat="server">
    <link href="jsnont/jquery.dataTables.css" rel="stylesheet" />
    <script src="jsnont/jquery.js"></script>
    <script src="jsnont/jquery.dataTables.js"></script>
    <script src="jsnont/jquery.dataTables.min.js"></script>
    <script>

        $(document).ready(function () {
            var i = 1;
            $(".gvv").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
            $('table.display').DataTable();
            $("#add_row").click(function () {
                var str = $("#input-text").val();
                $('#addr' + i).html("<td>" + (i + 1) + "</td><td>" + str + " </td><td><input  name='mail" + i + "' type='text' placeholder='Mail'  class='form-control input-md'></td><td><a onclick='deleteR(" + i + ")' class='pull-right btn btn-default'>Delete Row</a></td>");

                $('#tab_logic').append('<tr id="addr' + (i + 1) + '"></tr>');
                i++;
            });
            $("#delete_row").click(function () {
                if (i > 1) {
                    $("#addr" + (i - 1)).html('');
                    i--;
                }
                if (i = 0) {
                    i = 0;
                }
            });


        });
        function deleteR(index) {
            $("#addr" + index).html('');
        }

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="rightmenu" runat="server"></asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="content_col9" runat="server">
    <asp:GridView ID="buildgrid" class="gvv" runat="server" AutoGenerateColumns="False" DataKeyNames="buidlingid" OnRowCommand="buildgrid_RowCommand">
        <Columns>
            <asp:BoundField DataField="building_name" HeaderText="ชื่อตึก" />
            <asp:TemplateField HeaderText="ลบ" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="Delete" runat="server" CausesValidation="False" CommandName="deleteCourse" Text="ลบ" class="btn btn-danger btn-xs" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClientClick="JavaScript:return confirm('ยืนยันการลบข้อมูล ?');"><span class="glyphicon glyphicon-trash" aria-hidden="true"></span></asp:LinkButton>
                </ItemTemplate>
                
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
    <%-- <table class="table table-bordered table-hover" id="tab_logic">
        <thead>
            <tr>
                <th class="text-center">#
                </th>
                <th class="text-center">Name
                </th>
                <th class="text-center">Mail
                </th>
                <th class="text-center">Mobile
                </th>
            </tr>
        </thead>
        <tbody>
            <tr id='addr0' runat="server">
                <td>1
                </td>
                <td>2
                </td>
                <td>
                    <input type="text" name='mail0' placeholder='Mail' class="form-control" />
                </td>
                <td>
                    <input type="text" name='mobile0' placeholder='Mobile' class="form-control" />
                </td>
            </tr>
        </tbody>
    </table>--%>
    <table id="" class="display" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Name</th>
                <th>Position</th>
                <th>Office</th>
                <th>Age</th>
                <th>Salary</th>
            </tr>
        </thead>
        <tfoot>
            <tr>
                <th>Name</th>
                <th>Position</th>
                <th>Office</th>
                <th>Age</th>
                <th>Salary</th>
            </tr>
        </tfoot>
        <tbody>
            <tr>
                <td>Tiger Nixon</td>
                <td>System Architect</td>
                <td>Edinburgh</td>
                <td>61</td>
                <td>$320,800</td>
            </tr>
            <tr>
                <td>Cedric Kelly</td>
                <td>Senior Javascript Developer</td>
                <td>Edinburgh</td>
                <td>22</td>
                <td>$433,060</td>
            </tr>
            <tr>
                <td>Sonya Frost</td>
                <td>Software Engineer</td>
                <td>Edinburgh</td>
                <td>23</td>
                <td>$103,600</td>
            </tr>
            <tr>
                <td>Quinn Flynn</td>
                <td>Support Lead</td>
                <td>Edinburgh</td>
                <td>22</td>
                <td>$342,000</td>
            </tr>
            <tr>
                <td>Dai Rios</td>
                <td>Personnel Lead</td>
                <td>Edinburgh</td>
                <td>35</td>
                <td>$217,500</td>
            </tr>
            <tr>
                <td>Gavin Joyce</td>
                <td>Developer</td>
                <td>Edinburgh</td>
                <td>42</td>
                <td>$92,575</td>
            </tr>
            <tr>
                <td>Martena Mccray</td>
                <td>Post-Sales support</td>
                <td>Edinburgh</td>
                <td>46</td>
                <td>$324,050</td>
            </tr>
            <tr>
                <td>Jennifer Acosta</td>
                <td>Junior Javascript Developer</td>
                <td>Edinburgh</td>
                <td>43</td>
                <td>$75,650</td>
            </tr>
            <tr>
                <td>Shad Decker</td>
                <td>Regional Director</td>
                <td>Edinburgh</td>
                <td>51</td>
                <td>$183,000</td>
            </tr>
        </tbody>
    </table>
    <%--  <input type="text" id="input-text" placeholder='Mail' class="form-control"/>--%>
    <a id="add_row" class="btn btn-default pull-left">Add Row</a>
    <a id='delete_row' class="pull-right btn btn-default">Delete Row</a>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="content_col12" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="contentInRow_outcol12" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="content_inRowUpperSection" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="content_container" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="content_footer" runat="server">
</asp:Content>


