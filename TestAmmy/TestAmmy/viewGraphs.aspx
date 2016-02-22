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
    <div id="chartContainer" style="height: 300px; width: 90%;">
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
    
    <script type="text/javascript">

        window.onload = function () {
            var date= [<%foreach (var s in date){%>'<%=s%>',<%}%>];
            var data1 = [<%foreach (var s in dg){%>'<%=s%>',<%}%>];
            var data2 = [<%foreach (var s in Vehicle){%>'<%=s%>',<%}%>];
            var data3=[<%foreach (var s in Other){%>'<%=s%>',<%}%>];
           // var date = [new Date('2010-01-02'), new Date('2010-01-27'), new Date('2010-02-27')];
            var temp1 = [];
            var temp2 = [];
            var temp3 = [];
            for (var i in date) {
                temp1.push({ x: new Date(date[i]), y: parseInt(data1[i]) });
                temp2.push({ x: new Date(date[i]), y: parseInt(data2[i]) });
                temp3.push({ x: new Date(date[i]), y: parseInt(data3[i]) });
            }
            var xxx = ({ x: new Date('2010-01-27'), y: data3[i] });
            console.log(xxx);
            console.log(temp1[0]);
            console.log({ x: new Date(2010, 0, 1), y: 20 });
		var chart = new CanvasJS.Chart("chartContainer",
		{

			title:{
				text: "Diesel Consumption Details",
				padding: 15,
				fontFamily: "Source Sans Pro,Helvetica Neue,Helvetica,Arial,sans-serif",
				fontSize: 30
			},
                        animationEnabled: true,
			axisX:{

				gridColor: "Silver",
				tickColor: "silver",
				valueFormatString: "DD/MMM",
				title: "Date"

				

			},                        
                        toolTip:{
                          shared:true
                        },
			theme: "theme2",
			axisY: {
				gridColor: "Silver",
				tickColor: "silver",
				title: "Diesel consumed",
				suffix: " Liter"

			},
			legend:{
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
				dataPoints: temp1
			},
			{        
				type: "line",
				showInLegend: true,
				name: "for vehicle ",
				color: "#20B2AA",
				lineThickness: 2,

				dataPoints: temp2
			},
            {
                type: "line",
                showInLegend: true,
                name: "for other purpose ",
                color: "#000",
                lineThickness: 2,

                dataPoints: temp3
				
            }

			
			],
          legend:{
            cursor:"pointer",
            itemclick:function(e){
              if (typeof(e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
              	e.dataSeries.visible = false;
              }
              else{
                e.dataSeries.visible = true;
              }
              chart.render();
            }
          }
		});

chart.render();
}
</script>

    <script type="text/javascript" src="/assets/script/canvasjs.min.js"></script>

</asp:Content>
