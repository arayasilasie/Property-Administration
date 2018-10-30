<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FixedAssetCard.aspx.cs" Inherits="PropertyAdmin.FixedAssetCard" %>

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
                    </div>
                    <div class="rightControl">
                    </div>
                </div>
            </div>
            <div id="Div2" class="form" style="float: left; margin-bottom: 10px;">
                <div class="controlContainer" style="margin-top: 10px; margin-left">
                    <div class="leftControl">
                        <asp:Label ID="Label21" runat="server" Text="Item"></asp:Label>
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
                    <div class="rightControl" style="float: right;">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                            ValidationGroup="search" CssClass="btn" />
                    </div>
                </div>
            </div>
            <div style="clear: both; margin: 1px;">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                <div style="padding-top: 5px;">
                    <asp:Label ID="lblSearchMessage" runat="server" Text=""></asp:Label>
                    <div style="padding-top: 5px;">
                        <asp:GridView ID="grvFixedAssetCard" runat="server" AllowPaging="True" CellPadding="4"
                            ForeColor="#333333" GridLines="None" PageSize="5" AutoGenerateColumns="False"
                            DataKeyNames="ID" OnPageIndexChanging="grvFixedAssetCard_PageIndexChanging" OnSelectedIndexChanged="grvFixedAssetCard_SelectedIndexChanged">
                            <EmptyDataTemplate>
                                <asp:Label ID="lbl" runat="server" Text="No data available."></asp:Label>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Select"
                                            ImageUrl="~/Images/Delete.png" Text="X" />
                                        <asp:ModalPopupExtender ID="btnDelete_ModalPopupExtender" runat="server" DynamicServicePath=""
                                            Enabled="True" TargetControlID="btnDelete" CancelControlID="btnNo" OkControlID="btnYes"
                                            PopupControlID="pnlConfirmation">
                                        </asp:ModalPopupExtender>
                                        <asp:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" ConfirmText=""
                                            Enabled="True" TargetControlID="btnDelete" DisplayModalPopupID="btnDelete_ModalPopupExtender">
                                        </asp:ConfirmButtonExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ItemType">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemType" Text='<%# Eval("ItemType") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem" Text='<%# Eval("Item") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Beg.Qty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuantity" Text='<%# Eval("BeginingQuantity") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cur.Qty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCurrentQuantity" Text='<%# Eval("CurrentQuantity") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Location">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation" Text='<%# Eval("Location") %>' runat="server"></asp:Label>
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
                </asp:Panel>
                    </Content>
                </asp:AccordionPane>
            </Panes>
        </asp:Accordion>
        <div class="titleSub2" style="width: 59%">
            <asp:Label ID="Label3" runat="server" Text="Fixed Asset Card"></asp:Label></div>
        <div id="MainForm" style="width: 60%">
            <div>
                <div id="LeftForm" class="form2" style="width: 90%">
                    <%--   --%>
                    <div class="controlContainer" style="margin-top: 10px">
                        <div class="leftControl">
                            <asp:Label ID="Label14" runat="server" Text="Item Type"></asp:Label>
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
                            <asp:Label ID="Label9" runat="server" Text="Item"></asp:Label>
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
                            <asp:Label ID="Label10" runat="server" Text="Begining Quantity"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtBeginingQuantity" runat="server" ValidationGroup="save">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtBeginingQuantity"
                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cv1" runat="server" ControlToValidate="txtBeginingQuantity"
                                Display="None" ErrorMessage="Please enter numbers only." ForeColor="#CC3300"
                                Operator="DataTypeCheck" Type="Double" ValidationGroup="save"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="Cv1_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="Cv1">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px; height: 50px;">
                        <div class="leftControl">
                            <asp:Label ID="Label11" runat="server" Text="Location"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtLocation" runat="server" TextMode="MultiLine">
                            </asp:TextBox>
                        </div>
                    </div>
                    <%--  --%>
                    <div class="controlContainer" style="margin-top: 10px; height: 50px;">
                        <div class="leftControl">
                            <asp:Label ID="Label12" runat="server" Text="Remark"></asp:Label>
                        </div>
                        <div class="rightControl">
                            <asp:TextBox ID="txtRemark" runat="server" ValidationGroup="btnSave" TextMode="MultiLine">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="controlContainer">
                        <div class="leftControl">
                        </div>
                        <div class="rightControl">
                        </div>
                    </div>
                </div>
                <div style="clear: both; margin-bottom: 10px; margin-left: 10px; width: 100%" align="center">
                                                    <asp:Button ID="btnSave" runat="server" Text=" Save " CssClass="btn" ValidationGroup="save" OnClick="btnSave_Click" />
                            
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
