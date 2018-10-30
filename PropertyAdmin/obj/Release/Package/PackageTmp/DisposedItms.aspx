<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="DisposedItms.aspx.cs" Inherits="PropertyAdmin.DisposedItms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="titleSub2">
            <asp:Label ID="Label6" runat="server" Text=" Disposed Fixed Assets Report by Date"></asp:Label></div>
    <div>
        <table>
           <%-- <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Report Disposed Items By Date"></asp:Label></td>

            </tr>--%>
            <tr>
                <td>  <asp:Label ID="Lblitem" runat="server" Text="Item"></asp:Label></td>
                <td><asp:TextBox ID="Txtitem" runat="server"></asp:TextBox></td>   
            </tr>
            <tr>  
                <td> <asp:Label ID="Lbldt" runat="server" Text="Date Between"></asp:Label></td>
                <td><asp:TextBox ID="Txtdt1" runat="server"></asp:TextBox></td>        
                <td><asp:TextBox ID="Txt2" runat="server"></asp:TextBox></td>        
            </tr>
            <tr>
                <td><asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" /></td>
            </tr>
        </table>

    </div>
</asp:Content>