﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="User_Login_CS.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:Login ID="Login1" runat="server" OnAuthenticate="ValidateUser">
    </asp:Login>
    <hr />
    Username: Admin<br />
    Password: 12345<br />
    Role: Administrator<br />
    <br /><br />
    Username: Mudassar<br />
    Password: 12345<br />
    Role: User
</asp:Content>
