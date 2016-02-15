<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="addPage.aspx.cs" Inherits="TestAmmy.addPage" %>

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
        <h3>Electricity</h3>
        <hr />
        <ul class="nav nav-tabs" id="myTab">
            <li class="active"><a href="#profile" data-toggle="tab">For Non Designated Building</a></li>
            <li><a href="#messages" data-toggle="tab">For Designated Building (As per AMR)</a></li>
            <%--            <li><a href="#settings" data-toggle="tab">This year</a></li>--%>
        </ul>

        <div class="tab-content">
            <div class="tab-pane active" id="profile">


                <table class="table table-bordered table-hover" id="tab_logics">
                    <thead>
                        <tr>
                            <th class="text-center">Date   
                            </th>
                            <th class="text-center">Current Meter Reading
                            </th>

                        </tr>
                    </thead>
                    <tbody>
                        <tr id='addrs0'>
                            <td>
                                <input type="text" name='date' placeholder='Name' class="form-control datepicker" />
                            </td>                           
                            <td>
                                <input type="text" name='meter' placeholder='Name' class="form-control" />
                            </td>
                        </tr>
                        <tr id='addrs1'></tr>
                    </tbody>
                </table>
                <a id="add_rows" class="btn btn-default pull-left">Add Row</a>
                <a id='delete_rows' class="pull-right btn btn-default">Delete Row</a>
                <asp:Button ID="Button1" runat="server" Text="Button" class="btn btn-info center-block" OnClick="Button1_Click"/>

            </div>
            <%--end tab1--%>

            <div class="tab-pane" id="messages">
                <table class="table table-bordered table-hover" id="tab_logic">
                    <thead>
                        <tr>
                            <th class="text-center">Date   
                            </th>
                            <th class="text-center">Peak (kwh)
                            </th>
                            <th class="text-center">Off Peak (kwh)
                            </th>
                            <th class="text-center">Holiday (kwh)
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr id='addr0'>
                            <td>
                                <input type="text" id="mydate2" class="form-control" />

                            </td>
                            <td>
                                <input type="text" name='name[]' placeholder='Name' class="form-control" />
                            </td>
                            <td>
                                <input type="text" name='mail[]' placeholder='Mail' class="form-control" />
                            </td>
                            <td>
                                <input type="text" name='mobile0[]' placeholder='Mobile' class="form-control" />
                            </td>
                        </tr>
                        <tr id='addr1'></tr>
                    </tbody>
                </table>
                <a id="add_row" class="btn btn-default pull-left">Add Row</a>
                <a id='delete_row' class="pull-right btn btn-default">Delete Row</a>

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
       
        //script2
        $(document).ready(function () {
            var i = 1;
            $("#add_row").click(function () {
                $('#addr' + [i]).html("<td><input class='form-control datepicker' />"+i+"</td><td><input name='name[] ' type='text' placeholder='Name' class='form-control input-md'  /> </td><td><input  name='mail" + i + "' type='text' placeholder='Mail'  class='form-control input-md'></td><td><input  name='mobile" + i + "' type='text' placeholder='Mobile'  class='form-control input-md'></td>");
                $('#tab_logic').append('<tr id="addr[' + (i + 1) + ']"></tr>');
                i++;
            });
            $("#delete_row").click(function () {
                if (i > 1) {
                    $("#addr" + [(i - 1)]).html('');
                    i--;
                }
            });



        });
        //script1
        
        $(document).ready(function () {
            var j = 1;
            functionOne();
            $("#add_rows").click(function () {
                $('#addrs'+j).html("<td><input type 'text' name='date' placeholder='Name' class='form-control datepicker'/></td><td><input name='meter' type='text' placeholder='Name' class='form-control input-md'  /> </td>");

                $('#tab_logics').append('<tr id="addrs'+(j+1)+'"></tr>');
                j++;
                functionOne();
            });
            $("#delete_rows").click(function () {
                if (j > 1) {
                    $("#addrs"+(j - 1)).html('');
                    j--;
                }
            });

        });



    </script>
    <script type="text/javascript">
     
        function  functionOne() {
            var $input = $( '.datepicker' ).pickadate({
                formatSubmit: 'dd/mm/yyyy',
                // min: [2015, 7, 14],
                container: '#datePopup',
                // editable: true,
                closeOnSelect: false,
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

