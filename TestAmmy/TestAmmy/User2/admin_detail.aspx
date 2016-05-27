<%@ Page Title="" Language="C#" MasterPageFile="~/User2/admin_master.Master" AutoEventWireup="true" CodeBehind="admin_detail.aspx.cs" Inherits="TestAmmy.User2.admin_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head_css" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_title" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="title_description" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breadcrumb" runat="server">
    <li class="active">Detail</li>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="main_content" runat="server">
     <!-- Default box -->
    <div class="box">
        <div class="box-header with-border">
            <h3 class="box-title">User Profile</h3>

        </div>
        <div class="box-body">
            <div class="row">
                <div class="col-md-4">
                    <!-- Profile Image -->

                    <h3 class="profile-username text-center"><%=full_name2%></h3>
                    <p class="text-muted text-center">Joined 22 April 2013</p>
                    <img class="profile-user-img img-responsive img-circle" src="../assets/img/nontpic/<%=firstName.Value%>.jpg" " alt="User profile picture" />
                    <br />
                    <div class="col-sm-2"></div>
                    <div class="col-sm-8">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </div>
                    <div class="col-sm-2"></div>

                </div>
                <!--/.col4-->

                <div class="col-md-8">
                    <div class="form-horizontal">
                        <div class="box-body">
                           
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-2 control-label">Email</label>
                                <div class="col-sm-9">
                                    <input type="email" class="form-control" id="email" runat="server" placeholder="Email" disabled="disabled" />
                                </div>
                            </div>
                           
                            <div class="form-group">
                                <label for="firstName" class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-9">
                                    <input type="text" class="form-control" id="firstName" runat="server" placeholder="First name" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="lastName" class="col-sm-2 control-label">Last Name</label>
                                <div class="col-sm-9">
                                    <input type="text" class="form-control" id="lastName" runat="server" placeholder="Last name" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="jobTitle" class="col-sm-2 control-label">Job Title</label>
                                <div class="col-sm-9">
                                    <input type="text" class="form-control" id="jobTitle" runat="server" placeholder="Job title" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="DateofBirth" class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-9">
                                     <input type="text" name='date' placeholder='select date' runat="server" class="form-control datepicker" id="dob2"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="address" class="col-sm-2 control-label">Address</label>
                                <div class="col-sm-9">
                                    <input type="text" class="form-control" id="address" runat="server" placeholder="Address"  />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="phone" class="col-sm-2 control-label">Phone</label>
                                <div class="col-sm-9">
                                    <input type="text" class="form-control" id="phone" runat="server" placeholder="Phone number" />
                                </div>
                            </div>
                           

                        </div>

                    </div>
                </div>
                <!--/.col8-->
            </div>
            <!--/.row-->
        </div>
        <!-- /.box-body -->
        <div class="box-footer">
            <asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-primary pull-right" OnClick="Button1_Click" />

        </div>
        <!-- /.box-footer-->
    </div>
    <!-- /.box -->
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="for_script" runat="server">
    <script>
        $(document).ready(function () {
            $('.datepicker').pickadate({
                format: 'yyyy-mm-dd',
                selectMonths: true,
                selectYears: true,
                max: new Date(Date.now),
                //new Date()
                
            })
            var picker = $('.datepicker').pickadate('picker')
            picker.set('select', new Date(<%=temp.Year%>,<%=temp.Month%>-1,<%=temp.Day%>))
        });
       

    </script>
</asp:Content>
