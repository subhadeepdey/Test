<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FDDWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>FDD</h1>
        <p>Enjoy on what you are paying.</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h3>Offer!!!<asp:Label ID="PublishingOffer" runat="server"></asp:Label></h3>
            
        </div>
        <div class="col-md-4">
            <h3>Best Indian food online. Promise on quality by
                <asp:Label ID="DeliveryTime" runat="server"></asp:Label></h3>
        </div>
        <div class="col-md-4">
            <h3>Menu of the Day</h3>
            <h4>Try our best and special menu today<asp:Label ID="MenuOfTheDay" runat="server"></asp:Label></h4>

        </div>
    </div>
</asp:Content>
