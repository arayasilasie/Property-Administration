<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestTransaction.aspx.cs" Inherits="PropertyAdmin.TestTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnTest" runat="server" onclick="btnTest_Click" Text="Test" />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:myDatabaseConnectionString %>" 
        SelectCommand="SELECT * FROM [Test]"></asp:SqlDataSource>
</asp:Content>
