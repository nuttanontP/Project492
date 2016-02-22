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

            var testdata = [10, 50, 100, 400, 450, 660, 733, 866, 900];
           // var date = [new Date('2010-01-02'), new Date('2010-01-27'), new Date('2010-02-27')];
            var temp = [];
            for (var i in testdata) {
                temp.push({ x: new Date("2010-03-10"), y: testdata[i] });
                console.log(temp);
                new Date()
            }
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
				dataPoints: temp
			},
			{        
				type: "line",
				showInLegend: true,
				name: "for vehicle ",
				color: "#20B2AA",
				lineThickness: 2,

				dataPoints: [
				{ x: new Date(2010,0,1), y: 510 },
				{ x: new Date(2010,0,2), y: 560 },
				{ x: new Date(2010,0,3), y: 540 },
				{ x: new Date(2010,0,4), y: 558 },
				{ x: new Date(2010,0,5), y: 544 },
				{ x: new Date(2010,0,6), y: 693 },
				{ x: new Date(2010,0,7), y: 657 },
				{ x: new Date(2010,0,8), y: 663 },
				{ x: new Date(2010,0,9), y: 639 },
				{ x: new Date(2010, 0, 10), y: 673 },
                { x: new Date(2010, 0, 11), y: 510 },
				{ x: new Date(2010, 0, 12), y: 560 },
				{ x: new Date(2010, 0, 13), y: 540 },
				{ x: new Date(2010, 0, 14), y: 558 },
				{ x: new Date(2010, 0, 15), y: 544 },
				{ x: new Date(2010, 0, 16), y: 693 },
				{ x: new Date(2010, 0, 17), y: 657 },
				{ x: new Date(2010, 0, 18), y: 663 },
				{ x: new Date(2010, 0, 19), y: 639 },
				{ x: new Date(2010, 0, 20), y: 673 },
                { x: new Date(2010, 0, 21), y: 558 },
				{ x: new Date(2010, 0, 22), y: 544 },
				{ x: new Date(2010, 0, 23), y: 693 },
				{ x: new Date(2010, 0, 24), y: 657 },
				{ x: new Date(2010, 0, 25), y: 663 },
				{ x: new Date(2010, 0, 26), y: 639 },
				{ x: new Date(2010, 0, 27), y: 673 },
                { x: new Date(2010, 0, 28), y: 663 },
				{ x: new Date(2010, 0, 29), y: 639 },
				{ x: new Date(2010, 0, 30), y: 673 },
				{ x: new Date(2010,0,31), y: 660 }
				]
			},
            {
                type: "line",
                showInLegend: true,
                name: "for other purpose ",
                color: "#000",
                lineThickness: 2,

                dataPoints: [
				{ x: new Date(2010, 0, 1), y: 310 },
				{ x: new Date(2010, 0, 2), y: 360 },
				{ x: new Date(2010, 0, 3), y: 340 },
				{ x: new Date(2010, 0, 4), y: 358 },
				{ x: new Date(2010, 0, 5), y: 344 },
				{ x: new Date(2010, 0, 6), y: 393 },
				{ x: new Date(2010, 0, 7), y: 457 },
				{ x: new Date(2010, 0, 8), y: 463 },
				{ x: new Date(2010, 0, 9), y: 339 },
				{ x: new Date(2010, 0, 10), y: 473 },
                { x: new Date(2010, 0, 11), y: 410 },
				{ x: new Date(2010, 0, 12), y: 460 },
				{ x: new Date(2010, 0, 13), y: 340 },
				{ x: new Date(2010, 0, 14), y: 358 },
				{ x: new Date(2010, 0, 15), y: 344 },
				{ x: new Date(2010, 0, 16), y: 493 },
				{ x: new Date(2010, 0, 17), y: 457 },
				{ x: new Date(2010, 0, 18), y: 363 },
				{ x: new Date(2010, 0, 19), y: 339 },
				{ x: new Date(2010, 0, 20), y: 373 },
                { x: new Date(2010, 0, 21), y: 458 },
				{ x: new Date(2010, 0, 22), y: 444 },
				{ x: new Date(2010, 0, 23), y: 393 },
				{ x: new Date(2010, 0, 24), y: 457 },
				{ x: new Date(2010, 0, 25), y: 363 },
				{ x: new Date(2010, 0, 26), y: 439 },
				{ x: new Date(2010, 0, 27), y: 473 },
                { x: new Date(2010, 0, 28), y: 463 },
				{ x: new Date(2010, 0, 29), y: 339 },
				{ x: new Date(2010, 0, 30), y: 373 },
				{ x: new Date(2010, 0, 31), y: 460 }
                ]
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
