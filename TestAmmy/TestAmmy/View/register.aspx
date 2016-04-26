<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="TestAmmy.View.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>MIS for Energy Management | Registration Page</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="../assets/adminLTE/bootstrap/css/bootstrap.min.css" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="../assets/adminLTE/dist/css/AdminLTE.min.css" />
    <!-- iCheck -->
    <link rel="stylesheet" href="../assets/adminLTE/plugins/iCheck/square/blue.css" />
    <%--select 2--%>
    <link href="../assets/adminLTE/plugins/select2/select2.css" rel="stylesheet" />
</head>
<body class="hold-transition register-page">
    <form id="form1" runat="server">
        <div>
            <div class="register-box">
                <div class="register-logo">
                    <a href="#"><b>MIS</b> Energy Management</a>
                </div>

                <div class="register-box-body">
                    <p class="login-box-msg">Register a new membership</p>

                    <div class="form-group has-feedback">
                        <input type="text" id="firstname" runat="server" class="form-control" placeholder="First name" />
                        <span class="glyphicon glyphicon-user form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">
                        <input type="text" id="lastname" runat="server" class="form-control" placeholder="Last name" />
                        <span class="glyphicon glyphicon-user form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">
                        <input type="email" id="email" runat="server" class="form-control" placeholder="Email" />
                        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">
                        <input type="password" id="password" runat="server" class="form-control" placeholder="Password" />
                        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">
                        <input type="password" id="password2" runat="server" class="form-control" placeholder="Retype password" />
                        <span class="glyphicon glyphicon-log-in form-control-feedback"></span>
                    </div>
                    <%--<div class="form-group has-feedback">
                            <input type="text" class="form-control" id="1" placeholder="New Company Name" />
                        </div>--%>

                    <div class=" form-group has-feedback   " id="yourformID-form">
                        <div class="form-inline   ">

                            <select class="form-control select2" id="category" runat="server">
                                <option value=""></option>
                                <option value="0">CODE</option>
                                <option value="1">NAME</option>
                            </select>
                            <div class="form-group has-feedback">
                                <input type="text" id="com_passs" runat="server" class="form-control" placeholder="Code or Name" />
                                <span class="glyphicon glyphicon-log-in form-control-feedback"></span>
                            </div>

                        </div>
                    </div>
                     <asp:Label ID="Labelvalidation" runat="server" Text=""></asp:Label>
                    <div class="row">
                        <div class="col-xs-8">
                            <div id="dvCaptcha"></div>
                            <%--   <div class="checkbox icheck">
                                <label>
                                    <input type="checkbox" />
                                    I agree to the <a href="#">terms</a>
                                </label>
                            </div>--%>
                        </div>
                        <!-- /.col -->
                        <div class="col-xs-4">
                            <%--<button type="submit" class="btn btn-primary btn-block btn-flat">Register</button>--%>
                            <asp:Button ID="BTNRegister" runat="server" Text="Register" class="btn btn-primary btn-block btn-flat" OnClick="register_Click" />
                        </div>
                        <!-- /.col -->
                    </div>


                    <div class="social-auth-links text-center">
                        <p>- OR -</p>
                        <a href="#" class="btn btn-block btn-social btn-facebook btn-flat"><i class="fa fa-facebook"></i>Sign up using Facebook</a>
                    </div>

                    <a href="login.aspx" class="text-center">I already have a membership</a>
                </div>
                <!-- /.form-box -->
            </div>
            <!-- /.register-box -->
        </div>
    </form>
    
   <%-- <script type="text/javascript" src="https://www.google.com/recaptcha/api.js?onload=onloadCallback&render=explicit"async defer></script>
    <script type="text/javascript">
        var onloadCallback = function () {
            grecaptcha.render('dvCaptcha', {
                'sitekey': '6LeAqxkTAAAAAOsw6IObSyJHea1kDeF0KNRrKV3e',
                'callback': function (response) {
                    $.ajax({
                        type: "POST",
                        url: "http://localhost:1291/Service1/VerifyCaptcha",
                        data: "{response: '" + response + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (r) {
                            //console.log(response);
                            var captchaResponse = jQuery.parseJSON(r.d);
                            if (captchaResponse.success) {
                                $("[id*=txtCaptcha]").val(captchaResponse.success);
                                $("[id*=rfvCaptcha]").hide();
                            } else {
                                $("[id*=txtCaptcha]").val("");
                                $("[id*=rfvCaptcha]").show();
                                var error = captchaResponse["error-codes"][0];
                                $("[id*=rfvCaptcha]").html("RECaptcha error. " + error);
                            }
                        }
                    });
                }
            });
        };
    </script>--%>
    <!-- jQuery 2.1.4 -->
    <script src="../assets/adminLTE/plugins/jQuery/jQuery-2.1.4.min.js"></script>

        <!-- select 2  -->
    <script src="../assets/adminLTE/plugins/select2/select2.full.min.js"></script>

    <!-- Bootstrap 3.3.5 -->
    <script src="../assets/adminLTE/bootstrap/js/bootstrap.min.js"></script>
    <!-- iCheck -->
    <script src="../assets/adminLTE/plugins/iCheck/icheck.min.js"></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });


    </script>
</body>
</html>
