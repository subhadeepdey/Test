<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MockUp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="padding-top: 50px; padding-bottom: 50px">
        <div class="form-horizontal">
            <h4>Please select Alert/Notification settings.</h4>
        </div>

        <asp:Repeater ID="rptUserAlert" runat="server">
            <HeaderTemplate>
                <table class="table-striped" style="width: 60%;">
                    <thead>
                        <tr>
                            <th colspan="3">
                                <hr />
                            </th>
                        </tr>
                        <tr class="header">
                            <th>Location</th>
                            <th>Email</th>
                            <th>SMS/Text</th>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="control-label"><%# Eval("LocationName") %>
                        <input type="hidden" id="hdnLocationID" runat="server" value='<%# Eval("LocationID") %>' />
                    </td>
                    <td>
                        <input type="checkbox" id="chkIsEmail" runat="server" checked='<%# Eval("IsEmail") %>' /></td>
                    <td>
                        <input type="checkbox" id="chkIsSMSText" runat="server" checked='<%# Eval("isSMSText") %>' /></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <div style="width: 60%;">
            <hr />
        </div>

        <br />
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Save" CssClass="btn btn-default" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
