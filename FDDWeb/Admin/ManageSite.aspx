<%@ Page Title="Admin" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="ManageSite.aspx.cs" Inherits="FDDWeb.Admin.ManageSite" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <div class="form-horizontal">
        <h4>Manage FDD Site</h4>
        <hr />
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <div class="form-group">
            <asp:Repeater ID="Users" runat="server">
                <HeaderTemplate>
                    <table class="col-md-12 table-hover" style="padding: 2px">
                        <thead class="thead-light">
                            <tr>
                                <th colspan="3">
                                    <h5>Upgrade Users to Premium</h5>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label runat="server" CssClass="col-md-2">Username</asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" CssClass="col-md-2">Name</asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" CssClass="col-md-1">Premuim</asp:Label>
                                </th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td class="table-column">
                                <asp:Label runat="server" CssClass="control-label"><%#Eval("Username") %></asp:Label>
                            </td>
                            <td class="table-column">
                                <asp:Label runat="server" CssClass="control-label"><%#Eval("Name") %></asp:Label>
                            </td>
                            <td class="table-column">
                                <asp:Button ID="UpgradeUser" runat="server" Text="Upgrade to Premium" OnCommand="UpgradeUser" CommandName="UpgradeUser" CommandArgument='<%#Eval("Username") %>' />
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
               
                </FooterTemplate>
            </asp:Repeater>
        </div>


        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Address" CssClass="col-md-2 control-label">Publishing offer</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="PublishingOffer" CssClass="form-control" TextMode="MultiLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PublishingOffer"
                    CssClass="text-danger" ErrorMessage="The publishing ffer field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="MenuOfTheDay" CssClass="col-md-2 control-label">Menu of the Day</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="MenuOfTheDay" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="MenuOfTheDay"
                    CssClass="text-danger" ErrorMessage="The Menu of the Day field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="MenuOfTheDay" CssClass="col-md-2 control-label">Delivery time</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="DeliveryTime" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DeliveryTime"
                    CssClass="text-danger" ErrorMessage="The Delivery time field is required." />
            </div>
        </div>
    </div>
</asp:Content>
