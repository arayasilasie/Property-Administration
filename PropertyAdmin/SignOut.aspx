<%@ Page Language="C#" MasterPageFile="~/Site.master"  AutoEventWireup="true" CodeBehind="SignOut.aspx.cs" Inherits="PropertyAdmin.SignOut" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Header</title>
    <script language="javascript">
//        if (self.location == top.location) self.location = "SignOut.aspx";


        function Logout() {
            try {
                if (window.XMLHttpRequest) {
                    alert("You have been logged off from this website. Note that if you run Internet Explorer 6.0 without Service Pack 1 you need to close all browser windows in order to complete the log off process.");
                    document.execCommand("ClearAuthenticationCache", "false");


                    if (top.location != location) {
                        top.location.href = ".";
                    }
                }
                else {
                    alert("This feature requires Internet Explorer 6.0 Service Pack 1 or above. " + "Please close all browser windows in order to complete the logout process.");
                }
            }
            catch (e) {
                alert("This feature requires Internet Explorer 6.0 Service Pack 1 or above. " + "Please close all browser windows in order to complete the logout process.");
            }
        }
    </script>
<%--    <link href="styles/StyleSheet.css" rel="stylesheet" type="text/css" />--%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent" >
    <div style="position:inherit absolute; width:99%; text-align:center; left: 0px; top: 54px; z-index: 100;">
      
        <asp:Label ID="Label1" runat="server" Text="You have already logged Out of your account. Please log in to continue!!"></asp:Label>
       
        <br> 
        <asp:HyperLink ID="HyperLink1" runat="server" Style="z-index: 102; right: 10px;
            top: 0px" Width="40px" Visible="true" Text="Login" NavigateUrl="~/Login.aspx"></asp:HyperLink>
    </div>
    </asp:Content>
    <%--</div></form>
</body>
</html>--%>
