<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerifyGRN.aspx.cs" Inherits="PropertyAdmin.VerifyGRN" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="titleSub2">
            <asp:Label ID="Label6" runat="server" Text=" Verify GRN :"></asp:Label></div>
    <asp:GridView ID="GRNApproval" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="label" 
        DataKeyNames="ID" GridLines="Vertical" 
        OnPageIndexChanging="grvSRApproval_PageIndexChanging" 
        OnRowDataBound="grvSRApproval_RowDataBound" PageSize="30" 
        Style="font-size: small" 
        onselectedindexchanged="SRApproval_SelectedIndexChanged">
          <EmptyDataTemplate>
                            <asp:Label ID="lbl" runat="server" Text="No GRN to approve." /></EmptyDataTemplate>
        <Columns>
            <%--<asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="Chkselect" runat="server" AutoPostBack="false" />
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="GRNNo">
                <ItemTemplate>
                    <asp:Label ID="GRNNo" runat="server" Text='<%# Bind("GRNNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField headertext="Item">
                <ItemTemplate>
                    <asp:Label ID="Item" runat="server" Text='<%# Bind("Item") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SupplyCategory">
                <ItemTemplate>
                    <asp:Label ID="SupplyCategory" runat="server" Text='<%# Bind("SupplyCategory") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label ID="Quantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="UnitPrice">
                <ItemTemplate>
                    <asp:Label ID="UnitPrice" runat="server" Text='<%# Bind("UnitPrice") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="InvoiceNo">
                <ItemTemplate>
                    <asp:Label ID="InvoiceNo" runat="server" Text='<%# Bind("InvoiceNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Received By">
                <ItemTemplate>
                    <asp:Label ID="Receivedby" runat="server" Text='<%# Bind("ReceivedBy") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Received Date">
                <ItemTemplate>
                    <asp:Label ID="ReceivedDate" runat="server" Text='<%# Bind("ReceivedDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Verified By">
                <ItemTemplate>
                    <asp:Label ID="lblVerifiedBy" runat="server" Text='<%# Bind("VerifiedBy") %>'></asp:Label>
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
                            <%--<td>
                                                Time
                                            </td>--%>
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
                                <asp:TextBox ID="txtDateTimeRvwrSigned" Width="70px" runat="server" Text='<%# Bind("VerifiedDate") %>'
                                                    ControlToValidate="txtDateTimeRvwrSigned"></asp:TextBox>
                                <%--<asp:Label Width="70px" Visible="false" Text='<%#Bind("GRNCreatedDate") %>' ID="lblGRNCreatedDate"
                                                    runat="server"></asp:Label>
                                <asp:RangeValidator ID="DateRangeValidator" ValidationGroup="Save" Type="Date" ControlToValidate="txtDateTimeRvwrSigned"
                                                    Display="None" ForeColor="Tomato" runat="server" ErrorMessage="Please enter valid date."></asp:RangeValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                                                    TargetControlID="DateRangeValidator">
                                                    </ajaxToolkit:ValidatorCalloutExtender>--%>
                                
                            </td>
                            <%--<td>
                                <asp:TextBox ID="txtTimeRvwrSigned" Width="60px" runat="server" Text='<%# Bind("ApprovedTime") %>'></asp:TextBox>
                            </td>--%>
                        </tr>
                    </table>
                    
                    <%--<ajaxToolkit:MaskedEditExtender ID="EarliestTimeExtender1" runat="server" AcceptAMPM="True"
                                        Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtTimeRvwrSigned">
                                    </ajaxToolkit:MaskedEditExtender>
                    <ajaxToolkit:MaskedEditValidator ID="EarliestTimeValidator1" runat="server" ControlExtender="EarliestTimeExtender1"
                                        ControlToValidate="txtTimeLICSigned" Display="Dynamic" InvalidValueMessage="Please enter a valid time."
                                        SetFocusOnError="True">                                          
                                    </ajaxToolkit:MaskedEditValidator>
                    <ajaxToolkit:ValidatorCalloutExtender ID="EarliestTimeValidator1_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="EarliestTimeValidator1">
                                    </ajaxToolkit:ValidatorCalloutExtender>--%>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderDateTimeLICSigned" runat="server"
                                        Enabled="True" TargetControlID="txtDateTimeRvwrSigned">
                                    </ajaxToolkit:CalendarExtender>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            
            <asp:CommandField SelectText="Approve" ShowSelectButton="True" />

        </Columns>
        
          <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#FBE49F" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#88AB2D" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#e4efd0" />
    </asp:GridView>

    
      <div>
    <asp:Label ID="lblApprovedmsg" runat="server" 
            Text="The SIV is Approved and it is out of UnApproved list now!!" 
            ForeColor="#88AB2D" Visible="False"></asp:Label>
    </div>


</asp:Content>
