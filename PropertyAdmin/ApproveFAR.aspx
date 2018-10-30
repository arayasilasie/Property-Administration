<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveFAR.aspx.cs" Inherits="PropertyAdmin.ApproveFAR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="titleSub2">
            <asp:Label ID="Label6" runat="server" Text=" Approve FAR"></asp:Label></div>
    <asp:GridView ID="FAApproval" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="label" 
        DataKeyNames="ID" GridLines="Vertical" 
        OnPageIndexChanging="grvGRNApproval_PageIndexChanging" 
        OnRowDataBound="grvGRNApproval_RowDataBound" PageSize="30" 
        Style="font-size: small" 
        onselectedindexchanged="SRApproval_SelectedIndexChanged">
        <Columns>
        <%--<asp:TemplateField HeaderText="Select">
            <ItemTemplate>
           <asp:CheckBox ID="Chkselect" runat="server" AutoPostBack="false" />
           </ItemTemplate>
                  </asp:TemplateField>--%>

                  <asp:TemplateField HeaderText="FARNNo">
                                <ItemTemplate>
                                    <asp:Label ID="FARNNo" runat="server" Text='<%# Bind("FARNNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField FooterText="Item">
                                <ItemTemplate>
                                    <asp:Label ID="Item" runat="server" Text='<%# Bind("Item") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="SNo">
                                <ItemTemplate>
                                    <asp:Label ID="SNo" runat="server" Text='<%# Bind("SNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Model">
                                <ItemTemplate>
                                    <asp:Label ID="Model" runat="server" Text='<%# Bind("Model") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TagNo">
                                <ItemTemplate>
                                    <asp:Label ID="TagNo" runat="server" Text='<%# Bind("TagNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cost">
                                <ItemTemplate>
                                    <asp:Label ID="Cost" runat="server" Text='<%# Bind("Cost") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Reviewed By">
                                <ItemTemplate>
                                    <asp:Label ID="lblRvedby" runat="server" Text='<%# Bind("RvwdBy") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="DateTimeRvwerSigned" HeaderText="Reviewer Signed">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                Status
                                            </td>
                                            <td>
                                                Date
                                            </td>
                                            <td>
                                                Time
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="drpRvwrStatus" Width="70px" runat="server">
                                                    <%-- <asp:ListItem Text="Select" Value=""> </asp:ListItem>--%>
                                                    <asp:ListItem Text="Accept" Value="1"> </asp:ListItem>
                                                    <asp:ListItem Text="Reject" Value="2"> </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDateTimeRvwrSigned" Width="70px" runat="server" Text='<%# Bind("ApprovedDateTime") %>'
                                                    ControlToValidate="txtDateTimeRvwrSigned"></asp:TextBox>
                                                <asp:Label Width="70px" Visible="false" Text='<%#Bind("GRNCreatedDate") %>' ID="lblGRNCreatedDate"
                                                    runat="server"></asp:Label>
                                                <asp:RangeValidator ID="DateRangeValidator" ValidationGroup="Save" Type="Date" ControlToValidate="txtDateTimeRvwrSigned"
                                                    Display="None" ForeColor="Tomato" runat="server" ErrorMessage="Please enter valid date."></asp:RangeValidator>
                                                <%--<ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                                                    TargetControlID="DateRangeValidator">
                                                </ajaxToolkit:ValidatorCalloutExtender>--%>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTimeRvwrSigned" Width="60px" runat="server" Text='<%# Bind("ApprovedTime") %>'></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <ajaxToolkit:MaskedEditExtender ID="EarliestTimeExtender1" runat="server" AcceptAMPM="True"
                                        Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtTimeRvwrSigned">
                                    </ajaxToolkit:MaskedEditExtender>
                                    <ajaxToolkit:MaskedEditValidator ID="EarliestTimeValidator1" runat="server" ControlExtender="EarliestTimeExtender1"
                                        ControlToValidate="txtTimeLICSigned" Display="Dynamic" InvalidValueMessage="Please enter a valid time."
                                        SetFocusOnError="True">                                          
                                    </ajaxToolkit:MaskedEditValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="EarliestTimeValidator1_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="EarliestTimeValidator1">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderDateTimeLICSigned" runat="server"
                                        Enabled="True" TargetControlID="txtDateTimeLICSigned">
                                    </ajaxToolkit:CalendarExtender>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LICStatus" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblLICStatus" runat="server" Text='<%# Bind("LICStatus") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
            <asp:CommandField SelectText="Approve" ShowSelectButton="True" />
        </Columns>
        
          <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#FBE49F" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#88AB2D" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#e4efd0" />
    </asp:GridView>
</asp:Content>
