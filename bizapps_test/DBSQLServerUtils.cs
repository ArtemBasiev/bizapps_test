using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


    public class DBSQLServerUtils
    {
        public static SqlConnection
            GetDBConnection(string datasource, string database)
              {
                  //Data Source=DESKTOP-5QPRQC5\SQLEXPRESS;Initial Catalog=BizappsTest;Integrated Security=True; User ID=DESKTOP-5QPRQC5\ARTEM

            string connString = @"Data Source="+datasource+";Initial Catalog="+database+";Integrated Security =SSPI;";

            SqlConnection conn = new SqlConnection(connString);
            return conn;
              }

    }



