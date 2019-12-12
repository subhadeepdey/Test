<%@ Page Title="Manage Order" Language="C#" AutoEventWireup="true" CodeBehind="ManageOrder.aspx.cs" Inherits="FDDWeb.Customer.ManageOrder" MasterPageFile="~/Site.Master" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <div class="form-horizontal">
        <h4>Manage your orders</h4>
        <hr />
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <div class="form-group">
            <h3>Your Orders: </h3>
            <asp:Repeater ID="Orders" runat="server">
                <ItemTemplate>
                    <div class="col-md-10">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Order ID:</asp:Label>
                        <asp:Label runat="server" ID="OrderID" CssClass="col-md-2 control-label"></asp:Label>
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Price: </asp:Label>
                        <asp:Label runat="server" ID="TotalPrice" CssClass="col-md-2 control-label"></asp:Label>

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
                                        <asp:Label runat="server" CssClass="control-label"><%#Eval("Name") %></asp:Label>

                                    </td>
                                    <td class="table-column">
                                        <asp:Label runat="server" CssClass="control-label"><%#Eval("Description") %></asp:Label>

                                    </td>
                                    <td class="table-column">
                                        <asp:Label runat="server" CssClass="control-label"><%#Eval("Price") %></asp:Label>

                                    </td>
                                    <td class="table-column">
                                        <asp:Button runat="server" Text="Delete" OnCommand="DeleteOrder" CausesValidation="false" CommandArgument='<%#Eval("OrderID") %>' />
                                    </td>
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

            <%--<asp:Repeater ID="OrderHistory" runat="server">
                <HeaderTemplate>
                    <table class="col-md-12 table-hover" style="padding: 2px">
                        <thead class="thead-light">
                            <tr>
                                <th>
                                    <asp:Label runat="server" CssClass="col-md-2">Category</asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" CssClass="col-md-2">Name</asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" CssClass="col-md-4">Description</asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" CssClass="col-md-1">Price</asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" CssClass="col-md-1">Remove</asp:Label>
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
                                <asp:Label runat="server" CssClass="control-label"><%#Eval("Name") %></asp:Label>

                            </td>
                            <td class="table-column">
                                <asp:Label runat="server" CssClass="control-label"><%#Eval("Description") %></asp:Label>

                            </td>
                            <td class="table-column">
                                <asp:Label runat="server" CssClass="control-label"><%#Eval("Price") %></asp:Label>

                            </td>
                            <td class="table-column">
                                <asp:Button runat="server" Text="Delete" OnCommand="DeleteOrder" CausesValidation="false" CommandArgument='<%#Eval("OrderID") %>' />
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>--%>
        </div>
    </div>
</asp:Content>
