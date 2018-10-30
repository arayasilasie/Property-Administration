using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BLL
{
    public class BaseBLL
    {
        protected static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["PropertyAdminConnectionString"].ConnectionString;

            }
        }     
    }
}
