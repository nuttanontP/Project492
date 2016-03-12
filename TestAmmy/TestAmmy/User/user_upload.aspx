<%@ Page Title="" Language="C#" MasterPageFile="~/User/user_master.Master" AutoEventWireup="true" CodeBehind="user_upload.aspx.cs" Inherits="TestAmmy.User.user_upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head_css" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_title" runat="server">
    Import excel
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="title_description" runat="server">
    HEEI Form
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="main_content" runat="server">
     <div class="row">
        <div class="col-md-12" style="background-color: #ffffff; padding-bottom: 30px; padding-top: 0px">
          
              <div class="box-body">
                <!-- checkbox -->
                <div class="form-group">
                     <label>Select data</label>
                  <div class="checkbox">
                    <label>
                      <input type="checkbox"/>
                      Electricity
                    </label>
                  </div>

                  <div class="checkbox">
                    <label>
                      <input type="checkbox"/>
                      Diesel
                    </label>
                  </div>
                     <div class="checkbox">
                    <label>
                      <input type="checkbox"/>
                      Gasoline
                    </label>
                  </div>
                     <div class="checkbox">
                    <label>
                      <input type="checkbox"/>
                      LPG
                    </label>
                  </div>
                     <div class="checkbox">
                    <label>
                      <input type="checkbox"/>
                      Water Consumption
                    </label>
                  </div>
                     <div class="checkbox">
                    <label>
                      <input type="checkbox"/>
                      Occupancy
                    </label>
                  </div>
              
                </div>

    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <br />
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4>Add permission</h4>
                </div>
                <div class="modal-body">
                 
                    <div class="form-group">
                        <label for="energy-type" class="control-label">Energy Type DDL:</label> 
                        <br />
                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                       
                        
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <%--<button type="button" class="btn btn-primary">Save</button>--%>
                </div>
            </div>
        </div>
    </div>

<hr />
                <div class="form-group">
                  <label for="exampleInputFile">File input</label>
                  <input type="file" id="exampleInputFile"/>

                  <p class="help-block">Files must be in the HEEI form.</p>
                </div>
               
              </div>
              <!-- /.box-body -->

              <div class="box-footer">
                <button type="submit" class="btn btn-primary">Submit</button>
              </div>
           
        </div>       
     </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="for_script" runat="server">
</asp:Content>
