<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="PropertyAdmin.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<%--    <p><asp:label runat="server" ID="lblloggedout" Text="You have successfully logged Out. All your sessions are closed!!" Visible="false"></asp:label></p>
<p><asp:label runat="server" ID="lblloggedout2" Text="Please log in to further process . . . " Visible="false"></asp:label></p>--%>
    
    <div>
    <table width="100%">
    <tr>
    <td align="center">
    <%--<asp:Login ID="LoginUser" runat="server" EnableViewState="false" BackColor="#ACBA82" TitleTextStyle-ForeColor="White" TitleTextStyle-Font-Size="Large" 
         TextBoxStyle-BackColor="#E9EEDE" LoginButtonStyle-BackColor="#E9EEDE"  
             Font-Names="Arial" Font-Size="Medium" DisplayRememberMe="false"  BorderStyle="Solid" BorderWidth="2px" BorderColor="White">--%>
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>
        <asp:Label ID="loginfailLbl" runat="server" Text="" CssClass="failureNotification" ></asp:Label>
            <div class="accountInfo">
            
<%--                <fieldset class="login">
                    <legend>Account Information</legend>--%>
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtUserName">Username:</asp:Label>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUserName" 
                             CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="txtPassword">Password:</asp:Label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword" 
                             CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:CheckBox ID="RememberMe" runat="server"/>
                        <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Keep me logged in</asp:Label>
                    </p>
                <%--</fieldset>--%>
                <p class="submitButton">
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup" OnClick="LoginButton_Login"/>
                </p>
            </div>
     </LayoutTemplate>
     <%--  </asp:Login>--%>
    </td>
    </tr>
    </table>
    </div>
</asp:Content>
