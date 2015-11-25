<%@ Page Title="" Language="C#" MasterPageFile="~/masterp.Master" AutoEventWireup="true" CodeBehind="loginRegister.aspx.cs" Inherits="TestAmmy.loginRegister" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head1" runat="server">
    Signing in and Registration
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="content1" runat="server">
    <div class="row">
        <div class="col-md-6" style="border: 1px solid rgb(243, 243, 243); padding-bottom: 20px;">
           <h4>Sign in</h4> 
           <div class="form-horizontal">
               <div class="form-group">
                   <label  for="inputEmail3" class="col-sm-2 control-label">Email</label>
                   <div class="col-sm-10">
                       <%--<input  type="email" class="form-control" placeholder="Email">--%>
                       <asp:TextBox ID="txtemail" runat="server" class="form-control" placeholder="Email" ></asp:TextBox>
                   </div>
               </div>
               <div class="form-group">
                   <label for="inputPassword3" class="col-sm-2 control-label">Password</label>
                   <div class="col-sm-10">
                       <%--<input type="password" class="form-control" id="inputPassword1" placeholder="Password">--%>
                       <asp:TextBox ID="txtpassword" runat="server" class="form-control" placeholder="Password" TextMode="Password" ></asp:TextBox>                        
                   </div>
               </div>
               <div class="form-group">
                   <div class="col-sm-offset-2 col-sm-10">
                       <div class="checkbox">
                           <label>
                               <input type="checkbox">
                               Remember me
                           </label>
                       </div>
                       <asp:Label ID="LabelValidation" runat="server" Text=""></asp:Label>
                   </div>
               </div>
               <div class="form-group">
                   <div class="col-sm-offset-2 col-sm-10">
                  <%--     <button type="submit" class="btn btn-default">Sign in</button>--%>
                       <asp:Button ID="Button1" class="btn btn-default" runat="server" Text="Sign in" OnClick="Button1_Click" />
                   </div>
               </div>
           </div>

        </div>

        <%--Register--%>
        <div class="col-md-6" style="border: 1px solid rgb(243, 243, 243); padding-bottom: 20px;">
            <h4>Register</h4>

            <div class="form-horizontal">
                <div class="form-group">
                   <label for="inputName2" class="col-sm-2 control-label">Name</label>
                   <div class="col-sm-10">
                       <%--<input type="text" class="form-control" id="inputName2" placeholder="Firstname">--%>
                       <asp:TextBox ID="txtfirstname" runat="server" class="form-control"  placeholder="Firstname"></asp:TextBox>
                   </div>
               </div>
                <div class="form-group">
                   <label for="inputSurname2" class="col-sm-2 control-label">Surname</label>
                   <div class="col-sm-10">
                       <%--<input type="text" class="form-control" id="inputSurname2" placeholder="Lastname">--%>
                       <asp:TextBox ID="txtlastname" runat="server" class="form-control"  placeholder="Lastname"></asp:TextBox>
                   </div>
               </div>
               <div class="form-group">
                   <label for="inputEmail3" class="col-sm-2 control-label">Email</label>
                   <div class="col-sm-10">
                       <%--<input type="email" class="form-control" id="inputEmail2" placeholder="Email">--%>
                         <asp:TextBox ID="txtemail2" runat="server" class="form-control"  placeholder="Email" TextMode="Email"></asp:TextBox>
                   </div>
               </div>
               <div class="form-group">
                   <label for="inputPassword2" class="col-sm-2 control-label">Password</label>
                   <div class="col-sm-10">
                       <%--<input type="password" class="form-control" id="inputPassword2" placeholder="0-9 or a-z">--%>
                         <asp:TextBox ID="txtpassword2" runat="server" class="form-control"  placeholder="0-9 or a-z" TextMode="Password"></asp:TextBox>
                   </div>
               </div>
                   <div class="form-group">
                   <label for="inputPassword3" class="col-sm-2 control-label">Confirm Password</label>
                   <div class="col-sm-10">
                       <%--<input type="password" class="form-control" id="inputPassword3" placeholder="0-9 or a-z">--%>
                       <asp:TextBox ID="txtconfrimpassword" runat="server" class="form-control"  placeholder="0-9 or a-z" TextMode="Password"></asp:TextBox>
                   </div>
               </div>
                 <div class="form-group">
                   <label for="inputCompany" class="col-sm-2 control-label">Company</label>
                   <div class="col-sm-10">
                       <%--<input type="text" class="form-control" id="inputCompany" placeholder="Company Name">--%>
                       <asp:TextBox ID="txtcompany" runat="server" class="form-control"  placeholder="Company Name"></asp:TextBox>
                   </div>
               </div>
                <div class="form-group">
                   <label for="inputCompany" class="col-sm-2 control-label">Position</label>
                   <div class="col-sm-10">
                       <%--<input type="text" class="form-control" id="inputPosition" placeholder="Your Position">--%>
                       <asp:TextBox ID="txtPosition" runat="server" class="form-control"  placeholder="Your Position"></asp:TextBox>
                   </div>
               </div>
               <div class="form-group">
                   <div class="col-sm-offset-2 col-sm-10">
                       <div class="checkbox">
                           <label>
                               <input type="checkbox">
                                accept condition
                           </label>
                       </div>
                       <asp:Label ID="Labelregister" runat="server" Text=""></asp:Label>
                   </div>
               </div>
               <div class="form-group">
                   <div class="col-sm-offset-2 col-sm-10">
                       <%--<button type="submit" class="btn btn-default">Register</button>--%>
                       <asp:Button ID="submit" runat="server" Text="Register" class="btn btn-default" OnClick="submit_Click" />
                   </div>
               </div>
           </div>
        </div>
    </div>

</asp:Content>
