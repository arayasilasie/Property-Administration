using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using BLL;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace PropertyAdmin
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

            new CachingBusinessBLL();



        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

            // set up domain context
            //using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
            //{
            //    // find a user
            //    //HttpConext.Current.User
            //    //    Thread.CurrentPrincipal
            //    //        "(userPrincipalName=" & User.Identity.Name.Split("\".ToCharArray())(1) & ")"
            //    UserPrincipal user = UserPrincipal.FindByIdentity(ctx, User.Identity.Name);
            //    if (user != null)
            //    {
            //        Guid userGuid = user.Guid ?? Guid.Empty;
            //        Session["UserGuid"] = userGuid;
            //    }
            //}


            //string login = HttpContext.Current.User.Identity.Name;
            //string domain = login.Substring(0, login.IndexOf('\\'));
            //string userName = login.Substring(login.IndexOf('\\') + 1);
            //DirectoryEntry domainEntry = new DirectoryEntry("LDAP://" + domain);
            //DirectorySearcher searcher = new DirectorySearcher(domainEntry);
            //searcher.Filter = string.Format("(&(objectCategory=person)(objectClass=user)(sAMAccountName={0}))", userName);
            //SearchResult searchResult = searcher.FindOne();
            //DirectoryEntry entry = searchResult.GetDirectoryEntry();
            //Session["UserGuid"] = entry.Guid;


            //try
            //{
            //    string UserName = HttpContext.Current.User.Identity.Name.Remove(0, HttpContext.Current.User.Identity.Name.LastIndexOf(@"\") + 1);
            //    Guid? useguid= HttpContext.Current.Session["CurrentUserGuid"] as Guid?; 
                //dssearch = New System.DirectoryServices.AccountManagement.DirectoryServices.DirectorySearcher(cn);
                //currentUserGuid = HttpContext.Current.Session["CurrentUserGuid"] as Guid?;
                //System.DirectoryServices.AccountManagement.DirectoryEntry de = new DirectoryEntry(ConfigurationManager.AppSettings["DirPath"]);
            //    de.Username = ConfigurationManager.AppSettings["ACDUser"];
            //    de.Password = ConfigurationManager.AppSettings["ACDPass"];

            //    DirectorySearcher deSearch = new DirectorySearcher();
            //    deSearch.SearchRoot = de;

            //    deSearch.Filter = "(&(objectClass=user))";
            //    deSearch.SearchScope = SearchScope.Subtree;

            //    SearchResultCollection results = deSearch.FindAll();

            //    for (int i = 0; i < results.Count; i++)
            //    {
            //        if (results[i].GetDirectoryEntry().Properties["sAMAccountName"].Value.ToString().ToUpper() == UserName.ToUpper())
            //        {
            //            return results[i].GetDirectoryEntry().Guid;
            //        }
            //    }

            //    for (int i = 0; i < results.Count; i++)
            //    {
            //        if (results[i].GetDirectoryEntry().Name.Remove(0, 3).Replace(" ", ".").ToUpper() == UserName.ToUpper())
            //        {
            //            return results[i].GetDirectoryEntry().Guid;
            //        }
            //    }
            //    return null;
            //}
            //catch (Exception ex)
            //{
            ////    //ErrorHandler.WriteLogEntry(ex);
            ////    //return null;
            //}
        

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
