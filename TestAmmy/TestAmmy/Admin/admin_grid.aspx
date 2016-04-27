<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_master.Master" AutoEventWireup="true" CodeBehind="admin_grid.aspx.cs" Inherits="TestAmmy.Admin.admin_grid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head_css" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_title" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="title_description" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breadcrumb" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="main_content" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">Previous Data</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <div class="box-body">

                    <div class="row">
                        <div class="col-sm-10 col-sm-offset-0">

                            <div class="nav-tabs-custom ">
                                <ul class="nav nav-tabs " id="myTab">
                                    <li class="active"><a href="#profile" data-toggle="tab"><strong>Electric</strong></a></li>
                                    <li><a href="#tab2" data-toggle="tab"><strong>Diesel</strong></a></li>
                                    <li><a href="#tab3" data-toggle="tab"><strong>Gasoline</strong></a></li>
                                    <li><a href="#tab4" data-toggle="tab"><strong>LPG</strong></a></li>
                                    <li><a href="#tab5" data-toggle="tab"><strong>Water</strong></a></li>
                                    <li><a href="#tab6" data-toggle="tab"><strong>Occupancy</strong></a></li>
                                </ul>
                                <div class="tab-content">
                                    <div class="tab-pane active" id="profile">
                                        <div class="row">
                                            <div class="col-sm-12 col-sm-offset-1">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="electric" AutoGenerateColumns="False" class="electric table table-bordered table-striped" HeaderStyle-HorizontalAlign="Center" DataKeyNames="randomID" runat="server" OnRowDeleting="electric_RowDeleting">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="No">
                                                                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="type" HeaderText="type" />
                                                                <asp:BoundField DataField="date" HeaderText="date" DataFormatString="{0:dd , MMMM , yyyy}" />
                                                                <asp:BoundField DataField="current meter" HeaderText="current" NullDisplayText="-" />
                                                                <asp:BoundField DataField="bath/unit" HeaderText="price/unit" NullDisplayText="-" />
                                                                <asp:BoundField DataField="peak" HeaderText="peak" NullDisplayText="-" />
                                                                <asp:BoundField DataField="off peak" HeaderText="off peak" NullDisplayText="-" />
                                                                <asp:BoundField DataField="holiday" HeaderText="holiday" NullDisplayText="-" />
                                                                <asp:BoundField DataField="name" HeaderText="name" NullDisplayText="-" />
                                                                <asp:BoundField DataField="building_name" HeaderText="name of building" NullDisplayText="-" />
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="Delete" runat="server" CausesValidation="False" CommandName="delete" Text="ลบ" class="btn btn-danger btn-xs" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClientClick="JavaScript:return confirm('delete ?');"><span class="fa fa-times" aria-hidden="true"></span></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane" id="tab2">
                                        <div class="row">
                                            <div class="col-sm-12 col-sm-offset-1">
                                                <asp:GridView ID="diesel" AutoGenerateColumns="False" class="diesel table table-bordered table-striped" HeaderStyle-HorizontalAlign="Center" DataKeyNames="randomID" runat="server" OnRowDeleting="diesel_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="No">
                                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="date" HeaderText="date" DataFormatString="{0:dd , MMMM , yyyy}" />
                                                        <asp:BoundField DataField="purchased" HeaderText="Purchased (liter)" NullDisplayText="-" />
                                                        <asp:BoundField DataField="DGSet" HeaderText="DG Set Consumed" NullDisplayText="-" />
                                                        <asp:BoundField DataField="Vehicle" HeaderText="Vehicle Consumed" NullDisplayText="-" />
                                                        <asp:BoundField DataField="OtherPurpose" HeaderText="Other Purpose Consumed" NullDisplayText="-" />
                                                        <asp:BoundField DataField="Runningtime" HeaderText="Running time of DG set (Minutes)" NullDisplayText="-" />
                                                        <asp:BoundField DataField="bath/unit" HeaderText="price/unit" NullDisplayText="-" />
                                                        <asp:BoundField DataField="name" HeaderText="name" NullDisplayText="-" />
                                                        <asp:BoundField DataField="building_name" HeaderText="name of building" NullDisplayText="-" />
                                                        <asp:TemplateField ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="Delete" runat="server" CausesValidation="False" CommandName="delete" Text="ลบ" class="btn btn-danger btn-xs" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClientClick="JavaScript:return confirm('delete ?');"><span class="fa fa-times" aria-hidden="true"></span></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane" id="tab3">
                                        <div class="row">
                                            <div class="col-sm-12 col-sm-offset-1">
                                                <asp:GridView ID="gasoline" AutoGenerateColumns="False" class="gasoline table table-bordered table-striped" HeaderStyle-HorizontalAlign="Center" DataKeyNames="randomID" runat="server" OnRowDeleting="gasoline_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="No">
                                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="date" HeaderText="date" DataFormatString="{0:dd , MMMM , yyyy}" />
                                                        <asp:BoundField DataField="purchased" HeaderText="Gasoline Purchased(Liter)" NullDisplayText="-" />
                                                        <asp:BoundField DataField="consumed" HeaderText="Gasoline Consumed(Liter)" NullDisplayText="-" />
                                                        <asp:BoundField DataField="bath/unit" HeaderText="price/unit" NullDisplayText="-" />
                                                        <asp:BoundField DataField="name" HeaderText="name" NullDisplayText="-" />
                                                        <asp:BoundField DataField="building_name" HeaderText="name of building" NullDisplayText="-" />
                                                        <asp:TemplateField ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="Delete" runat="server" CausesValidation="False" CommandName="delete" Text="ลบ" class="btn btn-danger btn-xs" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClientClick="JavaScript:return confirm('delete ?');"><span class="fa fa-times" aria-hidden="true"></span></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane" id="tab4">
                                        <div class="row">
                                            <div class="col-sm-12 col-sm-offset-1">
                                                <asp:GridView ID="lpg" AutoGenerateColumns="False" class="lpg table table-bordered table-striped" HeaderStyle-HorizontalAlign="Center" DataKeyNames="randomID" runat="server" OnRowDeleting="lpg_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="No">
                                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="date" HeaderText="date" DataFormatString="{0:dd , MMMM , yyyy}" />
                                                        <asp:BoundField DataField="purchased" HeaderText="LPG Purchased(KG)" NullDisplayText="-" />
                                                        <asp:BoundField DataField="consumed" HeaderText="LPG Consumed(KG)" NullDisplayText="-" />
                                                        <asp:BoundField DataField="bath/unit" HeaderText="price/unit" NullDisplayText="-" />
                                                        <asp:BoundField DataField="name" HeaderText="name" NullDisplayText="-" />
                                                        <asp:BoundField DataField="building_name" HeaderText="name of building" NullDisplayText="-" />
                                                        <asp:TemplateField ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="Delete" runat="server" CausesValidation="False" CommandName="delete" Text="ลบ" class="btn btn-danger btn-xs" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClientClick="JavaScript:return confirm('delete ?');"><span class="fa fa-times" aria-hidden="true"></span></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane" id="tab5">
                                        <div class="row">
                                            <div class="col-sm-12 col-sm-offset-1">
                                                <asp:GridView ID="water" AutoGenerateColumns="False" class="water table table-bordered table-striped" HeaderStyle-HorizontalAlign="Center" DataKeyNames="randomID" runat="server" OnRowDeleting="water_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="No">
                                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="date" HeaderText="date" DataFormatString="{0:dd , MMMM , yyyy}" />
                                                        <asp:BoundField DataField="factor" HeaderText="factor" NullDisplayText="-" />
                                                        <asp:BoundField DataField="type" HeaderText="type" NullDisplayText="-" />
                                                        <asp:BoundField DataField="current" HeaderText="Current Meter Reading" NullDisplayText="-" />
                                                        <asp:BoundField DataField="bath/unit" HeaderText="price/unit" NullDisplayText="-" />
                                                        <asp:BoundField DataField="name" HeaderText="name" NullDisplayText="-" />
                                                        <asp:BoundField DataField="building_name" HeaderText="name of building" NullDisplayText="-" />
                                                        <asp:TemplateField ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="Delete" runat="server" CausesValidation="False" CommandName="delete" Text="ลบ" class="btn btn-danger btn-xs" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClientClick="JavaScript:return confirm('delete ?');"><span class="fa fa-times" aria-hidden="true"></span></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane" id="tab6">
                                        <div class="row">
                                            <div class="col-sm-12 col-sm-offset-1">
                                                <asp:GridView ID="occupancy" AutoGenerateColumns="False" class="occupancy table table-bordered table-striped" HeaderStyle-HorizontalAlign="Center" DataKeyNames="randomID" runat="server" OnRowDeleting="occupancy_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="No">
                                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="date" HeaderText="date" DataFormatString="{0:dd , MMMM , yyyy}" />
                                                        <asp:BoundField DataField="Available" HeaderText="Available" NullDisplayText="-" />
                                                        <asp:BoundField DataField="Occupied" HeaderText="Occupied" NullDisplayText="-" />
                                                        <asp:BoundField DataField="Number_Guests" HeaderText="Number of Guests(Number)" NullDisplayText="-" />
                                                        <asp:BoundField DataField="name" HeaderText="name" NullDisplayText="-" />
                                                        <asp:BoundField DataField="building_name" HeaderText="name of building" NullDisplayText="-" />
                                                        <asp:TemplateField ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="Delete" runat="server" CausesValidation="False" CommandName="delete" Text="ลบ" class="btn btn-danger btn-xs" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClientClick="JavaScript:return confirm('delete ?');"><span class="fa fa-times" aria-hidden="true"></span></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>

                </div>

            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="for_script" runat="server">
    <script>


        //
        //


        $(document).ready(function () {
            //$(".electric").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
            //$(".Diesel").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
            $('.electric').dataTable({ "scrollX": true });
            $('.diesel').dataTable({ "scrollX": true });
            $('.gasoline').dataTable({ "scrollX": true });
            $('.lpg').dataTable({ "scrollX": true });
            $('.water').dataTable({ "scrollX": true });
            $('.occupancy').dataTable({ "scrollX": true });

        });

    </script>
</asp:Content>
