<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SWOTEntry.aspx.cs" MasterPageFile="~/Site.Master" Inherits="FormsAuthAd.Account.SWOTEntry" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="padding-top: 50px; padding-bottom: 50px">
        <div class="form-horizontal">
            <h4>Please enter your SWOT.</h4>
        </div>

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
