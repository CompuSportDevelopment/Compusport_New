<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HTML_FileToPDF.aspx.cs" Inherits="PDF_File_HTML_FileToPDF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<style type="text/css">
    .TextClass
    {
        text-indent: 7%;
        font-size: 120%;
        text-align: justify;
        font-family: sans-serif;
        letter-spacing: 1px;
    }
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
</head>
<body >
    <script src="../Scripts/html2canvas.min.js" type="text/javascript"></script>
    <script src="../Scripts/pdfmake.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Scripts/ErrorFunction.js"></script>
    <script type="text/javascript">
        function Export() {
            debugger;
            html2canvas(document.getElementById('errors'), {
                onrendered: function (canvas) {
                    var data = canvas.toDataURL();
                    var docDefinition = {
                        pageSize: 'A4',
                        pageOrientation: 'portrait',
                        content: [{
                            image: data,
                            width: 500
                        }]
                    };
                    pdfMake.createPdf(docDefinition).download("errors.pdf");
                }
            });
        }
    </script>
    <form id="form1" runat="server">
    </form>
    <div id="errors" style="margin-left: 8%; margin-right: 8%;">
        <div class="row">
            <div class="col-sm-12" style="text-align: center">
                <img src="../Images/PDF_Error.JPG" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-sm-12">
                <h2 style="text-align: center;">
                    <asp:Label ID="lblPageInfo" runat="server" Text="" Style="text-align: center;"></asp:Label>
                    Analysis:
                    <asp:Label ID="lblUserName" runat="server" Text="" Style="color: Red; text-align: center;"></asp:Label>
                </h2>
                <h3 style="text-align: center;">
                    Session:
                    <asp:Label ID="lblSession" runat="server" Text="" Style="color: Red"></asp:Label>
                </h3>
                <p class="TextClass">
                    This is a summary of the On-Track or Competitive Session listed above. Performance
                    Variables that are flagged as errors are identified in four Groups: <span style="font-weight: 600;">
                        Result, General, Special, and Specific.</span>
                </p>
                <p class="TextClass">
                    The challenge for the Elite Coach is to improve the Specific Performance Descriptors
                    which will, in turn, improve the results in the remaining Groups.
                </p>
                <h3>
                    Result:</h3>
                <p class="TextClass">
                    The Variable that is the end product of all of the athlete’s efforts is put in the
                    Result category. In the Sprint, this Variable is the Horizontal Velocity down the
                    Track. Since this result is compared to the velocity required to produce a World
                    Record effort, it is extremely rare for this variable not to be flagged as one to
                    be improved.
                </p>
                <asp:Label class="TextClass" ID="ErrorList" runat="server" Text="" Style="color: Red;
                    text-align: center;"></asp:Label>
                <br />
                <h3>
                    General Performance Descriptors:</h3>
                <p class="TextClass">
                    Those variables in this Group identify how well the athlete is doing, but they do
                    not identify how the performer is mechanically producing the results. They are critical,
                    however, in determining what area needs to be addressed for improvement to occur.
                </p>
                <h4>
                    Ground Phase:</h4>
                <%--                <asp:Label ID="Label2" runat="server" Text="Stride Rate is Too Low" Style="color: Red"></asp:Label>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Ground Time is Too Long" Style="color: Red"></asp:Label>
                <br />
                <br />--%>
                <h3>
                    Air Phase:</h3>
                <%--     <asp:Label ID="Label4" runat="server" Text="Air Time is Too Long" Style="color: Red"></asp:Label>
                <br />
                <asp:Label ID="Label5" runat="server" Text="Stride Rate is Too Low" Style="color: Red"></asp:Label>
                <br />
                <br />--%>
                <h3>
                    Special Performance Descriptors:</h3>
                <p class="TextClass">
                    Stride Length is placed in its own Special group because it is evaluated differently
                    than other Variables. Because the actual Length result is directly affected by Air
                    Time, to determine if the Length is actually a problem the result is adjusted for
                    the athlete’s actual Air Time. This error can be mechanically based, but in most
                    cases it is due to the athlete's inability to generate sufficient Dynamic Strength
                    during Ground contact.
                </p>
                <asp:Label ID="Label6" runat="server" Text="Not Producing Sufficient Stride Length During Right Ground Contact"></asp:Label>
                <h3>
                    Specific Performance Descriptors:</h3>
                <p class="TextClass">
                    These Variables identify how the performer is mechanically producing the results
                    in the Result, General, and Special groups. These are the areas where changes must
                    be made to improve performance. In the unlikely case where all Specific Variables
                    fall in the acceptable range, the only remaining way to improve performance would
                    be to improve Strength levels (Static, Dynamic, or Elastic).
                </p>
                <br />
                <h3>
                    Ground Phase:</h3>
                <%--   <asp:Label ID="Label7" runat="server" Text="Upper Leg Full Extension Angle is Too Small (Over-Extending into Back Side)"
                    Style="color: Red"></asp:Label>
                <br />
                <asp:Label ID="Label8" runat="server" Text="Upper Leg Full Flexion Angle Right (High Knee Position) During Air Phase is Too Small"
                    Style="color: Red"></asp:Label>
                <br />
                <asp:Label ID="Label9" runat="server" Text="Lower Leg Angle at Takeoff is Too Large (Over-Extending into Back Side)"
                    Style="color: Red"></asp:Label>
                <br />--%>
                <h3>
                    Air Phase:</h3>
                <%--<asp:Label ID="Label10" runat="server" Text="Knee-Knee Separation at Touchdown is Too Large (Excessive Back Side)"
                    Style="color: Red"></asp:Label>
                <br />
                <asp:Label ID="Label11" runat="server" Text="Body COG to Foot Touchdown Distance is Too Long (Over Reaching)"
                    Style="color: Red"></asp:Label>
                <br />
                <asp:Label ID="Label12" runat="server" Text="Lower Leg Full Flexion Angle Left is Too Small During Ground Contact (Back Side Indicator)"
                    Style="color: Red"></asp:Label>--%>
            </div>
        </div>
        <div class="col-sm-12" style="text-align: center">
            <input type="button" id="btnExport" value="Export" onclick="Export();"/>
        </div>
    </div>
</body>
</html>
