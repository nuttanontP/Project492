﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User/user_master.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TestAmmy.testFBAPI.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head_css" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_title" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="title_description" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="main_content" runat="server">

    <asp:Button ID="btnLogin" runat="server" Text="Login with FaceBook" OnClick="Login" />
    <asp:Panel ID="pnlFaceBookUser" runat="server" Visible="false">
        <hr />
        <table>
            <tr>
                <td rowspan="5" valign="top">
                    <asp:Image ID="ProfileImage" runat="server" Width="50" Height="50" />
                </td>
            </tr>
            <tr>
                <td>ID:<asp:Label ID="lblId" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>UserName:<asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Name:<asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Email:<asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
    </asp:Panel>



    <fb:login-button scope="public_profile,email" onlogin="checkLoginState();">
</fb:login-button>

    <div id="status">
    </div>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="for_script" runat="server">
    <script>

    </script>
    <script>
        // This is called with the results from from FB.getLoginStatus().
        function statusChangeCallback(response) {
            console.log('statusChangeCallback');
            console.log(response);
            // The response object is returned with a status field that lets the
            // app know the current login status of the person.
            // Full docs on the response object can be found in the documentation
            // for FB.getLoginStatus().
            if (response.status === 'connected') {
                // Logged into your app and Facebook.
                testAPI();
            } else if (response.status === 'not_authorized') {
                // The person is logged into Facebook, but not your app.
                document.getElementById('status').innerHTML = 'Please log ' +
                  'into this app.';
            } else {
                // The person is not logged into Facebook, so we're not sure if
                // they are logged into this app or not.
                document.getElementById('status').innerHTML = 'Please log ' +
                  'into Facebook.';
            }
        }

        // This function is called when someone finishes with the Login
        // Button.  See the onlogin handler attached to it in the sample
        // code below.
        function checkLoginState() {
            FB.getLoginStatus(function (response) {
                statusChangeCallback(response);
            });
        }

        window.fbAsyncInit = function () {
            FB.init({
                appId: '1518100615161402',
                cookie: true,  // enable cookies to allow the server to access 
                // the session
                xfbml: true,  // parse social plugins on this page
                version: 'v2.5' // use graph api version 2.5
            });

            // Now that we've initialized the JavaScript SDK, we call 
            // FB.getLoginStatus().  This function gets the state of the
            // person visiting this page and can return one of three states to
            // the callback you provide.  They can be:
            //
            // 1. Logged into your app ('connected')
            // 2. Logged into Facebook, but not your app ('not_authorized')
            // 3. Not logged into Facebook and can't tell if they are logged into
            //    your app or not.
            //
            // These three cases are handled in the callback function.

            FB.getLoginStatus(function (response) {
                statusChangeCallback(response);
            });

        };

        // Load the SDK asynchronously
        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/en_US/sdk.js";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));

        // Here we run a very simple test of the Graph API after login is
        // successful.  See statusChangeCallback() for when this call is made.
        function testAPI() {
            console.log('Welcome!  Fetching your information.... ');
            FB.api('/me', function (response) {
                console.log('Successful login for: ' + response.name);
                console.log(response);
                document.getElementById('status').innerHTML =
                  'Thanks for logging in, ' + response.name + '!';
            });
        }
    </script>
</asp:Content>
