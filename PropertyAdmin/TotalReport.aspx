<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="TotalReport.aspx.cs" Inherits="PropertyAdmin.TotalReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register assembly="ActiveReports.Web, Version=6.0.2250.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff" namespace="DataDynamics.ActiveReports.Web" tagprefix="ActiveReportsWeb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="titleSub2">
            <asp:Label ID="Label6" runat="server" Text=" Fixed Asset Registry Report by Branch"></asp:Label></div>
    <div>
        <table>
            <tr>
                <td>  <asp:Label ID="Lblitem" runat="server" Text="Item"></asp:Label></td>
                <td><asp:TextBox ID="Txtitem" runat="server"></asp:TextBox></td>     
                <td> <asp:Label ID="Lblprice" runat="server" Text="Price"></asp:Label></td>
                <td><asp:TextBox ID="Txtprice" runat="server"></asp:TextBox></td>        
            </tr>
            <tr>
                <td><asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" /></td>
            </tr>
        </table>

    </div>

    <div>
        
    <ActiveReportsWeb:WebViewer ID="WebViewer1" runat="server" height="46" 
        width="345">
    </ActiveReportsWeb:WebViewer>
   

    </div>
</asp:Content>