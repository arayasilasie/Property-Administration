<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="FARReport.aspx.cs" Inherits="PropertyAdmin.FARReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titleSub2">
            <asp:Label ID="Label6" runat="server" Text=" Fixed Asset Registry Report"></asp:Label></div>

    <div>

          <asp:Panel ID="PanelSearch3" runat="server">
                            <fieldset style="border: 1px solid #FDBF12;">
                                <div class="titleSub3">
                                    <asp:Label ID="Label1" runat="server" Text="Search:"></asp:Label></div>
                                <div id="Div1" class="form" style="float: left; margin-right: 35px; margin-top: 0;
                                    margin-bottom: 10px">
                                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                                        <div class="leftControl">
                                            <asp:Label ID="Label18" runat="server" Text="Item Type"></asp:Label>
                                        </div>
                                        <div class="rightControl">
                                            <asp:DropDownList ID="ddlSItemType" runat="server" AutoPostBack="True" Width="140px"
                                                OnSelectedIndexChanged="ddlSItemType_SelectedIndexChanged" AppendDataBoundItems="True"
                                                ValidationGroup="search">
                                                <asp:ListItem Value="">Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <%--  --%>
                                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                                        <div class="leftControl">
                                            <asp:Label ID="Label19" runat="server" Text="Item"></asp:Label>
                                        </div>
                                        <div class="rightControl">
                                            <asp:DropDownList ID="ddlSItem" runat="server" Width="140px" AppendDataBoundItems="True"
                                                ValidationGroup="search" Style="margin-bottom: 0px">
                                                <asp:ListItem Value="">Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                                        <div class="leftControl">
                                        </div>
                                        <div class="rightControl">
                                            <asp:Button ID="btnSearch0" runat="server" CssClass="btn" OnClick="btnSearch_Click" Text="Search" ValidationGroup="search" />
                                        </div>
                                    </div>
                                </div>
                                <div id="Div2" class="form" style="float: left; margin-bottom: 10px;">
                                    <%--<div class="controlContainer" style="margin-top: 10px; margin-left">
                                        <div class="leftControl">
                                            <asp:Label ID="Label21" runat="server" Text="Received Date"></asp:Label>
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
                                    </div>--%>
                                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                                        <div class="leftControl"><asp:Label ID="Lblprice" runat="server" Text="Price"></asp:Label>
                                        </div>
                                        <div class="rightControl">
                                        <asp:TextBox ID="Txtprice" runat="server"></asp:TextBox>    
                                        </div>
                                    </div>
                                    <div class="controlContainer" style="margin-top: 10px; margin-left">
                                        <div class="leftControl">
                                        </div>
                                        <div class="rightControl" style="float: right;">
                                        </div>
                                    </div>
                                </div>
                               
                            </fieldset>
                        </asp:Panel>

        <%--<table>
            <tr>
                <td>  <asp:Label ID="Lblitem" runat="server" Text="Item"></asp:Label></td>
                <td><asp:TextBox ID="Txtitem" runat="server"></asp:TextBox></td>     
                <td> <asp:Label ID="Lblprice" runat="server" Text="Price"></asp:Label></td>
                <td><asp:TextBox ID="Txtprice" runat="server"></asp:TextBox></td>        
            </tr>
            <tr>
                <td><asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" /></td>
            </tr>
        </table>--%>

    </div>

      <div>
        
<%--    <ActiveReportsWeb:WebViewer ID="WebViewer1" runat="server" height="46" 
        width="345">
    </ActiveReportsWeb:WebViewer>--%>
   

          <asp:GridView ID="grvFARReport" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="label" 
        DataKeyNames="ID" GridLines="None" PageSize="30" 
        Style="font-size: small" Width="90%" >
        <Columns>
           <asp:TemplateField HeaderText="Current Custodian">
                <ItemTemplate>
                    <asp:Label ID="SRNo" runat="server" Text='<%# Bind("Custodian") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Model">
                <ItemTemplate>
                    <asp:Label ID="PRNo" runat="server" Text='<%# Bind("Model") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Item">
                <ItemTemplate>
                    <asp:Label ID="WorkUnit" runat="server" Text='<%# Bind("Item") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SNo">
                <ItemTemplate>
                    <asp:Label ID="Requestedby" runat="server" Text='<%# Bind("SNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TagNo">
                <ItemTemplate>
                    <asp:Label ID="Item" runat="server" Text='<%# Bind("TagNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
          <asp:TemplateField HeaderText="Location">
                <ItemTemplate>
                    <asp:Label ID="RequestType" runat="server" Text='<%# Bind("Location") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ReceivedDate">
                <ItemTemplate>
                    <asp:Label ID="Quantity" runat="server" Text='<%# Bind("ReceivedDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cost">
                <ItemTemplate>
                    <asp:Label ID="RequestedDate" runat="server" Text='<%# Bind("Cost") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
    

        </Columns>

          <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#FBE49F" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#88AB2D" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#e4efd0" />
    </asp:GridView>

    </div>

</asp:Content>
