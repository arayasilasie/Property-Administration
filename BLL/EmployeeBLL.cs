using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class EmployeeBLL:BaseBLL
    {
        #region Properties and Methods

        public Guid ID { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int Status { get; set; }
        //public Guid CreatedBy { get; set; }
        //public DateTime CreatedTimestamp { get; set; }
        //public Guid LastModifiedBy { get; set; }
        //public DateTime LastModifiedDate { get; set; }
        #endregion

        //public static List<string> GetEmployeesName(string Name)
        //{
        //    return SQLHelper.GetList(ConnectionString, "GetEmployees", Name);
        //}



        public static DataTable GetEmployees(string Name)
        {
            DataTable dt = SQLHelper.getDataTable(ConnectionString, "GetEmployees",Name);
            return dt;
        }

        public DataTable GetAllEmployees()
        {
            DataTable dt = SQLHelper.getDataTable(ConnectionString, "GetAllEmployees");
            return dt;
        }


        public DataTable GetAlluseremployees()
        {
            DataTable dt = SQLHelper.getDataTable(ConnectionString, "GetAlluseremployees");
            return dt;
        }

        /// <summary>
        /// Use this method to facilitate the caching proccess
        /// </summary>
        /// <returns></returns>
        public List<EmployeeBLL> GetAllEmployeeList()
        {
            DataTable dt = GetAllEmployees();

            List<EmployeeBLL> empList = new List<EmployeeBLL>();
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeBLL emp = new EmployeeBLL();

                emp.ID = new Guid(dr["ID"].ToString());
                emp.EmployeeId = dr["EmployeeId"].ToString();
                emp.EmployeeName = dr["EmployeeName"].ToString();
                emp.Status = int.Parse(dr["Status"].ToString());

                empList.Add(emp);
            }
            return empList;
        }


        public List<EmployeeBLL> GetAllEmployeeusersList()
        {
            DataTable dt = GetAlluseremployees();

            List<EmployeeBLL> empList = new List<EmployeeBLL>();
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeBLL emp = new EmployeeBLL();

                emp.ID = new Guid(dr["Guid"].ToString());
                //emp.EmployeeId = dr["EmployeeId"].ToString();
                emp.EmployeeName = dr["UserName"].ToString();
                emp.Status = Convert.ToInt32(dr["Active"]);

                empList.Add(emp);
            }
            return empList;
        }




        public static List<EmployeeBLL> GetEmployeeList(string name)
        {
            List<EmployeeBLL> listEmp = (from list in CachingBusinessBLL.EmployeeCache where list.EmployeeName.StartsWith(name, StringComparison.CurrentCultureIgnoreCase) select list).ToList();
            return listEmp;          
        }
       
        public static List<string> GetEmployeeNames2(string Name)
        {
            DataTable dt = GetEmployees(Name);

            List<string> empList = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                string emp;
              
                emp=dr["EmployeeName"].ToString();

                empList.Add(emp);
            }

            return empList;
        }

        public static List<string> GetEmployeeNames(string name)
        {
            List<string> listEmp = (from list in CachingBusinessBLL.EmployeeCache where list.EmployeeName.StartsWith(name, StringComparison.CurrentCultureIgnoreCase) select list.EmployeeName).ToList();
            return listEmp;            
        }

        public static Guid? ResolveEmployeeName(string employeeName)
        {
            Guid? _empId;

            var emp = (from empObj in EmployeeBLL.GetEmployeeList(employeeName) where empObj.EmployeeName.ToUpper() == employeeName.ToUpper() select empObj).FirstOrDefault();
                     
            if (emp == null) return null;

            _empId = emp.ID;          
            return _empId.Value;
        }

       
    }
}
