<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="viewGraphs.aspx.cs" Inherits="TestAmmy.viewGraphs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="rightmenu" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="content_col9" runat="server">
    <h3>Data summary</h3>
    <hr />
    <div class="col-sm-4">
        <h4>Data from month:</h4>
        <asp:DropDownList ID="ddl_month" class="form-control dropdown-toggle" runat="server">
            <asp:ListItem Text="--Select month--" Value="00" />
            <asp:ListItem Text="January" Value="01" />
            <asp:ListItem Text="February" Value="02" />
            <asp:ListItem Text="March" Value="03" />
            <asp:ListItem Text="April" Value="04" />
            <asp:ListItem Text="May" Value="05" />
            <asp:ListItem Text="June" Value="06" />
            <asp:ListItem Text="July" Value="07" />
            <asp:ListItem Text="August" Value="08" />
            <asp:ListItem Text="September" Value="09" />
            <asp:ListItem Text="October" Value="10" />
            <asp:ListItem Text="November" Value="11" />
            <asp:ListItem Text="December" Value="12" />
        </asp:DropDownList>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <div id="chartContainer" style="height: 400px; width: 100%;">
    </div>
    <br />
    <br />
    <br />
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
    <script type="text/javascript">
        var result;
        function recall(result) {
            console.log(result);
            tempx1 = [];
            tempx2 = [];
            tempx3 = [];
            if (result != 'no') {
                for (var i in result) {
                    tempx1.push({ x: new Date(result[i]["date"]), y: result[i]["DGSet"] });
                    tempx2.push({ x: new Date(result[i]["date"]), y: result[i]["Vehicle"] });
                    tempx3.push({ x: new Date(result[i]["date"]), y: result[i]["OtherPurpose"] });
                }
            }
            
            var chart = new CanvasJS.Chart("chartContainer",
            {

                title: {
                    text: "Diesel Consumption Details",
                    padding: 15,
                    fontFamily: "Source Sans Pro,Helvetica Neue,Helvetica,Arial,sans-serif",
                    fontSize: 30
                },
                animationEnabled: true,
                axisX: {

                    gridColor: "Silver",
                    tickColor: "silver",
                    valueFormatString: "DD/MMM",
                    title: "Date"



                },
                toolTip: {
                    shared: true
                },
                theme: "theme2",
                axisY: {
                    gridColor: "Silver",
                    tickColor: "silver",
                    title: "Diesel consumed",
                    suffix: " Liter"

                },
                legend: {
                    verticalAlign: "center",
                    horizontalAlign: "right"
                },
                data: [
                {
                    type: "line",
                    showInLegend: true,
                    lineThickness: 2,
                    name: "for DG set",
                    markerType: "square",
                    color: "#F08080",
                    dataPoints: tempx1
                },
                {
                    type: "line",
                    showInLegend: true,
                    name: "for vehicle ",
                    color: "#20B2AA",
                    lineThickness: 2,

                    dataPoints: tempx2
                },
                {
                    type: "line",
                    showInLegend: true,
                    name: "for other purpose ",
                    color: "#000",
                    lineThickness: 2,

                    dataPoints: tempx3

                }


                ],
                legend: {
                    cursor: "pointer",
                    itemclick: function (e) {
                        if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                            e.dataSeries.visible = false;
                        }
                        else {
                            e.dataSeries.visible = true;
                        }
                        chart.render();
                    }
                }
            });

            chart.render();
        }
     <%--   $(function () {

            var customer = { contact_name: "Scott", company_name: "HP" };
            var nont = [<%=ddl_month.SelectedValue%>];
            console.log('ddl select=',nont);
        });--%>

        $('#content_col9_ddl_month').change(function () {
            //alert($('#content_col9_ddl_month').val());
            var nont = [$('#content_col9_ddl_month').val()];
            $.ajax({
                type: "POST",
                data: JSON.stringify(nont),
                url: "http://localhost:1291/Service1/selectdiesel2",
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {
                    if (data == 'no') {
                        recall('no');
                    }
                    else {
                        result = JSON.parse(data);
                        recall(result);
                    }
                    
                }
            });
          
        });
      
        window.onload = function () {
            // var date = [new Date('2010-01-02'), new Date('2010-01-27'), new Date('2010-02-27')];
            var nont = [$('#content_col9_ddl_month').val()];
            $.ajax({
                type: "POST",
                data: JSON.stringify(nont),
                url: "http://localhost:1291/Service1/selectdiesel2",
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {
                    if (data == 'no') {
                        recall('no');
                    } else {
                        result = JSON.parse(data);
                        recall(result);
                    }
                   
                }
            });
        }
    </script>

    <script type="text/javascript" src="/assets/script/canvasjs.min.js"></script>

</asp:Content>
