
using System.Data.SqlClient;

namespace bizapps_test.DAL.Utils
{
    class DbSqlServerUtil
    {

        //public static SqlConnection sqlConnection;
        public static SqlConnection GetDbConnection(string datasource, string database)
        {
            //Data Source=DESKTOP-5QPRQC5\SQLEXPRESS;Initial Catalog=BizappsTest;Integrated Security=True; User ID=DESKTOP-5QPRQC5\ARTEM

            string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Integrated Security =SSPI;";

            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}
