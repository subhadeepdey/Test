<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestWebApplication.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>This is a sample Test</title>
    <script src="scripts/jquery-3.1.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            var date = new Date()
            var offsetms = date.getTimezoneOffset() * 60 * 1000;
            $('.toLocaldate').each(function () {
                try {
                    var text = $(this).html();
                    var serverDate = new Date(text);
                    serverDate = new Date(serverDate.valueOf() - offsetms);
                    var optionsDate = { weekday: 'long', year: 'long', month: 'long', day: 'numeric' };
                    var optionsTime = { hour: '2 digit', minute: 'numeric', second: 'numeric' };
                    $(this).html(serverDate.toLocaleDateString('en-US', { weekday: 'narrow', year: 'numeric', month: 'narrow', day: 'numeric' }) + " " + serverDate.toLocaleTimeString('en-US', { hour: '2-digit', minute: '2-digit', second: '2-digit', hour12: true }));
                }
                catch (ex) {
                    //SD: Need to log error
                }
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divTest1" runat="server">
        </div>
        <div id="divTest2" runat="server">
        </div>

        <table id="NotificationDetails">

            <tr>
                <td valign='top' width='10%'></td>
                <td width='90%'>
                    <table>
                        <tr>
                            <td class="toLocaldate" style='font-weight: bolder'>8/1/2017 3:55:18 PM</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
