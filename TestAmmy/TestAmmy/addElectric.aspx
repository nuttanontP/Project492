<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="addElectric.aspx.cs" Inherits="TestAmmy.addPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" runat="server">
    <link href="assets/pickadate.js-3.5.6/pickadate.js-3.5.6/lib/compressed/themes/default.css" rel="stylesheet" />
    <link href="assets/pickadate.js-3.5.6/pickadate.js-3.5.6/lib/compressed/themes/default.date.css" rel="stylesheet" />

    <%--<script src="//code.jquery.com/jquery-1.9.1.min.js"></script>
  <link id="bsdp-css" href="http://eternicode.github.io/bootstrap-datepicker/bootstrap-datepicker/css/datepicker3.css" rel="stylesheet"/>
  <script src='http://eternicode.github.io/bootstrap-datepicker/bootstrap-datepicker/js/bootstrap-datepicker.js'></script>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="rightmenu" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="content_col9" runat="server">


    <%------------%>
     <div id="datePopup"></div>
    <div>
        <h3>Daily Electricity Consumption Details</h3>
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
            <li class="active"><a href="#profile" data-toggle="tab"><strong>For Non Designated Building</strong></a></li>
            <li><a href="#messages" data-toggle="tab"><strong>For Designated Building (As per AMR)</strong></a></li>
            <%--            <li><a href="#settings" data-toggle="tab">This year</a></li>--%>
        </ul>

        <div class="tab-content">
            <div class="tab-pane active" id="profile">


                <table class="table table-bordered table-hover" id="tab_logics">
                    <thead>
                        <tr>
                            <th class="text-center  col-xs-2">Date   
                            </th>
                            <th class="text-center">Current Meter Reading
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
                                <input type="text" name='meter' placeholder='eg. 1024' class="form-control" />
                            </td>
                            <td class="text-center">
                                <button type="button" class="btn btn-success glyphicon glyphicon-floppy-disk"></button>
                                <button type="button" class="btn btn-warning glyphicon glyphicon-pencil"></button>
                                <button type="button" class="btn btn-danger glyphicon glyphicon-trash" onclick="dels(0)"></button>
                            </td>
                        </tr>
                        <tr id='addrs1'></tr>
                    </tbody>
                </table>
                <a id="add_rows" class=" btn btn-success  pull-right glyphicon glyphicon-plus"></a>

                <asp:Button ID="Button1" runat="server" Text="Save all" class="btn btn-info center-block" OnClick="Button1_Click" />

            </div>
           
            <%--end tab1--%>

            <div class="tab-pane" id="messages">
                <table class="table table-bordered table-hover" id="tab_logic">
                    <thead>
                        <tr>
                            <th class="text-center col-xs-2">Date   
                            </th>
                            <th class="text-center">Peak (kwh)
                            </th>
                            <th class="text-center">Off Peak (kwh)
                            </th>
                            <th class="text-center">Holiday (kwh)
                            </th>
                            <th class="text-center col-xs-3">Tools</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr id='addr0'>
                            <td>
                                <input type='text' name='date1' placeholder='select date' class='form-control datepicker' />
                            </td>
                            <td>
                                <input type="text" name='peak' placeholder='eg. 1250' class="form-control" />
                            </td>
                            <td>
                                <input type="text" name='off' placeholder='eg. 1200' class="form-control" />
                            </td>
                            <td>
                                <input type="text" name='holiday' placeholder='eg. 1400' class="form-control" />
                            </td>
                            <td class="text-center">
                                <button type="button" class="btn btn-success glyphicon glyphicon-floppy-disk"></button>
                                <button type="button" class="btn btn-warning glyphicon glyphicon-pencil"></button>
                                <button type="button" class="btn btn-danger glyphicon glyphicon-trash" onclick="del(0)"></button>
                            </td>
                        </tr>
                        <tr id='addr1'></tr>
                    </tbody>
                </table>
                <a id="add_row" class=" btn btn-success  pull-right glyphicon glyphicon-plus"></a>
                <asp:Button ID="Button2" runat="server" Text="Save all" class="btn btn-info center-block" OnClick="Button2_Click" />


            </div>

            <%--end tab2--%>
        </div>

    </div>


    <%--script1--%>
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
        function del(i) {
            console.log("del it");
            $('#addr' + i).remove();
        }

        //script1
        $(document).ready(function () {
            var j = 1;
            functionOne();
            $("#add_rows").click(function () {
                $('#tab_logics').append('<tr id="addrs' + (j + 1) + '"></tr>');
                $('#addrs' + j).html("<td><input type 'text' name='date' placeholder='select date' class='form-control datepicker'/></td><td><input name='meter'  type='text' placeholder='eg.1024' class='form-control input-md'  /> </td><td class='text-center'><button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk'></button> <button type='button' class='btn btn-warning glyphicon glyphicon-pencil'></button> <button type='button'  class='btn btn-danger glyphicon glyphicon-trash' onclick='dels(" + j + ")'></button></td>");
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
        //script2
        $(document).ready(function () {

            var i = 1;
            functionOne();
            $("#add_row").click(function () {


                $('#addr' + i).html("<td>  <input type='text' name='date1' placeholder='select date' class='form-control datepicker' /></td><td><input name='peak' type='text' placeholder='eg.1250' class='form-control input-md'  /> </td><td><input  name='off' type='text' placeholder='eg. 1200'  class='form-control input-md'></td><td><input  name='holiday' type='text' placeholder='eg. 1400'  class='form-control input-md'></td><td class='text-center'><button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk'></button> <button type='button' class='btn btn-warning glyphicon glyphicon-pencil'></button> <button type='button' class='btn btn-danger glyphicon glyphicon-trash' onclick='del(" + i + ")'></button></td>");
                $('#tab_logic').append('<tr id="addr' + (i + 1) + '"></tr>');
                i++;
                functionOne();
            });
            $("#delete_row").click(function () {
                if (i > 1) {
                    $("#addr" + (i - 1)).html('');
                    i--;
                }
            });



        });


    </script>
    <script type="text/javascript">

        function functionOne() {
            var $input = $('.datepicker').pickadate({
                format: "dd/mm/yyyy",
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

