<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FAIV.aspx.cs" Inherits="PropertyAdmin.FAIV" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="Messages.ascx" TagName="Messages" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .accordionHeader
        {
            background-image: url('Images/search-add-icon.png');
            width: 32px;
            height: 32px;
        }
        
        .accordionHeaderSelected
        {
            background-image: url('Images/search-remove-icon.png');
            width: 32px;
            height: 32px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="overflow: auto; padding: 5px;">
        <uc1:Messages ID="Messages1" runat="server" />
        <%--      </Content>
                </asp:AccordionPane>
            </Panes>
        </asp:Accordion>--%>

         <asp:Accordion ID="Accordion1" SuppressHeaderPostbacks="true" runat="server" FramesPerSecond="40"
            RequireOpenedPane="false" TransitionDuration="250" SelectedIndex="-1" HeaderCssClass="accordionHeader"
            HeaderSelectedCssClass="accordionHeaderSelected">

          <Panes>

                <asp:AccordionPane ID="AccordionPane1" runat="server">
                    <Header>
                    </Header>
                    <Content>
        <asp:Panel ID="PanelSearch3" runat="server">
            <fieldset style="border: 1px solid #FDBF12;">
                <div class="titleSub3">
                    <asp:Label ID="Label01" runat="server" Text="Search:"></asp:Label></div>
                <div id="Div1" class="form" style="float: left; margin-right: 35px; margin-top: 0;
                    margin-bottom: 10px">
                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                        <div class="leftControl">
                            <asp:Label ID="Label18" runat="server" Text="Work Unit"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:DropDownList ID="ddlSWorkUnit" runat="server" Width="140px" AppendDataBoundItems="True"
                                ValidationGroup="search">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                        <div class="leftControl">
                            <asp:Label ID="Label19" runat="server" Text="Issued To"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtSIssuedTo" runat="server" ValidationGroup="save"> </asp:TextBox>
                            <asp:AutoCompleteExtender ID="txtSIssuedTo_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                Enabled="True" MinimumPrefixLength="1" ServicePath="" TargetControlID="txtSIssuedTo"
                                UseContextKey="True" ServiceMethod="GetEmployees">
                            </asp:AutoCompleteExtender>
                        </div>
                    </div>
                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                        <div class="leftControl">
                            <asp:Label ID="Label20" runat="server" Text="Issued Date"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtSIssueDate" runat="server" ValidationGroup="search" Width="65px"> </asp:TextBox>
                            <asp:CalendarExtender ID="txtSIssueDate_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtSIssueDate">
                            </asp:CalendarExtender>
                            -
                            <asp:TextBox ID="txtSIssueDate2" runat="server" ValidationGroup="search" Width="65px"> </asp:TextBox>
                            <asp:CalendarExtender ID="txtSIssueDate2_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtSIssueDate2">
                            </asp:CalendarExtender>
                            <asp:CompareValidator ID="Cv13" runat="server" ControlToCompare="txtSIssueDate" ControlToValidate="txtSIssueDate2"
                                Display="None" ErrorMessage="Date shouldn't be less than the start date" ForeColor="#CC3300"
                                Operator="GreaterThanEqual" Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv12_ValidatorCalloutExtender0" runat="server"
                                Enabled="True" TargetControlID="Cv12">
                            </asp:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="Cv14" runat="server" ControlToValidate="txtSIssueDate"
                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv10_ValidatorCalloutExtender0" runat="server"
                                Enabled="True" TargetControlID="Cv10">
                            </asp:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="Cv15" runat="server" ControlToValidate="txtSIssueDate2"
                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv11_ValidatorCalloutExtender0" runat="server"
                                Enabled="True" TargetControlID="Cv11">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                        <div class="leftControl">
                        </div>
                        <div class="rightControl">
                        </div>
                    </div>
                </div>
                <div id="Div2" class="form" style="float: left; margin-bottom: 10px;">
                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                        <div class="leftControl">
                            <asp:Label ID="Label21" runat="server" Text="Item Type "></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:DropDownList ID="ddlSItemType" runat="server" AutoPostBack="True" Width="140px"
                                OnSelectedIndexChanged="ddlSItemType_SelectedIndexChanged" AppendDataBoundItems="True"
                                ValidationGroup="search">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                        <div class="leftControl">
                            <asp:Label ID="Label22" runat="server" Text="Item "></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:DropDownList ID="ddlSItem" runat="server" Width="140px" AppendDataBoundItems="True"
                                ValidationGroup="search">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                        <div class="leftControl">
                            <asp:Label ID="Label23" runat="server" Text="Approved Date"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtSApproveDate" runat="server" ValidationGroup="search" Width="65px"> </asp:TextBox>
                            <asp:CalendarExtender ID="txtSApproveDate_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtSApproveDate">
                            </asp:CalendarExtender>
                            -
                            <asp:TextBox ID="txtSApproveDate2" runat="server" ValidationGroup="search" Width="65px"> </asp:TextBox>
                            <asp:CalendarExtender ID="txtSApproveDate2_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtSApproveDate2">
                            </asp:CalendarExtender>
                            <asp:CompareValidator ID="Cv12" runat="server" ControlToCompare="txtSApproveDate"
                                ControlToValidate="txtSApproveDate2" Display="None" ErrorMessage="Date shouldn't be less than the start date"
                                ForeColor="#CC3300" Operator="GreaterThanEqual" Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv12_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv12">
                            </asp:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="Cv10" runat="server" ControlToValidate="txtSApproveDate"
                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv10_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv10">
                            </asp:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="Cv11" runat="server" ControlToValidate="txtSApproveDate2"
                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv11_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv11">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                        <div class="leftControl">
                        </div>
                        <div class="rightControl" style="float: right;">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn" OnClick="btnSearch_Click"
                                ValidationGroup="search" />
                        </div>
                    </div>
                </div>
                <div style="clear: both; margin: 1px;">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <div style="padding-top: 5px;">
                        <asp:Label ID="lblSearchMessage" runat="server" Text=""></asp:Label>
                        <div style="padding-top: 5px;">
                            <asp:GridView ID="grvFAIV" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333"
                                GridLines="None" PageSize="5" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="grvFAIV_SelectedIndexChanged"
                                OnPageIndexChanging="grvFAIV_PageIndexChanging" OnRowDataBound="grvFAIV_RowDataBound">
                                <EmptyDataTemplate>
                                    <asp:Label ID="lbl" runat="server" Text="No data available."></asp:Label>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="false" CommandName="Select"
                                                ImageUrl="~/Images/Editpencil.png" OnClick="btnEdit_Click" Text="/" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Select"
                                                ImageUrl="~/Images/Delete.png" OnClick="btnDelete_Click" Text="X" />
                                            <asp:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" ConfirmText=""
                                                Enabled="True" TargetControlID="btnDelete" DisplayModalPopupID="btnDelete_ModalPopupExtender">
                                            </asp:ConfirmButtonExtender>
                                            <asp:ModalPopupExtender ID="btnDelete_ModalPopupExtender" runat="server" DynamicServicePath=""
                                                Enabled="True" TargetControlID="btnDelete" OkControlID="btnYes" CancelControlID="btnNo"
                                                PopupControlID="pnlConfirmation">
                                            </asp:ModalPopupExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="WorkUnit">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWorkUnit" Text='<%# Eval("WorkUnit") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItem" Text='<%# Eval("Item") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RequestedQty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRequestedQuantity" Text='<%# Eval("RequestedQuantity") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IssuedQty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIssuedQuantity" Text='<%# Eval("IssuedQuantity") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UnitPrice">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitPrice" Text='<%# Eval("UnitPrice") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IssuedBy">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIssuedBy" Text='<%# Eval("IssuedBy") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IssuedTo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIssuedTo" Text='<%# Eval("IssuedTo") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IssuedDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIssuedDate" Text='<%# Eval("IssuedDate") %>' runat="server"></asp:Label>
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
                                    <asp:TemplateField HeaderText="PropertyType" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPropertyType" Text='<%# Eval("PropertyType") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRMID" Text='<%# Eval("RMID") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRMStatus" Text='<%# Eval("RMStatus") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:HyperLinkField DataNavigateUrlFields="ID" HeaderText="RMRN" DataNavigateUrlFormatString="RMRN.aspx?FAIVID={0}"
                                        DataTextField="FAIVNo" NavigateUrl="~/RMRN.aspx" />
                                </Columns>
                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#89ac2e" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="#e4efd0" />
                            </asp:GridView>
                        </div>
                    </div>
            </fieldset>
        </asp:Panel>

                          </Content>
                </asp:AccordionPane>
           </Panes>
        </asp:Accordion>

       <%--    --%>
        <div class="titleSub2">
            <asp:Label ID="lblHeader" runat="server" Text="Fixed Asset Issue Voucher"></asp:Label></div>
        <div id="MainForm">
            <div>
                <div id="LeftForm" class="form2">
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label17" runat="server" Text="FAIVNo"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtFAIVNo" runat="server" ValidationGroup="save"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFAIVNo"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CVs" runat="server" ControlToValidate="txtFAIVNo" Display="None"
                                ErrorMessage="Please enter numbers only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Integer" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="CVs_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="CVs">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <%--  --%>
                    <%--<div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label4" runat="server" Text="Work Unit"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:DropDownList ID="ddlWorkUnit" runat="server" AppendDataBoundItems="True" ValidationGroup="save"
                                Width="140px">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlWorkUnit"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save"> </asp:RequiredFieldValidator>
                        </div>
                    </div>--%>


                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label4" runat="server" Text="Division"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:DropDownList ID="ddldivision" AutoPostBack="true" runat="server" AppendDataBoundItems="True" ValidationGroup="save"
                                Width="140px" onselectedindexchanged="ddldivision_SelectedIndexChanged">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlWorkUnit"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label3" runat="server" Text="Work Unit"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:DropDownList ID="ddlWorkUnit" runat="server" AppendDataBoundItems="True" ValidationGroup="save"
                                Width="140px">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlWorkUnit"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>


                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label15" runat="server" Text="Item Type "></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:DropDownList ID="ddlItemType" runat="server" AutoPostBack="True" Width="140px"
                                OnSelectedIndexChanged="ddItemType_SelectedIndexChanged" AppendDataBoundItems="True"
                                ValidationGroup="save">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label14" runat="server" Text="Item"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:DropDownList ID="ddlItem" runat="server" Width="140px" AppendDataBoundItems="True"
                                ValidationGroup="save">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                ControlToValidate="ddlItem" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="save"> </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%-- --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label5" runat="server" Text="Requested Quantity"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtReqQuantity" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtReqQuantity"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv1" runat="server" ControlToValidate="txtReqQuantity"
                                Display="None" ErrorMessage="Please enter numbers only." ForeColor="#CC3300"
                                Operator="DataTypeCheck" Type="Double" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv1_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv1">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <%-- --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label6" runat="server" Text="Issued Quantity"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtIssuedQuantity" runat="server" ValidationGroup="save"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="IssuedQuantityValidator6" runat="server" ControlToValidate="txtIssuedQuantity"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save"> </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv2" runat="server" ControlToValidate="txtIssuedQuantity"
                                Display="None" ErrorMessage="Please enter numbers only." ForeColor="#CC3300"
                                Operator="DataTypeCheck" Type="Double" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv2_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv2">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <%-- --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label7" runat="server" Text="Unit Price "></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtUnitPrice" runat="server" ValidationGroup="save"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtUnitPriceValidator6" runat="server" ControlToValidate="txtUnitPrice"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save"> </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv3" runat="server" ControlToValidate="txtUnitPrice" Display="None"
                                ErrorMessage="Please enter numbers only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Currency" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv3_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv3">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                </div>
                <div id="RightForm" class="form2">
                    <%--<asp:Button ID="Button1" runat="server" Text="Add Stack" OnClick="btnSave_Click"
                            BorderStyle="None" CssClass="style1" ForeColor="White" BackColor="#88AB2D" ValidationGroup="Save" />--%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label8" runat="server" Text="Issued By "></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtIssuedBy" runat="server" ValidationGroup="save"> </asp:TextBox>
                            <asp:AutoCompleteExtender ID="txtIssuedBy_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                Enabled="True" MinimumPrefixLength="1" ServicePath="" TargetControlID="txtIssuedBy"
                                UseContextKey="True" ServiceMethod="GetEmployees">
                            </asp:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                ControlToValidate="txtIssuedBy" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="save"> </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%--<asp:Button ID="Button1" runat="server" Text="Add Stack" OnClick="btnSave_Click"
                            BorderStyle="None" CssClass="style1" ForeColor="White" BackColor="#88AB2D" ValidationGroup="Save" />--%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label9" runat="server" Text="Issued Date"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtIssuedDate" runat="server" ValidationGroup="save"> </asp:TextBox>
                            <asp:CalendarExtender ID="txtIssuedDate_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtIssuedDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtIssuedDate"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save"> </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv8" runat="server" ControlToValidate="txtIssuedDate" Display="None"
                                ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv8_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv8">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <%--<asp:Button ID="Button1" runat="server" Text="Add Stack" OnClick="btnSave_Click"
                            BorderStyle="None" CssClass="style1" ForeColor="White" BackColor="#88AB2D" ValidationGroup="Save" />--%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label10" runat="server" Text="Issued To"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <%--<asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
                                TargetControlID="Cv5">
                            </asp:ValidatorCalloutExtender>--%>
                            <asp:TextBox ID="txtIssuedTo" runat="server" ValidationGroup="save"> </asp:TextBox>
                            <asp:AutoCompleteExtender ID="txtIssuedTo_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                Enabled="True" MinimumPrefixLength="1" ServiceMethod="GetEmployees" ServicePath=""
                                TargetControlID="txtIssuedTo" UseContextKey="True">
                            </asp:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="txtIssuedToValidator7" runat="server" ControlToValidate="txtIssuedTo"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save"> </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%--<asp:Button ID="Button1" runat="server" Text="Add Stack" OnClick="btnSave_Click"
                            BorderStyle="None" CssClass="style1" ForeColor="White" BackColor="#88AB2D" ValidationGroup="Save" />--%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label24" runat="server" Text="Approved By "></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtApprovedBy" runat="server" ValidationGroup="save"> </asp:TextBox>
                            <asp:AutoCompleteExtender ID="txtApprovedBy_AutoCompleteExtender" runat="server"
                                DelimiterCharacters="" Enabled="True" MinimumPrefixLength="1" ServiceMethod="GetEmployees"
                                ServicePath="" TargetControlID="txtApprovedBy">
                            </asp:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtApprovedBy"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save"> </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%--<asp:Button ID="Button1" runat="server" Text="Add Stack" OnClick="btnSave_Click"
                            BorderStyle="None" CssClass="style1" ForeColor="White" BackColor="#88AB2D" ValidationGroup="Save" />--%>
                    <%--<div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label13" runat="server" Text="Approved Date "></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtApprovedDate" runat="server" ValidationGroup="save"> </asp:TextBox>
                            <asp:CalendarExtender ID="txtApprovedDate_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtApprovedDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtApprovedDate"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save"> </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv9" runat="server" ControlToValidate="txtApprovedDate"
                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv9_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv9">
                            </asp:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="Cv5" runat="server" ControlToCompare="txtIssuedDate" ControlToValidate="txtApprovedDate"
                                Display="None" ErrorMessage="Approved Date shouldn't be less than issued date"
                                ForeColor="#CC3300" Operator="GreaterThanEqual" Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv5_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv5">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>--%>
                    <%--<asp:Button ID="Button1" runat="server" Text="Add Stack" OnClick="btnSave_Click"
                            BorderStyle="None" CssClass="style1" ForeColor="White" BackColor="#88AB2D" ValidationGroup="Save" />--%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label12" runat="server" Text="Remark"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtRemark" runat="server" ValidationGroup="save" TextMode="MultiLine"> </asp:TextBox>
                        </div>
                    </div>
                    <%--<asp:Button ID="Button1" runat="server" Text="Add Stack" OnClick="btnSave_Click"
                            BorderStyle="None" CssClass="style1" ForeColor="White" BackColor="#88AB2D" ValidationGroup="Save" />--%>
                    <div style="clear: both; margin-bottom: 10px; width: 100%" align="center">
                        <%--<asp:Button ID="Button1" runat="server" Text="Add Stack" OnClick="btnSave_Click"
                            BorderStyle="None" CssClass="style1" ForeColor="White" BackColor="#88AB2D" ValidationGroup="Save" />--%>
                    </div>
                </div>
                <div style="clear: both; margin-bottom: 10px; margin-left: 10px; width: 100%" align="center">
                    <asp:Button ID="btnSave" runat="server" Text=" Save " CssClass="btn" ValidationGroup="save"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" CssClass="btn" 
                        onclick="btnCancel_Click" Text="Cancel" />
                </div>
            </div>
            <div>
                <asp:Panel ID="pnlConfirmation" runat="server" Style="display: none; width: 300px;
                    background-color: White; border-width: 2px; border-color: #A5CBB0; border-style: solid;">
                    <div class="formHeader">
                        <asp:Label ID="Label2" runat="server" Text="" Style="font-size: medium; font-family: 'Times New Roman', Times, serif;"></asp:Label>
                    </div>
                    <div style="margin: 20px 20px;">
                        <asp:Label ID="configmMessage" runat="server" Text="Are you sure , You want to Cancel"></asp:Label>
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
        </div>
    </div>
</asp:Content>
