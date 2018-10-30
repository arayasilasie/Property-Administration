<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FARN.aspx.cs" Inherits="PropertyAdmin.FARN" %>

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
                                        </div>
                                        <div class="rightControl">
                                        </div>
                                    </div>
                                </div>
                                <div id="Div2" class="form" style="float: left; margin-bottom: 10px;">
                                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                                        <div class="leftControl">
                                            <asp:Label ID="Label23" runat="server" Text="Received Date&nbsp;"></asp:Label>
                                        </div>
                                        <div class="rightControl">
                                            <asp:TextBox ID="txtSReceiveDate" runat="server" ValidationGroup="search" Width="65px">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="txtSReceiveDate_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtSReceiveDate">
                                            </asp:CalendarExtender>
                                            -
                                            <asp:TextBox ID="txtSReceiveDate2" runat="server" ValidationGroup="search" Width="65px">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="txtSReceiveDate2_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtSReceiveDate2">
                                            </asp:CalendarExtender>
                                            <asp:CompareValidator ID="Cv12" runat="server" ControlToValidate="txtSReceiveDate"
                                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                                Type="Date" ValidationGroup="search"></asp:CompareValidator>
                                            <asp:ValidatorCalloutExtender ID="Cv12_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                TargetControlID="Cv12">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:CompareValidator ID="Cv13" runat="server" ControlToValidate="txtSReceiveDate2"
                                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                                Type="Date" ValidationGroup="search"></asp:CompareValidator>
                                            <asp:ValidatorCalloutExtender ID="Cv13_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                TargetControlID="Cv13">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:CompareValidator ID="Cv14" runat="server" ControlToCompare="txtSReceiveDate"
                                                ControlToValidate="txtSReceiveDate2" Display="None" ErrorMessage="Date shouldn't be less than the start date"
                                                ForeColor="#CC3300" Operator="GreaterThanEqual" Type="Date" ValidationGroup="search"></asp:CompareValidator>
                                            <asp:ValidatorCalloutExtender ID="Cv14_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                TargetControlID="Cv14">
                                            </asp:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                                        <div class="leftControl">
                                        </div>
                                        <div class="rightControl" style="float: right;">
                                        </div>
                                    </div>
                                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                                        <div class="leftControl">
                                        </div>
                                        <div class="rightControl" style="float: right;">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                                                CssClass="btn" ValidationGroup="search" />
                                        </div>
                                    </div>
                                </div>
                                <div style="clear: both; margin: 1px;">
                                    <asp:Label ID="lblSearchMessage" runat="server" Text=""></asp:Label>
                                    <div style="padding-top: 5px;">
                                        <asp:GridView ID="grvFarn" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333"
                                            GridLines="None" PageSize="5" AutoGenerateColumns="False" DataKeyNames="ID" OnPageIndexChanging="grvFarn_PageIndexChanging"
                                            OnSelectedIndexChanged="grvFarn_SelectedIndexChanged" OnRowDataBound="grvFarn_RowDataBound">
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
                                                <asp:TemplateField HeaderText="FARNNo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFARNNo" Text='<%# Eval("FARNNo") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="PRNo" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPRNo" Text='<%# Eval("PRNo") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SuppliedBy">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSuppliedBy" Text='<%# Eval("SuppliedBy") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Item">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItem" Text='<%# Eval("Item") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quantity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQuantity" Text='<%# Eval("Quantity") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="UnitPrice">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUnitPrice" Text='<%# Eval("UnitPrice") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ReceivedBy">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReceivedBy" Text='<%# Eval("ReceivedBy") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ReceivedDate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReceivedDate" Text='<%# Eval("ReceivedDate") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%-- <asp:TemplateField HeaderText="VerifiedBy">
                                <ItemTemplate>
                                    <asp:Label ID="lblVerifiedBy" Text='<%# Eval("VerifiedBy") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VerifiedDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblVerifiedDate" Text='<%# Eval("VerifiedDate") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DeliveredBy">
                                <ItemTemplate>
                                    <asp:Label ID="lblDeliveredBy" Text='<%# Eval("DeliveredBy") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DeliveredDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblDeliveredDate" Text='<%# Eval("DeliveredDate") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSRID" Text='<%# Eval("SRID") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSRStatus" Text='<%# Eval("SRStatus") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFAIVID" Text='<%# Eval("FAIVID") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFAIVStatus" Text='<%# Eval("FAIVStatus") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:HyperLinkField HeaderText="FAIV" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="FAIV.aspx?FARNID={0}"
                                                    DataTextField="FARNNo" NavigateUrl="~/FAIV.aspx" />
                                                <%--<asp:HyperLinkField HeaderText="SIV" DataNavigateUrlFields="ID,SRID" DataNavigateUrlFormatString="StoreIssueVoucher.aspx?FARNGRNID={0}&SRID={1}"
                                DataTextField="FARNNo" NavigateUrl="~/StoreIssueVoucher.aspx" />--%>
                                                <asp:HyperLinkField HeaderText="SR" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="StroreRequest.aspx?FARNID={0}"
                                                    DataTextField="FARNNo" NavigateUrl="~/StroreRequest.aspx" />
                                                <asp:HyperLinkField HeaderText="FAR" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="FixedAsset.aspx?FARNID={0}"
                                                    DataTextField="FARNNo" NavigateUrl="~/FixedAsset.aspx" />
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
                            </fieldset>
                        </asp:Panel>
                    </Content>
                </asp:AccordionPane>
            </Panes>
        </asp:Accordion>
        <div class="titleSub2">
            <asp:Label ID="lbl" runat="server" Text="Fixed Asset Receiving Note"></asp:Label></div>
        <div id="MainForm">
            <div>
                <div id="LeftForm" class="form2">
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label17" runat="server" Text="FARNNo"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtFARNNo" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFARNNo"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CVs" runat="server" ControlToValidate="txtFARNNo" Display="None"
                                ErrorMessage="Please enter numbers only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Integer" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="CVs_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="CVs">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <%--   --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label11" runat="server" Text="PRNo"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtPRNo" runat="server" Enabled="False"></asp:TextBox>
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
                    <%--   --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label14" runat="server" Text="Item"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:DropDownList ID="ddlItem" runat="server" AppendDataBoundItems="True" ValidationGroup="save"
                                Width="140px">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlItem"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label4" runat="server" Text="Model"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtModel" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                        </div>
                    </div>
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label5" runat="server" Text="Quantity"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtQuantity" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtQuantity"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv1" runat="server" ControlToValidate="txtQuantity" Display="None"
                                ErrorMessage="Please enter numbers only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Double" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv1_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv1">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <%--   --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label19" runat="server" Text="Unit Price "></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtUnitPrice" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtUnitPriceValidator6" runat="server" ControlToValidate="txtUnitPrice"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv2" runat="server" ControlToValidate="txtUnitPrice" Display="None"
                                ErrorMessage="Please enter numbers only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Currency" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv2_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv2">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label3" runat="server" Width="100px">Supplied By</asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtSuppliedBy" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                        </div>
                    </div>
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label18" runat="server" Width="100px">Supplier Phone</asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtSupPhone" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                        </div>
                    </div>
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label26" runat="server" Width="100px">Supplier Email</asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtSupEmail" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                        </div>
                    </div>
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label6" runat="server" Text="Invoice No"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                TargetControlID="Cv1">
                            </asp:ValidatorCalloutExtender>
                            <asp:TextBox ID="txtInvoiceNo" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                        </div>
                    </div>
                </div>
                <div id="RightForm" class="form2">
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label7" runat="server" Text="Received By"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtReceivedBy" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="txtReceivedBy_AutoCompleteExtender" runat="server"
                                DelimiterCharacters="" Enabled="True" MinimumPrefixLength="1" ServiceMethod="GetEmployees"
                                ServicePath="" TargetControlID="txtReceivedBy" UseContextKey="True">
                            </asp:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="ReceivedByValidator7" runat="server" ControlToValidate="txtReceivedBy"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label8" runat="server" Text="Received Date"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                TargetControlID="Cv2">
                            </asp:ValidatorCalloutExtender>
                            <asp:TextBox ID="txtReceivedDate" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtReceivedDate_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtReceivedDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="DateValidator8" runat="server" ControlToValidate="txtReceivedDate"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv8" runat="server" ControlToValidate="txtReceivedDate"
                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv8_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv8">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label9" runat="server" Text="Verified By "></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtVerifiedBy" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="txtVerifiedBy_AutoCompleteExtender" runat="server"
                                DelimiterCharacters="" Enabled="True" MinimumPrefixLength="1" ServiceMethod="GetEmployees"
                                ServicePath="" TargetControlID="txtVerifiedBy">
                            </asp:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="txtVerifiedByValidator9" runat="server" ControlToValidate="txtVerifiedBy"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%--  --%>
                    <%--<div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label10" runat="server" Text="Verified Date"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtVerifiedDate" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtVerifiedDate_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtVerifiedDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtVerifiedDate"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv9" runat="server" ControlToValidate="txtVerifiedDate"
                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv9_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv9">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>--%>
                    <%-- --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label16" runat="server" Text="Delivered By "></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtDeliveredBy" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                        </div>
                    </div>
                    <%-- --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label20" runat="server" Text="Delivered Date"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtDeliveredDate" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtDeliveredDate_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtDeliveredDate">
                            </asp:CalendarExtender>
                            <asp:CompareValidator ID="Cv10" runat="server" ControlToValidate="txtDeliveredDate"
                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv10_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv10">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <%-- --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label24" runat="server" Text="Ref No "></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtRefNo" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                        </div>
                    </div>
                    <%-- --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label25" runat="server" Text="Ref Date "></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtRefDate" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtRefDate_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtRefDate">
                            </asp:CalendarExtender>
                            <asp:CompareValidator ID="Cv11" runat="server" ControlToValidate="txtRefDate" Display="None"
                                ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv11_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv11">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <%-- --%>
                    <div class="controlContainer" style="margin-top: 10px; height: 50px;">
                        <div class="leftControl">
                            <asp:Label ID="Label13" runat="server" Text="Location"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtLocation" runat="server" TextMode="MultiLine">
                            </asp:TextBox>
                        </div>
                    </div>
                    <%-- --%>
                    <div class="controlContainer" style="margin-top: 10px; height: 50px;">
                        <div class="leftControl">
                            <asp:Label ID="Label12" runat="server" Text="Remark"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtRemark" runat="server" ValidationGroup="btnSave" TextMode="MultiLine">
                            </asp:TextBox>
                        </div>
                    </div>
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
        </div>
</asp:Content>
