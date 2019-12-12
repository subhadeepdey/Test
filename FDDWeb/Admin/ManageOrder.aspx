<%@ Page Title="Manage Order" Language="C#" AutoEventWireup="true" CodeBehind="ManageOrder.aspx.cs" Inherits="FDDWeb.Admin.ManageOrder" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <div class="form-horizontal">
        <h4>Manage orders</h4>
        <hr />
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <div class="form-group">
            <h3>Orders: </h3>
            <asp:Repeater ID="Orders" runat="server">
                <ItemTemplate>
                    <div class="col-md-10">
                        <div class="col-md-6">
                            <asp:Label runat="server" AssociatedControlID="CustomerName" CssClass="col-md-3 control-label">Placed by: </asp:Label>
                            <asp:Label runat="server" ID="CustomerName" CssClass="col-md-3 control-label"></asp:Label>
                            
                            <asp:Label runat="server" AssociatedControlID="TotalPrice" CssClass="col-md-3 control-label">Price: </asp:Label>
                            <asp:Label runat="server" ID="TotalPrice" CssClass="col-md-3 control-label"></asp:Label>

                            <asp:Button runat="server" Text="Completed" OnCommand="CompleteOrder" CausesValidation="false" CommandArgument='<%#Eval("OrderID") %>' />
                        </div>
                    </div>
                    <asp:Repeater ID="OrderDetail" runat="server">
                        <HeaderTemplate>
                            <table class="col-md-12 table-hover" style="padding: 2px">
                                <thead class="thead-light">
                                    <tr>
                                        <th>
                                            <asp:Label runat="server" CssClass="col-md-2">Item</asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label runat="server" CssClass="col-md-2">Quantity</asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label runat="server" CssClass="col-md-1">Price</asp:Label>
                                        </th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tbody>
                                <tr>
                                    <td class="table-column">
                                        <asp:Label runat="server" CssClass="control-label"><%#Eval("FoodCategory") %></asp:Label>
                                    </td>
                                    <td class="table-column">
                                        <asp:Label runat="server" CssClass="control-label"><%#Eval("Quantity") %></asp:Label>
                                    </td>
                                    <td class="table-column">
                                        <asp:Label runat="server" CssClass="control-label"><%#Eval("Price") %></asp:Label>
                                    </td>
                                    <td class="table-column"></td>
                                </tr>
                            </tbody>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:Repeater>
            <hr />
        </div>
    </div>
</asp:Content>
