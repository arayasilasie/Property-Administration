using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PropertyAdmin.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);

            if (Request.QueryString["loggedout"] == "true")
            {
                //lblloggedout.Visible = true;
                //lblloggedout2.Visible = true;
            }

            ClearAll();


        }

        protected void LoginButton_Login(object sender, EventArgs e)
        {
            string UsrName = txtUserName.Text;
            string Password = txtPassword.Text;

            Guid UserGuid = Guid.Empty;
            ECXSecurityAccess.AuthenticationStatus AuStatus = new ECXSecurityAccess.ECXSecurityAccess().IsAuthenticated(
                HttpUtility.HtmlEncode(UsrName), HttpUtility.HtmlEncode(Password), "", out UserGuid);

            //ECXSecurityAccess.ECXSecurityAccess.HasRights(System.Guid, string[], string);


            if (AuStatus == ECXSecurityAccess.AuthenticationStatus.AccessGranted)
            {
                Session["UserGuid"] = UserGuid;
                Response.Redirect("~/Custodian.aspx");

                //user.UserName = UserLogin.UserName;
                //user.UniqueIdentifier = UserGuid;
                //this.Session["LoggedUser"] = user;
                //FormsAuthentication.RedirectFromLoginPage(HttpUtility.HtmlEncode(UserLogin.UserName), false);

                //if (FormsAuthentication.GetRedirectUrl(HttpUtility.HtmlEncode(UserLogin.UserName), false) == "/default.aspx" ||
                //    FormsAuthentication.GetRedirectUrl(user.UserName, false) == "/Login.aspx")
                //{
                //    this.Response.Redirect("~/pHome.aspx");
                //}
                //else
                //{
                //    this.Response.Redirect("~/pHome.aspx");
                //}
            }
            else
            {
                loginfailLbl.Text = "Either your password or username is not correct. Please try again . . . ";
            }
        }

        void ClearAll()
        {
            Session.RemoveAll();
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();


        }

    }
}
