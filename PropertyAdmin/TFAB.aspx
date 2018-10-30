<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="TFAB.aspx.cs" Inherits="PropertyAdmin.TFAB" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="Messages.ascx" TagName="Messages" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style4
        {
            height: 38px;
        }
        .style5
        {
            height: 30px;
        }
        /*#MainContent_txtRequestedBy_AutoCompleteExtender_completionListElem
        {
            z-index:100000;
        }*/
        .style7
        {
            height: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="overflow: auto; padding: 5px;">
        <uc1:Messages ID="Messages1" runat="server" />
        <div class="leftContent">
            <div class="titleSub">
                <asp:Label ID="lbl" runat="server" Text=" Temporary Fixed Asset Borrowing"></asp:Label></div>
            <br />
            <div class="content">
                <table border="0"> 
                <tr>
                        <td class="style4">
                            TFABNo
                        </td>
                        <td class="style4">
                              <asp:TextBox ID="txtTFABNo" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTFABNo"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CVs" runat="server" ControlToValidate="txtTFABNo" Display="None"
                                ErrorMessage="Please enter numbers only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Integer" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="CVs_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="CVs">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            Item
                        </td>
                        <td class="style4">
                            <asp:TextBox ID="txtItem" runat="server" Enabled="false">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <%--   <tr>
                        <td class="style5">
                            SNo
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtSNo" runat="server" Enabled="false">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            TagNo
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtTagNo" runat="server" Enabled="false">
                            </asp:TextBox>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="style5">
                            Dispatched From
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtDispatchedFrom" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ControlToValidate="txtDispatchedFrom" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Dispatched To
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtDispatchedTo" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                ControlToValidate="txtDispatchedTo" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Dispatching Date
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtDispatchedDate" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtDispatchedDate_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtDispatchedDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="DateValidator8" runat="server" ErrorMessage="*" ControlToValidate="txtDispatchedDate"
                                Display="Dynamic" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv15" runat="server" Display="None" ErrorMessage="Please enter date only."
                                ForeColor="#CC3300" Operator="DataTypeCheck" Type="Date" ValidationGroup="save"
                                ControlToValidate="txtDispatchedDate"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv15_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv15">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Returning Date
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtReturnDate" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" TargetControlID="txtReturnDate">
                            </asp:CalendarExtender>
                            <%--</asp:RequiredFieldValidator>--%>
                            <asp:CompareValidator ID="Cv7" runat="server" Display="None" ErrorMessage="Please enter date only."
                                ForeColor="#CC3300" Operator="DataTypeCheck" Type="Date" ValidationGroup="save"
                                ControlToValidate="txtReturnDate"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv7_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv7">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Verified By
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtPreparedBy" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" ServiceMethod="GetEmployees"
                                runat="server" DelimiterCharacters="" Enabled="True" ServicePath="" TargetControlID="txtPreparedBy"
                                MinimumPrefixLength="1">
                            </asp:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                ControlToValidate="txtPreparedBy" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Prepared Date
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtPreparedDate" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtPreparedDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                ControlToValidate="txtPreparedDate" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv6" runat="server" Display="None" ErrorMessage="Please enter date only."
                                ForeColor="#CC3300" Operator="DataTypeCheck" Type="Date" ValidationGroup="save"
                                ControlToValidate="txtPreparedDate"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv6_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv6">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Checked By
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtCheckedBy" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="AutoCompleteExtender4" ServiceMethod="GetEmployees"
                                runat="server" DelimiterCharacters="" Enabled="True" ServicePath="" TargetControlID="txtCheckedBy"
                                MinimumPrefixLength="1">
                            </asp:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="txtCheckedByValidator" runat="server" ErrorMessage="*"
                                ControlToValidate="txtCheckedBy" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Checked Date
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtCheckedDate" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtChecked_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtCheckedDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"
                                ControlToValidate="txtCheckedDate" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv16" runat="server" Display="None" ErrorMessage="Please enter date only."
                                ForeColor="#CC3300" Operator="DataTypeCheck" Type="Date" ValidationGroup="save"
                                ControlToValidate="txtCheckedDate"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv16_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv16">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Approved By
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtApprovedBy" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="txtApprovedBy_AutoCompleteExtender" ServiceMethod="GetEmployees"
                                runat="server" DelimiterCharacters="" Enabled="True" ServicePath="" TargetControlID="txtApprovedBy"
                                MinimumPrefixLength="1">
                            </asp:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                ControlToValidate="txtApprovedBy" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Approved Date
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtApprovedDate" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txtApprovedDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                ControlToValidate="txtApprovedDate" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv3" runat="server" Display="None" ErrorMessage="Please enter date only."
                                ForeColor="#CC3300" Operator="DataTypeCheck" Type="Date" ValidationGroup="save"
                                ControlToValidate="txtApprovedDate"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv3_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv3">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Received By
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtReceivedBy" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" ServiceMethod="GetEmployees"
                                runat="server" DelimiterCharacters="" Enabled="True" ServicePath="" TargetControlID="txtReceivedBy"
                                MinimumPrefixLength="1">
                            </asp:AutoCompleteExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Received Date
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtReceivedDate" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" TargetControlID="txtReceivedDate">
                            </asp:CalendarExtender>
                            <asp:CompareValidator ID="Cv4" runat="server" Display="None" ErrorMessage="Please enter date only."
                                ForeColor="#CC3300" Operator="DataTypeCheck" Type="Date" ValidationGroup="save"
                                ControlToValidate="txtReceivedDate"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv4_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv4">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Confirmed By
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtConfirmedBy" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="AutoCompleteExtender3" ServiceMethod="GetEmployees"
                                runat="server" DelimiterCharacters="" Enabled="True" ServicePath="" TargetControlID="txtConfirmedBy"
                                MinimumPrefixLength="1">
                            </asp:AutoCompleteExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Confirmed Date
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtConfirmedDate" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtConfirmedDate_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtConfirmedDate">
                            </asp:CalendarExtender>
                            <asp:CompareValidator ID="Cv5" runat="server" Display="None" ErrorMessage="Please enter date only."
                                ForeColor="#CC3300" Operator="DataTypeCheck" Type="Date" ValidationGroup="save"
                                ControlToValidate="txtConfirmedDate"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv5_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv5">
                            </asp:ValidatorCalloutExtender>
                        </td>
                        <%--  <tr>
                        <td class="style5">
                           Returned Date
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtReturnedDate" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True"
                                TargetControlID="txtReturnedDate">
                            </asp:CalendarExtender>
                        </td>
                    </tr>--%>
                        <tr valign="top">
                            <td>
                                Reason
                            </td>
                            <td>
                                <asp:TextBox ID="txtReason" runat="server" ValidationGroup="btnSave" TextMode="MultiLine">
                                </asp:TextBox>
                            </td>
                        </tr>
                    </tr>
                    <tr>
                        <td class="style5">
                            <asp:CheckBox ID="ckbReturn" runat="server" Text="Retunred" />
                        </td>
                        <td class="style5">
                            &nbsp;
                        </td>
                    </tr>
                    <tr class="style4">
                        <td class="style7">
                        </td>
                        <td class="style7">
                            <asp:Button ID="btnSave" runat="server" Text=" Save " ValidationGroup="save" OnClick="btnSave_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="rightContent">
            <div class="titleSub">
                Search:</div>
            <div class="content">
                <table border="0">
                    <tr>
                        <td>
                            Item Type
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSItemType" runat="server" AutoPostBack="True" Width="140px"
                                OnSelectedIndexChanged="ddlSItemType_SelectedIndexChanged" AppendDataBoundItems="True"
                                ValidationGroup="search">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            Item
                        </td>
                        <td class="style4">
                            <asp:DropDownList ID="ddlSItem" runat="server" Width="140px" AppendDataBoundItems="True"
                                ValidationGroup="search">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            Dispatch Date&nbsp;
                        </td>
                        <td class="style4">
                            <asp:TextBox ID="txtSDispatchingDate" runat="server" Width="65px" ValidationGroup="search"></asp:TextBox>
                            <asp:CalendarExtender ID="txtSDispatchingDate_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtSDispatchingDate">
                            </asp:CalendarExtender>
                            -
                            <asp:TextBox ID="txtSDispatchingDate2" runat="server" Width="65px" ValidationGroup="search"></asp:TextBox>
                            <asp:CalendarExtender ID="txtSDispatchingDate2_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtSDispatchingDate2">
                            </asp:CalendarExtender>
                            <asp:CompareValidator ID="Cv12" runat="server" Display="None" ErrorMessage="Please enter date only."
                                ForeColor="#CC3300" Operator="DataTypeCheck" Type="Date" ValidationGroup="search"
                                ControlToValidate="txtSDispatchingDate"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv12_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv12">
                            </asp:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="Cv13" runat="server" Display="None" ErrorMessage="Please enter date only."
                                ForeColor="#CC3300" Operator="DataTypeCheck" Type="Date" ValidationGroup="search"
                                ControlToValidate="txtSDispatchingDate2"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv13_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv13">
                            </asp:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="Cv14" runat="server" Display="None" ErrorMessage="Date shouldn't be less than the start date"
                                ForeColor="#CC3300" Operator="GreaterThanEqual" Type="Date" ValidationGroup="search"
                                ControlToCompare="txtSDispatchingDate" 
                                ControlToValidate="txtSDispatchingDate2"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv14_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv14">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                        </td>
                        <td class="style4">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                                ValidationGroup="search" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <br />
        <br style="clear: both" />
        <div class="parent">
            <div class="titleSub">
                Search Result:
            </div>
            <div class="content">
                <asp:Label ID="lblSearchMessage" runat="server" Text=""></asp:Label>
                <div style="padding-top: 5px;">
                    <asp:GridView ID="grvBFA" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333"
                        GridLines="None" PageSize="5" AutoGenerateColumns="False" DataKeyNames="ID" OnPageIndexChanging="grvBFA_PageIndexChanging"
                        OnSelectedIndexChanged="grvBFA_SelectedIndexChanged">
                        <EmptyDataTemplate>
                            <asp:Label ID="lbl" runat="server" Text="No data available."></asp:Label>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="false" CommandName="Select"
                                        ImageUrl="~/Images/Editpencil.png" OnClick="btnEdit_Click" Style="height: 16px"
                                        Text="/" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Select"
                                        ImageUrl="~/Images/Delete.png" OnClick="btnDelete_Click" Text="X" />
                                    <asp:ModalPopupExtender ID="btnDelete_ModalPopupExtender" runat="server" DynamicServicePath=""
                                        Enabled="True" TargetControlID="btnDelete" CancelControlID="btnNo" OkControlID="btnYes"
                                        PopupControlID="pnlConfirmation">
                                    </asp:ModalPopupExtender>
                                    <asp:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" ConfirmText=""
                                        Enabled="True" TargetControlID="btnDelete" DisplayModalPopupID="btnDelete_ModalPopupExtender">
                                    </asp:ConfirmButtonExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item">
                                <ItemTemplate>
                                    <asp:Label ID="lblItem" Text='<%# Eval("Item") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="TagNo" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblTagNo" Text='<%# Eval("TagNo") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Disp.From">
                                <ItemTemplate>
                                    <asp:Label ID="lblDispatchedFrom" Text='<%# Eval("DispatchedFrom") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Disp.To">
                                <ItemTemplate>
                                    <asp:Label ID="lblDispatchedTo" Text='<%# Eval("DispatchedTo") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Disp.Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblDispatchingDate" Text='<%# Eval("DispatchingDate") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PreparedBy">
                                <ItemTemplate>
                                    <asp:Label ID="lblPreparedBy" Text='<%# Eval("PreparedBy") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PreparedDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblPreparedDate" Text='<%# Eval("PreparedDate") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CheckedBy">
                                <ItemTemplate>
                                    <asp:Label ID="lblCheckedBy" Text='<%# Eval("CheckedBy") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CheckedDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblCheckedDate" Text='<%# Eval("CheckedDate") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ApprovedBy">
                                <ItemTemplate>
                                    <asp:Label ID="lblApprovedBy" Text='<%# Eval("ApprovedBy") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ApprovedDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblApprovedDate" Text='<%# Eval("ApprovedDate") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Staus" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblStaus" Text='<%# Eval("Status") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:HyperLinkField DataNavigateUrlFields="ID" 
                                DataNavigateUrlFormatString="StoreIssueVoucher.aspx?GRNID={0}" DataTextField="FARNNo" 
                                NavigateUrl="~/StoreIssueVoucher.aspx" />--%>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#89ac2e" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#e4efd0" />
                    </asp:GridView>
                    <br />
                </div>
            </div>
        </div>
    </div>
    <div>
        <asp:Panel ID="pnlConfirmation" runat="server" Style="display: none; width: 300px;
            background-color: White; border-width: 2px; border-color: #A5CBB0; border-style: solid;">
            <div class="formHeader">
                <asp:Label ID="Label2" runat="server" Text="" Style="font-size: medium; font-family: 'Times New Roman', Times, serif;">
                </asp:Label>
            </div>
            <div style="margin: 20px 20px;">
                <asp:Label ID="configmMessage" runat="server" Text="Are you sure , You want to Cancel">
                </asp:Label>
            </div>
            <div>
                <div class="controlContainer" style="margin: 20px 20px;">
                    <div style="width: 30%; float: left">
                        <asp:Button ID="btnYes" runat="server" Text="Yes" Width="60px" />
                    </div>
                    <div style="float: left">
                        <asp:Button ID="btnNo" runat="server" Text="No" Width="60px" />
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
