<%@ Page Title="Menu" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="FDDWeb.Menu" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <hr />
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
                    <table class="table-hovered" style="width: 100%">
                        <thead class="thead-light">
                            <tr>
                                <th>
                                    <asp:Label runat="server" CssClass="col-md-4">Category</asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" CssClass="col-md-2">Name</asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" CssClass="col-md-4">Description</asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" CssClass="col-md-2">Price</asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" CssClass="col-md-2">Add to Cart</asp:Label>
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
                                <asp:TextBox ID="Quantity" runat="server" TextMode="Number" ValidationGroup='<%#Eval("MenuID") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Quantity" ValidationGroup='<%#Eval("MenuID") %>'
                                    CssClass="text-danger" ErrorMessage="The quantity field is required." />
                                <asp:Button runat="server" Text="Add" OnCommand="AddMenu" CausesValidation="false" ValidationGroup='<%#Eval("MenuID") %>' CommandArgument='<%#Eval("MenuID") %>' />
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
