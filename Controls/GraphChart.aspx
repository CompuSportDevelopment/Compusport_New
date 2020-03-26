<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GraphChart.aspx.cs" Inherits="Controls_GraphChart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://www.gstatic.com/charts/loader.js" type="text/javaScript"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.0.0/jquery.min.js" type="text/javaScript"></script>
    <script type="text/javascript">
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawChart);
        google.charts.setOnLoadCallback(drawChart1);
        var session_Name=('<%=HttpContext.Current.Session["Session_Name"]%>');
        function drawChart() {
        debugger;
        var graphDataChart1 = ([<%=HttpContext.Current.Session["GRAPH_DATA_CHART1"]%>]);
            var data = google.visualization.arrayToDataTable(graphDataChart1);
            var view = new google.visualization.DataView(data);
            view.setColumns([0, 1,
                       { calc: "stringify",
                           sourceColumn: 3,
                           type: "string",
                           role: "annotation"
                       },
                       2]);

            var options = {
                 chartArea: { width: '35%' ,top: '-4%'},
                hAxis: {
                    minValue: 0
                },
                vAxis: {
                    title: 'Performance Variable'
                }

            };
             var chart = new google.visualization.BarChart(document.getElementById("chart_div"));
      google.visualization.events.addListener(chart, 'ready', function () {
        chart_div.innerHTML = '<img src="' + chart.getImageURI() + '">';
      });
            chart.draw(view, options);
        }
        function drawChart1() {
        debugger;
        var graphDataChart2 = ([<%=HttpContext.Current.Session["GRAPH_DATA_CHART2"]%>]);
            var data = google.visualization.arrayToDataTable(graphDataChart2);
            var view = new google.visualization.DataView(data);
            view.setColumns([0, 1,
                       { calc: "stringify",
                           sourceColumn: 3,
                           type: "string",
                           role: "annotation"
                       },
                       2]);

            var options = {
                chartArea: { width: '35%',top:'2%'},
                hAxis: {
                    minValue: 0
                },
                vAxis: {
                    title: 'Performance Variable'
                }

            };
             var chart = new google.visualization.BarChart(document.getElementById("chart_div1"));
      google.visualization.events.addListener(chart, 'ready', function () {
        chart_div1.innerHTML = '<img src="' + chart.getImageURI() + '">';
      });
            chart.draw(view, options);
                          document.getElementById("<%=Chart1.ClientID %>").value = chart_div.innerHTML;
              document.getElementById("<%=Chart2.ClientID %>").value = chart_div1.innerHTML;
              document.getElementById("form1").submit();
        }
 
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="chart_div" style="height: 1000px; width: 1500px">
    </div>
    <div>
        <div id="chart_div1" style="height: 1500px; width: 1500px; margin-top:-26%">
    </div>
    </div>

        <input type="hidden" id="Chart1" runat="server"  />
    <input type="hidden" id="Chart2" runat="server"  />
    </form>
</body>
</html>
