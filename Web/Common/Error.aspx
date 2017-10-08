<%@ Page Title="Error" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Error.aspx.cs" Inherits="Web.Error" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-8 text-danger" style="height: 400px">
            <h4>OOPS! Error occurred. Please contact System Administrator.
                Error ID: <asp:Label ID="lblErrorID" runat="server"></asp:Label>
            </h4>
        </div>
    </div>
</asp:Content>
