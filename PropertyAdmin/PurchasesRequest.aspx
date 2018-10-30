<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PurchasesRequest.aspx.cs" Inherits="PropertyAdmin.PurchasesRequest" %>

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
                                            <asp:DropDownList ID="ddlSWorkUnit" runat="server" Width="140px" AppendDataBoundItems="True"
                                                ValidationGroup="search">
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
                                            <asp:DropDownList ID="ddlSRequestType" runat="server" Width="140px" AppendDataBoundItems="True"
                                                ValidationGroup="search">
                                                <asp:ListItem Value="">Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                                        <div class="leftControl">
                                            <asp:Label ID="Label20" runat="server" Text="Requested Date"></asp:Label>
                                        </div>
                                        <div class="rightControl">
                                            <asp:TextBox ID="txtSRequestDate" runat="server" Width="65px" ValidationGroup="search">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="txtSRequestDate_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtSRequestDate">
                                            </asp:CalendarExtender>
                                            -
                                            <asp:TextBox ID="txtSRequestDate2" runat="server" Width="65px" ValidationGroup="search">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="txtSRequestDate2_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtSRequestDate2">
                                            </asp:CalendarExtender>
                                            <asp:CompareValidator ID="Cv8" runat="server" Display="None" ErrorMessage="Please enter date only."
                                                ForeColor="#CC3300" Operator="DataTypeCheck" Type="Date" ValidationGroup="search"
                                                ControlToValidate="txtSRequestDate"></asp:CompareValidator>
                                            <asp:ValidatorCalloutExtender ID="Cv8_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                TargetControlID="Cv8">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:CompareValidator ID="Cv9" runat="server" Display="None" ErrorMessage="Please enter date only."
                                                ForeColor="#CC3300" Operator="DataTypeCheck" Type="Date" ValidationGroup="search"
                                                ControlToValidate="txtSRequestDate2"></asp:CompareValidator>
                                            <asp:ValidatorCalloutExtender ID="Cv9_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                TargetControlID="Cv9">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:CompareValidator ID="Cv7" runat="server" Display="None" ErrorMessage="Date shouldn't be less than the start date"
                                                ForeColor="#CC3300" Operator="GreaterThanEqual" Type="Date" ValidationGroup="search"
                                                ControlToCompare="txtSRequestDate" ControlToValidate="txtSRequestDate2"></asp:CompareValidator>
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
                                            <asp:TextBox ID="txtSApproveDate" runat="server" Width="65px" ValidationGroup="search">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="txtSApproveDate_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtSApproveDate">
                                            </asp:CalendarExtender>
                                            -
                                            <asp:TextBox ID="txtSApproveDate2" runat="server" Width="65px" ValidationGroup="search">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="txtSApproveDate2_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtSApproveDate2">
                                            </asp:CalendarExtender>
                                            <asp:CompareValidator ID="Cv12" runat="server" Display="None" ErrorMessage="Date shouldn't be less than the start date"
                                                ForeColor="#CC3300" Operator="GreaterThanEqual" Type="Date" ValidationGroup="search"
                                                ControlToCompare="txtSApproveDate" ControlToValidate="txtSApproveDate2"></asp:CompareValidator>
                                            <asp:ValidatorCalloutExtender ID="Cv12_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                TargetControlID="Cv12">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:CompareValidator ID="Cv10" runat="server" Display="None" ErrorMessage="Please enter date only."
                                                ForeColor="#CC3300" Operator="DataTypeCheck" Type="Date" ValidationGroup="search"
                                                ControlToValidate="txtSApproveDate"></asp:CompareValidator>
                                            <asp:ValidatorCalloutExtender ID="Cv10_ValidatorCalloutExtender" runat="server" Enabled="True"
                                                TargetControlID="Cv10">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:CompareValidator ID="Cv11" runat="server" Display="None" ErrorMessage="Please enter date only."
                                                ForeColor="#CC3300" Operator="DataTypeCheck" Type="Date" ValidationGroup="search"
                                                ControlToValidate="txtSApproveDate2"></asp:CompareValidator>
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
                                    <%-- <div class="content">--%>
                                    <%-- <div class="titleSub">
                                        Search :
                                    </div>--%>
                                    <div style="padding-top: 5px;">
                                        <asp:GridView ID="grvPurchaseRequest" runat="server" AllowPaging="True" CellPadding="4"
                                            ForeColor="#333333" GridLines="None" PageSize="5" AutoGenerateColumns="False"
                                            DataKeyNames="ID" OnPageIndexChanging="grvPurchaseRequest_PageIndexChanging"
                                            OnSelectedIndexChanged="grvPurchaseRequest_SelectedIndexChanged" OnRowDataBound="grvPurchaseRequest_RowDataBound">
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
                                                <asp:TemplateField HeaderText="Purpose">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPurpose" Text='<%# Eval("Purpose") %>' runat="server"></asp:Label>
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
                                                <asp:TemplateField HeaderText="SRNo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSRNo" Text='<%# Eval("SRNo") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               <%-- <asp:TemplateField HeaderText="SRDate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSRDate" Text='<%# Eval("SRDate") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Type" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblType" Text='<%# Eval("Type") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGRNID" Text='<%# Eval("GRNID") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFARNID" Text='<%# Eval("FARNID") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGRNStatus" Text='<%# Eval("GRNStatus") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFARNStatus" Text='<%# Eval("FARNStatus") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:HyperLinkField HeaderText="GRN" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="GRN.aspx?PRID={0}"
                                                    DataTextField="PRNo" NavigateUrl="~/GRN.aspx" />
                                                <asp:HyperLinkField HeaderText="FARN" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="FARN.aspx?PRID={0}"
                                                    DataTextField="PRNo" NavigateUrl="~/FARN.aspx" />
                                            </Columns>
                                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#e4efd0" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#89ac2e" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="#e4efd0" />
                                        </asp:GridView>
                                    </div>
                                    <%-- </div>--%>
                                </div>
                            </fieldset>
                        </asp:Panel>
                    </Content>
                </asp:AccordionPane>
            </Panes>
        </asp:Accordion>
        <div class="titleSub2">
            <asp:Label ID="Label3" runat="server" Text="Purchase Request"></asp:Label></div>
        <div id="MainForm">
            <div>
                <div id="LeftForm" class="form2">
                <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label17" runat="server" Text="PRNo"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtPRNo" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPRNo"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CVs" runat="server" ControlToValidate="txtPRNo" Display="None"
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
                            <asp:Label ID="Label11" runat="server" Text="SRNo"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:DropDownList ID="ddlSReq" AutoPostBack="true" runat="server" 
                                AppendDataBoundItems="True" ValidationGroup="save" Width="140px">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                    <%--   --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label16" runat="server" Text="SRDate"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtSRDate" runat="server" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <%--  --%>
                   <%-- <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label4" runat="server" Text="Work Unit"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:DropDownList ID="ddlWorkUnit" runat="server" AppendDataBoundItems="True" ValidationGroup="save"
                                Width="140px">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlWorkUnit"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>--%>
                    <%--   --%>


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

                    <%-- --%>

                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label5" runat="server" Text="Request Type"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:DropDownList ID="ddlRequestType" runat="server" AppendDataBoundItems="True"
                                ValidationGroup="save" Width="140px">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlRequestType"
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
                            <asp:DropDownList ID="ddlItemType" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                OnSelectedIndexChanged="ddItemType_SelectedIndexChanged" ValidationGroup="save"
                                Width="140px">
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
                            <asp:DropDownList ID="ddlItem" runat="server" Width="140px" AppendDataBoundItems="True"
                                ValidationGroup="save">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                ControlToValidate="ddlItem" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                  
                  
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label6" runat="server" Text="Quantity"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtQuantity" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                ControlToValidate="txtQuantity" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv1" runat="server" Display="None" ErrorMessage="Please enter numbers only."
                                ForeColor="#CC3300" Operator="DataTypeCheck" Type="Double" ValidationGroup="save"
                                ControlToValidate="txtQuantity"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv1_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv1">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                  
                </div>

                <div id="RightForm" class="form2">
                  <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label7" runat="server" Text="Requested By"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtRequestedBy" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="txtRequestedBy_AutoCompleteExtender" runat="server"
                                DelimiterCharacters="" Enabled="True" MinimumPrefixLength="1" ServicePath=""
                                TargetControlID="txtRequestedBy" UseContextKey="True" ServiceMethod="GetEmployees">
                            </asp:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                ControlToValidate="txtRequestedBy" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="save">
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                                ControlToValidate="txtRequestedDate" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv2" runat="server" Display="None" ErrorMessage="Please enter date only."
                                ForeColor="#CC3300" Operator="DataTypeCheck" Type="Date" ValidationGroup="save"
                                ControlToValidate="txtRequestedDate"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv2_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv2">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                 
                       <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label9" runat="server" Text="Approved By"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtApprovedBy" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="txtApprovedBy_AutoCompleteExtender" ServiceMethod="GetEmployees"
                                runat="server" DelimiterCharacters="" Enabled="True" ServicePath="" TargetControlID="txtApprovedBy"
                                MinimumPrefixLength="1">
                            </asp:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*"
                                ControlToValidate="txtApprovedBy" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="save">
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"
                                ControlToValidate="txtApprovedDate" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="save">
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
                    <div class="controlContainer" style="margin-top: 10px;height:50px;">
                        <div class="leftControl">
                            <asp:Label ID="Label13" runat="server" Text="Purpose"></asp:Label>
                        </div>
                        <div class="rightControl" >
                            <asp:TextBox ID="txtPorpose" runat="server" TextMode="MultiLine">
                            </asp:TextBox>
                        </div>
                    </div>
                    <%-- --%>
                    <div class="controlContainer" style="margin-top: 10px; height:50px;"">
                        <div class="leftControl">
                            <asp:Label ID="Label12" runat="server" Text="Remark"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtRemark" runat="server" ValidationGroup="save" TextMode="MultiLine">
                            </asp:TextBox>
                        </div>
                    </div>
                
                    <div style="clear: both; margin-bottom: 10px; width: 100%" align="center">
                        <%--<asp:Button ID="Button1" runat="server" Text="Add Stack" OnClick="btnSave_Click"
                            BorderStyle="None" CssClass="style1" ForeColor="White" BackColor="#88AB2D" ValidationGroup="Save" />--%>
                    </div>
                </div>
                <div style="clear: both; margin-bottom: 10px; width: 100%" align="center">
                    <asp:Button ID="btnSave" runat="server" Text=" Save " ValidationGroup="save" CssClass="btn"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" CssClass="btn" 
                        onclick="btnCancel_Click" Text="Cancel" />
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
    </div>
</asp:Content>
