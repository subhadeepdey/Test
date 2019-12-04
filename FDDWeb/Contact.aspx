<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="FDDWeb.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="row">
        <div class="col-md-4">
            <h4>We are available at -</h4>
            <address>
                FDD Way<br />
                Redmond, UT 99999-9999<br />
                <abbr title="Phone">P:</abbr>
                800.500.1234
            </address>
        </div>
        <div class="col-md-4">
            <h4 class="h4">Hours of Operation</h4>
            <table border="0">
                <tbody>
                    <tr>
                        <td><b>Monday</b></td>
                        <td>:</td>
                        <td>11:00 AM - 02:30 PM<br>
                            05:00 PM - 10:00 PM<br>
                        </td>
                    </tr>
                    <tr>
                        <td><b>Tuesday</b></td>
                        <td>:</td>
                        <td>11:00 AM - 02:30 PM<br>
                            05:00 PM - 10:00 PM<br>
                        </td>
                    </tr>
                    <tr>
                        <td><b>Wednesday</b></td>
                        <td>:</td>
                        <td>11:00 AM - 02:30 PM<br>
                            05:00 PM - 10:00 PM<br>
                        </td>
                    </tr>
                    <tr>
                        <td><b>Thursday</b></td>
                        <td>:</td>
                        <td>11:00 AM - 02:30 PM<br>
                            05:00 PM - 10:00 PM<br>
                        </td>
                    </tr>
                    <tr>
                        <td><b>Friday</b></td>
                        <td>:</td>
                        <td>11:00 AM - 02:30 PM<br>
                            05:00 PM - 10:30 PM<br>
                        </td>
                    </tr>
                    <tr>
                        <td><b>Saturday</b></td>
                        <td>:</td>
                        <td>11:00 AM - 03:00 PM<br>
                            05:00 PM - 10:30 PM<br>
                        </td>
                    </tr>
                    <tr>
                        <td><b>Sunday</b></td>
                        <td>:</td>
                        <td>11:00 AM - 03:00 PM<br>
                            05:00 PM - 09:30 PM<br>
                        </td>
                    </tr>
                </tbody>
            </table>
            <br>
        </div>
        <div class="col-md-4">
            <address>
                <strong>E-Mail:</strong>   <a href="mailto:contact@fdd.com">contact@fdd.com</a><br />
            </address>
        </div>
    </div>
</asp:Content>
