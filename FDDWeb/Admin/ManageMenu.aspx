<%@ Page Title="Manage Menu" Language="C#" AutoEventWireup="true" CodeBehind="ManageMenu.aspx.cs" Inherits="FDDWeb.Admin.ManageMenu" MasterPageFile="~/Site.Master" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <div class="form-horizontal">
        <h4>Manage Menu Items</h4>
        <hr />
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <div class="form-group">
            <h3>Menu</h3>
            <div class="col-md-3">
                <asp:Label runat="server" AssociatedControlID="Category" CssClass="col-md-2 control-label">Category</asp:Label>
                <asp:DropDownList runat="server" ID="Category" CssClass="form-control" DataTextField="Category" DataValueField="ID"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Category"
                    CssClass="text-danger" ErrorMessage="The name category is required." />
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Name</asp:Label>
                <asp:TextBox runat="server" ID="Name" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                    CssClass="text-danger" ErrorMessage="The name field is required." />
            </div>

            <div class="col-md-3">
                <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-2 control-label">Description</asp:Label>
                <asp:TextBox runat="server" ID="Description" CssClass="form-control" TextMode="MultiLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Description"
                    CssClass="text-danger" ErrorMessage="The description field is required." />
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" AssociatedControlID="Price" CssClass="col-md-2 control-label">Price</asp:Label>
                <asp:TextBox runat="server" ID="Price" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Price"
                    CssClass="text-danger" ErrorMessage="The price field is required." />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="Price"
                    CssClass="text-danger" ErrorMessage="Numbers only allowed e.g. 100 or 100.00" ValidationExpression="^\d+(\.\d\d)?$"></asp:RegularExpressionValidator>

            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" OnClick="AddMenu" Text="Add Menu Item" CssClass="btn btn-default" />
                    <asp:Button runat="server" OnClick="Reset" Text="Reset" CssClass="btn btn-default" />
                </div>
            </div>
            <hr />

            <asp:Repeater ID="Menu" runat="server">
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
                                    <asp:Label runat="server" CssClass="col-md-1">Price($)</asp:Label>
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
                                <asp:Label runat="server" CssClass="control-label"><%# String.Format("{0:C}",Eval("Price")) %></asp:Label>

                            </td>
                            <td class="table-column">
                                <asp:Button runat="server" Text="Delete" OnCommand="DeleteMenu" CausesValidation="false" CommandArgument='<%#Eval("MenuID") %>' />
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
