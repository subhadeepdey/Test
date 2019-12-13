﻿<%@ Page Title="Manage Order" Language="C#" AutoEventWireup="true" CodeBehind="ManageOrder.aspx.cs" Inherits="FDDWeb.Admin.ManageOrder" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <div class="form-horizontal">
        <h4>Manage orders</h4>
        <hr />
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <div class="form-group">
            <asp:Repeater ID="Orders" runat="server" OnItemDataBound="OrdersItemDataBound">
                <HeaderTemplate>
                    <table class="col-md-12 table-hover">
                        <thead class="thead-light">
                            <tr>
                                <th>
                                    <asp:Label runat="server" CssClass="col-md-2">Name</asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" CssClass="col-md-2">Items(Quantity)</asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" CssClass="col-md-2">Date</asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" CssClass="col-md-1">Price($)</asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" CssClass="col-md-1">Status</asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" CssClass="col-md-1">Approve/Cancel</asp:Label>
                                </th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="table-column">
                            <asp:Label runat="server" CssClass="control-label" ID="Name"></asp:Label>
                        </td>
                        <td class="table-column">
                            <asp:Label runat="server" CssClass="control-label" ID="Items"></asp:Label>
                        </td>
                        <td class="table-column">
                            <asp:Label runat="server" CssClass="control-label" ID="OrderDate"></asp:Label>
                        </td>
                        <td class="table-column">
                            <asp:Label runat="server" CssClass="control-label" ID="TotalPrice"></asp:Label>
                        </td>
                        <td class="table-column">
                            <asp:Label runat="server" CssClass="control-label" ID="Status"><%#Eval("OrderStatus") %></asp:Label>
                        </td>
                        <td class="table-column">
                            <asp:Button ID="Approve" runat="server" Text="Approve" OnCommand="UpdateOrderStatus" CommandName="Approved" CommandArgument='<%#Eval("ID") %>' />
                            <asp:Button ID="Cancel" runat="server" Text="Cancel" OnCommand="UpdateOrderStatus" CommandName="Canceled" CommandArgument='<%#Eval("ID") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr>
                        <td colspan="4">
                            <hr />
                        </td>
                    </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <hr />
        </div>
    </div>
</asp:Content>