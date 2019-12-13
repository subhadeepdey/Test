<%@ Page Title="Menu" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="FDDWeb.Menu" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <hr />
    <p class="text-success">
        <asp:Literal runat="server" ID="SuccessMessage" />
    </p>

    <asp:Repeater ID="CartDetail" runat="server" Visible="<%# !string.IsNullOrEmpty(USERNAME)%>" OnItemDataBound="CartDetailItemDataBound">
        <HeaderTemplate>
            <table class="col-md-12 table-hover">
                <thead class="thead-light">
                    <tr>
                        <th colspan="3">
                            <asp:Label runat="server" CssClass="col-md-2">Orders in your cart:</asp:Label>
                            <hr />
                        </th>
                    </tr>
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
            <tr>
                <td class="table-column">
                    <asp:Label runat="server" CssClass="control-label" ID="Item"></asp:Label>
                </td>
                <td class="table-column">
                    <asp:Label runat="server" CssClass="control-label" ID="Quantity"></asp:Label>
                </td>
                <td class="table-column">
                    <asp:Label runat="server" CssClass="control-label" ID="Price"></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <tr>
                <td colspan="3">
                    <hr />
                    <asp:Button runat="server" Text="Place Order" OnClick="PlaceOrder" />
                    <hr />
                </td>
            </tr>
            </table>
       
        </FooterTemplate>
    </asp:Repeater>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="row">
        <div class="form-group">
            <div class="col-md-2">
                <asp:Label runat="server" AssociatedControlID="Category" CssClass="col-md-2 control-label">Category</asp:Label>
            </div>
            <div class="col-md-2">
                <asp:DropDownList runat="server" ID="Category" AutoPostBack="true" OnSelectedIndexChanged="CategorySelected" CssClass="form-control" DataTextField="Category" DataValueField="ID"></asp:DropDownList>
            </div>
        </div>

        <div class="col-md-12 row">
            <hr />
            <asp:Repeater ID="MenuList" runat="server">
                <HeaderTemplate>
                    <table class="col-md-12 table-hover" style="width: 100%">
                        <thead class="thead-light">
                            <tr>
                                <th class="col-md-2">
                                    <asp:Label runat="server">Category</asp:Label>
                                </th>
                                <th class="col-md-2">
                                    <asp:Label runat="server">Name</asp:Label>
                                </th>
                                <th class="col-md-4">
                                    <asp:Label runat="server">Description</asp:Label>
                                </th>
                                <th class="col-md-2">
                                    <asp:Label runat="server">Price</asp:Label>
                                </th>
                                <th class="col-md-2">Quantity
                                </th>
                                <th class="col-md-2">&nbsp;
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
                                <asp:TextBox ID="Quantity" runat="server" TextMode="Number" Width="50px"></asp:TextBox>
                              
                            </td>
                            <td class="table-column">
                                <asp:Button runat="server" Text="Add To Cart" OnCommand="AddMenuToCart" CausesValidation="false" CommandArgument='<%#Eval("MenuID") %>' />
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
               
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
