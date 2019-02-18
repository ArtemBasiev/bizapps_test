using System.Data.SqlClient;

namespace bizapps_test.DAL.Utils
{
    public static class DbUtil
    {
        public static SqlConnection GetDbConnection(string flag="0")
        {
            string datasource;
            string database;

            if (flag =="T")
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
         

            return DbSqlServerUtil.GetDbConnection(datasource, database);

        }
    }
}
