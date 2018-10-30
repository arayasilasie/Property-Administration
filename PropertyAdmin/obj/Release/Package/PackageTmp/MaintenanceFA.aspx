<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MaintenanceFA.aspx.cs" Inherits="PropertyAdmin.MaintenanceFA" %>

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
        
        .accordionHeader2
        {
            background-image: url('Images/add.png');
            width: 32px;
            height: 32px;
        }
        
        .accordionHeaderSelected2
        {
            background-image: url('Images/add_.png');
            width: 32px;
            height: 32px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="overflow: auto; padding: 5px;">
        <uc1:Messages ID="Messages1" runat="server" />
        <%--  --%>
        <fieldset style="border: 1px solid #FDBF12;">
            <div class="titleSub3">
                <asp:Label ID="Label01" runat="server" Text="Search:"></asp:Label></div>
            <div id="Div1" class="form" style="float: left; margin-right: 35px; margin-top: 0;
                margin-bottom: 10px">
                <div class="controlContainer" style="margin-top: 10px; margin-left">
                    <div class="leftControl">
                        <asp:Label ID="Label21" runat="server" Text="Tag No"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:TextBox ID="txtTAG" runat="server" ValidationGroup="save" Enabled="False"></asp:TextBox>
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
                        <asp:Label ID="Label23" runat="server" Text="Maintenance Date"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:TextBox ID="txtSMantanedDate" runat="server" Width="65px" ValidationGroup="search"></asp:TextBox>
                        <asp:CalendarExtender ID="txtSRecievede_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtSMantanedDate">
                        </asp:CalendarExtender>
                        -
                        <asp:TextBox ID="txtSMantanedDate2" runat="server" Width="65px" ValidationGroup="search"></asp:TextBox>
                        <asp:CalendarExtender ID="txtSMantanedDate2_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="txtSMantanedDate2">
                        </asp:CalendarExtender>
                        <asp:CalendarExtender ID="txtStxtSRecievedDate2_CalendarExtender" runat="server"
                            Enabled="True" TargetControlID="txtSMantanedDate">
                        </asp:CalendarExtender>
                        <asp:CompareValidator ID="Cv3" runat="server" Display="None" ErrorMessage="Please enter date only."
                            ForeColor="#CC3300" Operator="DataTypeCheck" Type="Date" ValidationGroup="search"
                            ControlToValidate="txtSMantanedDate"></asp:CompareValidator>
                        <asp:ValidatorCalloutExtender ID="Cv3_ValidatorCalloutExtender" runat="server" Enabled="True"
                            TargetControlID="Cv3">
                        </asp:ValidatorCalloutExtender>
                        <asp:CompareValidator ID="Cv4" runat="server" Display="None" ErrorMessage="Please enter date only."
                            ForeColor="#CC3300" Operator="DataTypeCheck" Type="Date" ValidationGroup="search"
                            ControlToValidate="txtSMantanedDate2"></asp:CompareValidator>
                        <asp:ValidatorCalloutExtender ID="Cv4_ValidatorCalloutExtender" runat="server" Enabled="True"
                            TargetControlID="Cv4">
                        </asp:ValidatorCalloutExtender>
                        <asp:CompareValidator ID="Cv12" runat="server" Display="None" ErrorMessage="Date shouldn't be less than the start date"
                            ForeColor="#CC3300" Operator="GreaterThanEqual" Type="Date" ValidationGroup="search"
                            ControlToCompare="txtSMantanedDate" ControlToValidate="txtSMantanedDate2"></asp:CompareValidator>
                        <asp:ValidatorCalloutExtender ID="Cv12_ValidatorCalloutExtender" runat="server" Enabled="True"
                            TargetControlID="Cv12">
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
                <div style="padding-top: 5px;">
                    <asp:Label ID="lblSearchMessage" runat="server" Text=""></asp:Label>
                    <div style="padding-top: 5px;">
                        <asp:GridView ID="grvFixedassetMainten" runat="server" AllowPaging="True" CellPadding="4"
                            ForeColor="#333333" GridLines="None" PageSize="5" AutoGenerateColumns="False"
                            DataKeyNames="ID" OnPageIndexChanging="grvFixedassetMainten_PageIndexChanging"
                            OnSelectedIndexChanged="grvFixedassetMainten_SelectedIndexChanged">
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
                                <asp:TemplateField HeaderText="Item">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem" Text='<%# Eval("Item") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TagNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTagNo" Text='<%# Eval("TagNo") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MaintainedBy">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaintainedBy" Text='<%# Eval("MaintainedBy") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MaintainanceDate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaintainanceDate" Text='<%# Eval("MaintainanceDate") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CurrentCustodian">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustodian" Text='<%# Eval("Custodian") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ServiceCost">
                                    <ItemTemplate>
                                        <asp:Label ID="lblServiceCost" Text='<%# Eval("ServiceCost") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SpareCost">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSpareCost" Text='<%# Eval("SpareCost") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
        </fieldset>
        <%--  --%>
        <br />
        <div class="titleSub2">
            <asp:Label ID="Label3" runat="server" Text="Fixed Asset Maintenance"></asp:Label></div>
        <div id="MainForm">
            <div>
                <div id="LeftForm" class="form2">
                    <%--  --%><div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label9" runat="server" Text="Item "></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtItem" runat="server" ValidationGroup="save" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <%-- --%><div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label6" runat="server" Text="TagNo "></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtTagNo" runat="server" ValidationGroup="save" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label4" runat="server" Text="Maintained By"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtMaintainedBy" runat="server" ValidationGroup="save"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMaintainedBy"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%-- --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label5" runat="server" Text="Maintenance Date"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtMaintenaneDate" runat="server" ValidationGroup="save"></asp:TextBox>
                            <asp:CalendarExtender ID="txtMaintenaneDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtMaintenaneDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMaintenaneDate"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv13" runat="server" ControlToValidate="txtMaintenaneDate"
                                Display="None" ErrorMessage="Please enter date only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Date" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv13_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv13">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label24" runat="server" Text="Service Cost"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtServiceCost" runat="server" ValidationGroup="save"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtServiceCost"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv1" runat="server" ControlToValidate="txtServiceCost"
                                Display="None" ErrorMessage="Please enter numbers only." ForeColor="#CC3300"
                                Operator="DataTypeCheck" Type="Currency" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv1_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv1">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <%-- --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label7" runat="server" Text="Spare Cost"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtSpareCost" runat="server" ValidationGroup="save"> </asp:TextBox>
                            <asp:CompareValidator ID="CV2" runat="server" ControlToValidate="txtSpareCost" Display="None"
                                ErrorMessage="Please enter numbers only." ForeColor="#CC3300" Operator="DataTypeCheck"
                                Type="Currency" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                TargetControlID="CV2">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                </div>
                <div id="RightForm" class="form2">
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            Current Custodian</div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtCustadian" runat="server" ValidationGroup="save" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="controlContainer" style="margin-top: 10px; height: 50px;">
                        <div class="leftControl">
                            <asp:Label ID="Label11" runat="server" Text="Problem"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtProblem" runat="server" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProblem"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save"> </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%-- --%>
                    <div class="controlContainer" style="margin-top: 10px; height: 50px;">
                        <div class="leftControl">
                            <asp:Label ID="Label12" runat="server" Text="Remark"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine"> </asp:TextBox>
                        </div>
                    </div>
                    <div style="clear: both; margin-bottom: 10px; width: 100%" align="center">
                    </div>
                </div>
                <div style="clear: both; margin-bottom: 10px; margin-left: 10px; width: 100%" align="center">
                    <asp:Button ID="btnSave" CssClass="btn" runat="server" Text=" Save " ValidationGroup="save"
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
