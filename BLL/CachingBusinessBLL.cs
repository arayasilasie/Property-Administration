using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Configuration;

namespace BLL
{
    public class CachingBusinessBLL
    {
        #region Declarations of caches 
        public static List<EmployeeBLL> EmployeeCache = new List<EmployeeBLL>();
        public static DateTime? EmployeeCacheExpiration = null;
        #endregion

        public CachingBusinessBLL()
        {           
            Thread _thread1 = new Thread(InitializeEmployee);   
            _thread1.Start();          
        }

        #region Init Cache

        private void InitializeEmployee()
        {
            InitEmpoyeeCache();
            Thread.Sleep(1800000);
            InitializeEmployee();
        }

        public static void InitEmpoyeeCache()
        {
            DateTime _requestedTime=DateTime.Now;
            if(EmployeeCacheExpiration==null)
                EmployeeCacheExpiration=_requestedTime;

            TimeSpan _elapsedTime = _requestedTime.Subtract(EmployeeCacheExpiration.Value);
            if (EmployeeCache.Count == 0 || _elapsedTime.Minutes >= int.Parse(ConfigurationManager.AppSettings["EmployeeCacheRefreshRate"]))
            {
                EmployeeBLL empObj=new EmployeeBLL();
                List<EmployeeBLL> newListOfEmp = empObj.GetAllEmployeeusersList();
                EmployeeCache = newListOfEmp; //New list assigned to cache                
                EmployeeCacheExpiration = _requestedTime; //Last cache timestamp is updated
            }
        }

        #endregion



    }
}
