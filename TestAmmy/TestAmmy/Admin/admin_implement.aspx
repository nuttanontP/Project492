<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_master.Master" AutoEventWireup="true" CodeBehind="admin_implement.aspx.cs" Inherits="TestAmmy.Admin.admin_implement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_title" runat="server">
    Implement EXCEL to Database
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head_css" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_title" runat="server">
    Implement
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="title_description" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breadcrumb" runat="server">
    <li class="active"><i class="fa fa-download"></i>Implement</li>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="main_content" runat="server">
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <div class="box box-pimary">
                <div class="box-header with-border">
                    <h3 class="box-title">IMPORT EXCEL</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <div class="box-body">
                    <div class="row">
                        <div class="col-md-2">
                            <label>Sheet</label>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <select id="sheet" name="sheet" runat="server" class="form-control select2"  onchange="getbuilding(this.value);">
                                    <option value='1'>ELECTRIC</option>
                                    <option value='2'>DIESEL</option>
                                    <option value='3'>GASOLINE</option>
                                    <option value='4'>LPG</option>
                                    <option value='5'>WATER</option>
                                    <option value='6'>OCCUPANCY</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-md-2">
                            <label>Asset Name:</label>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">

                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-building"></i>
                                    </div>
                                    <select id="building" name="building" class="form-control select2" runat="server" placeholder='select building'>
                                    </select>
                                </div>
                            </div>
                        </div>

                    </div>
                    
                    <div class="row">
                        <div class="col-md-2">
                            <label>Uploadfie</label>
                        </div>
                        <div class="col-md-6">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-10 col-md-offset-1">
                            <asp:Button ID="submit" class="btn btn-block btn-success" runat="server" Text="submit" OnClick="submit_Click" OnCommand="submit_Command" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="for_script" runat="server">
    <script>
       
        var email = '<%=Session["email"].ToString()%>';
        
        function getbuilding(id) {
            var data_pro = [email, id];
            console.log(data_pro);
            $.ajax({
                type: "POST",
                data: JSON.stringify(data_pro),
                url: "http://localhost:1291/Service1/get_building_importxcel",
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {
                    var data2 = JSON.parse(data);
                    console.log(data2);
                    console.log(document.getElementById("main_content_building").innerHTML);
                    var options = "";
                    for (var i in data2) {
                        console.log(i);
                        options += "<option value=" + data2[i]["building_id"] + ">" + data2[i]["building_name"] + "</option>";
                    }
                    if (data2 != 'no') {
                        document.getElementById("main_content_building").innerHTML = options;
                    }
                    $("#main_content_building").select2('val', "");
                    $("#main_content_building").select2({
                        placeholder: 'Select Building '
                    });
                },
                error: bb
            });
        }
        function bb(result) {
            alert(result.status + ' ' + result.statusText);
        }
        $("#sheet").select2('', "");
        $("#sheet").select2({
            placeholder: 'Select energy type'
        });
    </script>
    <script>
      
    </script>
</asp:Content>
