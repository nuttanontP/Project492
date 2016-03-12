<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TestAmmy.View.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <title>MIS for Eng=ergy Management | Log in</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>
    <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="../assets/adminLTE/bootstrap/css/bootstrap.min.css"/>
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css"/>
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css"/>
    <!-- Theme style -->
    <link rel="stylesheet" href="../assets/adminLTE/dist/css/AdminLTE.min.css"/>
    <!-- iCheck -->
    <link rel="stylesheet" href="../assets/adminLTE/plugins/iCheck/square/blue.css"/>

</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
    <div>
    <div class="login-box">
      <div class="login-logo">
        <a href="../assets/adminLTE/index2.html"><b>MIS</b> Energy Management</a>
      </div><!-- /.login-logo -->
      <div class="login-box-body">
        <p class="login-box-msg">Sign in to start your session</p>
          <div class="form-group has-feedback">
            <input type="email" id="email" runat="server" class="form-control" placeholder="Email"/>
            <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
          </div>
          <div class="form-group has-feedback">
            <input type="password" id="password" runat="server" class="form-control" placeholder="Password"/>
            <span class="glyphicon glyphicon-lock form-control-feedback"></span>
               <asp:Label ID="Labelvalidation" runat="server" Text=""></asp:Label>
          </div>
          <div class="row">
            <div class="col-xs-8">
              <div class="checkbox icheck">
                <label>
                  <input type="checkbox"/> Remember Me
                </label>
              </div>
            </div><!-- /.col -->
            <div class="col-xs-4">
                <asp:Button ID="btn_signIn" runat="server" Text="Sign In" class="btn btn-primary btn-block btn-flat" OnClick="btn_signIn_Click" />
<%--              <button type="submit" >Sign In</button>--%>
            </div><!-- /.col -->
          </div>

        <div class="social-auth-links text-center">
          <p>- OR -</p>
          <a href="#" class="btn btn-block btn-social btn-facebook btn-flat"><i class="fa fa-facebook"></i> Sign in using Facebook</a>
        </div><!-- /.social-auth-links -->

        <a href="#">I forgot my password</a><br/>
        <a href="register.aspx" class="text-center">Register a new membership</a>

      </div><!-- /.login-box-body -->
    </div><!-- /.login-box -->
    </div>
    </form>

     <!-- jQuery 2.1.4 -->
    <script src="../assets/adminLTE/plugins/jQuery/jQuery-2.1.4.min.js"></script>
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
