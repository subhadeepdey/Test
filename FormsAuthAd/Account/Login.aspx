<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FormsAuthAd.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Login ID="loginAD" runat="server" OnLoggingIn="loginAD_LoggingIn"></asp:Login>
    </div>
    </form>
</body>
</html>
