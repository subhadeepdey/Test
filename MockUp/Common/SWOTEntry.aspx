<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SWOTEntry.aspx.cs" Inherits="MockUp.SWOTEntry" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="min-width: 100%!important;">
        <div class="row">
            <div class="col col-md-3 user-input">
                <div class="form-horizontal header-text">
                    <h5><span><b>Select SWOT Group to Update.</b></span></h5>
                </div>
                <hr />
                <div>
                    <div class="row">
                        <div class="col col-md-4 label-text">
                            <b>Group:</b>
                        </div>
                        <div class="col col-md-4  text-left">
                            <asp:DropDownList ID="drpUserGroup1" runat="server" CssClass="control">
                                <asp:ListItem Text="Regulatory" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Market Based" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Service Company" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Threat" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col col-md-4  text-left ">
                            <asp:DropDownList ID="drpUserGroup2" runat="server" CssClass="control">
                                <asp:ListItem Text="Eastern Division" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Mid-Atlantic Division" Value="1"></asp:ListItem>
                                <asp:ListItem Text="CA/HI Company" Value="1"></asp:ListItem>
                                <asp:ListItem Text="MSG" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col col-md-8">
                            &nbsp;
                        </div>
                        <div class="col col-md-4">
                            <asp:DropDownList ID="drpUserGroup3" runat="server" CssClass="control">
                                <asp:ListItem Text="NJ" Value="1"></asp:ListItem>
                                <asp:ListItem Text="NY" Value="1"></asp:ListItem>
                                <asp:ListItem Text="VA" Value="1"></asp:ListItem>
                                <asp:ListItem Text="MD" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col col-md-8  text-left">
                            &nbsp;
                        </div>
                        <div class="col col-md-4  text-left">
                            <asp:Button runat="server" Text="Update" CssClass="btn btn-default control" />
                        </div>
                    </div>
                </div>
                <br />
                <br />
                <div class="form-horizontal header-text">
                    <h5><span><b>SWOT Data Entry</b></span></h5>
                </div>
                <hr />
                <div>
                    <div class="row">
                        <div class="col col-md-4 label-text">
                            <b>SWOT Type: </b>
                        </div>
                        <div class="col col-md-4  text-left">
                            &nbsp;
                        </div>
                        <div class="col col-md-4  text-left ">
                            <asp:DropDownList ID="drpSWOTType" runat="server" CssClass="control">
                                <asp:ListItem Text="Strength" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Weakness" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Opportunity" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Threat" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col text-center">
                            <asp:TextBox ID="txtSWOTDetail" runat="server" TextMode="MultiLine" CssClass="control-center" Columns="10" Rows="3" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col col-md-4 label-text">
                            <b>Strategy:</b>
                        </div>
                        <div class="col col-md-4  text-left">
                            <asp:DropDownList ID="drpStrategy1" runat="server" CssClass="control">
                                <asp:ListItem Text="Safety" Value="1"></asp:ListItem>
                                <asp:ListItem Text="People" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Technology" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Growth" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col col-md-4  text-left ">
                            <asp:DropDownList ID="drpStrategy2" runat="server" CssClass="control">
                                <asp:ListItem Text="Safety" Value="1"></asp:ListItem>
                                <asp:ListItem Text="People" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Technology" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Growth" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col col-md-4 label-text">
                            <b>Group:</b>
                        </div>
                        <div class="col col-md-4  text-left">
                            <asp:DropDownList ID="drpStrategyGroup1" runat="server" CssClass="control">
                                <asp:ListItem Text="Regulatory" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Market Based" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Service Company" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Threat" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col col-md-4  text-left ">
                            <asp:DropDownList ID="drpStrategyGroup2" runat="server" CssClass="control">
                                <asp:ListItem Text="Eastern Division" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Mid-Atlantic Division" Value="1"></asp:ListItem>
                                <asp:ListItem Text="CA/HI Company" Value="1"></asp:ListItem>
                                <asp:ListItem Text="MSG" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col col-md-8">
                            &nbsp;
                        </div>
                        <div class="col col-md-4">
                            <asp:DropDownList ID="drpStrategyGroup3" runat="server" CssClass="control">
                                <asp:ListItem Text="NJ" Value="1"></asp:ListItem>
                                <asp:ListItem Text="NY" Value="1"></asp:ListItem>
                                <asp:ListItem Text="VA" Value="1"></asp:ListItem>
                                <asp:ListItem Text="MD" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col col-md-8  text-left">
                            &nbsp;
                        </div>
                        <div class="col col-md-4  text-left">
                            <asp:Button runat="server" Text="Submit" CssClass="btn btn-default control" />
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                </div>
            </div>
            <div class="col col-md-9 report">
                <table>
                    <tr>
                        <td>
                            <table class="table report-strengths">
                                <thead>
                                    <tr>
                                        <th style="width: 60%"><span>Strength</span></th>
                                        <th style="width: 20%"><span>Strategy</span></th>
                                        <th style="width: 12%"><span>Group</span></th>
                                        <th style="width: 8%">&nbsp;</th>
                                    </tr>
                                </thead>
                                <tr>
                                    <td>
                                        <ul>
                                            <li>Strength ABC</li>
                                        </ul>
                                    </td>
                                    <td>
                                        <div><span>P</span><span>G</span></div>
                                    </td>
                                    <td>
                                        <div><span>NJ</span></div>
                                    </td>
                                    <td>
                                        <div>
                                            <asp:ImageButton ID="ImageButton5" runat="server"
                                                ImageUrl="~/Image/edit.png" />
                                            <asp:ImageButton ID="ImageButton6" runat="server"
                                                ImageUrl="~/Image/delete.png" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ul>
                                            <li>Strength DEF</li>
                                        </ul>
                                    </td>
                                    <td>
                                        <div><span>S</span></div>
                                    </td>
                                    <td>
                                        <div><span>NJ</span></div>
                                    </td>
                                    <td>
                                        <div>
                                            <asp:ImageButton ID="ImageButton2" runat="server"
                                                ImageUrl="~/Image/edit.png" /><asp:ImageButton ID="ImageButton3" runat="server"
                                                    ImageUrl="~/Image/delete.png" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ul>
                                            <li>Long strength example text requiring two lines to presentC</li>
                                        </ul>
                                    </td>
                                    <td>
                                        <div><span>C</span></div>
                                    </td>
                                    <td>
                                        <div><span>NJ</span></div>
                                    </td>
                                    <td>
                                        <div>
                                            <asp:ImageButton ID="ImageButton1" runat="server"
                                                ImageUrl="~/Image/edit.png" /><asp:ImageButton ID="ImageButton4" runat="server"
                                                    ImageUrl="~/Image/delete.png" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ul>
                                            <li>Strength XYZ</li>
                                        </ul>
                                    </td>
                                    <td>
                                        <div><span>T</span><span>G</span></div>
                                    </td>
                                    <td>
                                        <div><span>NJ</span></div>
                                    </td>
                                    <td>
                                        <div>
                                            <asp:ImageButton ID="ImageButton7" runat="server"
                                                ImageUrl="~/Image/edit.png" /><asp:ImageButton ID="ImageButton8" runat="server"
                                                    ImageUrl="~/Image/delete.png" />
                                        </div>
                                    </td>
                                </tr>

                            </table>
                        </td>
                        <td>
                            <table class="table report-weaknesses">
                                <thead>
                                    <tr>
                                        <th style="width: 70%"><span>Weakness</span></th>
                                        <th style="width: 15%"><span>Strategy</span></th>
                                        <th style="width: 8%"><span>Group</span></th>
                                        <th style="width: 7%">&nbsp;</th>
                                    </tr>
                                </thead>
                                <tr>
                                    <td>
                                        <ul>
                                            <li>Weakness ABC</li>
                                        </ul>
                                    </td>
                                    <td>
                                        <div><span>T</span><span>G</span></div>
                                    </td>
                                    <td>
                                        <div><span>NJ</span></div>
                                    </td>
                                    <td>
                                        <div>
                                            <asp:ImageButton ID="ImageButton9" runat="server"
                                                ImageUrl="~/Image/edit.png" /><asp:ImageButton ID="ImageButton10" runat="server"
                                                    ImageUrl="~/Image/delete.png" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ul>
                                            <li>Weakness DEF</li>
                                        </ul>
                                    </td>
                                    <td>
                                        <div><span>C</span></div>
                                    </td>
                                    <td>
                                        <div><span>NJ</span></div>
                                    </td>
                                    <td>
                                        <div>
                                            <asp:ImageButton ID="ImageButton11" runat="server"
                                                ImageUrl="~/Image/edit.png" /><asp:ImageButton ID="ImageButton12" runat="server"
                                                    ImageUrl="~/Image/delete.png" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ul>
                                            <li>Weakness XYZ</li>
                                        </ul>
                                    </td>
                                    <td>
                                        <div><span>C</span></div>
                                    </td>
                                    <td>
                                        <div><span>NJ</span></div>
                                    </td>
                                    <td>
                                        <div>
                                            <asp:ImageButton ID="ImageButton13" runat="server"
                                                ImageUrl="~/Image/edit.png" /><asp:ImageButton ID="ImageButton14" runat="server"
                                                    ImageUrl="~/Image/delete.png" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="table report-opportunities">
                                <thead>
                                    <tr>
                                        <th style="width: 70%"><span>Oppertunities</span></th>
                                        <th style="width: 15%"><span>Strategy</span></th>
                                        <th style="width: 8%"><span>Group</span></th>
                                        <th style="width: 7%">&nbsp;</th>
                                    </tr>
                                </thead>
                                <tr>
                                    <td>
                                        <ul>
                                            <li>Oppertunities ABC</li>
                                        </ul>
                                    </td>
                                    <td>
                                        <div><span>T</span><span>G</span></div>
                                    </td>
                                    <td>
                                        <div><span>NJ</span></div>
                                    </td>
                                    <td>
                                        <div>
                                            <asp:ImageButton ID="ImageButton15" runat="server"
                                                ImageUrl="~/Image/edit.png" /><asp:ImageButton ID="ImageButton16" runat="server"
                                                    ImageUrl="~/Image/delete.png" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ul>
                                            <li>Oppertunities DEF</li>
                                        </ul>
                                    </td>
                                    <td>
                                        <div><span>C</span></div>
                                    </td>
                                    <td>
                                        <div><span>NJ</span></div>
                                    </td>
                                    <td>
                                        <div>
                                            <asp:ImageButton ID="ImageButton17" runat="server"
                                                ImageUrl="~/Image/edit.png" /><asp:ImageButton ID="ImageButton18" runat="server"
                                                    ImageUrl="~/Image/delete.png" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ul>
                                            <li>Oppertunities XYZ</li>
                                        </ul>
                                    </td>
                                    <td>
                                        <div><span>C</span></div>
                                    </td>
                                    <td>
                                        <div><span>NJ</span></div>
                                    </td>
                                    <td>
                                        <div>
                                            <asp:ImageButton ID="ImageButton19" runat="server"
                                                ImageUrl="~/Image/edit.png" /><asp:ImageButton ID="ImageButton20" runat="server"
                                                    ImageUrl="~/Image/delete.png" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table class="table report-threats">
                                <thead>
                                    <tr>
                                        <th style="width: 70%"><span>Threats</span></th>
                                        <th style="width: 15%"><span>Strategy</span></th>
                                        <th style="width: 8%"><span>Group</span></th>
                                        <th style="width: 7%">&nbsp;</th>
                                    </tr>
                                </thead>
                                <tr>
                                    <td>
                                        <ul>
                                            <li>Threat ABC</li>
                                        </ul>
                                    </td>
                                    <td>
                                        <div><span>T</span><span>G</span></div>
                                    </td>
                                    <td>
                                        <div><span>NJ</span></div>
                                    </td>
                                    <td>
                                        <div>
                                            <asp:ImageButton ID="ImageButton21" runat="server"
                                                ImageUrl="~/Image/edit.png" /><asp:ImageButton ID="ImageButton22" runat="server"
                                                    ImageUrl="~/Image/delete.png" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ul>
                                            <li>Threat DEF</li>
                                        </ul>
                                    </td>
                                    <td>
                                        <div><span>C</span></div>
                                    </td>
                                    <td>
                                        <div><span>NJ</span></div>
                                    </td>
                                    <td>
                                        <div>
                                            <asp:ImageButton ID="ImageButton23" runat="server"
                                                ImageUrl="~/Image/edit.png" /><asp:ImageButton ID="ImageButton24" runat="server"
                                                    ImageUrl="~/Image/delete.png" />
                                        </div>
                                    </td>
                                </tr>

                            </table>
                        </td>
                    </tr>
                </table>

            </div>
        </div>
    </div>
</asp:Content>
