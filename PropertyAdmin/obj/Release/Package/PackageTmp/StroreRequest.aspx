<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="StroreRequest.aspx.cs" Inherits="PropertyAdmin.StroreRequest" %>

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
                                    <asp:Label ID="Label1" runat="server" Text="Search:"></asp:Label></div>
                                <div id="Div1" class="form" style="float: left; margin-right: 35px; margin-top: 0;
                                    margin-bottom: 10px">
                                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                                        <div class="leftControl">
                                            <asp:Label ID="Label18" runat="server" Text="Work Unit"></asp:Label>
                                        </div>
                                        <div class="rightControl">
                                            <asp:DropDownList ID="ddlSWorkUnit" runat="server" AppendDataBoundItems="True" ValidationGroup="search"
                                                Width="140px">
                                                <asp:ListItem Value="">Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <%--  --%>
                                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                                        <div class="leftControl">
                                            <asp:Label ID="Label19" runat="server" Text="Request Type"></asp:Label>
                                        </div>
                                        <div class="rightControl">
                                            <asp:DropDownList ID="ddlSRequestType" runat="server" AppendDataBoundItems="True"
                                                ValidationGroup="search" Width="140px">
                                                <asp:ListItem Value="">Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                                        <div class="leftControl">
                                            <asp:Label ID="Label20" runat="server" Text="Requested Date"></asp:Label>
                                        </div>
                                        <div class="rightControl">
                                            <asp:TextBox ID="txtSRequestDate" runat="server" ValidationGroup="search" Width="65px">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="txtSRequestDate_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtSRequestDate">
                                            </asp:CalendarExtender>
                                            -
                                            <asp:TextBox ID="txtSRequestDate2" runat="server" ValidationGroup="search" Width="65px">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="txtSRequestDate2_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtSRequestDate2">
                                            </asp:CalendarExtender>
                                            <asp:CompareValidator ID="Cv8" runat="server" ControlToValidate="txtSRequestDate"
                                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                                Type="Date" ValidationGroup="search"></asp:CompareValidator>
                                            <asp:ValidatorCalloutExtender ID="Cv8_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                TargetControlID="Cv8">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:CompareValidator ID="Cv9" runat="server" ControlToValidate="txtSRequestDate2"
                                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                                Type="Date" ValidationGroup="search"></asp:CompareValidator>
                                            <asp:ValidatorCalloutExtender ID="Cv9_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                TargetControlID="Cv9">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:CompareValidator ID="Cv7" runat="server" ControlToCompare="txtSRequestDate"
                                                ControlToValidate="txtSRequestDate2" Display="None" ErrorMessage="Date shouldn't be less than the start date"
                                                ForeColor="#CC3300" Operator="GreaterThanEqual" Type="Date" ValidationGroup="search"></asp:CompareValidator>
                                            <asp:ValidatorCalloutExtender ID="Cv7_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                TargetControlID="Cv7">
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
                                            <asp:DropDownList ID="ddlSItemType" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlSItemType_SelectedIndexChanged" ValidationGroup="search"
                                                Width="140px">
                                                <asp:ListItem Value="">Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                                        <div class="leftControl">
                                            <asp:Label ID="Label22" runat="server" Text="Item "></asp:Label>
                                        </div>
                                        <div class="rightControl">
                                            <asp:DropDownList ID="ddlSItem" runat="server" AppendDataBoundItems="True" ValidationGroup="search"
                                                Width="140px">
                                                <asp:ListItem Value="">Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                                        <div class="leftControl">
                                            <asp:Label ID="Label23" runat="server" Text="Approved Date"></asp:Label>
                                        </div>
                                        <div class="rightControl">
                                            <asp:TextBox ID="txtSApproveDate" runat="server" ValidationGroup="search" Width="65px">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="txtSApproveDate_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtSApproveDate">
                                            </asp:CalendarExtender>
                                            -
                                            <asp:TextBox ID="txtSApproveDate2" runat="server" ValidationGroup="search" Width="65px">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="txtSApproveDate2_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtSApproveDate2">
                                            </asp:CalendarExtender>
                                            <asp:CompareValidator ID="Cv12" runat="server" ControlToCompare="txtSApproveDate"
                                                ControlToValidate="txtSApproveDate2" Display="None" ErrorMessage="Date shouldn't be less than the start date"
                                                ForeColor="#CC3300" Operator="GreaterThanEqual" Type="Date" ValidationGroup="search"></asp:CompareValidator>
                                            <asp:ValidatorCalloutExtender ID="Cv12_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                TargetControlID="Cv12">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:CompareValidator ID="Cv10" runat="server" ControlToValidate="txtSApproveDate"
                                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                                Type="Date" ValidationGroup="search"></asp:CompareValidator>
                                            <asp:ValidatorCalloutExtender ID="Cv10_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                TargetControlID="Cv10">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:CompareValidator ID="Cv11" runat="server" ControlToValidate="txtSApproveDate2"
                                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                                Type="Date" ValidationGroup="search"></asp:CompareValidator>
                                            <asp:ValidatorCalloutExtender ID="Cv11_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                TargetControlID="Cv11">
                                            </asp:ValidatorCalloutExtender>
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
                                        <asp:GridView ID="grvStoreRequest" runat="server" AllowPaging="True" CellPadding="4"
                                            ForeColor="#333333" GridLines="None" PageSize="5" AutoGenerateColumns="False"
                                            DataKeyNames="ID" OnSelectedIndexChanged="grvStoreRequest_SelectedIndexChanged"
                                            OnPageIndexChanging="grvStoreRequest_PageIndexChanging" OnRowDataBound="grvStoreRequest_RowDataBound">
                                            <EmptyDataTemplate>
                                                <asp:Label ID="lbl" runat="server" Text="No data available."></asp:Label>
                                            </EmptyDataTemplate>
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="false" CommandName="Select"
                                                            ImageUrl="~/Images/Editpencil.png" OnClick="btnEdit_Click" Text="e" ToolTip="Edit" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Select"
                                                            ImageUrl="~/Images/Delete.png" Text="X" OnClick="btnDelete_Click" ToolTip="Delete" />
                                                        <asp:ModalPopupExtender ID="btnDelete_ModalPopupExtender" runat="server" DynamicServicePath=""
                                                            Enabled="True" TargetControlID="btnDelete" CancelControlID="btnNo" OkControlID="btnYes"
                                                            PopupControlID="pnlConfirmation">
                                                        </asp:ModalPopupExtender>
                                                        <asp:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" ConfirmText=""
                                                            Enabled="True" TargetControlID="btnDelete" DisplayModalPopupID="btnDelete_ModalPopupExtender">
                                                        </asp:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="WorkUnit">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblWorkUnit" Text='<%# Eval("WorkUnit") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="RequestType" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRequestType" Text='<%# Eval("RequestType") %>' runat="server"></asp:Label>
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
                                                <asp:TemplateField HeaderText="RequestedBy">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRequestedBy" Text='<%# Eval("RequestedBy") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="RequestedDate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRequestedDate" Text='<%# Eval("RequestedDate") %>' runat="server"></asp:Label>
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
                                                <%-- <asp:TemplateField HeaderText="ReviewedBy">
                                <ItemTemplate>
                                    <asp:Label ID="lblReviewedBy" Text='<%# Eval("ReviewedBy") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ReviewedDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblReviewedDate" Text='<%# Eval("ReviewedDate") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Staus" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStaus" Text='<%# Eval("Status") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSIVId" Text='<%# Eval("SIVId") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPRId" Text='<%# Eval("PRId") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSIVStatus" Text='<%# Eval("SIVStatus") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPRStatus" Text='<%# Eval("PRStatus") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFARNGRNID" Text='<%# Eval("FARNGRNID") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPropertyType" Text='<%# Eval("PropertyType") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="PurchasesRequest.aspx?SRID={0}"
                                                    DataTextField="SRNo" NavigateUrl="~/PurchasesRequest.aspx" HeaderText="PR" />
                                                <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="StoreIssueVoucher.aspx?SRID={0}"
                                                    DataTextField="SRNo" NavigateUrl="~/StoreIssueVoucher.aspx" HeaderText="SIV" />
                                                <asp:HyperLinkField DataNavigateUrlFields="ID,FARNGRNID" DataNavigateUrlFormatString="FAIV.aspx?SRID={0}&FARNID={1}"
                                                    DataTextField="SRNo" NavigateUrl="~/FAIV.aspx" HeaderText="FAIV" />
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
        <div class="titleSub2">
            <asp:Label ID="lbl" runat="server" Text="Store Request"></asp:Label></div>
        <div id="MainForm">
            <div>
                <div id="LeftForm" class="form2">
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label3" runat="server" Text="SRNo"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtSRNo" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSRNo"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CVs" runat="server" ControlToValidate="txtSRNo" Display="None"
                                ErrorMessage="Please enter numbers only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Integer" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="CVs_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="CVs">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <%--  --%>
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
                            <asp:Label ID="Label24" runat="server" Text="Work Unit"></asp:Label>
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
                    <%--   --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label5" runat="server" Text="Request Type"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:DropDownList ID="ddlRequestType" runat="server" Width="140px" AppendDataBoundItems="True"
                                ValidationGroup="save">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                ControlToValidate="ddlRequestType" Display="Dynamic" ForeColor="#FF3300" ValidationGroup="save"></asp:RequiredFieldValidator>
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
                    <%--   <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label3" runat="server" Width="100px"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtItem" runat="server"></asp:TextBox>
                            <asp:AutoCompleteExtender ID="txtItem_AutoCompleteExtender" runat="server" ServiceMethod="GetIems"
                                DelimiterCharacters="" Enabled="True" ServicePath="" TargetControlID="txtItem"
                                MinimumPrefixLength="1">
                            </asp:AutoCompleteExtender>
                        </div>
                    </div>--%>
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label6" runat="server" Text="Quantity"></asp:Label>
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
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label7" runat="server" Text="Requested By"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtRequestedBy" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="txtRequestedBy_AutoCompleteExtender" runat="server"
                                DelimiterCharacters="" Enabled="True" MinimumPrefixLength="1" ServiceMethod="GetEmployees"
                                ServicePath="" TargetControlID="txtRequestedBy"> 
                            </asp:AutoCompleteExtender>


                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtRequestedBy"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label8" runat="server" Text="Requested Date"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtRequestedDate" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtRequestedDate_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtRequestedDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtRequestedDate"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv2" runat="server" ControlToValidate="txtRequestedDate"
                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv2_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv2">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                </div>
                <div id="RightForm" class="form2">
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label9" runat="server" Text="Approved By"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtApprovedBy" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="txtApprovedBy_AutoCompleteExtender" runat="server"
                                DelimiterCharacters="" Enabled="True" MinimumPrefixLength="1" ServiceMethod="GetEmployees"
                                ServicePath="" TargetControlID="txtApprovedBy">
                            </asp:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtApprovedBy"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%--  --%>
                    <%--<div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label10" runat="server" Text="Approved Date"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtApprovedDate" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtApprovedDate_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtApprovedDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtApprovedDate"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv3" runat="server" ControlToValidate="txtApprovedDate"
                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv3_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv3">
                            </asp:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="Cv5" runat="server" ControlToCompare="txtRequestedDate"
                                ControlToValidate="txtApprovedDate" Display="None" ErrorMessage="Approved Date shouldn't be less than requested date"
                                ForeColor="#CC3300" Operator="GreaterThanEqual" Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv5_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv5">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>--%>
                    <%-- --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label16" runat="server" Text="Reviewed By "></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtReviewdBy" runat="server" ValidationGroup="save">
                            </asp:TextBox>

                            <asp:AutoCompleteExtender ID="txtReviewdBy_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                Enabled="True" MinimumPrefixLength="1" ServiceMethod="GetEmployees" ServicePath=""
                                TargetControlID="txtReviewdBy">
                            </asp:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="RequiredReviewdBy" runat="server" ControlToValidate="txtReviewdBy"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%-- --%>
                    <%--<div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label17" runat="server" Text="Reviewed Date"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtReviewdDate" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtReviewdDat_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtReviewdDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredReviewdDate" runat="server" ControlToValidate="txtReviewdDate"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv4" runat="server" ControlToValidate="txtReviewdDate"
                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv4_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv4">
                            </asp:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="Cv6" runat="server" ControlToCompare="txtRequestedDate"
                                ControlToValidate="txtReviewdDate" Display="None" ErrorMessage="Reviewed Date shouldn't be less than requested date"
                                ForeColor="#CC3300" Operator="GreaterThanEqual" Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv6_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv6">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>--%>
                    <%-- --%>
                    <div class="controlContainer" style="margin-top: 10px; height: 50px;">
                        <div class="leftControl">
                            <asp:Label ID="Label13" runat="server" Text="Purpose"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtPorpose" runat="server" TextMode="MultiLine">
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
                    <%-- --%>
                    <div class="controlContainer" style="margin-top: 10px; height: 50px;">
                        <div class="leftControl">
                            <asp:Label ID="Label11" runat="server" Text="Store Keeper Action"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtStoreAction" runat="server" ValidationGroup="btnSave" TextMode="MultiLine">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div style="clear: both; margin-bottom: 10px; width: 100%" align="center">
                        <%--<asp:Button ID="Button1" runat="server" Text="Add Stack" OnClick="btnSave_Click"
                            BorderStyle="None" CssClass="style1" ForeColor="White" BackColor="#88AB2D" ValidationGroup="Save" />--%>
                    </div>
                </div>
                <div style="clear: both; margin-bottom: 10px; margin-left: 10px; width: 100%" align="center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="save" CssClass="btn"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" onclick="btnCancel_Click" />
                    
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
