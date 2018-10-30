<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveFAIV.aspx.cs" Inherits="PropertyAdmin.ApproveFAIV" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="titleSub2">
            <asp:Label ID="Label6" runat="server" Text=" Approve Fixed Asset Issue Voucher :"></asp:Label></div>
    <asp:GridView ID="FAIVApproval" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="label" 
        DataKeyNames="ID" GridLines="Vertical" 
        OnPageIndexChanging="grvSRApproval_PageIndexChanging" 
        OnRowDataBound="grvSRApproval_RowDataBound" PageSize="30" 
        Style="font-size: small" 
    onselectedindexchanged="SRApproval_SelectedIndexChanged">
          <EmptyDataTemplate>
                            <asp:Label ID="lbl" runat="server" Text="No FAIV to approve." /></EmptyDataTemplate>
        <Columns>
            <%--<asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="Chkselect" runat="server" AutoPostBack="false" />
                </ItemTemplate>
            </asp:TemplateField>--%>


            <asp:TemplateField HeaderText="FAIVNo">
                <ItemTemplate>
                    <asp:Label ID="FAIVNo" runat="server" Text='<%# Bind("FAIVNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SRNo">
                <ItemTemplate>
                    <asp:Label ID="SRNo" runat="server" Text='<%# Bind("SRNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Work Unit">
                <ItemTemplate>
                    <asp:Label ID="WorkUnit" runat="server" Text='<%# Bind("WorkUnit") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Item">
                <ItemTemplate>
                    <asp:Label ID="Item" runat="server" Text='<%# Bind("Item") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Issued By">
                <ItemTemplate>
                    <asp:Label ID="IssuedBy" runat="server" Text='<%# Bind("IssuedBy") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Issued To">
                <ItemTemplate>
                    <asp:Label ID="IssuedTo" runat="server" Text='<%# Bind("IssuedTo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="Requested Date">
                <ItemTemplate>
                    <asp:Label ID="RequestedDate" runat="server" Text='<%# Bind("RequestedDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Issued Date">
                <ItemTemplate>
                    <asp:Label ID="IssuedDate" runat="server" Text='<%# Bind("IssuedDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Approved By">
                <ItemTemplate>
                    <asp:Label ID="ApprovedBy" runat="server" Text='<%# Bind("ApprovedBy") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="DateTimeRvwerSigned" HeaderText="Approver Signed">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                                Status
                                            </td>
                            <td>
                                                Date
                                            </td>
                          <%--  <td>
                                                Time
                                            </td>--%>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="drpApprStatus" Width="70px" runat="server">
                                    <%-- <asp:ListItem Text="Select" Value=""> </asp:ListItem>--%>
                                    <asp:ListItem Text="Accept" Value="1"> </asp:ListItem>
                                    <asp:ListItem Text="Reject" Value="2"> </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDateTimeApprSigned" Width="70px" runat="server" Text='<%# Bind("ApprovedDate") %>'
                                                    ControlToValidate="txtDateTimeApprSigned"></asp:TextBox>
                               <%-- <asp:Label Width="70px" Visible="false" Text='<%#Bind("GRNCreatedDate") %>' ID="lblGRNCreatedDate"
                                                    runat="server"></asp:Label>--%>
                              <%--  <asp:RangeValidator ID="DateRangeValidator" Type="Date" ControlToValidate="txtDateTimeRvwrSigned"
                                                    Display="None" ForeColor="Tomato" runat="server" ErrorMessage="Please enter valid date."></asp:RangeValidator>
                               <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                                                    TargetControlID="DateRangeValidator">
                                </ajaxToolkit:ValidatorCalloutExtender> --%>
                            </td>
                            <%--<td>
                                <asp:TextBox ID="txtTimeRvwrSigned" Width="60px" runat="server" Text='<%# Bind("ApprovedTime") %>'></asp:TextBox>
                            </td>--%>
                        </tr>
                    </table>
                    
                    <%--<ajaxToolkit:MaskedEditExtender ID="EarliestTimeExtender1" runat="server" AcceptAMPM="True"
                                        Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtDateTimeRvwrSigned">
                                    </ajaxToolkit:MaskedEditExtender>
                    <ajaxToolkit:MaskedEditValidator ID="EarliestTimeValidator1" runat="server" ControlExtender="EarliestTimeExtender1"
                                        ControlToValidate="txtDateTimeRvwrSigned" Display="Dynamic" InvalidValueMessage="Please enter a valid time."
                                        SetFocusOnError="True">                                          
                                    </ajaxToolkit:MaskedEditValidator>
                    <ajaxToolkit:ValidatorCalloutExtender ID="EarliestTimeValidator1_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="EarliestTimeValidator1">
                                    </ajaxToolkit:ValidatorCalloutExtender>--%>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderDateTimeLICSigned" runat="server"
                                        Enabled="True" TargetControlID="txtDateTimeApprSigned">
                                    </ajaxToolkit:CalendarExtender>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
         <%--   <asp:TemplateField HeaderText="LICStatus" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblLICStatus" runat="server" Text='<%# Bind("LICStatus") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>

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
            Text="The FAIV is Approved and it is out of UnApproved list now!!" 
            ForeColor="#88AB2D" Visible="False"></asp:Label>
    </div>
</asp:Content>
