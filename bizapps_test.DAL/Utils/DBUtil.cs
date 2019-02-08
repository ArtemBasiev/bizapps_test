using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace bizapps_test.DAL.Utils
{
    public static class DBUtil
    {
        public static SqlConnection GetDBConnection(string Flag="0")
        {
            string datasource;
            string database;

            if (Flag =="T")
            {
                 datasource = @"DESKTOP-5QPRQC5\SQLEXPRESS";
                database = "test_BizappsTest";
            }
            else
            {
                datasource = @"VMSMF-TRAINEE\SQLEXPRESS";
                database = "BizappsTest";
                //string username = @"DESKTOP-5QPRQC5\ARTEM";
                //string password = @"Tema190797";
            }
         

            return DBSQLServerUtil.GetDBConnection(datasource, database);

        }
    }
}
