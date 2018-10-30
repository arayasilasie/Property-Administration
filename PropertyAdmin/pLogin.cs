using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;
using System.Data;
using ECXERP.Business;
using System.DirectoryServices;

namespace ECXERP
{
    public partial class pLogin : System.Web.UI.Page
    {
        Security.User user = new ECXERP.Security.User();
        int Index = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                LoadPage();
            }
        }
        /*protected void UserLogin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string UserName = UserLogin.UserName;
            string Password = UserLogin.Password;

            Guid UserGuid = Guid.Empty;
            ECXSecurityAccess.AuthenticationStatus AuStatus = new ECXSecurityAccess.ECXSecurityAccess().IsAuthenticated(
                HttpUtility.HtmlEncode(UserLogin.UserName), HttpUtility.HtmlEncode(UserLogin.Password), "", out UserGuid);

            if (AuStatus == ECXSecurityAccess.AuthenticationStatus.AccessGranted)
            {
                user.UserName = UserLogin.UserName;
                user.UniqueIdentifier = UserGuid;
                this.Session["LoggedUser"] = user;
                FormsAuthentication.RedirectFromLoginPage(HttpUtility.HtmlEncode(UserLogin.UserName), false);

                if (FormsAuthentication.GetRedirectUrl(HttpUtility.HtmlEncode(UserLogin.UserName), false) == "/default.aspx" ||
                    FormsAuthentication.GetRedirectUrl(user.UserName, false) == "/Login.aspx")
                {
                    this.Response.Redirect("~/pHome.aspx");
                }
                else
                {
                    this.Response.Redirect("~/pHome.aspx");
                }
            }





         
        }*/
        protected void UserLogin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string UserName = UserLogin.UserName;
            string Password = UserLogin.Password;

            Guid UserGuid = Guid.Empty;
            ECXSecurityAccess.AuthenticationStatus AuStatus = new ECXSecurityAccess.ECXSecurityAccess().IsAuthenticated(
                HttpUtility.HtmlEncode(UserLogin.UserName), UserLogin.Password, "", out UserGuid);

            if (AuStatus == ECXSecurityAccess.AuthenticationStatus.AccessGranted)
            {
                user.UserName = UserLogin.UserName;
                user.UniqueIdentifier = UserGuid;
                this.Session["LoggedUser"] = user;
                FormsAuthentication.RedirectFromLoginPage(HttpUtility.HtmlEncode(UserLogin.UserName), false);

                if (FormsAuthentication.GetRedirectUrl(HttpUtility.HtmlEncode(UserLogin.UserName), false) == "/default.aspx" ||
                    FormsAuthentication.GetRedirectUrl(user.UserName, false) == "/Login.aspx")
                {
                    this.Response.Redirect("~/pHome.aspx");
                }
                else
                {
                    this.Response.Redirect("~/pHome.aspx");
                }
            }





            /* SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
             SqlCommand command = new SqlCommand();
             SqlDataAdapter adapter = new SqlDataAdapter(command);
             command.Connection = connection;
             command.CommandType = CommandType.Text;
             command.CommandText = "SELECT * FROM UserAccount WHERE UserName ='" + UserName + "' AND Password ='" + Password + "'";
             DataTable tbl = new DataTable();
             try
             {
                 connection.Open();
                 command.ExecuteNonQuery();
                 adapter.Fill(tbl);
             }
             finally
             {
                 connection.Close();
                 command.Dispose();
             }
             if (tbl.Rows.Count == 1)
             {
                 DataRow r = tbl.Rows[0];
                 //DataTable tblEmployee = new CEmployee().GetRecord(new Guid(r["EmployeeGuid"].ToString()));
                 //if (tblEmployee.Rows.Count > 0)
                 //{
                 //    DataRow rEmployee = tblEmployee.Rows[0];
                 //    user.Name = rEmployee["Name"] + " " + rEmployee["FatherName"].ToString();
                 //}
                 user.UserName = r["UserName"].ToString();
                 user.UniqueIdentifier = new Guid(r["EmployeeGuid"].ToString());
                 this.Session["LoggedUser"] = user;

                 FormsAuthentication.RedirectFromLoginPage(user.UserName, false);
                 if (FormsAuthentication.GetRedirectUrl(user.UserName, false) == "/default.aspx" || FormsAuthentication.GetRedirectUrl(user.UserName, false) == "/Login.aspx")
                 {
                     this.Response.Redirect("~/pHome.aspx", false);
                 }
             }
             else
             {
                 Session["LoggedUser"] = "";
             }*/
        }
        private void LoadPage()
        {
            CAnonymousFeedback objFeedback = new CAnonymousFeedback();
            DataTable tblFeedback = objFeedback.GetAllFeedback();
            this.grvFeedback.DataSource = tblFeedback;
            this.grvFeedback.DataBind();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CAnonymousFeedback objAno = new CAnonymousFeedback();
            Int16? rdb1 = null; Int16? rdb2 = null; Int16? rdb3 = null; Int16? rdb4 = null; Int16? rdb5 = null; Int16? rdb6 = null; Int16? rdb7 = null;
            Int16? rdb8 = null; Int16? rdb9 = null; Int16? rdb10 = null; Int16? rdb11 = null; Int16? rdb12 = null; Int16? rdb13 = null; Int16? rdb14 = null;
            Int16? rdb15 = null; Int16? rdb16 = null; Int16? rdb17 = null; Int16? rdb18 = null; Int16? rdb19 = null; Int16? rdb20 = null; Int16? rdb21 = null;
            Int16? rdb22 = null; Int16? rdb23 = null; Int16? rdb24 = null; Int16? rdb25 = null; Int16? rdb26 = null; Int16? rdb27 = null; Int16? rdb28 = null;
            Int16? rdb29 = null; Int16? rdb30 = null; Int16? rdb31 = null; Int16? rdb32 = null; Int16? rdb33 = null; Int16? rdb34 = null; Int16? rdb35 = null;

            if (IsValidInput())
            {
                if (rdblist1.SelectedValue != "")
                {
                    rdb1 = Convert.ToInt16(rdblist1.SelectedValue);
                }
                if (rdblist2.SelectedValue != "")
                {
                    rdb2 = Convert.ToInt16(rdblist2.SelectedValue);
                }
                if (rdblist3.SelectedValue != "")
                {
                    rdb3 = Convert.ToInt16(rdblist3.SelectedValue);
                }
                if (rdblist4.SelectedValue != "")
                {
                    rdb4 = Convert.ToInt16(rdblist4.SelectedValue);
                }
                if (rdblist5.SelectedValue != "")
                {
                    rdb5 = Convert.ToInt16(rdblist5.SelectedValue);
                }
                if (rdblist6.SelectedValue != "")
                {
                    rdb6 = Convert.ToInt16(rdblist6.SelectedValue);
                }
                if (rdblist7.SelectedValue != "")
                {
                    rdb7 = Convert.ToInt16(rdblist7.SelectedValue);
                }
                if (rdblist8.SelectedValue != "")
                {
                    rdb8 = Convert.ToInt16(rdblist8.SelectedValue);
                }
                if (rdblist9.SelectedValue != "")
                {
                    rdb9 = Convert.ToInt16(rdblist9.SelectedValue);
                }
                if (rdblist10.SelectedValue != "")
                {
                    rdb10 = Convert.ToInt16(rdblist10.SelectedValue);
                }
                if (rdblist11.SelectedValue != "")
                {
                    rdb11 = Convert.ToInt16(rdblist11.SelectedValue);
                }
                if (rdblist12.SelectedValue != "")
                {
                    rdb12 = Convert.ToInt16(rdblist12.SelectedValue);
                }
                if (rdblist13.SelectedValue != "")
                {
                    rdb13 = Convert.ToInt16(rdblist13.SelectedValue);
                }
                if (rdblist14.SelectedValue != "")
                {
                    rdb14 = Convert.ToInt16(rdblist14.SelectedValue);
                }
                if (rdblist15.SelectedValue != "")
                {
                    rdb15 = Convert.ToInt16(rdblist15.SelectedValue);
                }
                if (rdblist16.SelectedValue != "")
                {
                    rdb16 = Convert.ToInt16(rdblist16.SelectedValue);
                }
                if (rdblist17.SelectedValue != "")
                {
                    rdb17 = Convert.ToInt16(rdblist17.SelectedValue);
                }
                if (rdblist18.SelectedValue != "")
                {
                    rdb18 = Convert.ToInt16(rdblist18.SelectedValue);
                }
                if (rdblist19.SelectedValue != "")
                {
                    rdb19 = Convert.ToInt16(rdblist19.SelectedValue);
                }
                if (rdblist20.SelectedValue != "")
                {
                    rdb20 = Convert.ToInt16(rdblist20.SelectedValue);
                }
                if (rdblist21.SelectedValue != "")
                {
                    rdb21 = Convert.ToInt16(rdblist21.SelectedValue);
                }
                if (rdblist22.SelectedValue != "")
                {
                    rdb22 = Convert.ToInt16(rdblist22.SelectedValue);
                }
                if (rdblist23.SelectedValue != "")
                {
                    rdb23 = Convert.ToInt16(rdblist23.SelectedValue);
                }
                if (rdblist24.SelectedValue != "")
                {
                    rdb24 = Convert.ToInt16(rdblist24.SelectedValue);
                }
                if (rdblist25.SelectedValue != "")
                {
                    rdb25 = Convert.ToInt16(rdblist25.SelectedValue);

                }
                if (rdblist26.SelectedValue != "")
                {
                    rdb26 = Convert.ToInt16(rdblist26.SelectedValue);
                }
                if (rdblist27.SelectedValue != "")
                {
                    rdb27 = Convert.ToInt16(rdblist27.SelectedValue);
                }
                if (rdblist28.SelectedValue != "")
                {
                    rdb28 = Convert.ToInt16(rdblist28.SelectedValue);
                }
                if (rdblist29.SelectedValue != "")
                {
                    rdb29 = Convert.ToInt16(rdblist29.SelectedValue);
                }
                if (rdblist30.SelectedValue != "")
                {
                    rdb30 = Convert.ToInt16(rdblist30.SelectedValue);
                }
                if (rdblist31.SelectedValue != "")
                {
                    rdb31 = Convert.ToInt16(rdblist31.SelectedValue);
                }
                if (rdblist32.SelectedValue != "")
                {
                    rdb32 = Convert.ToInt16(rdblist32.SelectedValue);
                }
                if (rdblist33.SelectedValue != "")
                {
                    rdb33 = Convert.ToInt16(rdblist33.SelectedValue);
                }
                if (rdblist34.SelectedValue != "")
                {
                    rdb34 = Convert.ToInt16(rdblist34.SelectedValue);
                }
                if (rdblist35.SelectedValue != "")
                {
                    rdb35 = Convert.ToInt16(rdblist35.SelectedValue);
                }

                if (objAno.Insert(HttpUtility.HtmlEncode(txtPrime.Text), rdb1, rdb2, rdb3, rdb4, rdb5, rdb6, rdb7, rdb8, rdb9, rdb10, rdb11, rdb12, rdb13, rdb14, rdb15,
                                 rdb16, rdb17, rdb18, rdb19, rdb20, rdb21, rdb22, rdb23, rdb24, rdb25, rdb26, rdb27, rdb28, rdb29, rdb3, rdb31, rdb32, rdb33, rdb34, rdb35,
                                HttpUtility.HtmlEncode(txtEmployerName.Text), HttpUtility.HtmlEncode(txtPosLoc.Text), HttpUtility.HtmlEncode(txtPosTitle.Text),
                                HttpUtility.HtmlEncode(txtPosNature.Text), HttpUtility.HtmlEncode(txtPosSalary.Text), HttpUtility.HtmlEncode(txtNewOffer.Text),
                                HttpUtility.HtmlEncode(txtComment.Text)) == 1)
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "Thank you for your honest feedback!!!";
                }
            }
            else
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Sorry it is not a feedback! Please Try Again!";
            }
        }
        protected void grvFeedback_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Index = e.NewEditIndex;
            LoadForEdit(Index);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Show()", true);
        }
        
        private void LoadForEdit(int index)
        {
            try
            {
                //this.Reset();
                DataTable tblData = new CAnonymousFeedback().GetFeedback(new Guid(this.grvFeedback.DataKeys[Index].Value.ToString()));
                if (tblData.Rows.Count > 0)
                {
                    DataRow rData = tblData.Rows[0];
                    #region LoadData
                    txtPrime.Text = rData["PrimaryReason"].ToString();

                    rdblist1.SelectedValue = rData["TypeOfWork"].ToString();
                    if (rdblist1.SelectedValue != "")
                    {
                        rdblist1.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }

                    rdblist2.SelectedValue = rData["WorkingCondition"].ToString();
                    if (rdblist2.SelectedValue != "")
                    {
                        rdblist2.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist3.SelectedValue = rData["PayBenefits"].ToString();
                    if (rdblist3.SelectedValue != "")
                    {
                        rdblist3.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist4.SelectedValue = rData["SupervisorLeadership"].ToString();
                    if (rdblist4.SelectedValue != "")
                    {
                        rdblist4.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist5.SelectedValue = rData["NatureOfTheJob"].ToString();
                    if (rdblist5.SelectedValue != "")
                    {
                        rdblist5.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist6.SelectedValue = rData["Location"].ToString();
                    if (rdblist6.SelectedValue != "")
                    {
                        rdblist6.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist7.SelectedValue = rData["RateTypeOfWork"].ToString();
                    if (rdblist7.SelectedValue != "")
                    {
                        rdblist7.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist8.SelectedValue = rData["RateSalary"].ToString();
                    if (rdblist8.SelectedValue != "")
                    {
                        rdblist8.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist9.SelectedValue = rData["RateworkingCondition"].ToString();
                    if (rdblist9.SelectedValue != "")
                    {
                        rdblist9.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist10.SelectedValue = rData["RateEquipmentProvided"].ToString();
                    if (rdblist10.SelectedValue != "")
                    {
                        rdblist10.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist11.SelectedValue = rData["RateColleagues"].ToString();
                    if (rdblist11.SelectedValue != "")
                    {
                        rdblist11.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist12.SelectedValue = rData["RateSupervisor"].ToString();
                    if (rdblist12.SelectedValue != "")
                    {
                        rdblist12.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist13.SelectedValue = rData["RateLevelOfInput"].ToString();
                    if (rdblist13.SelectedValue != "")
                    {
                        rdblist13.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist14.SelectedValue = rData["ORGRecruitmentProcess"].ToString();
                    if (rdblist14.SelectedValue != "")
                    {
                        rdblist14.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist15.SelectedValue = rData["ORGEmployeeOrientation"].ToString();
                    if (rdblist15.SelectedValue != "")
                    {
                        rdblist15.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist16.SelectedValue = rData["ORGTrainingOpportunities"].ToString();
                    if (rdblist16.SelectedValue != "")
                    {
                        rdblist16.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist17.SelectedValue = rData["ORGCareerDevtOpp"].ToString();
                    if (rdblist17.SelectedValue != "")
                    {
                        rdblist17.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist18.SelectedValue = rData["ORGEmployeeMorale"].ToString();
                    if (rdblist18.SelectedValue != "")
                    {
                        rdblist18.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist19.SelectedValue = rData["ORGFairTreatement"].ToString();
                    if (rdblist19.SelectedValue != "")
                    {
                        rdblist19.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist20.SelectedValue = rData["ORGJobRecognition"].ToString();
                    if (rdblist20.SelectedValue != "")
                    {
                        rdblist20.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist21.SelectedValue = rData["ORGCommunication"].ToString();
                    if (rdblist21.SelectedValue != "")
                    {
                        rdblist21.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist22.SelectedValue = rData["ORGPerformanceEval"].ToString();
                    if (rdblist22.SelectedValue != "")
                    {
                        rdblist22.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist23.SelectedValue = rData["ORGCustomerService"].ToString();
                    if (rdblist23.SelectedValue != "")
                    {
                        rdblist23.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist24.SelectedValue = rData["ORGConcernForExcellence"].ToString();
                    if (rdblist24.SelectedValue != "")
                    {
                        rdblist24.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist25.SelectedValue = rData["ORGAdminPolices"].ToString();
                    if (rdblist25.SelectedValue != "")
                    {
                        rdblist25.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist26.SelectedValue = rData["SUPUsableFeedback"].ToString();
                    if (rdblist26.SelectedValue != "")
                    {
                        rdblist26.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist27.SelectedValue = rData["SUPRecognizeAccomplishement"].ToString();
                    if (rdblist27.SelectedValue != "")
                    {
                        rdblist27.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist28.SelectedValue = rData["SUPFairTreatement"].ToString();
                    if (rdblist28.SelectedValue != "")
                    {
                        rdblist28.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist29.SelectedValue = rData["SUPTrained"].ToString();
                    if (rdblist29.SelectedValue != "")
                    {
                        rdblist29.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist30.SelectedValue = rData["SUPProvodedLeadership"].ToString();
                    if (rdblist30.SelectedValue != "")
                    {
                        rdblist30.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist31.SelectedValue = rData["SUPEncourageTeamWork"].ToString();
                    if (rdblist31.SelectedValue != "")
                    {
                        rdblist31.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist32.SelectedValue = rData["SUPResolvedConcern"].ToString();
                    if (rdblist32.SelectedValue != "")
                    {
                        rdblist32.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist33.SelectedValue = rData["SUPListened"].ToString();
                    if (rdblist33.SelectedValue != "")
                    {
                        rdblist33.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist34.SelectedValue = rData["SUPInform"].ToString();
                    if (rdblist34.SelectedValue != "")
                    {
                        rdblist34.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    rdblist35.SelectedValue = rData["SUPAppropriateAssign"].ToString();
                    if (rdblist35.SelectedValue != "")
                    {
                        rdblist35.SelectedItem.Attributes.Add("style", "color:#ee0930; font-weight:Bold;");
                    }
                    txtEmployerName.Text = rData["NewEmployerName"].ToString();
                    //if(txtEmployerName.Text != "")
                    //{
                    //    txtEmployerName.BorderColor = Color.DeepPink;
                    //}
                    txtPosLoc.Text = rData["LocationOfPosition"].ToString();
                    //if (txtPosLoc.Text != "")
                    //{
                    //    txtPosLoc.BorderColor = Color.DeepPink;
                    //}
                    txtPosTitle.Text = rData["PositionTitle"].ToString();
                    //if (txtPosTitle.Text != "")
                    //{
                    //    txtPosTitle.BorderColor = Color.DeepPink;
                    //}
                    txtPosNature.Text = rData["NatureOfPosition"].ToString();
                    //if (txtPosNature.Text != "")
                    //{
                    //    txtPosNature.BorderColor = Color.DeepPink;
                    //}
                    txtPosSalary.Text = rData["SalaryOfPosition"].ToString();
                    //if (txtPosSalary.Text != "")
                    //{
                    //    txtPosSalary.BorderColor = Color.DeepPink;
                    //}
                    txtNewOffer.Text = rData["NewORGOffer"].ToString();
                    //if (txtNewOffer.Text != "")
                    //{
                    //    txtNewOffer.BorderColor = Color.DeepPink;
                    //}
                    txtComment.Text = rData["AdditionalComment"].ToString();
                    //if (txtComment.Text != "")
                    //{
                    //    txtComment.BorderColor = Color.DeepPink;
                    //}
                    #endregion

                }

            }
            catch (Exception ex)
            {
                this.Session["Error"] = ex.Message;
                this.Response.Redirect("~/pError.aspx", false);
            }
        }
        private bool IsValidInput()
        {

            if (txtPrime.Text == "")
            {
                if (rdblist1.SelectedValue == "")
                {
                    if (rdblist2.SelectedValue == "")
                    {
                        if (rdblist3.SelectedValue == "")
                        {
                            if (rdblist4.SelectedValue == "")
                            {
                                if (rdblist5.SelectedValue == "")
                                {
                                    if (rdblist6.SelectedValue == "")
                                    {
                                        if (rdblist7.SelectedValue == "")
                                        {
                                            if (rdblist8.SelectedValue == "")
                                            {
                                                if (rdblist9.SelectedValue == "")
                                                {
                                                    if (rdblist10.SelectedValue == "")
                                                    {
                                                        if (rdblist11.SelectedValue == "")
                                                        {
                                                            if (rdblist12.SelectedValue == "")
                                                            {
                                                                if (rdblist13.SelectedValue == "")
                                                                {
                                                                    if (rdblist14.SelectedValue == "")
                                                                    {
                                                                        if (rdblist15.SelectedValue == "")
                                                                        {
                                                                            if (rdblist16.SelectedValue == "")
                                                                            {
                                                                                if (rdblist17.SelectedValue == "")
                                                                                {
                                                                                    if (rdblist18.SelectedValue == "")
                                                                                    {
                                                                                        if (rdblist19.SelectedValue == "")
                                                                                        {
                                                                                            if (rdblist20.SelectedValue == "")
                                                                                            {
                                                                                                if (rdblist21.SelectedValue == "")
                                                                                                {
                                                                                                    if (rdblist22.SelectedValue == "")
                                                                                                    {
                                                                                                        if (rdblist23.SelectedValue == "")
                                                                                                        {
                                                                                                            if (rdblist24.SelectedValue == "")
                                                                                                            {
                                                                                                                if (rdblist25.SelectedValue == "")
                                                                                                                {
                                                                                                                    if (rdblist26.SelectedValue == "")
                                                                                                                    {
                                                                                                                        if (rdblist27.SelectedValue == "")
                                                                                                                        {
                                                                                                                            if (rdblist28.SelectedValue == "")
                                                                                                                            {
                                                                                                                                if (rdblist29.SelectedValue == "")
                                                                                                                                {
                                                                                                                                    if (rdblist30.SelectedValue == "")
                                                                                                                                    {
                                                                                                                                        if (rdblist31.SelectedValue == "")
                                                                                                                                        {
                                                                                                                                            if (rdblist32.SelectedValue == "")
                                                                                                                                            {
                                                                                                                                                if (rdblist33.SelectedValue == "")
                                                                                                                                                {
                                                                                                                                                    if (rdblist34.SelectedValue == "")
                                                                                                                                                    {
                                                                                                                                                        if (rdblist35.SelectedValue == "")
                                                                                                                                                        {
                                                                                                                                                            if (txtEmployerName.Text == "")
                                                                                                                                                            {
                                                                                                                                                                if (txtPosLoc.Text == "")
                                                                                                                                                                {
                                                                                                                                                                    if (txtPosNature.Text == "")
                                                                                                                                                                    {
                                                                                                                                                                        if (txtPosSalary.Text == "")
                                                                                                                                                                        {
                                                                                                                                                                            if (txtPosTitle.Text == "")
                                                                                                                                                                            {
                                                                                                                                                                                if (txtNewOffer.Text == "")
                                                                                                                                                                                {
                                                                                                                                                                                    if (txtComment.Text == "")
                                                                                                                                                                                    {
                                                                                                                                                                                        return false;
                                                                                                                                                                                    }
                                                                                                                                                                                }
                                                                                                                                                                            }
                                                                                                                                                                        }
                                                                                                                                                                    }
                                                                                                                                                                }
                                                                                                                                                            }
                                                                                                                                                        }
                                                                                                                                                    }
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;

        }
        private void Reset()
        {
            #region Reset Control
            //rdblist1.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist2.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist3.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist4.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist5.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist6.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist7.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist8.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist9.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist10.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist11.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist12.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist13.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist14.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist15.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist16.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist17.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist18.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist19.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist20.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist21.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist22.Attributes.Add("style", "color:#000000; font-weight:normal;");

            //rdblist23.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist24.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist25.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist26.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist27.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist28.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist29.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist30.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist31.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist32.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist33.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist34.Attributes.Add("style", "color:#000000; font-weight:normal;");
            //rdblist35.Attributes.Add("style", "color:#000000; font-weight:normal;");

            //txtEmployerName.BorderColor = Color.Black;
            //txtPosLoc.BorderColor = Color.Black;
            //txtPosTitle.BorderColor = Color.Black;
            //txtPosNature.BorderColor = Color.Black;
            //txtPosSalary.BorderColor = Color.Black;
            //txtNewOffer.BorderColor = Color.Black;
            //txtComment.BorderColor = Color.Black;
            #endregion
        }
        private void LoadPage_ForLeave()
        {
            //int count = 0;
            //try
            //{
            //    //DataTable tbl = new CLeave().GetRecordsToBeApproved(((Security.User)this.Session["LoggedUser"]).UniqueIdentifier,true);
            //    //if (tbl.Rows.Count > 0)
            //    //{
            //    //    foreach (DataRow r in tbl.Rows)
            //    //    {
            //    //        if (r["ManagerApprovedDate"] == DBNull.Value)
            //    //        {
            //    //            count++;
            //    //        }
            //    //    }
            //    //}
            //    //lblTotalLeaveRequest.Text = "(" + count.ToString() + ")";
            //}
            //catch (Exception ex)
            //{
            //    this.Session["Error"] = ex.Message;
            //    this.Response.Redirect("~/pError.aspx", false);
            //}
        }

        protected void lbLogin_Click(object sender, EventArgs e)
        {
            //pnlLog.Visible = true;
        }

        protected void imgbtn_Click(object sender, EventArgs e)
        {
            //pnlLog.Visible = false;
        }
    }   
}

                   
