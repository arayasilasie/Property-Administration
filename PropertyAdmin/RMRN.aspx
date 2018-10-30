<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RMRN.aspx.cs" Inherits="PropertyAdmin.RMRN" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="Messages.ascx" TagName="Messages" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
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
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                                            <asp:Label ID="Label4" runat="server" Text="Item Type "></asp:Label>
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
                                            <asp:Label ID="Label5" runat="server" Text="Item "></asp:Label>
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
                                            <asp:Label ID="Label21" runat="server" Text="Condition"></asp:Label>
                                        </div>
                                        <div class="rightControl">
                                            <asp:DropDownList ID="ddlSCondition" runat="server" Width="140px" AppendDataBoundItems="True">
                                                <asp:ListItem Value="">Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                                        <div class="leftControl">
                                            <asp:Label ID="Label22" runat="server" Text="Recieved Date"></asp:Label>
                                        </div>
                                        <div class="rightControl">
                                            <asp:TextBox ID="txtSRecievedDate" runat="server" ValidationGroup="search" Width="65px">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="txtSRecievede_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtSRecievedDate">
                                            </asp:CalendarExtender>
                                            -
                                            <asp:TextBox ID="txtSRecievedDate2" runat="server" ValidationGroup="search" Width="65px">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="txtSRecievedDate2_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtSRecievedDate2">
                                            </asp:CalendarExtender>
                                            <asp:CompareValidator ID="Cv12" runat="server" ControlToValidate="txtSRecievedDate"
                                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                                Type="Date" ValidationGroup="search"></asp:CompareValidator>
                                            <asp:ValidatorCalloutExtender ID="Cv12_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                TargetControlID="Cv12">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:CompareValidator ID="Cv13" runat="server" ControlToValidate="txtSRecievedDate2"
                                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                                Type="Date" ValidationGroup="search"></asp:CompareValidator>
                                            <asp:ValidatorCalloutExtender ID="Cv13_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                TargetControlID="Cv13">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:CompareValidator ID="Cv14" runat="server" ControlToCompare="txtSRecievedDate"
                                                ControlToValidate="txtSRecievedDate2" Display="None" ErrorMessage="Date shouldn't be less than the start date"
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
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                                                ValidationGroup="search" CssClass="btn" />
                                        </div>
                                    </div>
                                </div>
                                <div style="clear: both; margin: 1px;">
                                    <asp:Label ID="lblSearchMessage" runat="server" Text=""></asp:Label>
                                    <div style="padding-top: 5px;">
                                        <asp:GridView ID="grvRMRN" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333"
                                            GridLines="None" PageSize="5" AutoGenerateColumns="False" DataKeyNames="ID" OnPageIndexChanging="grvRMRN_PageIndexChanging"
                                            OnSelectedIndexChanged="grvRMRN_SelectedIndexChanged" OnRowDataBound="grvRMRN_RowDataBound">
                                            <EmptyDataTemplate>
                                                <asp:Label ID="lbl1" runat="server" Text="No data available."></asp:Label>
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
                                                <asp:TemplateField HeaderText="Quantity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQuantity" Text='<%# Eval("Quantity") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="UnitCost">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCost" Text='<%# Eval("UnitCost") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ReturnedBy">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReturnedBy" Text='<%# Eval("ReturnedBy") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="RecievedBy">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRecievedBy" Text='<%# Eval("RecievedBy") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="RecievedDate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRecievedDate" Text='<%# Eval("RecievedDate") %>' runat="server"></asp:Label>
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
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTMID" Text='<%# Eval("TMID") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTMStatus" Text='<%# Eval("TMStatus") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBMID" Text='<%# Eval("BMID") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBMStatus" Text='<%# Eval("BMStatus") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFAIVID" Text='<%# Eval("FAIVID") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:HyperLinkField HeaderText="RMTN" DataNavigateUrlFields="ID,FAIVID" DataNavigateUrlFormatString="RMTN.aspx?RMID={0}&FAIVID={1}"
                                                    DataTextField="RMRNNo" NavigateUrl="~/RMTN.aspx" />

                                                <%--<asp:HyperLinkField HeaderText="TFAB" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="TFAB.aspx?RMID={0}"
                                                    DataTextField="RMRNNo" NavigateUrl="~/TFAB.aspx" />--%>
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
            <asp:Label ID="Label3" runat="server" Text=" Returned Materials Receiving Note"></asp:Label></div>
        <div id="MainForm">
            <div>
                <div id="LeftForm" class="form2">
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label8" runat="server" Text="RMRNNo"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtRMRNNo" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRMRNNo"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CVs" runat="server" ControlToValidate="txtRMRNNo" Display="None"
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
                            <asp:Label ID="Label14" runat="server" Text="Item"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtItem" runat="server" Enabled="true">
                            </asp:TextBox>
                        </div>
                    </div>
                    <%--  --%>
                   <%-- <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label15" runat="server" Text="Tag No."></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtTagNo" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                Enabled="True" MinimumPrefixLength="1" ServiceMethod="GetIemTagNo" ServicePath=""
                                TargetControlID="txtTagNo" UseContextKey="True">
                            </asp:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatortg" runat="server" ControlToValidate="txtTagNo"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>--%>
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label9" runat="server" Text="Quantity"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtQuantity" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="QuantityValidator6" runat="server" ControlToValidate="txtQuantity"
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
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label10" runat="server" Text="Unit Price"></asp:Label>
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
                            <asp:Label ID="Label11" runat="server" Text="Condition"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                TargetControlID="Cv2">
                            </asp:ValidatorCalloutExtender>
                            <asp:DropDownList ID="ddlCondition" runat="server" AppendDataBoundItems="True" ValidationGroup="save"
                                Width="140px">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlCondition"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label12" runat="server" Text="PIN"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtPIN" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                        </div>
                    </div>
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label13" runat="server" Text="Returned By"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtReturnedBy" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="AutoCompleteExtender11" runat="server" DelimiterCharacters=""
                                Enabled="True" MinimumPrefixLength="1" ServiceMethod="GetEmployees" ServicePath=""
                                TargetControlID="txtReturnedBy" UseContextKey="True">
                            </asp:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtReturnedBy"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div id="RightForm" class="form2">
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label6" runat="server" Text="Received By"></asp:Label>
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
                            <asp:Label ID="Label7" runat="server" Text="Recieved Date "></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtRecievedDate" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtRecievedDate_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtRecievedDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtRecievedDate"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv8" runat="server" ControlToValidate="txtRecievedDate"
                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv8_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv8">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <%-- --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label16" runat="server" Text="Approved By"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtApprovedBy" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters=""
                                Enabled="True" MinimumPrefixLength="1" ServicePath="" TargetControlID="txtApprovedBy"
                                UseContextKey="True" ServiceMethod="GetEmployees">
                            </asp:AutoCompleteExtender>
                        </div>
                    </div>
                    <%-- --%>
                    <%--<div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label17" runat="server" Text="Approved Date"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtApproveDate" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txtApproveDate">
                            </asp:CalendarExtender>
                            <%-- <asp:TemplateField HeaderText="RMRNNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblRMRNNo" Text='<%# Eval("RMRNNo") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CompareValidator ID="Cv3" runat="server" ControlToValidate="txtApproveDate"
                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv3_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv3">
                            </asp:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="Cv5" runat="server" ControlToCompare="txtRecievedDate"
                                ControlToValidate="txtApproveDate" Display="None" ErrorMessage="Approved Date shouldn't be less than recieved date"
                                ForeColor="#CC3300" Operator="GreaterThanEqual" Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv5_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv5">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>--%>
                    <%-- --%>
                    <div class="controlContainer" style="margin-top: 10px; height: 50px;">
                        <div class="leftControl">
                            <asp:Label ID="Label24" runat="server" Text="Reason"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine">
                            </asp:TextBox>
                        </div>
                    </div>
                    <%-- --%>
                    <div class="controlContainer" style="margin-top: 10px; height: 50px;">
                        <div class="leftControl">
                            <asp:Label ID="Label25" runat="server" Text="Remark"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine">
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
    </div>
</asp:Content>
