using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
using System.Data;
using BLL;
using System.Data.SqlClient;
using System.Configuration;
namespace PropertyAdmin
{
    public partial class TestTransaction : System.Web.UI.Page
    {
        BaseBLL bas = new BaseBLL();
        string WHConString = ConfigurationManager.ConnectionStrings["WarehouseConnectionString"].ToString();
        string PAConString = ConfigurationManager.ConnectionStrings["PropertyAdminConnectionString"].ToString();
        string myConString = ConfigurationManager.ConnectionStrings["myDatabaseConnectionString"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTest_Click2(object sender, EventArgs e)
        {
            int w = 0, p = 0;
            SqlParameter par;
            TransactionOptions option = new TransactionOptions();
            option.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            option.Timeout = new TimeSpan(0, 0, 60);
               try
                {
                    using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, option))
                    {
                        using (SqlConnection Wcon = new SqlConnection(WHConString))
                        {
                            using (SqlCommand cmd = new SqlCommand("AddTable_1"))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = Wcon;
                                Wcon.Open();
                                par = new SqlParameter("@ID", new Guid("000000000-0000-0000-0000-0000000000000"));
                                par.Direction = ParameterDirection.Input;
                                par.DbType = DbType.Guid;
                                par = new SqlParameter("@Name", "TEsting");
                                par.Direction = ParameterDirection.Input;
                                par.DbType = DbType.String;
                                cmd.Parameters.Add(par);
                                w = cmd.ExecuteNonQuery();
                                if (w > 0)
                                {
                                    using (SqlConnection Pcon = new SqlConnection(PAConString))
                                    {
                                        using (SqlCommand cmd2 = new SqlCommand("AddTable_1"))
                                        {
                                            cmd2.CommandType = CommandType.StoredProcedure;
                                            cmd2.Connection = Pcon;
                                            Pcon.Open();
                                            par = new SqlParameter("@ID", new Guid("000000000-0000-0000-0000-0000000000000"));
                                            par.Direction = ParameterDirection.Input;
                                            par.DbType = DbType.Guid;
                                            par = new SqlParameter("@Name", "TEsting");
                                            par.Direction = ParameterDirection.Input;
                                            par.DbType = DbType.String;
                                            cmd2.Parameters.Add(par);
                                            p = cmd2.ExecuteNonQuery();
                                            if (p > 0)
                                            {
                                                transaction.Complete();
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
                catch(Exception ex)
                {

                }

            //}
        }

        public void PerformSQLTrancation()
        {
            SqlTransaction transaction = null;
            SqlConnection con = null;
            SqlConnection con2 = null;

            // they will be used to decide whether to commit or rollback the transaction
            bool WHResult = false;
            bool PAResult = false;

            try
            {
                con = new SqlConnection(WHConString);
                con.Open();

                // lets begin a transaction here
                transaction = con.BeginTransaction();

                // Let us do WH first
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO dbo.Table_1 (ID ,Name) VALUES ('000000000-0000-0000-0000-0000000000000' ,'Warehouse Test')";

                    // assosiate this command with transaction
                    cmd.Transaction = transaction;

                    WHResult = cmd.ExecuteNonQuery() == 1;
                }

               
                // And now do a PA
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO dbo.Table_1 (ID ,Name) VALUES ('000000000-0000-0000-0000-0000000000000' ,'PA Test')";

                    // assosiate this command with transaction
                    cmd.Transaction = transaction;

                    PAResult = cmd.ExecuteNonQuery() == 1;
                }

                if (WHResult && PAResult)
                {
                    transaction.Commit();
                }
            }
            catch
            {
                transaction.Rollback();
            }
            finally
            {
                con.Close();
            }

        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            // Create the TransactionScope to execute the commands
            TransactionOptions option = new TransactionOptions();
            option.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            option.Timeout = new TimeSpan(0, 0, 60);

            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, option))
            {
                SQLHelper.execNonQuery(myConString, "AddTest", "myDB Testing");
              
                //create WarehouseReciept
                SQLHelper.execNonQuery(PAConString, "AddTest2", "AddPrppertyAdmin Test2");

                // The Complete method commits the transaction
                transaction.Complete();
            }
        }


        public  void Add(Guid ID, Guid StackID, Guid SupervisorApprovedBy, int SupervisorStatus, DateTime SupervisorApprovedDateTime, DateTime SupervisorApprovedTimeStamp)
        {
            SQLHelper.execNonQuery(myConString, "AddTest", ID, StackID, SupervisorApprovedBy, SupervisorStatus, SupervisorApprovedDateTime, SupervisorApprovedTimeStamp);
        }

        

    }

}