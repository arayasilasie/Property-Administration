using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PropertyAdmin
{
    public partial class SignOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClearAll();
            ClientScriptManager cm = Page.ClientScript;
            //string cbReference = cm.GetCallbackEventReference(this, "arg", "HandleResult", "");
            //string cbScript = "function CallServer(arg, context){" + cbReference + ";}";
            //cm.RegisterClientScriptBlock(this.GetType(), "CallServer", cbScript, true);
            //cm.RegisterStartupScript(this.GetType(), "cle", "windows.history.clear", true);
            if(Request.QueryString["loggedout"]=="true")
                Response.Redirect("/login.aspx?loggedout=true");

        }
        protected void Page_Init(object sender, EventArgs e)
        {
            ClearAll();
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