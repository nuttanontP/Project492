<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="addGasoline.aspx.cs" Inherits="TestAmmy.addGasoline" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" runat="server">
     <link href="assets/pickadate.js-3.5.6/pickadate.js-3.5.6/lib/compressed/themes/default.css" rel="stylesheet" />
    <link href="assets/pickadate.js-3.5.6/pickadate.js-3.5.6/lib/compressed/themes/default.date.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="rightmenu" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="content_col9" runat="server">

       <%------------%>
    <div id="datePopup"></div>
    <div>
        <h3>Details of Gasoline Consumption	</h3>
        <hr />
        <div class="col-sm-4">
            <h4>Building Name:</h4>
            <asp:DropDownList ID="ddl_building" class="form-control dropdown-toggle" runat="server">
                 <asp:ListItem Text="No Building" Value="" />
            </asp:DropDownList>
        </div>
        <%--<div class="col-sm-4"></div>
        <div class="col-sm-4"></div>--%>
        <br />
        <br />
        <br />
        <br />
        <hr />
        <ul class="nav nav-tabs" id="myTab">
            <li class="active"><a href="#profile" data-toggle="tab"><strong>Gasoline Consumption</strong></a></li>

        </ul>

        <div class="tab-content">
            <div class="tab-pane active" id="profile">


                <table class="table table-bordered table-hover" id="tab_logics">
                    <thead>
                        <tr>
                            <th class="text-center col-xs-2">Date   
                            </th>
                            <th class="text-center">Gasoline Purchased(Liter)
                            </th>
                            <th class="text-center">Gasoline Consumed(Liter)
                            </th>
                            <th class="text-center col-xs-3">Tools</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr id='addrs0'>
                            <td>
                                <input type="text" name='date' placeholder='select date' class="form-control datepicker" />
                            </td>
                            <td>
                                <input type="text" name='per' placeholder='eg. 123' class="form-control" />
                            </td>
                            <td>
                                <input type="text" name='con' placeholder='eg. 123' class="form-control" />
                            </td>
                            <td class="text-center">
                                <button type="button" class="btn btn-success glyphicon glyphicon-floppy-disk"></button>
                                <button type="button" class="btn btn-warning glyphicon glyphicon-pencil"></button>
                                <button type="button" class="btn btn-danger glyphicon glyphicon-trash" onclick='dels(0)'></button>
                            </td>
                        </tr>
                        <tr id='addrs1'></tr>
                    </tbody>
                </table>
                <a id="add_rows" class=" btn btn-success  pull-right glyphicon glyphicon-plus"></a>

                <asp:Button ID="Button1" runat="server" Text="Button" class="btn btn-info center-block" OnClick="Button1_Click" />

            </div>
            <%--end tab1--%>
        </div>

    </div>
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
<asp:Content ID="Content10" ContentPlaceHolderID="forScripts" runat="server">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="http://code.jquery.com/ui/1.9.2/jquery-ui.js"></script>
    <script src="assets/js/bootstrap_dash.min.js"></script>
    <script src="assets/pickadate.js-3.5.6/pickadate.js-3.5.6/lib/compressed/picker.js"></script>
    <script src="assets/pickadate.js-3.5.6/pickadate.js-3.5.6/lib/compressed/picker.date.js"></script>
    <script src="assets/pickadate.js-3.5.6/pickadate.js-3.5.6/lib/legacy.js"></script>

    <script>

        //delete one by one in tab 1
        function dels(j) {
            console.log("del it");
            $('#addrs' + j).remove();
        }

        //script1

        $(document).ready(function () {
            var j = 1;
            functionOne();
            $("#add_rows").click(function () {
                $('#tab_logics').append('<tr id="addrs' + (j + 1) + '"></tr>');
                $('#addrs' + j).html("<td><input type 'text' name='date' placeholder='select date' class='form-control datepicker'/></td><td><input name='per' type='text' placeholder='eg. 123' class='form-control input-md'  /> </td><td><input name='con' type='text' placeholder='eg. 123' class='form-control input-md' /></td><td class='text-center'><button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk'></button> <button type='button' class='btn btn-warning glyphicon glyphicon-pencil'></button> <button type='button' class='btn btn-danger glyphicon glyphicon-trash' onclick='dels(" + j + ")'></button></td>");
                j++;
                functionOne();
            });
            $("#delete_rows").click(function () {
                if (j > 1) {
                    $("#addrs" + (j - 1)).html('');
                    j--;
                }
            });

        });



    </script>
    <script type="text/javascript">

        function functionOne(j) {
            console.log(j);
            var $input = $('.datepicker').pickadate({
                format: 'dd/mm/yyyy',
                formatSubmit: 'dd/mm/yyyy',
                // min: [2015, 7, 14],
                container: '#datePopup',
                // editable: true,
                closeOnSelect: true,
                closeOnClear: false,
            })

            var picker = $input.pickadate('picker')
            // picker.set('select', '14 October, 2014')
            // picker.open()

            // $('button').on('click', function() {
            //     picker.set('disable', true);
            // });
        }


    </script>
</asp:Content>
