<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="LookUp.aspx.cs" Inherits="PropertyAdmin.LookUp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="Messages.ascx" TagName="Messages" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        /*   .MyTabStyle .ajax__tab_header
        {
            font-family: "Helvetica Neue" , Arial, Sans-Serif;
            font-size: 14px;
            font-weight:bold;
            display: block;

        }
        .MyTabStyle .ajax__tab_header .ajax__tab_outer
        {
            border-color: #222;
            color: #222;
            padding-left: 10px;
            margin-right: 3px;
            border:solid 1px #d7d7d7;
        }
        .MyTabStyle .ajax__tab_header .ajax__tab_inner
        {
            border-color: #666;
            color: #666;
            padding: 3px 10px 2px 0px;
        }
        .MyTabStyle .ajax__tab_hover .ajax__tab_outer
        {
            background-color:#9c3;
        }
        .MyTabStyle .ajax__tab_hover .ajax__tab_inner
        {
            color: #fff;
        }
        .MyTabStyle .ajax__tab_active .ajax__tab_outer
        {
            border-bottom-color: #ffffff;
            background-color: #d7d7d7;
        }
        .MyTabStyle .ajax__tab_active .ajax__tab_inner
        {
            color: #000;
            border-color: #333;
        }
        .MyTabStyle .ajax__tab_body
        {
            font-family: verdana,tahoma,helvetica;
            font-size: 10pt;
            background-color: #fff;
            border-top-width: 0;
            border: solid 1px #d7d7d7;
            border-top-color: #ffffff;
        }
        */
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
        .leftContent2
        {
            margin: 3px; /*border: 1px solid #FDBF12;*/
            padding: 10px;
            float: left;
            overflow: auto;
        }
        
        .blue {

border: 1px solid #09B;

}
        .tab
        {
            border: 1px solid #DDD;
        }
        
        .tab .ajax__tab_body
        {
            padding: 10px;
        }
        
       .tab  .ajax__tab_header
        {
            font-family: Tahoma;
            text-transform: uppercase;
            font-size: 12px;
            font-weight: bold;
            background: #F5F5F5;
            border-bottom: 1px solid #bbb;
            border-top: 1px solid #BBB;
        }
        
      .tab .ajax__tab_header .ajax__tab_active .ajax__tab_outer
        {
            height: 21px;
            background: #fff;
        }
        
        .tab .ajax__tab_header .ajax__tab_active .ajax__tab_tab
        {
            background: #fff;
            height: 18px;
            padding: 5px 7px 5px 7px;
            margin: 0px;
            border: 0;
            color: #333;
        }
        
          .tab .ajax__tab_header .ajax__tab_active .ajax__tab_inner
        {
            padding-left: 3px;
            background: #fff;
            border-right: 1px solid #bbb;
            border-left: 1px solid #bbb;
            border-bottom: 0;
        }
        
        .tab .ajax__tab_tab
        {
            padding: 7px;
            color: #333;
            border-right: 1px solid #bbb;
            border-left: 1px solid #bbb;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="3" Height="380px"
            CssClass="tab" Width="420px">
            <asp:TabPanel runat="server" HeaderText="Item Type" ID="TabPanel1">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="leftContent2">
                                <div class="content">
                                    <table border="0">
                                        <tr>
                                            <td class="style5">
                                                Item Type
                                            </td>
                                            <td class="style5">
                                                <asp:TextBox ID="txtItemTypeCode" runat="server" ValidationGroup="save">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                Description
                                            </td>
                                            <td class="style5">
                                                <asp:TextBox ID="txtItemTypeDes" runat="server" ValidationGroup="save">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="style4">
                                            <td class="style7">
                                            </td>
                                            <td class="style7">
                                                <asp:Button ID="btnSaveItemType" CssClass="btn" runat="server" Text=" Save " 
                                                    ValidationGroup="save" onclick="btnSaveItemType_Click" />
                                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn" 
                        onclick="btnCancel_Click" Text="Cancel" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Item">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="leftContent2">
                                <div class="content">
                                    <table border="0">
                                        <tr>
                                            <td class="style4">
                                                Item Type
                                            </td>
                                            <td class="style4">
                                                <asp:DropDownList ID="ddlItemType" runat="server" Width="140px" AppendDataBoundItems="True"
                                                    ValidationGroup="save">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style4">
                                                Unit
                                            </td>
                                            <td class="style4">
                                                <asp:DropDownList ID="ddUnit" runat="server" Width="140px" AppendDataBoundItems="True"
                                                    ValidationGroup="save">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                Item
                                            </td>
                                            <td class="style5">
                                                <asp:TextBox ID="txtItemCode" runat="server" ValidationGroup="save">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                Item Description
                                            </td>
                                            <td class="style5">
                                                <asp:TextBox ID="txtItemDesc" runat="server" ValidationGroup="save">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="style4">
                                            <td class="style7">
                                            </td>
                                            <td class="style7">
                                                <asp:Button ID="btnSaveItem" CssClass="btn" runat="server" Text=" Save " 
                                                    ValidationGroup="save" onclick="btnSaveItem_Click" />

                                                    <asp:Button ID="Button3" runat="server" CssClass="btn" 
                        onclick="btnCancel_Click" Text="Cancel" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Supplier">
                <HeaderTemplate>
                    Reqeust Type
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <div class="leftContent2">
                                <div class="content">
                                    <table border="0">
                                       <%-- <tr>
                                            <td class="style4">
                                                Name
                                            </td>
                                            <td class="style4">
                                                <asp:TextBox ID="txtSupName" runat="server" ValidationGroup="save">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style4">
                                                Email
                                            </td>
                                            <td class="style4">
                                                <asp:TextBox ID="txtSupEmail" runat="server" ValidationGroup="save">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                Address
                                            </td>
                                            <td class="style5">
                                                <asp:TextBox ID="txtSupAddres" runat="server" ValidationGroup="save" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td class="style5">
                                                Description
                                            </td>
                                            <td class="style5">
                                                <asp:TextBox ID="txtReqdesc" runat="server" ValidationGroup="save"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="style4">
                                            <td class="style7">
                                            </td>
                                            <td class="style7">
                                                <asp:Button ID="Button2" CssClass="btn" runat="server" Text=" Save " ValidationGroup="save" 
                                                    onclick="Button2_Click" />

                                                    <asp:Button ID="Button4" runat="server" CssClass="btn" 
                        onclick="btnCancel_Click" Text="Cancel" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="Request Type">
                <HeaderTemplate>
                    Supplier
                </HeaderTemplate>
             <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <div class="leftContent2">
                                <div class="content">
                                    <table border="0">
                                        <%--<tr>
                                            <td class="style4">
                                                Name
                                            </td>
                                            <td class="style4">
                                                <asp:TextBox ID="Txtsupname" runat="server" ValidationGroup="save"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style4">
                                                Email
                                            </td>
                                            <td class="style4">
                                                <asp:TextBox ID="Txtsupemail" runat="server" ValidationGroup="save"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                Address
                                            </td>
                                            <td class="style5">
                                                <asp:TextBox ID="txtsupadd" runat="server" ValidationGroup="save" 
                                                    TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td class="style5">
                                                Description
                                            </td>
                                            <td class="style5">
                                                <asp:TextBox ID="txtsupdesc" runat="server" ValidationGroup="save" 
                                                    TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="style4">
                                            <td class="style7">
                                            </td>
                                            <td class="style7">
                                                <asp:Button ID="Button1" CssClass="btn" runat="server" Text=" Save " 
                                                    ValidationGroup="save" onclick="Button1_Click" />
                                                <asp:Button ID="Button5" runat="server" CssClass="btn" onclick="btnCancel_Click" Text="Cancel" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
    </p>
</asp:Content>
