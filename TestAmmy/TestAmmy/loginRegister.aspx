<%@ Page Title="" Language="C#" MasterPageFile="~/masterp.Master" AutoEventWireup="true" CodeBehind="loginRegister.aspx.cs" Inherits="TestAmmy.loginRegister" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head1" runat="server">
    Signing in and Registration
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="content1" runat="server">
    <div class="row">
        <div class="col-md-6" style="border: 1px solid rgb(243, 243, 243); padding-bottom: 20px;">
           <h4>Sign in</h4> 
           <form class="form-horizontal">
               <div class="form-group">
                   <label  for="inputEmail3" class="col-sm-2 control-label">Email</label>
                   <div class="col-sm-10">
                       <input  type="email" class="form-control" id=<%inputEmail1%> placeholder="Email">
                   </div>
               </div>
               <div class="form-group">
                   <label for="inputPassword3" class="col-sm-2 control-label">Password</label>
                   <div class="col-sm-10">
                       <input type="password" class="form-control" id="inputPassword1" placeholder="Password">
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
                   </div>
               </div>
               <div class="form-group">
                   <div class="col-sm-offset-2 col-sm-10">
                  <%--     <button type="submit" class="btn btn-default">Sign in</button>--%>
                       <asp:Button ID="Button1" class="btn btn-default" runat="server" Text="Sign" />
                   </div>
               </div>
           </form>

        </div>

        <%--Register--%>
        <div class="col-md-6" style="border: 1px solid rgb(243, 243, 243); padding-bottom: 20px;">
            <h4>Register</h4>

            <form class="form-horizontal">
                <div class="form-group">
                   <label for="inputName2" class="col-sm-2 control-label">Name</label>
                   <div class="col-sm-10">
                       <input type="text" class="form-control" id="inputName2" placeholder="Firstname">
                   </div>
               </div>
                <div class="form-group">
                   <label for="inputSurname2" class="col-sm-2 control-label">Surname</label>
                   <div class="col-sm-10">
                       <input type="text" class="form-control" id="inputSurname2" placeholder="Lastname">
                   </div>
               </div>
               <div class="form-group">
                   <label for="inputEmail3" class="col-sm-2 control-label">Email</label>
                   <div class="col-sm-10">
                       <input type="email" class="form-control" id="inputEmail2" placeholder="Email">
                   </div>
               </div>
               <div class="form-group">
                   <label for="inputPassword2" class="col-sm-2 control-label">Password</label>
                   <div class="col-sm-10">
                       <input type="password" class="form-control" id="inputPassword2" placeholder="0-9 or a-z">
                   </div>
               </div>
                   <div class="form-group">
                   <label for="inputPassword3" class="col-sm-2 control-label">Confirm Password</label>
                   <div class="col-sm-10">
                       <input type="password" class="form-control" id="inputPassword3" placeholder="0-9 or a-z">
                   </div>
               </div>
                 <div class="form-group">
                   <label for="inputCompany" class="col-sm-2 control-label">Company</label>
                   <div class="col-sm-10">
                       <input type="text" class="form-control" id="inputCompany" placeholder="Company Name">
                   </div>
               </div>
                <div class="form-group">
                   <label for="inputCompany" class="col-sm-2 control-label">Position</label>
                   <div class="col-sm-10">
                       <input type="text" class="form-control" id="inputPosition" placeholder="Your Position">
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
                   </div>
               </div>
               <div class="form-group">
                   <div class="col-sm-offset-2 col-sm-10">
                       <button type="submit" class="btn btn-default">Register</button>
                   </div>
               </div>
           </form>
        </div>
    </div>

</asp:Content>
